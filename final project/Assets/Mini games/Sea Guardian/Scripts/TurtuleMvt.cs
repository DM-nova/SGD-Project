using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public interface Attackable
{
    public void getAttacked(Player player);
}
public class TurtuleMvt : MonoBehaviour, Attackable
{
    [SerializeField] Transform[] points;
    Vector3 destination;
    [SerializeField]
    float speed;
    float initialSpeed;
    Rigidbody2D rb;
    Animator animator;
    [SerializeField] Animator animWoop, camShake, hurt;
    public ParticleSystem BOOM;
    GameManager02 manager;
    [SerializeField] AudioSource getAttackedSound;
    [SerializeField] GameObject hurtPanel;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        manager = FindObjectOfType<GameManager02>();
    }

    private void Start()
    {
        
        initialSpeed = speed;
        destination = points[Random.Range(0, points.Length)].position;
        animator.SetBool("swimFast", false);
    }
    float ddj = 0;
    void MoveToDestination(Vector2 pos) // mvt of turtule
    {
        rb.velocity = pos;
        //transform.Translate(pos);
        Vector3 direction = (destination - transform.position).normalized;
        Quaternion rotation = Quaternion.Euler(0, 0, Vector3.SignedAngle(Vector3.right, direction,transform.forward));
        transform.localScale = (rb.velocity.x > 0)?new Vector2(-.32f, .32f) : new Vector2(-.32f, -.32f);
        if (transform.rotation != rotation)
        {
            ddj += Time.deltaTime;
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, ddj);
        }
        else
            ddj = 0;
        //Debug.Log(angle +" dsf" + transform.rotation.z);
        if (Mathf.Abs(Vector2.Distance(transform.position, destination)) < 0.1f) //if the turtule go to the target it will be fine
            destination = points[Random.Range(0, points.Length)].position;  //points[Random.Range(0, points.Length)].position;


    }

    private void FixedUpdate()
    {

        if (!dead)
            MoveToDestination(((Vector2)destination - (Vector2)transform.position).normalized * Time.deltaTime * speed); // always move it;
    }

    public void getAttacked(Player player) //when the turtule get aattacked by the player
    {
        Debug.Log("dfg");
        getAttackedSound.Play();
        animator.SetBool("swimFast", true);
        speed = initialSpeed + 50;
        animWoop.gameObject.SetActive(true);
        animWoop.Play("Fart");
        StartCoroutine(backSpeed());
    }
    IEnumerator backSpeed()
    {
        yield return new WaitForSeconds(3f);
        speed = initialSpeed;
        animator.SetBool("swimFast", false);
    }
    //private void OnCollisionEnter2D(Collision2D collision) // when the tutrte hit somthing 
    //{
    //    TurtuleCanHit hitable = collision.transform.GetComponent<TurtuleCanHit>();
    //    if (hitable != null)
    //    {
    //        BOOM.Play();
    //        hitable.hit(this);
            
    //    }
            
    //}
    bool dead;
    public void eat()
    {
        animator.SetBool("eat", true);
    }
    public void eatFalse()
    {
        animator.SetBool("eat", false);
    }
    public void death()
    {

        if (!dead)
            animator.SetBool("dead", true);
        camShake.SetBool("shake", true);
        hurtPanel.SetActive(true);
        hurt.SetTrigger("hurt");

        dead = true;
        Invoke("stopShake", 0.25f);
        GetComponent<BoxCollider2D>().isTrigger = true;
        rb.gravityScale = .5f;
        if(manager.end == false)
        manager.TurtlesNum--;
        //Debug.Log("dfg");
        hurtPanel.SetActive(false);
    }
    public void deathFalse()
    {
        animator.SetBool("dead", false);
    }
    
    void stopShake()
    {
        camShake.SetBool("shake", false);
    }
}
