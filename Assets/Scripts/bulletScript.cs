using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{

	// Use this for initialization
	Rigidbody2D rb2d;
	GameObject player;
	SpriteRenderer ren;

	void Start ()
	{
		rb2d = GetComponent<Rigidbody2D> ();
		Invoke ("DestroySelf", 1f);
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
			//rb2d.velocity = new Vector2 (20, 0);
	}

	private void OnCollisionEnter2D (Collision2D collision)
	{
		if (collision.gameObject.CompareTag ("ground")) {
			DestroySelf ();
		}
	}

	private void DestroySelf ()
	{		
		Destroy (gameObject);

	}
}
