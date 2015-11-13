using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {
	
	public GameObject melee1;
	public GameObject ranged1;
	public int wave = 1;
	
	GameObject[] spawners;
	
	void Start () {
		spawners = GameObject.FindGameObjectsWithTag("Spawner");
	}
	
	void Update() {
		
		GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
		
		//if (enemies.Length == 0 && wave != 4) {
		//	Invoke ("Wave" + wave, 0);
		//	Debug.Log ("Wave " + wave + " called!");
		//	++wave;

            // HACK: Trying to just get a lot of enemies
            //if (wave == 4)
            //{

        if (enemies.Length == 0)
        {
            SpawnDemons(new GameObject[] { melee1, ranged1, melee1 }, new int[] { 0, 2, 4 });
            StartCoroutine(SpawnNextSet(3, new GameObject[] { melee1, ranged1, ranged1 }, new int[] { 1, 3, 5 }));

            SpawnDemons(new GameObject[] { melee1, ranged1, melee1 }, new int[] { 0, 2, 4 });
            StartCoroutine(SpawnNextSet(3, new GameObject[] { melee1, ranged1, ranged1 }, new int[] { 1, 3, 5 }));

            SpawnDemons(new GameObject[] { melee1, ranged1, melee1 }, new int[] { 0, 2, 4 });
            StartCoroutine(SpawnNextSet(3, new GameObject[] { melee1, ranged1, ranged1 }, new int[] { 1, 3, 5 }));

            SpawnDemons(new GameObject[] { melee1, ranged1, melee1 }, new int[] { 0, 2, 4 });
            StartCoroutine(SpawnNextSet(3, new GameObject[] { melee1, ranged1, ranged1 }, new int[] { 1, 3, 5 }));

            SpawnDemons(new GameObject[] { melee1, ranged1, melee1 }, new int[] { 0, 2, 4 });
            StartCoroutine(SpawnNextSet(3, new GameObject[] { melee1, ranged1, ranged1 }, new int[] { 1, 3, 5 }));

            SpawnDemons(new GameObject[] { melee1, ranged1, melee1 }, new int[] { 0, 2, 4 });
            StartCoroutine(SpawnNextSet(3, new GameObject[] { melee1, ranged1, ranged1 }, new int[] { 1, 3, 5 }));
        }

            //}
		//}
	}
	
	public void Wave1() {
		SpawnDemons(new GameObject[] {melee1, melee1, melee1}, new int[] {0,2,4});
	}
	
	public void Wave2() {
		SpawnDemons(new GameObject[] {melee1, melee1, melee1}, new int[] {0,2,4});
		StartCoroutine(SpawnNextSet (3, new GameObject[] {melee1, melee1, melee1}, new int[] {1,3,5}));
	}
	
	public void Wave3() {
		SpawnDemons(new GameObject[] {melee1, ranged1, melee1}, new int[] {0,2,4});
		StartCoroutine(SpawnNextSet (3,new GameObject[] {melee1, ranged1, ranged1}, new int[] {1,3,5}));
	}
	
	
	public void SpawnDemons(GameObject[] demons, int[] spawnerIndexes) {
		int i= 0;
		
		foreach(GameObject demon in demons) {
			Instantiate(demon, spawners[spawnerIndexes[i]].transform.position, Quaternion.identity);
			++i;
		}
	}
	
	public IEnumerator SpawnNextSet(float seconds, GameObject[] demons, int[] spawnerIndexes) {
		yield return new WaitForSeconds(seconds);
		SpawnDemons(demons, spawnerIndexes);
	}
}

