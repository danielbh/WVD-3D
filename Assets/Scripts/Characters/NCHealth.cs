using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent (typeof (AudioSource))]
public class NCHealth : MonoBehaviour, IHealthComponent
{
	
	[HideInInspector]
	public HealthController controller;
	
	public AudioClip hurtClip;
	public AudioClip deathClip;
	//public float sinkSpeed = 2.5f;
	public int hitPoints = 100;
	public bool invulnerable = false;
	public bool npc = false;
	public Slider healthSlider;
	public Image damageImage;
	public float flashSpeed = 5f;
	public Color flashColor = new Color(1f, 0f, 0f, 0.1f);
	
	AudioSource audioPlayer;
	//CapsuleCollider capsuleCol;
	//Animator anim;
	bool damaged;
	//bool isDead;
	//bool isSinking;
	
	void Awake() 
	{
		controller.SetComponent(this);
		audioPlayer = GetComponent <AudioSource> ();
		audioPlayer.clip = hurtClip;
		//capsuleCol = GetComponent <CapsuleCollider> ();
		//anim = GetComponent <Animator>();
	}
	
	void Update ()
	{
		if (!npc) {
			AnimDamageHud();
		}
		
		//		if (isSinking) 
		//		{
		//			transform.Translate (-Vector3.up * sinkSpeed * Time.deltaTime);
		//		}
	}
	
	void AnimDamageHud() {
		if(damaged)
		{
			damageImage.color = flashColor;
		}
		else{
			damageImage.color = Color.Lerp (damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
		}
		damaged = false;
	}
	
	public void Hit(int damage) 
	{

		// To avoid warning error that audio player doesn't exist we put this != null check.
		if (invulnerable == false && this != null) 
		{
			// Play hurt Clip
			audioPlayer.Play();
			controller.ReduceHitPoints(damage, hitPoints);
		}

		// TODO: create audio for invulnerability hit
	}
	
	#region IHitPointsComponent implementation
	
	public void ReduceHitPoints(int damage) { 
		damaged = true;
		//if(isDead)
		//return;
		hitPoints -= damage; 

		if (!npc) {
			healthSlider.value = hitPoints;
		}
	}
	
	// TODO: Add death triggers game over for player
	public void Die() {
		// TODO: To update the health slider remove when there is dying animation for the player.
		hitPoints -= 25; 

		if (!npc) {
			healthSlider.value = hitPoints;
		}
		Destroy (gameObject); 
		
		//isDead = true;
		
		//capsuleCol.isTrigger = true;
		
		//audioPlayer.clip = deathClip;
		//audioPlayer.Play();
		
		//StartSinking ();
	}
	
	//	public void StartSinking () {
	//		GetComponent <NavMeshAgent> ().enabled = false;
	//		GetComponent <Rigidbody>().isKinematic = true;
	//		isSinking = true;
	//		anim.SetBool("Walk" , false);
	//		Destroy (gameObject, 2f); 
	//	}
	
	#endregion
}

