using UnityEngine;
using System.Collections;

public class AreaEffect : NCMonoBehaviour
{
    public int damage = 25;
    public float radius = 5;
    public float power = 10;

    Collider[] colliders;
    Vector3 explosionPos;

    void OnEnable()
    {
        explosionPos = transform.position;
        int enemyLayer = 1 << LayerMask.NameToLayer("Enemy");
        colliders = Physics.OverlapSphere(explosionPos, radius, enemyLayer, QueryTriggerInteraction.Ignore);
    }

    public void Explode()
    {
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            bool enemyFrozen = rb.gameObject.GetComponent<Debuff>().Frozen;

            if (rb != null)
            {
                if (!enemyFrozen)
                {
                    rb.isKinematic = false;
                    rb.AddExplosionForce(power, explosionPos, radius, 3.0F);
                    StartCoroutine(MakeKinematic(rb, 0.1f));
                }

                // Attempt to hit gameObject to see if it can take damage.
                Hit(rb.gameObject);
            }
        }
        Destroy(gameObject, 0.5f);
    }

    public void Imobilize(float duration)
    {
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            GameObject obj = rb.gameObject;
            bool enemyFrozen = obj.GetComponent<Debuff>().Frozen;

            if (rb != null && !enemyFrozen)
            {
                CreateIceBlock(obj, duration);
            }
        }
        Destroy(gameObject, 0.5f);
    }

    void CreateIceBlock(GameObject target, float duration)
    {
        GameObject iceBlock = GetComponent<MaterializedObject>().model;

        if (iceBlock != null)
        {
            Vector3 pos = target.transform.position;
            // Instantiate Iceblock at feet of enemy
            GameObject iceBlockCopy = Instantiate(iceBlock, pos, Quaternion.identity) as GameObject;

            iceBlockCopy.GetComponent<DestroyIfTargetNull>().SetTarget(target);

            FreezeEnemy(target, duration);
            Destroy(iceBlockCopy, duration);
        }
        else
        {
            Debug.LogError("You must add a MateralizedObject class to " + gameObject.name + " class.");
        }
    }

    void FreezeEnemy(GameObject target, float duration)
    {
        target.GetComponent<Debuff>().Freeze(duration);
    }

    void Hit(GameObject gameObj)
    {
        NCHealth health = gameObj.GetComponent<NCHealth>();

        if (health != null)
        {
            health.Hit(damage);
        }
    }

    IEnumerator MakeKinematic(Rigidbody rb, float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        if (rb != null)
        {
            rb.isKinematic = true;
        }
    }
}
