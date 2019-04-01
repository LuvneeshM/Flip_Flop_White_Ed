using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;


public class loadingGameLevelFromTxtScript : MonoBehaviour {

    int size_of_obj = 100;

    string userLevel = "0-0";

    public GameObject board;
    

	// Use this for initialization
	void Start () {
        userLevel = loadSceneScript.levelSelected;

        fillTheLevel();

	}

    void fillTheLevel()
    {
        //will find the .txt level from the Levels folder and parse it
        TextAsset levelText = Resources.Load("Levels\\" + userLevel) as TextAsset;
        string levelTextString = levelText.ToString();
        string[] levelLines = Regex.Split(levelTextString, "\n|\r\n");

        //first line for every text file is the goal number of moves
        Debug.Log("number of moves to win = " + int.Parse(levelLines[0]));

        //second line is the matrix we will be working on N M
        //will be less than 10 greater than 0
        int nx = int.Parse(""+levelLines[1][0]);
        int my = int.Parse(""+levelLines[1][2]);
        int spacing_between_objs = 10;
        int left_obj_x;
        int left_obj_y;

        if (my % 2 == 1)
        {
             left_obj_y = 1 * (int)(my / 2) * size_of_obj + (spacing_between_objs * (int)(my / 2));
        }
        else
        {
            left_obj_y = 1 * (int)(my / 2) * size_of_obj + (spacing_between_objs * (int)(my / 2)) - (size_of_obj + spacing_between_objs) / 2; ;
        }
        for (int y = 0; y < my; y++)
        {
            if (nx % 2 == 1)
            {
                left_obj_x = -1 * (int)(nx / 2) * size_of_obj - (spacing_between_objs * (int)(nx / 2));
            }
            else
            {
                left_obj_x = -1 * (int)(nx / 2) * size_of_obj - (spacing_between_objs * (int)(nx / 2)) + (size_of_obj+spacing_between_objs)/2;
            }

            int x = 0;
            string curr_line = levelLines[2 + y];
            int offset = 0;
            while (x < curr_line.Length)
            {
                //shape then color
                GameObject obj = loadGameObject(curr_line[x], curr_line[x + 1]);
                //obj.transform.SetParent(board.transform);
                obj.transform.localPosition = new Vector3(left_obj_x, left_obj_y, 0);

                left_obj_x += size_of_obj + spacing_between_objs;

                x += 2;
            }

            //update the left_obj_y
            left_obj_y -= size_of_obj + spacing_between_objs;
        }
    }

    GameObject loadGameObject(char shape, char color)
    {
        GameObject g = null;
        string toLoad = "";
        string name = "";
        //square - s
        if (shape == 's')
        {
            if (color == 'W')
            {
                toLoad = "Prefabs\\whiteSquare";
                name = "white";
            }
            else if (color == 'B')
            {
                toLoad = "Prefabs\\blackSquare";
                name = "black";
            }
        }
        //triangle - t
        else if (shape == 't')
        {
            if (color == 'W')
            {
                toLoad = "Prefabs\\whiteTriangle";
                name = "white";
            }
            else if (color == 'B')
            {
                toLoad = "Prefabs\\blackTriangle";
                name = "black";
            }
        }
        //upside down triangle - u
        else if (shape == 'u')
        {
            if (color == 'W')
            {
                toLoad = "Prefabs\\whiteUTriangle";
                name = "white";
            }
            else if (color == 'B')
            {
                toLoad = "Prefabs\\blackUTriangle";
                name = "black";
            }
        }
        //diamond - d
        else if (shape == 'd')
        {
            if (color == 'W')
            {
                toLoad = "Prefabs\\whiteDiamond";
                name = "white";
            }
            else if (color == 'B')
            {
                toLoad = "Prefabs\\blackDiamond";
                name = "black";
            }
        }
        //pentagon - p
        else if (shape == 'p')
        {
            if (color == 'W')
            {
                toLoad = "Prefabs\\whitePentagon";
                name = "white";
            }
            else if (color == 'B')
            {
                toLoad = "Prefabs\\blackPentagon";
                name = "black";
            }
        }
        else if (shape == 'Z')
        {
            toLoad = "Prefabs\\_filler";
            name = "done";
        }
        g = (GameObject)Instantiate(Resources.Load(toLoad),board.transform);
        g.gameObject.name = name;

        Button g_button = g.GetComponent<Button>();
        g_button.onClick.AddListener(delegate { this.gameObject.GetComponent<FlipColor>().flipFlop(g); });

        return g;
    }
}
