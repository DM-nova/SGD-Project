using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public static bool gameOver;
    public GameObject gameOverPanel;
    public GameObject startingText;
    public static bool isGameStarted;
    public static int numberOfCoins;
    public static int numberOfBlueCoins;
    public static int numberOfyellowCoins;
    public Text coinsText;
    public Text bluecoinsText;
    public Text yellowcoinsText;
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
        if(gameOver)
        {
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);
        }
        coinsText.text = "Coins:" + numberOfCoins;
        bluecoinsText.text = "Coins:" + numberOfBlueCoins;
        yellowcoinsText.text = "Coins:" + numberOfyellowCoins;


        if (SwipeManager.tap)
           {
            isGameStarted = true;
            Destroy(startingText);
       }
    }
}
