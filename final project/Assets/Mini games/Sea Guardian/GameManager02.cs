using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager02 : MonoBehaviour
{
    [SerializeField] GameObject infoPanel;

    public GameObject SacPref;
    public GameObject JellyfishPref;

     float floorLevel=2f;
     float waterLevel=-3.5f;


    public ObjectPool<Sac> sacs;
    bool go = false;

   [HideInInspector] public int TurtlesNum = 3;
    public TextMeshProUGUI TurtlesText;

    [SerializeField]
    float Timer;
    public TextMeshProUGUI TimerText;

    public GameObject WinPanel;
    public GameObject LostPanel;
    public GameObject panel, scriptPanel;


    [SerializeField] starFxController StarsScript;

    [SerializeField] GameObject[] sprites;
    private void Awake()
    {
        sacs = new ObjectPool<Sac>(SpawnSacs<Sac>, getSac, realseSac, destroySac, maxSize: 6);
        StarsScript = FindObjectOfType<starFxController>();
    }

    void StartGame()
    {

        Time.timeScale = 1;
        if(LostPanel != null)
        {
            LostPanel.SetActive(false);

        }
        if(WinPanel != null)
        {
            WinPanel.SetActive(false);
        }
        if (panel)
        panel.SetActive(false);


        //InvokeRepeating("SpawnSacs",1,Random.Range(2,5));
        InvokeRepeating("SpawnJellyfish", 1, Random.Range(4, 6));
        StartCoroutine(spawnSacs(3f));
    }

    IEnumerator spawnSacs(float time)
    {
        yield return new WaitForSeconds(time);
        sacs.Get();
        StartCoroutine(spawnSacs(3.5f));
    }

    private void Update()
    {
        if (go) {
            Timer -= Time.deltaTime;
            if (TurtlesText)
                TurtlesText.text = TurtlesNum.ToString() + "/3";


            float minutes = Mathf.Floor(Timer / 60);
            float seconds = Mathf.RoundToInt(Timer % 60);
            if (TurtlesText)
                TimerText.text = minutes.ToString() + ":" + seconds.ToString();
            GameOver();
        }
    }

    T SpawnSacs<T>()
    {
        int a = Random.Range(0, 3) > 0 ? 2 : Random.Range(0, 2);
        GameObject s = Instantiate(sprites[a], new Vector2(Random.Range(-20, -12), Random.Range(waterLevel, floorLevel)), Quaternion.identity);
        //setRandomSprite(s);
        return s.GetComponent<T>();
    }
    void getSac(Sac sac)
    {
        //setRandomSprite(sac.gameObject);
        sac.transform.position = Random.Range(0,2)==0? new Vector2(Random.Range(-20, -12), Random.Range(waterLevel, floorLevel)): new Vector2(Random.Range(20, 12), Random.Range(waterLevel, floorLevel));
        sac.gameObject.SetActive(true);
    }
    void realseSac(Sac sac)
    {
        sac.gameObject.SetActive(false);
    }
    void destroySac(Sac sac)
    {
        Destroy(sac.gameObject);
    }
    void SpawnJellyfish()
    {
        float placeOfSpawn = Random.Range(0, 2) == 0 ? Random.Range(-9.5f, -3.1f) : Random.Range(1.8f, 9.5f);
      GameObject obj = Instantiate(JellyfishPref, new Vector2(placeOfSpawn, -6), Quaternion.identity);
        
    }
    public bool end = false;
    IEnumerator Loss(float time)
    {
        yield return new WaitForSeconds(time);
        
    }
    void GameOver()
    {
        
        if (Timer>0 && TurtlesNum <= 0)  //lost
        {
            StartCoroutine(Loss(1.5f));
            if (LostPanel != null)
            {
                LostPanel.SetActive(true);
            }
            panel.SetActive(true);

            Time.timeScale = 0;
            TimerText.text = "00:00";
            end = true;
        }

         if (Timer<=0 && TurtlesNum > 0)  //win
        {
            end = true;
            WinPanel.SetActive(true);
            panel.SetActive(true);

            TimerText.text = "00:00";
            //TurtlesNum = FindObjectsOfType<TurtuleMvt>().Length;
            if (StarsScript)
                StarsScript.ea = TurtlesNum;
            //Debug.Log(TurtlesNum);
            //
            StartCoroutine(stopGame());

        }
    }
    IEnumerator stopGame()
    {
        yield return new WaitForSeconds(2f);
        Time.timeScale = 0;
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("Save the ocean");
    }
    public void Menu()
    {
        SceneManager.LoadScene("Scene");
    }
    public void Levels()
    {
        SceneManager.LoadScene("SGLevels");
    }
    public void Home()
    {
        SceneManager.LoadScene("Games");
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
        StartGame();
    }
}
