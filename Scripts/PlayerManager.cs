using System.Collections;
using TMPro;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    Animator animator;

    public int DiamondTotal;
    public TextMeshProUGUI DiamondText;

    public float maxHealth;
    public float currentHealth;
    public HealthBar healthBar;

    public float maxOxy;
    public float currentOxy;
    public OxyBar oxyBar;

    public bool deathCheck;
    private bool timeLine;
    private const string DYING = "isDying";

    public new Camera camera;
    public GameObject player;
    public GameObject gameSound, gameOverSound;

    // Start is called before the first frame update
    public void Start()
    {
        animator = GetComponent<Animator>();

        //Diamonds Line
        DiamondTotal = 0;

        //Health Line
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

        //Oxygen Line
        currentOxy = maxOxy;
        oxyBar.SetMaxOxy(maxOxy);
        oxyBar.gameObject.GetComponent<OxyBar>();

        gameOverSound.SetActive(false);
    }
    // Update is called once per frame
    public void Update()
    {
        DiamondText.text = "x" + DiamondTotal.ToString();

        StartCoroutine(WaitForTimeline());
        if (currentOxy <= 0)
        {
            currentHealth -= 0.1f;
            healthBar.slider.value -= 0.1f;
            if (currentHealth <= 0)
            {
                DeathController();
            }
        }
        if(camera.transform.position.y > player.transform.position.y + 50)
        {
            currentHealth -= 1f;
            healthBar.slider.value -= 1f;
            if (currentHealth <= 0)
            {
                DeathController();
            }
        }
    }
    //Damage method here
    public void TakeDamage(int damage)
    {
        if (damage >= 0)
        {
            currentHealth -= damage;

            healthBar.SetHealth(currentHealth);

            if (currentHealth == 0)
            {
                currentHealth = 0;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Water")
        {
            TakeDamage(10);
            if (currentHealth <= 0)
            {
                DeathController();
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Block")
        {
            TakeDamage(30);
            if (currentHealth <= 0)
            {
                DeathController();
            }
        }
    }
    public void DeathController()
    {
        deathCheck = true;
        animator.SetTrigger(DYING);
        gameOverSound.SetActive(true);
        gameSound.SetActive(false);
        StartCoroutine(DelayLoadGameOver());
    }
    private IEnumerator DelayLoadGameOver()
    {
        while (currentHealth <= 0)
        {
            yield return new WaitForSeconds(2);
            GameOver.instance.PlayerDied();
        }
    }
    private IEnumerator WaitForTimeline()
    {
        while (timeLine == false)
        {
            yield return new WaitForSeconds(16);
            currentOxy -= 0.1f;
            oxyBar.slider.value -= 0.1f;
        }
    }
}
