using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveController : MonoBehaviour
{
    [SerializeField] GameObject infoPanel;
    public bool go = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
    public void InfoButton()
    {
        infoPanel.SetActive(true);
    }

    public void CloseInfoButton()
    {
        infoPanel.SetActive(false);
        go = true;

        //scriptPanel.gameObject.SetActive(true);
        //StartGame();
    }
}
