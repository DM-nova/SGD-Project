using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    AudioManager1 audioManager1;
    [SerializeField] private GameObject[] img;
    public GameObject infoPanel , WinPanel ;
    [SerializeField] TileManager1 tile;

    public GameObject[] m_GO;

    private bool hasPassedEmptyPath = false;


    private void Start()
    {
        audioManager1 = FindObjectOfType<AudioManager1>();
        tile = GameObject.FindObjectOfType<TileManager1>();

    }
   void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            //Game Over
            
            PlayerManager1.gameOver = true;
            //audioManager1.Play("gameover");


        }
        if (collision.gameObject.CompareTag("EmptyPath"))
        {
            Debug.Log("Player passed through an empty path.");
            hasPassedEmptyPath = true;

        }
        if (collision.gameObject.CompareTag("EndLevel"))
        {
            Debug.Log("END LEVEL");
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            WinPanel.SetActive(true);

        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Gem"))
        {
            // Player collides with a cube
            //audioManager1.Play("coins");
           int ob = PlayerManager1.gems++;
            Destroy(other.gameObject);
            Time.timeScale = 0;
            infoPanel.SetActive(true);
            Debug.Log(ob);
            m_GO[ob].SetActive(true);

            // Update TileManager to mark empty path as passed
            if (tile != null && hasPassedEmptyPath)
            {
                if (tile.MarkEmptyPathPassed())
                {
                    Debug.Log("Level Complete! Player passed through all empty paths.");

                    // Implement your retry level logic here
                    // For example, you can return to the start menu panel and restart the game
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                   
                }
            }
        }
    }
}
    