using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour {

	public GameObject[] waypoints;
	public GameObject testEnemyPrefab;


	void Start () {
		Instantiate(testEnemyPrefab).GetComponent<MoveEnemy>().waypoints = waypoints;
	}
	
	void Update () {
		
	}
}
