using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class FlipColor : MonoBehaviour {

	GameObject gameBoard;

	// Use this for initialization
	void Start () {
		gameBoard = GameObject.Find ("Board");
	}

	void swapColor(GameObject gO){
		if (gO.GetComponent<Image> ().color == Color.black) {
			gO.GetComponent<Image> ().color = Color.white;
			gO.name = "white";
		} else {
			gO.GetComponent<Image> ().color = Color.black;
			gO.name = "black";
		}
	}

	void shootRays(GameObject buttonClicked, Vector3 pos){
		RaycastHit hit;

		if (Physics.Raycast (buttonClicked.transform.position, pos, out hit)) {
			if (hit.collider != null) {
				swapColor (hit.collider.gameObject);
			}
		}
	}

	void checkAnswer(){
		for (int i = 0; i < gameBoard.transform.childCount; i++) {
			if (gameBoard.transform.GetChild (i).name == "black") {
				return;
			}
		}
		//all white, next level
		loadNextLevel(true);
	}

	IEnumerator delayLoadLevel(){
		this.GetComponent<AudioSource> ().PlayOneShot (this.GetComponent<AudioSource> ().clip);
		yield return new WaitForSeconds (3.0f);
		var levelIndex = SceneManager.GetActiveScene ().buildIndex;
		if (levelIndex < 5) {
			SceneManager.LoadScene (levelIndex + 1);
		} else {
			SceneManager.LoadScene (0);
		}
	}

	void loadNextLevel(bool delay){
		if (delay) {
			StartCoroutine ("delayLoadLevel");
		} else {
			SceneManager.LoadScene (1);
		}
	}

	public void flipFlop(GameObject buttonClicked){

		swapColor (buttonClicked);

		RaycastHit hit;

		if (buttonClicked.tag == "triangle") {
			shootRays (buttonClicked, new Vector3 (-1, 1, 0)); 	
			shootRays (buttonClicked, new Vector3 (1, 1, 0)); 
			shootRays (buttonClicked, Vector3.down); 
		}
		//default is square
		else {
			shootRays (buttonClicked, Vector3.up);
			shootRays (buttonClicked, Vector3.down);
			shootRays (buttonClicked, Vector3.left);
			shootRays (buttonClicked, Vector3.right);
		}


		checkAnswer ();

	}

	public void startGame(){
		loadNextLevel (false);
	}
}