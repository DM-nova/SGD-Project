using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Events : MonoBehaviour
{
  public void RêplayGame()
    {
        SceneManager.LoadScene("Level");
    }
    public void QuitGame()
    {
        Application.Quit();
    }

}
