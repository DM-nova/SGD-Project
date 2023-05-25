using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Player : MonoBehaviour
{
    [SerializeField] float speed,pingPongSpeed,backSpeed,s;
    [SerializeField] Transform weapon,h;
    float animTimer=0;
    float initialScale;
    [SerializeField] Animator stars;
    [SerializeField] AudioSource stun;
    private void Start()
    {
        initialScale = weapon.localScale.y;
        doneFishing = true;
        stars.gameObject.SetActive(false);
    }
    bool start;
    bool doneFishing = false;
    void Animation()
    {
        animTimer += Time.deltaTime*s;
        h.rotation = Quaternion.Lerp(Quaternion.Euler(0, 0, -70f), Quaternion.Euler(0, 0, 70f), Mathf.PingPong(animTimer, pingPongSpeed));
    }
    public void hitSomthing()
    {
        start = false;
    }
    private void Update()
    {
        if(!isStunned)
        {
            if (Input.GetMouseButtonDown(0) && doneFishing)
            {
                doneFishing = false;
                start = true;
            }
            if (Input.GetMouseButtonUp(0))
                start = false;
        }
    }
    private void FixedUpdate()
    {
        if (!start && doneFishing && !isStunned)
            Animation();

        if (start == true)
            playerUse();
        else
        {
            if (!doneFishing)
            playerUnuse();
        }
    }
    void playerUse()
    {
        weapon.localScale = new Vector2(weapon.localScale.x, weapon.localScale.y + speed);  
    }
   
    void playerUnuse()
    {
        if (weapon.localScale.y - initialScale > 0.1f)
            weapon.localScale = new Vector2(weapon.localScale.x, weapon.localScale.y - backSpeed);
              
        else
            doneFishing = true;   
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
       Attackable attackable = collision.GetComponent<Attackable>();
        if (attackable != null && start) attackable.getAttacked(this);
        hitSomthing();
    }
    bool isStunned = false;
    public void getStunned()
    {
        stun.Play();
        isStunned = true;
        stars.gameObject.SetActive(true);
        stars.Play("starsAnimation");
        StartCoroutine(canPlayBack());
    }
    IEnumerator canPlayBack()
    {
        yield return new WaitForSeconds(3f);
        isStunned = false;
        stars.gameObject.SetActive(false);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("floor"))
        {
            playerUnuse();
        }
    }
   
}
