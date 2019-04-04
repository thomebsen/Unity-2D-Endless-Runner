using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public void GameOver(){SceneManager.LoadScene("GameOver");}
    public void StartGame(){SceneManager.LoadScene("Level_1");}
    public void MainMenu(){SceneManager.LoadScene("MainMenu");}
    public void HowToPlay(){SceneManager.LoadScene("HowToPlay");}
    public void ExitGame(){Application.Quit();}

    public void ResetHighScore()
    {
        PlayerPrefs.DeleteKey("Highscore");
        PlayerPrefs.DeleteKey("BestTime");
    }
}
