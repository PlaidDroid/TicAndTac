using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
	[SerializeField]
	GameObject player;

	[SerializeField]
	float timeOffset;

	[SerializeField]
	Vector2 possOffset;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//Camera current position
		Vector3 startPos = transform.position;
		//Player current postion
		Vector3 endPos = player.transform.position;
		endPos.x += possOffset.x;
		endPos.y += possOffset.y;
		endPos.z = -10;
		transform.position = Vector3.Lerp (startPos, endPos, timeOffset * Time.deltaTime);
	}
}
