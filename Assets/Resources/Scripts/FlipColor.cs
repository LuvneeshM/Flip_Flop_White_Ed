﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class FlipColor : MonoBehaviour {

    int player_moves;
    bool shapes_flipping = true;
    bool game_paused = false;
    
    GameObject gameBoard;

    public GameObject endText;
    public GameObject moveCountText;

    private AudioSource audioSource;
    public AudioClip[] cardflip;
    public AudioClip winClip;
    public AudioClip opWinClip;
    public AudioClip hoverClip;
    private AudioClip cardflipClip;

    public Object[] black_to_white_diamond;
    public Object[] black_to_white_pentagon;
    public Object[] black_to_white_square;
    public Object[] black_to_white_triangle;
    public Object[] black_to_white_utriangle;

    public Object[] white_to_black_diamond;
    public Object[] white_to_black_pentagon;
    public Object[] white_to_black_square;
    public Object[] white_to_black_triangle;
    public Object[] white_to_black_utriangle;
    // Use this for initialization
    void Start () {
		gameBoard = GameObject.Find ("Board");
        audioSource = this.GetComponent<AudioSource>();
        player_moves = 0;
        toggleMoveCountText(GameObject.Find("BGMusic").GetComponent<liveForever>().showMoveCountText);
    }

    public void pauseGame()
    {
        game_paused = !game_paused;
        gameBoard.transform.parent.GetComponent<Canvas>().enabled = !game_paused;
        
        var pause = GameObject.Find("Pause");
        for (int i = 0; i < pause.transform.childCount; i++)
        {
            GameObject Go = pause.transform.GetChild(i).gameObject;
            Go.SetActive(game_paused);
        }
        if (game_paused)
        {
            var currlevel = GameObject.Find("CurrLevel");
            currlevel.GetComponent<Text>().text = loadSceneScript.levelSelected;
        }
    }
    public void reload()
    {
        SceneManager.LoadScene("GameScreen");
    }
    public void toggleMoveCount()
    {
        GameObject.Find("BGMusic").GetComponent<liveForever>().togglMoveCount();
    }
    public void toggleMoveCountText(bool val)
    {
        moveCountText.SetActive(val);
    }
    
    private void Update()
    {
        //restart level
        if (Input.GetKeyUp(KeyCode.R))
        {
            reload();
        }
        if (Input.GetKeyUp(KeyCode.P))
        {
            pauseGame();
        }
    }

    void swapColor(GameObject gO){
        if(gO.name == "black")
        {
            gO.name = "white";
        }
        else
        {
            gO.name = "black";
        }
		//if (gO.GetComponent<Image> ().color == Color.black) {
		//	//gO.GetComponent<Image> ().color = Color.white;
		//	gO.name = "white";
		//} else {
		//	//gO.GetComponent<Image> ().color = Color.black;
		//	gO.name = "black";
		//}
	}

	void shootRays(GameObject buttonClicked, Vector3 pos){
		RaycastHit hit;

		if (Physics.Raycast (buttonClicked.transform.position, pos, out hit)) {
			if (hit.collider != null) {
                if (hit.collider.gameObject.tag == "done")
                {
                    hit.collider.gameObject.name = "white";
                }
                //else if(hit.collider.gameObject.tag == "square")
                //{
                //    StartCoroutine(shapeAnimation(hit.collider.gameObject, false));
                //}
                //else
                //{
                //    swapColor(hit.collider.gameObject);
                //}
                StartCoroutine(shapeAnimation(hit.collider.gameObject, false));
            }
		}
	}

	bool checkAnswer(){
        gameBoard = GameObject.Find("Board");
        if (gameBoard == null)
        {
            return false;
        }
        for (int i = 0; i < gameBoard.transform.childCount; i++) {
			if (gameBoard.transform.GetChild (i).name.Contains("black")) {
				return false;
			}
		}
		//all white, next level
		loadNextLevel(true);
        return true;
	}

	IEnumerator delayLoadLevel(){
        //update player best score
        if (PlayerPrefs.HasKey(loadSceneScript.levelSelected))
        {
            if(PlayerPrefs.GetInt(loadSceneScript.levelSelected) > player_moves)
            {
                PlayerPrefs.SetInt(loadSceneScript.levelSelected, player_moves);
            }
        }
        else
        {
            PlayerPrefs.SetInt(loadSceneScript.levelSelected, player_moves);
        }

        endText.SetActive(true);
        

        if(player_moves < 11)
        {
            audioSource.clip = opWinClip;
            endText.transform.GetChild(0).gameObject.GetComponent<Text>().text = "★☆Congrats☆★";
        }
        else
        {
            audioSource.clip = winClip;
            if(player_moves < 20)
            {
                endText.transform.GetChild(0).gameObject.GetComponent<Text>().text = "★Good Job★";
            }
            else
            {
                endText.transform.GetChild(0).gameObject.GetComponent<Text>().text = "Well Done!";
            }
        }

        if (GameObject.Find("BGMusic").GetComponent<liveForever>().soundFx)
        {
            audioSource.PlayOneShot(audioSource.GetComponent<AudioSource>().clip);
            yield return new WaitForSeconds(1.75f);
        }
        else
        {
            yield return new WaitForSeconds(1.00f);
        }
        this.gameObject.GetComponent<loadSceneScript>().loadNextLevel();
	}

	void loadNextLevel(bool delay){
		if (delay) {
			StartCoroutine ("delayLoadLevel");
		} else {
			SceneManager.LoadScene (1);
		}
	}

    IEnumerator shapeAnimation(GameObject shape, bool first)
    {
        Object[] anim_array = new Object[0];
        Sprite final_sprite = null;
        if (shape.tag == "square") 
        {

            if (shape.name.Contains("black"))
            {
                anim_array = black_to_white_square;
                final_sprite = (UnityEngine.Sprite)white_to_black_square[0];
            } 
            else
            {
                anim_array = white_to_black_square;
                final_sprite = (UnityEngine.Sprite)black_to_white_square[0];
            }
        }
        else if (shape.tag == "triangle")
        {
            if (shape.name.Contains("black"))
            {
                anim_array = black_to_white_triangle;
                final_sprite = (UnityEngine.Sprite)white_to_black_triangle[0];
            }
            else
            {
                anim_array = white_to_black_triangle;
                final_sprite = (UnityEngine.Sprite)black_to_white_triangle[0];
            }
        }
        else if (shape.tag == "utriangle")
        {
            if (shape.name.Contains("black"))
            {
                anim_array = black_to_white_utriangle;
                final_sprite = (UnityEngine.Sprite)white_to_black_utriangle[0];
            }
            else
            {
                anim_array = white_to_black_utriangle;
                final_sprite = (UnityEngine.Sprite)black_to_white_utriangle[0];
            }
        }
        else if (shape.tag == "diamond")
        {
            if (shape.name.Contains("black"))
            {
                anim_array = black_to_white_diamond;
                final_sprite = (UnityEngine.Sprite)white_to_black_diamond[0];
            }
            else
            {
                anim_array = white_to_black_diamond;
                final_sprite = (UnityEngine.Sprite)black_to_white_diamond[0];
            }
        }
        else if (shape.tag == "pentagon")
        {
            if (shape.name.Contains("black"))
            {
                anim_array = black_to_white_pentagon;
                final_sprite = (UnityEngine.Sprite)white_to_black_pentagon[0];
            }
            else
            {
                anim_array = white_to_black_pentagon;
                final_sprite = (UnityEngine.Sprite)black_to_white_pentagon[0];
            }
        }

        //animate
        for (int i = 1; i < anim_array.Length; i++)
        {
            shape.GetComponent<Button>().GetComponent<Image>().sprite = (UnityEngine.Sprite)anim_array[i];
            yield return new WaitForSeconds(0.01f);

            if(i == (int) anim_array.Length / 2)
            {
                swapColor(shape);
            }
        }
        shape.GetComponent<Button>().GetComponent<Image>().sprite = final_sprite;
        if (first)
        {
            shapes_flipping = false;
        }
    }

    IEnumerator EndFlip()
    {
        while (shapes_flipping)
            yield return new WaitForSeconds(0.1f);
        yield return new WaitForSeconds(.10f);
        bool done = checkAnswer();
        print("checking answer " + done);
        if (done == false)
        {
            for (int i = 0; i < gameBoard.transform.childCount; i++)
            {
                var child = gameBoard.transform.GetChild(i);
                child.GetComponent<Button>().interactable = true;
            }
        }
    }

    public void flipFlop(GameObject buttonClicked){
        player_moves += 1;
        moveCountText.GetComponent<Text>().text = "Moves: " + player_moves;

        shapes_flipping = true;
        //loop through and disable all buttons
        for (int i = 0; i < gameBoard.transform.childCount; i++)
        {
            var child = gameBoard.transform.GetChild(i);
            child.GetComponent<Button>().interactable = false;
        }

        if (GameObject.Find("BGMusic").GetComponent<liveForever>().soundFx)
        {
            int index = Random.Range(0, cardflip.Length);
            cardflipClip = cardflip[index];
            audioSource.clip = cardflipClip;
            audioSource.PlayOneShot(audioSource.GetComponent<AudioSource>().clip);
        }

        RaycastHit hit;

        if (buttonClicked.tag == "triangle") {
            //swapColor(buttonClicked);
            StartCoroutine(shapeAnimation(buttonClicked, true));
            shootRays (buttonClicked, new Vector3 (-1, 1, 0)); 	
			shootRays (buttonClicked, new Vector3 (1, 1, 0)); 
			shootRays (buttonClicked, Vector3.down); 
		}
        else if (buttonClicked.tag == "utriangle")
        {
            //swapColor(buttonClicked);
            StartCoroutine(shapeAnimation(buttonClicked, true));
            shootRays(buttonClicked, Vector3.up);
            shootRays(buttonClicked, new Vector3(-1, -1, 0));
            shootRays(buttonClicked, new Vector3(1, -1, 0));
        }
        else if (buttonClicked.tag == "diamond")
        {
            //swapColor(buttonClicked);
            StartCoroutine(shapeAnimation(buttonClicked, true));
            shootRays(buttonClicked, new Vector3(-1, 1, 0));
            shootRays(buttonClicked, new Vector3(1, 1, 0));
            shootRays(buttonClicked, new Vector3(1, -1, 0));
            shootRays(buttonClicked, new Vector3(-1, -1, 0));
        }
        else if (buttonClicked.tag == "pentagon")
        {
            //swapColor(buttonClicked);
            StartCoroutine(shapeAnimation(buttonClicked, true));
            shootRays(buttonClicked, Vector3.left);
            shootRays(buttonClicked, Vector3.right);
            shootRays(buttonClicked, Vector3.down);
            shootRays(buttonClicked, new Vector3(-1, 1, 0));
            shootRays(buttonClicked, new Vector3(1, 1, 0));
        }
        //default is square
        else
        {
            StartCoroutine(shapeAnimation(buttonClicked, true));
            shootRays (buttonClicked, Vector3.up);
			shootRays (buttonClicked, Vector3.down);
			shootRays (buttonClicked, Vector3.left);
			shootRays (buttonClicked, Vector3.right);
            //StartCoroutine("EndFlip");
        }

        StartCoroutine("EndFlip");

    }

	public void startGame(){
		loadNextLevel (false);
	}
}