using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
public class resumeGame : MonoBehaviour
{
    //public RawImage m_RawImage;
    
    public GameObject infoPanel;

    public void ResumeGame()
    {
        // Disable the info panel
        infoPanel.SetActive(false);

        // Resume the game
        Time.timeScale = 1; 
    }

    public void AfficheImage(int i)
    {
        
    }

}









