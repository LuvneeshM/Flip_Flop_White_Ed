using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadSceneScript : MonoBehaviour {

    //this will be static, so it is same for all levels, unless changed
    static public string levelSelected;

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
        if (level == 10)
        {
            world += 1;
            level = 0;
        }

        if (world == 5 || level == 5)
        {
            SceneManager.LoadScene("HomeScreen");
        }
        //else we have levels, keep playing under conditions that you get 3 stars
        else
        {
            levelSelected = "" + world + "-" + level;
            SceneManager.LoadScene("GameScreen");
        }
    }


    // Use this for initialization
    void Start () {
		
	}
	
}
