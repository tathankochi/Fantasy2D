using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class Attack : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private GameObject swordAnimation;

    [SerializeField]
    private PolygonCollider2D slashHitBox;
    [SerializeField]
    private GameObject swordRotate;

    private bool isAttacking = false;

    public int damageRoot = 20;
    public int damageSword = 0;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mousePosition - swordRotate.transform.position;
        swordRotate.transform.right = direction;
        if (direction.x<0)
        {
            swordAnimation.transform.localScale = new Vector3(1, -1, 1);
        }
        else
        {
            swordAnimation.transform.localScale = new Vector3(1, 1, 1);
        }
        if (isAttacking)
        {
            if (!animator.GetBool("Action"))
            {
                isAttacking = false;
                slashHitBox.enabled = false;
            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            if (!animator.GetBool("Action"))
            {
                isAttacking = true;
                slashHitBox.enabled = true;
                animator.SetTrigger("Attack");
            }
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            EnemyHealth enemyHealth=collision.gameObject.GetComponent<EnemyHealth>();
            enemyHealth.TakeDamage(damageRoot+damageSword);
            slashHitBox.enabled = false;
        }
    }
}
