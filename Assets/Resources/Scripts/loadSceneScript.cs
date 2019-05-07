using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class loadSceneScript : MonoBehaviour {

    public void toggleMusic()
    {
        GameObject.Find("BGMusic").GetComponent<liveForever>().toggleMusic();
    }
    public void toggleSoundFx()
    {
        GameObject.Find("BGMusic").GetComponent<liveForever>().toggleSoundFx();
    }

    //this will be static, so it is same for all levels, unless changed
    static public string levelSelected;

    int uworld = 0;
    int ulevel = 0;

    public void loadLevelScreen()
    {
        SceneManager.LoadScene("MenuScreen");
    }

    public void restartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void mainMenu()
    {
        SceneManager.LoadScene("HomeScreen");
    }

    public void loadSelectedLevel(string name)
    {
        levelSelected = name;
        string currLevel = levelSelected;
        string[] levelInfo = currLevel.Split('-'); //World-Level
        var world = int.Parse(levelInfo[0]);
        var level = int.Parse(levelInfo[1]);

        SceneManager.LoadScene("GameScreen");
    }

    public void loadLevel()
    {
        loadSelectedLevel("" + uworld + "-" + ulevel);
    }

    void updateBestMove()
    {
        var movecount = GameObject.Find("bestmoves");
        if(PlayerPrefs.HasKey("" + uworld + "-" + ulevel))
        {
            movecount.GetComponent<Text>().text = "" + PlayerPrefs.GetInt("" + uworld + "-" + ulevel);
        }
        else
        {
            movecount.GetComponent<Text>().text = "--";
        }
    }
    public void changeWorld(int i)
    {
        //if(uworld == 0)
        //{
        //    Texture2D tex = Resources.Load("Animations\\levelselect_sprite_sheets\\s_light") as Texture2D;
        //    GameObject.Find("square").GetComponent<Image>().sprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector3());
        //} else if (uworld == 1)
        //{
        //    Texture2D tex = Resources.Load("Animations\\levelselect_sprite_sheets\\t_light") as Texture2D;
        //    GameObject.Find("triangle").GetComponent<Image>().sprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector3());
        //} else if (uworld == 2)
        //{
        //    Texture2D tex = Resources.Load("Animations\\levelselect_sprite_sheets\\ut_light") as Texture2D;
        //    GameObject.Find("utriangle").GetComponent<Image>().sprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector3());
        //}
        //else if (uworld == 3)
        //{
        //    Texture2D tex = Resources.Load("Animations\\levelselect_sprite_sheets\\d_light") as Texture2D;
        //    GameObject.Find("diamond").GetComponent<Image>().sprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector3());
        //} else if (uworld == 4)
        //{
        //    Texture2D tex = Resources.Load("Animations\\levelselect_sprite_sheets\\p_light") as Texture2D;
        //    GameObject.Find("pentagon").GetComponent<Image>().sprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector3());
        //}
        Texture2D texu = Resources.Load("Animations\\levelselect_sprite_sheets\\s_light") as Texture2D;
        GameObject.Find("square").GetComponent<Image>().sprite = Sprite.Create(texu, new Rect(0.0f, 0.0f, texu.width, texu.height), new Vector3());
        texu = Resources.Load("Animations\\levelselect_sprite_sheets\\t_light") as Texture2D;
        GameObject.Find("triangle").GetComponent<Image>().sprite = Sprite.Create(texu, new Rect(0.0f, 0.0f, texu.width, texu.height), new Vector3());
        texu = Resources.Load("Animations\\levelselect_sprite_sheets\\ut_light") as Texture2D;
        GameObject.Find("utriangle").GetComponent<Image>().sprite = Sprite.Create(texu, new Rect(0.0f, 0.0f, texu.width, texu.height), new Vector3());
        texu = Resources.Load("Animations\\levelselect_sprite_sheets\\d_light") as Texture2D;
        GameObject.Find("diamond").GetComponent<Image>().sprite = Sprite.Create(texu, new Rect(0.0f, 0.0f, texu.width, texu.height), new Vector3());
        texu = Resources.Load("Animations\\levelselect_sprite_sheets\\p_light") as Texture2D;
        GameObject.Find("pentagon").GetComponent<Image>().sprite = Sprite.Create(texu, new Rect(0.0f, 0.0f, texu.width, texu.height), new Vector3());
        uworld += i;
        if (uworld >= 5)
        {
            uworld = 0;
        }
        if (uworld <= -1)
        {
            uworld = 4;
        }
        GameObject.Find("world").GetComponent<Text>().text = ""+uworld;
        if (uworld == 0)
        {
            Texture2D tex = Resources.Load("Animations\\levelselect_sprite_sheets\\s_dark") as Texture2D;
            GameObject.Find("square").GetComponent<Image>().sprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector3());
        }
        else if (uworld == 1)
        {
            Texture2D tex = Resources.Load("Animations\\levelselect_sprite_sheets\\s_dark") as Texture2D;
            GameObject.Find("square").GetComponent<Image>().sprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector3());
            tex = Resources.Load("Animations\\levelselect_sprite_sheets\\t_dark") as Texture2D;
            GameObject.Find("triangle").GetComponent<Image>().sprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector3());
        }
        else if (uworld == 2)
        {
            Texture2D tex = Resources.Load("Animations\\levelselect_sprite_sheets\\s_dark") as Texture2D;
            GameObject.Find("square").GetComponent<Image>().sprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector3());
            tex = Resources.Load("Animations\\levelselect_sprite_sheets\\t_dark") as Texture2D;
            GameObject.Find("triangle").GetComponent<Image>().sprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector3());
            tex = Resources.Load("Animations\\levelselect_sprite_sheets\\ut_dark") as Texture2D;
            GameObject.Find("utriangle").GetComponent<Image>().sprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector3());
        }
        else if (uworld == 3)
        {
            Texture2D tex = Resources.Load("Animations\\levelselect_sprite_sheets\\s_dark") as Texture2D;
            GameObject.Find("square").GetComponent<Image>().sprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector3());
            tex = Resources.Load("Animations\\levelselect_sprite_sheets\\t_dark") as Texture2D;
            GameObject.Find("triangle").GetComponent<Image>().sprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector3());
            tex = Resources.Load("Animations\\levelselect_sprite_sheets\\ut_dark") as Texture2D;
            GameObject.Find("utriangle").GetComponent<Image>().sprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector3());
            tex = Resources.Load("Animations\\levelselect_sprite_sheets\\d_dark") as Texture2D;
            GameObject.Find("diamond").GetComponent<Image>().sprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector3());
        }
        else if (uworld == 4)
        {
            Texture2D tex = Resources.Load("Animations\\levelselect_sprite_sheets\\s_dark") as Texture2D;
            GameObject.Find("square").GetComponent<Image>().sprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector3());
            tex = Resources.Load("Animations\\levelselect_sprite_sheets\\t_dark") as Texture2D;
            GameObject.Find("triangle").GetComponent<Image>().sprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector3());
            tex = Resources.Load("Animations\\levelselect_sprite_sheets\\ut_dark") as Texture2D;
            GameObject.Find("utriangle").GetComponent<Image>().sprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector3());
            tex = Resources.Load("Animations\\levelselect_sprite_sheets\\d_dark") as Texture2D;
            GameObject.Find("diamond").GetComponent<Image>().sprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector3());
            tex = Resources.Load("Animations\\levelselect_sprite_sheets\\p_dark") as Texture2D;
            GameObject.Find("pentagon").GetComponent<Image>().sprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector3());
        }

        updateBestMove();
    }
    public void changeLevel(int i)
    {
        ulevel += i;
        if (ulevel >= 9)
        {
            ulevel = 0;
        }
        if (ulevel <= -1)
        {
            ulevel = 8;
        }
        GameObject.Find("level").GetComponent<Text>().text = "" + ulevel;
        updateBestMove();
    }
    
    public void loadNextLevel()
    {
        string currLevel = levelSelected;
        string[] levelInfo = currLevel.Split('-'); //World-Level
        var world = int.Parse(levelInfo[0]);
        var level = int.Parse(levelInfo[1]);

        //increment level
        level += 1;
        //reached outside the world's domain
        //for now we limit the levels in a world to 4
        //go to the next world
        if (level == 9)
        {
            world += 1;
            level = 0;
        }

        if (world == 5)
        {
            SceneManager.LoadScene("HomeScreen");
        }
        //else we have levels, keep playing under conditions that you get 3 stars
        else
        {
            levelSelected = "" + world + "-" + level;
            print("Loading " + levelSelected);
            SceneManager.LoadScene("GameScreen");
        }
    }


    // Use this for initialization
    void Start () {
        if (SceneManager.GetActiveScene().name == "MenuScreen")
        {
            updateBestMove();
        }
	}
	
}
