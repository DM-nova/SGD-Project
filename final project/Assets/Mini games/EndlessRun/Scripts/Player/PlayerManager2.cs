using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager2 : MonoBehaviour
{
    public static bool gameOver;
    public GameObject gameOverPanel;
    public GameObject WinPanel;
    public GameObject startingText;
    public static bool isGameStarted;
    public static int numberOfCoins;
    public static int numberOfBlueCoins;
    public static int numberOfyellowCoins;
    public Text coinsText;
    public Text bluecoinsText;
    public Text yellowcoinsText;
    public Timer1 Timer1;
    public GameObject Wheel;
    public int Wincoin = 1;

    void Start()
    {
        gameOver = false;
        Time.timeScale = 1;
        isGameStarted = false;
        numberOfCoins = 0;
        numberOfBlueCoins = 0;
        numberOfyellowCoins = 0;
    }

    // Update is called once per frame
    void Update()
    {

        if (gameOver)
        {
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);
        }
        coinsText.text = ":" + numberOfCoins;
        bluecoinsText.text = ":" + numberOfBlueCoins;
        yellowcoinsText.text = ":" + numberOfyellowCoins;

        if (SwipeManager1.tap)
        {
            isGameStarted = true;
            Destroy(startingText);
        }

        if (Timer1.Finish == true)
        {
            if ((numberOfCoins >= Wincoin) && (numberOfBlueCoins >= Wincoin) && (numberOfyellowCoins >= Wincoin))
            {
                WinPanel.SetActive(true);
            }
            else
            {
                gameOverPanel.SetActive(true);
            }
            Destroy(Wheel);
        }
    }
}
