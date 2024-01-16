using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    private int maxHealth = 100;
    private int curHealth;
    [SerializeField]
    private Animator bodyAnimator;

    public EHealthBar ehealthBar;
    [SerializeField]
    private CircleCollider2D circleCollider;
    // Start is called before the first frame update
    void Start()
    {
        curHealth = maxHealth;
        ehealthBar.UpdateBar(curHealth, maxHealth);
    }
    public void TakeDamage(int damage)
    {
        curHealth -= damage;
        if (curHealth <= 0 )
        {
            bodyAnimator.SetTrigger("Dead");
            circleCollider.enabled = false;
        }
        else
        {
            bodyAnimator.SetTrigger("takeDamage");
        }
        ehealthBar.UpdateBar(curHealth, maxHealth);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
