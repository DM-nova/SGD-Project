using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sac : Movebale, Attackable, TurtuleCanHit
{
    Transform destination, player;
    GameManager02 manager;
    [SerializeField] AudioSource  myaudio;
    public void getAttacked(Player player) // when the player attack it
    {
        myaudio.Play();
        destination = player.transform.GetChild(0);
        this.player = player.transform;
    }
    private void Awake()
    {
        manager = FindObjectOfType<GameManager02>();
    }
    private void Start()
    {
        
        setMaxs();
        StartCoroutine(changeM());
        //myaudio.GetComponent<AudioSource>();
    }
    float z = 0;
    private void FixedUpdate()
    {
        if(!hasReleased)
        {
            if (!destination)
            {
                Move();
                //z += 0.1f;
                //transform.rotation = Quaternion.Euler(0,0,z);
            }  
            else
            { // follow the player
                transform.position = destination.position;
                if (player)
                {
                    if (!hasReleased && Mathf.Abs(Vector2.Distance((Vector2)player.position, (Vector2)transform.position)) < .4f)
                    {
                        manager.sacs.Release(this);
                    }

                }
            }
        }
     
    }
    bool hasReleased = false;
    private void OnDisable()
    {
        player = null;
        destination = null;
        hasReleased = true;
    }
    private void OnEnable()
    {
        //Debug.Log("fdsg");
        z = Random.Range(0f,360f);
        destination = null;
        player = null;
        Invoke("release", 0.5f);
        
    }
    void release()
    {
        hasReleased = false;
        if (transform.position.x < 0) b = 1;
        else b = -1;
    }
    public void hit(TurtuleMvt turtule) //when the turtule eat it
    {
        if(!player)
        {
            turtule.death();
            //Destroy(turtule.gameObject);
            //manager.TurtlesNum -= 1;
            if (!hasReleased)
            {
                manager.sacs.Release(this);
            }
        }
    }
    public void getDestroyed()
    {
        if(!hasReleased)
        manager.sacs.Release(this);
    }



}
