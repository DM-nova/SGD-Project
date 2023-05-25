using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public List<Plants> plantsasAUsar;

    public GameObject Deck;
    public GameObject PrefabCarte;

    public Text TxtSuns;
    int Suns = 300 ;
    int plantAUsar = 0 ;


    void Start()
    {
        SunCollect(0);
        for (int i=0;i<plantsasAUsar.Count;i++)
        {
            GameObject go = Instantiate(PrefabCarte) as GameObject;
            go.transform.SetParent(Deck.transform);
            go.transform.position = Vector3.zero;

            Image img = go.GetComponent<Image>();
            img.sprite = plantsasAUsar[i].carteAsigned;

            Button bot = go.GetComponent<Button>();
            bot.onClick.RemoveAllListeners();
            int u = i;
            bot.onClick.AddListener(() => { plantAUsar = u; });


        }
    }

 

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(r.origin,r.direction);
            if (hit.collider != null)
            {
                if (hit.collider.CompareTag("Background"))
                {
                    Transform t = hit.collider.transform;
                    CreatePlant(plantAUsar, t);
                }
                else if (hit.collider.CompareTag("Sun"))
                {
                    SunCollect(50);
                    Destroy(hit.collider.gameObject);
                }
            }
        }
    }




    void CreatePlant(int num , Transform t)
    {
        if (plantsasAUsar[num].SunPrice > Suns)
            return;
        if (t.childCount != 0)
            return;

        GameObject g = Instantiate(plantsasAUsar[plantAUsar].gameObject, t.position, gameObject.transform.rotation) as GameObject;
        g.transform.SetParent(t);

        SunCollect(- plantsasAUsar[num].SunPrice);
    }

    public void SunCollect(int Add)
    {
        Suns += Add;
        TxtSuns.text = Suns.ToString();
    }
}
