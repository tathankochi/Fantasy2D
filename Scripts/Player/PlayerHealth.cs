using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth=300;
    public int curHealth;
    [SerializeField]
    private Animator bodyAnimator;

    public HealthBar healthBar;

    [SerializeField]
    private AudioClip dead;
    // Start is called before the first frame update
    void Start()
    {
        curHealth = maxHealth;
        healthBar.UpdateBar(curHealth, maxHealth);
    }
    public void TakeDamage(int damage)
    {
        curHealth -= damage;
        bodyAnimator.SetTrigger("takeDamage");
        healthBar.UpdateBar(curHealth, maxHealth);
        if (curHealth <= 0)
        {
            SceneLoad.Instance.LoadScene("InHome", new Vector2(-8.0f, 2.0f));
            GameObject.Find("soundRemain").GetComponent<AudioSource>().clip = dead;
            GameObject.Find("soundRemain").GetComponent<AudioSource>().Play();
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(20);
        }
    }
    public void HealthFull()
    {
        curHealth = maxHealth;
        healthBar.UpdateBar(maxHealth, maxHealth);
    }
}
