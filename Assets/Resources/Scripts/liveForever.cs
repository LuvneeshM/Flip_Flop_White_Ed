using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class liveForever : MonoBehaviour {

    public bool soundFx = true;
    bool musicOn = true;
    public bool showMoveCountText = true;

    public Sprite soundFxOnImg;
    public Sprite soundFxOffImg;
    public Sprite musicOnImg;
    public Sprite musicOffImg;
    public Sprite statsOnImg;
    public Sprite statsOffImg;

    public void toggleSoundFx()
    {
        soundFx = !soundFx;
        if (soundFx)
        {
            GameObject.Find("soundfx").GetComponent<Button>().GetComponent<Image>().sprite = soundFxOnImg;
        }
        else
        {
            GameObject.Find("soundfx").GetComponent<Button>().GetComponent<Image>().sprite = soundFxOffImg;
        }
    }
    public void toggleMusic()
    {
        print("music clicked");
        musicOn = !musicOn;
        toggleMusic(musicOn);
        if (musicOn)
        {
            GameObject.Find("music").GetComponent<Button>().GetComponent<Image>().sprite = musicOnImg;
        }
        else
        {
            GameObject.Find("music").GetComponent<Button>().GetComponent<Image>().sprite = musicOffImg;
        }
    }
    public void togglMoveCount()
    {
        showMoveCountText = !showMoveCountText;
        if(SceneManager.GetActiveScene().name == "GameScreen")
        {
            GameObject.Find("gameManager").GetComponent<FlipColor>().toggleMoveCountText(showMoveCountText);
        }
        if (showMoveCountText)
        {
            GameObject.Find("stats").GetComponent<Button>().GetComponent<Image>().sprite = statsOnImg;
        }
        else
        {
            GameObject.Find("stats").GetComponent<Button>().GetComponent<Image>().sprite = statsOffImg;
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

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // called second
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (musicOn)
        {
            GameObject.Find("music").GetComponent<Button>().GetComponent<Image>().sprite = musicOnImg;
        }
        else
        {
            GameObject.Find("music").GetComponent<Button>().GetComponent<Image>().sprite = musicOffImg;
        }
        if (soundFx)
        {
            GameObject.Find("soundfx").GetComponent<Button>().GetComponent<Image>().sprite = soundFxOnImg;
        }
        else
        {
            GameObject.Find("soundfx").GetComponent<Button>().GetComponent<Image>().sprite = soundFxOffImg;
        }
        if(scene.name == "GameScreen")
        {
            if (showMoveCountText)
            {
                GameObject.Find("gameManager").GetComponent<FlipColor>().toggleMoveCountText(showMoveCountText);
                GameObject.Find("stats").GetComponent<Button>().GetComponent<Image>().sprite = statsOnImg;
            }
            else
            {
                GameObject.Find("stats").GetComponent<Button>().GetComponent<Image>().sprite = statsOffImg;
            }
        }
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
