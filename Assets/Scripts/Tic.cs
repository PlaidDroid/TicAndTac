using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tic : MonoBehaviour
{

	// Use this for initialization
	Object bulletRef;
	private Rigidbody2D rb2d;
	private float jumpForce = 10f;
	private float forwardForce = 10f;
	private float backwardForce = 15f;
	SpriteRenderer ren;
	private int jumpctr = 0;

	void Start ()
	{
		ren = GetComponent<SpriteRenderer> ();
		bulletRef = Resources.Load ("bullet");
		rb2d = GetComponent<Rigidbody2D> ();
		rb2d.freezeRotation = true;
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		if (Input.GetKeyDown (KeyCode.W) && jumpctr < 3) {
			rb2d.velocity = new Vector2 (0, jumpForce);
			jumpctr++;
		}
		if (Input.GetKeyDown (KeyCode.D)) {
			rb2d.velocity = new Vector2 (10, rb2d.velocity.y);
			//rb2d.AddForce (Vector2.right);
//			Vector2 position = this.transform.position;
//			position.x = position.x + 0.5f;
//			this.transform.position = position;
//			rb2d.velocity = transform.right * forwardForce;
		}
		if (Input.GetKeyDown (KeyCode.A)) {
			rb2d.velocity = new Vector2 (-10, rb2d.velocity.y);
			//rb2d.AddForce (Vector2.left);
//			Vector2 position = this.transform.position;
//			position.x=position.x-0.5f;
//			this.transform.position = position;
			//rb2d.velocity = -transform.right * backwardForce;
		}
		if(Input.GetKeyDown(KeyCode.LeftShift)){
			if (ren.flipX == true) {
				ren.flipX = false;
			} else {
				ren.flipX = true;
			}
		}
		if(Input.GetKeyDown(KeyCode.S)){
			rb2d.AddForce(Vector2.down);
		}
		if (Input.GetButtonDown ("Fire1")) {
			GameObject bullet = (GameObject)Instantiate (bulletRef);
			Rigidbody2D r2 = bullet.GetComponent<Rigidbody2D> ();
			if (ren.flipX == true) {				
				r2.velocity= new Vector2 (-20, 0);
				bullet.transform.position = new Vector3 (transform.position.x - 1.5f, transform.position.y + .1f, -1);
			} else {
				rb2d.velocity = new Vector2 (20, 0);
				bullet.transform.position = new Vector3 (transform.position.x + 1.5f, transform.position.y + .1f, -1);
			}
		}
	}

	void OnCollisionEnter2D ()
	{
		rb2d.velocity = Vector2.zero;
		jumpctr = 0;
	}
}
