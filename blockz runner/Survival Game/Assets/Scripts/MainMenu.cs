using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

    public Text highScoreText;

    public void Start()
    {
        if(highScoreText != null)//stops errors in console at start
            highScoreText.text = "Highscore: " + (int)PlayerPrefs.GetFloat("HighScore");//sets highscore in the UI to the highscore in playerprefs
    }

    public void ToGame()//used on to game button
    {
        SceneManager.LoadScene("Level01");//goes to game
    }

    public void Exit()//used on exit button
    {
        Application.Quit();//closes the app
    }
}
