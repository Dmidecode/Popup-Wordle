using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_MainMenu : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject CreditsMenu;

    // Start is called before the first frame update
    void Start()
    {
        MainMenuButton();
    }

    public void EasyButton()
    {
        ScoreData.Difficulty = Difficulty.Easy;
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameLevel");
    }

    public void HardButton()
    {
        ScoreData.Difficulty = Difficulty.Hard;
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameLevel");
    }

    public void ShakespearButton()
    {
        ScoreData.Difficulty = Difficulty.Shakespear;
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameLevel");
    }

    public void CreditsButton()
    {
        // Show Credits Menu
        MainMenu.SetActive(false);
        CreditsMenu.SetActive(true);
    }

    public void MainMenuButton()
    {
        // Show Main Menu
        MainMenu.SetActive(true);
        CreditsMenu.SetActive(false);
    }
}