using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour {
	
	public Camera cam;
	public Player player;
	
	private Vector3 camOfs;
	
	void Start()
	{
		if ((cam != null) && (player != null))
			camOfs = cam.transform.position - player.transform.position;
		else
			camOfs = new Vector3(0, 5, -5);
	}
	
	void Update()
	{			
		// Update camera...
		if ((cam != null) && (player != null))
			
		{
			Transform camTf = cam.transform;
			camTf.position = player.transform.position + camOfs;
		}
		
		// TODO: Zone multi-touch and screen
		// TODO: Zone pause, see Control Freak
	}
}

