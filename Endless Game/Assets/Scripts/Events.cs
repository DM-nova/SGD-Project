using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Events : MonoBehaviour
{
  public void RęplayGame()
    {
        SceneManager.LoadScene("Level");
    }
    public void QuitGame()
    {
        Application.Quit();
    }

}
