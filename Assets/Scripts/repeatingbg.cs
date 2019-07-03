using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class repeatingbg : MonoBehaviour {


	private BoxCollider2D groundCollider;
	private float groundHorizontalLength;

	// Use this for initialization
	void Start () {
		groundCollider = GetComponent<BoxCollider2D> ();
		groundHorizontalLength = groundCollider.size.x - 0.88f;
	}

	// Update is called once per frame
	void Update () {
		if(transform.position.x<-groundHorizontalLength)
		{
			RepostionBackground ();
		}
	}

	private void RepostionBackground()
	{
		Vector2 groundOffset = new Vector2 (groundHorizontalLength * 2f, 0);
		transform.position = (Vector2)transform.position + groundOffset;
	}
}
