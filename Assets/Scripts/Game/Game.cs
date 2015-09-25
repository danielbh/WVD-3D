using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour {

	public Camera cam;
	public Player player;
	
	private Vector3 camOfs;
	
	void Start()
	{
		if ((this.cam != null) && (this.player != null))
			this.camOfs = this.cam.transform.position - this.player.transform.position;
		else
			this.camOfs = new Vector3(0, 5, -5);
	}
	
	void Update()
	{			
			// Update camera...
			if (this.cam != null)
			{
				Transform camTf = this.cam.transform;
				camTf.position = this.player.transform.position + this.camOfs;
			}
			
			// TODO: Zone multi-touch and screen
			// TODO: Zone pause, see Control Freak
	}
}

