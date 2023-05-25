using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;


public class PlayerManager1 : MonoBehaviour
{
    public static bool levelStarted;
    public static bool gameOver;
    public GameObject startMenuPanel;
    public GameObject gameOverPanel;
    public MoveController MoveController;
    //coins
    public static int gems;
    public TextMeshProUGUI gemsText;

    private void Start()
    {
        MoveController = FindObjectOfType<MoveController>();
        gameOver = levelStarted = false;
        Time.timeScale = 1;
        gems = 0;
        PlayerPrefs.DeleteAll();
    }

    // Update is called once per frame
    void Update()
    {
       
            gemsText.text = (PlayerPrefs.GetInt("TotalGems", 0) + gems).ToString();
            Touchscreen ts = Touchscreen.current;
            if (ts != null && ts.primaryTouch.press.isPressed && levelStarted == false && MoveController.go == true)
            {
                levelStarted = true;
                startMenuPanel.SetActive(false);
            }
            if (gameOver)
            {
                Time.timeScale = 0;
                gameOverPanel.SetActive(true);
                PlayerPrefs.SetInt("TotalGems", PlayerPrefs.GetInt("TotalGems", 0) + gems);
                this.enabled = false;
            }
        
    }
}
