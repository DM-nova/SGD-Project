using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Events : MonoBehaviour
{
  public void R�playGame()
    {
        SceneManager.LoadScene("Level");
    }
    public void QuitGame()
    {
        Application.Quit();
    }

}
