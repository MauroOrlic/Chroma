using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuBehaviour : MonoBehaviour {
	private bool gameIsPaused;
	void Start () {
		//gameIsPaused = false;
		//gameObject.SetActive(false);	
	}
	
	// Update is called once per frame
	void Update () {	
	}
	/*
	public void PauseHit(){
		Debug.Log("Escape hit!");
		if(!gameIsPaused)
		{
			gameObject.SetActive(true);
			Time.timeScale = 0f;
			gameIsPaused = true;
			GameObject.Find("playerShip").GetComponent<PlayerController>().gamePaused = true;

		}
		else
		{
			Time.timeScale = 1.0f;
			gameIsPaused = false;
			GameObject.Find("playerShip").GetComponent<PlayerController>().gamePaused = false;			
			gameObject.SetActive(false);
		}
	}
	*/
}
