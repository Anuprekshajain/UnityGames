using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Element : MonoBehaviour {
    public bool mine;
    public Button exit;
    public Button restart;
    public Button Easy;
    public Button Medium;
    public Button Hard;
    public Text winText;
    public Sprite[] emptyTextures;
    public Sprite mineTexture;
	// Use this for initialization
	void Start () {
        //Decide whether it's a mine or not
        mine = Random.value < 0.20;
        winText.text = "";
        // Register in Grid
        int x = (int)transform.position.x;
        int y = (int)transform.position.y;
        Grid.elements[x, y] = this;
        exit.onClick.AddListener(() => {
            Application.Quit();
        });
        restart.onClick.AddListener(() =>
        {
            Application.LoadLevel(Application.loadedLevel);
        });
        Easy.onClick.AddListener(() => {
            mine = Random.value < 0.15;
            Application.LoadLevel(Application.loadedLevel);
        });
        Medium.onClick.AddListener(() => {
            mine = Random.value < 0.20;
            Application.LoadLevel(Application.loadedLevel);
            
        });
        Hard.onClick.AddListener(() => {
            mine = Random.value < 0.25;
            Application.LoadLevel(Application.loadedLevel);
            
        });
    }
    private void Update()
    {
        if (SystemInfo.deviceType == DeviceType.Desktop)
        {
            // Exit condition for Desktop devices
            if (Input.GetKey("escape"))
                Application.Quit();
        }
        else
        {
            // Exit condition for mobile devices
            if (Input.GetKeyDown(KeyCode.Escape))
                Application.Quit();
        }
    }
    public void loadTexture(int adjacentCount)
    {
        //checks if it is a mine and load mine texture else load number texture according to adjacent mines
        if (mine)
            GetComponent<SpriteRenderer>().sprite = mineTexture;
        else
            GetComponent<SpriteRenderer>().sprite = emptyTextures[adjacentCount];
    }
    // Is it still covered?
    public bool isCovered()
    {
        return GetComponent<SpriteRenderer>().sprite.texture.name == "mine";
    }
    void OnMouseDown()
    {
       
        // It's a mine
        if (mine)
        {
            // Uncover all mines
            Grid.uncoverMines();

            // game over
            winText.text="You lose! Try again";
            
        }
        // It's not a mine
        else
        {
            // show adjacent mine number
            int x = (int)transform.position.x;
            int y = (int)transform.position.y;
            loadTexture(Grid.adjacentMines(x, y));

            // uncover area without mines
            Grid.FFuncover(x, y, new bool[Grid.w, Grid.h]);

            // find out if the game was won now
            if (Grid.isFinished())
                winText.text = "You Win!";
          
        }
    
    }
}
