using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerMagic : MonoBehaviour
{
    public Projectile primarySpell;
    public AreaEffect concussiveBlast;
    public AreaEffect iceBurst;
    public WizardShield wizardShield;
    public GameObject staffEnd;
    public float spellTimeOut = 5;
    public float iceBurstDuration = 2;

    TouchController touchController;
    TouchStick[] touchSticks;
    bool teleporting;
    float timer;

    void OnEnable()
    {
        touchController = GetComponent<Player>().touchController;
        touchSticks = touchController.sticks;
    }

    void Update()
    {
        if (teleporting)
        {
            ManageTeleport();
        }
    }

    public void CastPrimarySpell(Vector3 dir)
    {
        Projectile spell = Instantiate(primarySpell, staffEnd.transform.position, Quaternion.identity) as Projectile;
        spell.Shoot(dir);
    }

    public void CastConcussiveBlastSpell()
    {
        Vector3 pos = new Vector3(transform.position.x, 1.25f, transform.position.z);
        AreaEffect spell = Instantiate(concussiveBlast, pos, Quaternion.identity) as AreaEffect;

        spell.Explode();
    }

    public void CastWizardShieldSpell()
    {
        GameObject[] shields = GameObject.FindGameObjectsWithTag("WizardShield");

        // If there is no Wizard shield in the scene, create one around the player.
        if (shields.Length == 0)
        {
            Instantiate(wizardShield, transform.position, Quaternion.identity);
        }

        // If there is a Wizard Shield already in the scene reset it's timer. 
        else if (shields.Length == 1)
        {
            shields[0].GetComponent<WizardShield>().timer = 0;
        }
    }

    public void CastTeleportSpell()
    {
        EnableTeleportationMode();
    }

    public void CastIceBurstSpell()
    {
        Vector3 pos = new Vector3(transform.position.x, 1.25f, transform.position.z);
        AreaEffect spell = Instantiate(iceBurst, pos, Quaternion.identity) as AreaEffect;

        spell.Imobilize(iceBurstDuration);
    }

    public void CastMeteorShowerSpell()
    {

    }

    void ManageTeleport()
    {
        timer += Time.deltaTime;

        // teleport time out
        if (timer > spellTimeOut)
        {
            DisableTeleportationMode();
            Debug.Log("Teleport timed out.");
        }

        if (touchController.touchZones[0].JustUniReleased())
        {
            // Works for touch screens too supposedly
            Teleport(Input.mousePosition);
            DisableTeleportationMode();
        }
    }

    // Using local pos variable makes this function testable
    public void Teleport(Vector2 pos)
    {
        Ray ray = Camera.main.ScreenPointToRay(pos);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            transform.LookAt(hit.point);

            // a position where y is ALWAYS zero.
            transform.position = new Vector3(hit.point.x, 0, hit.point.z);
        }
    }

    void EnableTouchSticks()
    {
        touchSticks[0].Enable();
        touchSticks[1].Enable();
    }

    void EnableTeleportationMode()
    {
        teleporting = true;
        DisableTouchSticks();
    }

    void DisableTeleportationMode()
    {
        timer = 0;
        teleporting = false;
        EnableTouchSticks();
    }

    void DisableTouchSticks()
    {
        touchSticks[0].Disable();
        touchSticks[1].Disable();
    }
}
