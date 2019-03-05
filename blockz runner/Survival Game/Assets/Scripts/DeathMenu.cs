using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour {

    public Text scoreText;
    public Image backgroundImg;
    public GameObject mainMenu;
    public GameObject levelSelector;
    public GameObject scoreUI;
    public GameObject player;
    public GameObject player1;
    public GameObject player2;
    public GameObject player3;
    public GameObject player4;
    public GameObject player5;

	void Start ()
    {
        mainMenu.SetActive(false);//make sure manu menu isnt active
        levelSelector.SetActive(true);//put up the level selector menu
        scoreUI.SetActive(false);//make sure the score UI cant be scene
    }
    public void Restart()//on restart button on death menu
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);//resets scene
        scoreUI.SetActive(false);//dont show the score
    }
    public void ToMenu()//for the menu button
    {
        SceneManager.LoadScene("Menu");//go to the menu
    }
    private void LevelStart()//do at the start of every game
    {
        levelSelector.SetActive(false);//close the level selector
        scoreUI.SetActive(true);//show the current score
    }
    //all attached to the level buttons on UI
    public void Level1()
    {
        player.SetActive(true);
        LevelStart();
    }
    public void Level2()
    {
        player1.SetActive(true);
        LevelStart();
    }
    public void Level3()
    {
        player2.SetActive(true);
        LevelStart();
    }
    public void Level4()
    {
        player3.SetActive(true);
        LevelStart();
    }
    public void Level5()
    {
        player4.SetActive(true);
        LevelStart();
    }
    public void Level6()
    {
        player5.SetActive(true);
        LevelStart();
    }
}
