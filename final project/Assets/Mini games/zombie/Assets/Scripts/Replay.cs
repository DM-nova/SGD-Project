using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Replay : MonoBehaviour
{
    public void R�playGame()
    {
        SceneManager.LoadScene("ZombieScene");
    }
    public void QuitGame()
    {
        //Application.Quit();
        SceneManager.LoadScene("Scene");
    }

}
