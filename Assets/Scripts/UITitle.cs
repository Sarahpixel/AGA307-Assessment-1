using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UITitle : MonoBehaviour
{
   public void StartGame()
    {
        SceneManager.LoadScene("MainGame");
        //_GM.ChangeGameState(GameState.InGame);

    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
