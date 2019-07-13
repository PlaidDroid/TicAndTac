using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
	GameObject[] pauseObjects;
	GameObject[] deathObjects;
	GameObject player;
	Tic tic;
	private bool isPaused = false;
	private bool isDead = false;
	// Use this for initialization
	void Start ()
	{
		player = GameObject.Find ("maincharacter");
		tic = player.GetComponent<Tic> ();
		Time.timeScale = 1;
		pauseObjects = GameObject.FindGameObjectsWithTag ("paused");
		deathObjects = GameObject.FindGameObjectsWithTag ("dead");
		hidePaused ();
		hideDeath ();
	}

	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.Escape)&&!isPaused) {
			pauseControl ();
		}
		if (tic.getHealth() <= 0) {
			isDead = true;
			showDeath ();
		}
	}

	void Reload ()
	{
		//Application.LoadLevel (Application.loadedLevel);
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}

	public void deathControl(){
		//Camera.main.transform.position = player.transform.position;
		if(isDead)
			hideDeath ();	
			Reload ();
	}

	public void pauseControl ()
	{
		if (Time.timeScale == 1) {
			isPaused = true;
			Time.timeScale = 0;
			showPaused ();
		} else if (Time.timeScale == 0) {
			//Debug.Log ("high");
			isPaused = false;
			Time.timeScale = 1;
			hidePaused ();
		}
	}

	public void showPaused ()
	{
		foreach (GameObject g in pauseObjects) {
			g.SetActive (true);
		}
	}

	public void hidePaused ()
	{
		foreach (GameObject g in pauseObjects) {
			g.SetActive (false);
		}
	}

	public void showDeath ()
	{
		foreach (GameObject g in deathObjects) {
			g.SetActive (true);
		}
	}

	public void hideDeath ()
	{
		foreach (GameObject g in deathObjects) {
			g.SetActive (false);
		}
	}


	public void exitGame(){
		Application.Quit();
	}

	public void LoadLevel (string level)
	{
		//Application.LoadLevel (level);
		SceneManager.LoadScene (level);
	}
}
