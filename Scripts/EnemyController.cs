using System.Collections;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Hurt
    public int health = 100;
    bool takeDamage;

    //Animation
    public Animator animator;

    //Movement
    public float speed;
    float distance = 2f;
    public Transform groundDetection;
    RaycastHit2D groundInfo;
    private bool movingRight = true;
    private bool idle = true;

    private void Start()
    {
        animator = GetComponent<Animator>();
        
        StartCoroutine(Idle());
    }

    // Update is called once per frame
    void Update()
    {
        if (!idle)
        {
            Movement();
        }
        else
        {
            StartCoroutine(Idle());
            animator.SetBool("enemyIdle", true);
        }
        Attack();
        Hurt();
    }
    private IEnumerator Idle()
    {
        yield return new WaitForSeconds(2f);
        animator.SetBool("enemyIdle", false);
        idle = false;
    }
    void Movement()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        animator.SetBool("enemyWalk", true);

        groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance);

        if (groundInfo.collider == false)
        {
            if (movingRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
                idle = true;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
                idle = true;
            }
            animator.SetBool("enemyWalk", false);
        }
    }
    void Attack()
    {
        
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        takeDamage = true;
        if (health <= 0)
        {
            animator.SetTrigger("enemyDeath");
            StartCoroutine(DeathAnimation());
        }
    }
    void Hurt()
    {

    }
    IEnumerator DeathAnimation()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            if (!takeDamage)
            animator.SetTrigger("enemyHurt");
        }
    }
}
