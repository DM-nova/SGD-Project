using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Replay2 : MonoBehaviour
{
    public void RęplayGame()
    {
        SceneManager.LoadScene("SGLevel1");
    }
    public void QuitGame()
    {
        //Application.Quit();
        SceneManager.LoadScene("Scene");
    }

}
