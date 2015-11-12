using UnityEngine;
using System.Collections;

[System.Serializable]
public class PlayerMagic : MonoBehaviour 
{
	public Projectile primarySpell;
	public AreaEffect concussiveBlast;
	public AreaEffect iceBurst;
	public WizardShield wizardShield;
	public Teleport teleport;
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
		Instantiate (wizardShield, transform.position, Quaternion.identity);
	}

	public void CastTeleportSpell()
	{
		//Instantiate (teleport, transform.position, Quaternion.identity);
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
