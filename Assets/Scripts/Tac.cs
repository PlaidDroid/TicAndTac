using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tac : MonoBehaviour
{

	// Use this for initialization
	private int health = 10;

	//materials
	private Material matRed;
	private Material defMat;
	SpriteRenderer ren;
	GameObject player;
	Rigidbody2D rb2d;
	Object bulletRef;
	private int bulletcount;
	private float fireRate = 1f;
	private float nextFire;

	void Start ()
	{
		player = GameObject.Find ("maincharacter");
		ren = GetComponent<SpriteRenderer> ();
		rb2d = GetComponent<Rigidbody2D> ();
		bulletRef = Resources.Load ("bullet");

		rb2d.freezeRotation = true;
		matRed = Resources.Load ("RedFlash", typeof(Material))as Material;
		defMat = ren.material;
	}

	private void OnTriggerEnter2D (Collider2D collision)
	{
		
		if (collision.CompareTag ("bullet")) {
			Destroy (collision.gameObject);
			health--;
			ren.material = matRed;
			if (health <= 0) {
				KillSelf ();
			} else {
				Invoke ("ResetMaterial", .2f);
		
			}
		}
	}

	void ResetMaterial ()
	{
		ren.material = defMat;
	}

	void KillSelf ()
	{
		Destroy (gameObject);
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		//flipping
		Rigidbody2D r = player.GetComponent<Rigidbody2D> ();
		if (r.position.x - transform.position.x < 0) {
			ren.flipX = true;
		} else {
			ren.flipX = false;
		}

		//shoot in range
		Vector2 x = transform.position;
		if (Mathf.Abs (r.position.x - transform.position.x) <= 10 && Time.time > nextFire) {
			//jump to character
			if (r.position.y > transform.position.y) {
				rb2d.velocity = new Vector2 (0, (r.position.y - transform.position.y) + 10f);
			}
			nextFire = Time.time + fireRate;
			GameObject bullet = (GameObject)Instantiate (bulletRef);
			Rigidbody2D r2 = bullet.GetComponent<Rigidbody2D> ();

			if (ren.flipX == true) {				
				r2.velocity = new Vector2 (-20, 0);
				bullet.transform.position = new Vector3 (transform.position.x - 1.5f, transform.position.y + .1f, -1);
			} else {
				r2.velocity = new Vector2 (20, 0);
				bullet.transform.position = new Vector3 (transform.position.x + 1.5f, transform.position.y + .1f, -1);
			}
			
		}
		//enemy moves towards the character
		else if (r.position.x - transform.position.x < -10) {
			x.x -= 0.05f;
		} else if (r.position.x - transform.position.x > 10) {
			x.x += 0.05f;
		}
		transform.position = x;
	}

	void OnCollisionEnter2D (Collision2D collision)
	{
		rb2d.velocity = Vector2.zero;
	}
}
