using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class liveForever : MonoBehaviour {

    public bool soundFx = true;
    bool musicOn = true;
    public bool showMoveCountText = true;

    public void toggleSoundFx()
    {
        soundFx = !soundFx;
    }
    public void toggleMusic()
    {
        print("music clicked");
        musicOn = !musicOn;
        toggleMusic(musicOn);
    }
    public void togglMoveCount()
    {
        showMoveCountText = !showMoveCountText;
        if(SceneManager.GetActiveScene().name == "GameScreen")
        {
            GameObject.Find("gameManager").GetComponent<FlipColor>().toggleMoveCountText(showMoveCountText);
        }
    }


    void Awake()
    {
       GameObject[] temp = GameObject.FindGameObjectsWithTag("music");
       if (temp.Length > 1)
        {
            Destroy(this.gameObject);
        }
       DontDestroyOnLoad(transform.gameObject);
    }

    public void toggleMusic(bool musicOn)
    {
        if (musicOn)
        {
            this.GetComponent<AudioSource>().Play();
        }
        else
        {
            this.GetComponent<AudioSource>().Pause();
        }
    }

}
