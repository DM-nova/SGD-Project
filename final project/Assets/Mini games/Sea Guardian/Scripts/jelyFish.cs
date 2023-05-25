using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface TurtuleCanHit
{
    public void hit(TurtuleMvt turtule);
    public void getDestroyed();
}

public class jelyFish : MonoBehaviour, Attackable,TurtuleCanHit
{
    [SerializeField] float speed,finalDestination;
    Rigidbody2D rb;
    public void getAttacked(Player player) // when the player take the jelly
    {
        player.getStunned(); //stun the player
        destination = player.transform.GetChild(0);
        this.player = player.transform;
    }
   
    Transform destination,player;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnEnable()
    {
        //transform.localScale = new Vector3(.4f, .4f,.4f);
    }
    private void FixedUpdate()
    {
        moveJely();
        if (destination)
        transform.position = destination.position;
        if(player)
        {
            if (Mathf.Abs(Vector2.Distance((Vector2)player.position,(Vector2)transform.position)) < 1.1f)
                Destroy(gameObject);
        }
        
    }
    int a = 1;
    void SetAValue()
    {
       Transform p = FindObjectOfType<Player>().transform;
        if (transform.position.x > p.position.x)
            a = 1;
        else
            a = -1;
    }
    bool isAset = false;
    void moveJely() // jely mvts
    {
        if (!destination)
        {
            if (transform.position.y <= finalDestination)
                rb.velocity = new Vector2(0, speed * Time.deltaTime);
            else
            {
                if (!isAset) SetAValue();
                rb.velocity = new Vector2(a*speed * Time.deltaTime, 0);
            }
                
        }
    }
    public void hit(TurtuleMvt hit) // when the turtule eat it
    {
        hit.eat();
        Destroy(gameObject);
    }

    public void getDestroyed()
    {
        Destroy(gameObject);
    }
}
