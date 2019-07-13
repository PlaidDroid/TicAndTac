using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour {

	[SerializeField]
	GameObject enemy;

	// Use this for initialization
	public GameObject[] enemies;
	public float minTime = 5f;
	public float maxTime = 15f;
	bool isSpawning=false;
	void Start(){
		
	}
	IEnumerator SpawnObject(int index,float seconds){
		yield return new WaitForSeconds (seconds);
		Instantiate (enemy, new Vector3(Random.Range(transform.position.x-5,transform.position.x+5),transform.position.y), transform.rotation);
		isSpawning = false;
	}

	// Update is called once per frame
	void Update () {
		if (!isSpawning) {
			isSpawning = true;
			int enemyIndex = Random.Range (0, enemies.Length);
			StartCoroutine (SpawnObject (enemyIndex, Random.Range (minTime, maxTime)));		
		}
	}
}
