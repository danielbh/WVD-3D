using UnityEngine;
using System.Collections;

[System.Serializable]
public class PlayerMagic : MonoBehaviour 
{
	public Projectile primarySpell;
	public AreaEffect concussiveBlast;
	public AreaEffect iceBurst;
	public WizardShield wizardShield;
	public GameObject staffEnd;

    public float iceBurstDuration = 2;

	public void CastPrimarySpell(Vector3 dir) 
	{
		Projectile spell = Instantiate(primarySpell, staffEnd.transform.position, Quaternion.identity) as Projectile; 
		spell.Shoot(dir);
	}

	public void CastConcussiveBlastSpell() 
	{
		Vector3 pos = new Vector3(transform.position.x , 1.25f, transform.position.z);
		AreaEffect spell = Instantiate(concussiveBlast, pos, Quaternion.identity) as AreaEffect;

		spell.Explode();
	}

	public void CastWizardShieldSpell()
	{
        GameObject[] shields = GameObject.FindGameObjectsWithTag("WizardShield");

        // If there is no Wizard shield in the scene, create one around the player.
        if (shields.Length == 0)
        {
            Instantiate (wizardShield, transform.position, Quaternion.identity);
        }

        // If there is a Wizard Shield already in the scene reset it's timer. 
        else if (shields.Length == 1)
        {
            shields[0].GetComponent<WizardShield>().timer = 0;
        }
    }

	public void CastTeleportSpell()
	{
		// TODO: Instiatate Teleport
        // TODO: Start timeout timer 5 seconds
        // TODO: If user presses the screen within 5 seconds the player teleports
        // TODO: If not, nothing happens.
	}

	public void CastIceBurstSpell()
	{
		Vector3 pos = new Vector3(transform.position.x , 1.25f, transform.position.z);
		AreaEffect spell = Instantiate (iceBurst, pos, Quaternion.identity) as AreaEffect;

        spell.Imobilize(iceBurstDuration);
	}

	public void CastMeteorShowerSpell()
	{

	}
}
