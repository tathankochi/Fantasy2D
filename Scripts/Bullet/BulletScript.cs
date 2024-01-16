using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.UI;

public class BulletScript : MonoBehaviour
{
    private Vector2 startPosition;
    private Vector2 direction;
    private float speed;
    private float distance;
    private int damage;

    private bool isDestroy=false;
    private bool animationDestroy = false;

    private Animator animator;
    CircleCollider2D circleCollider2D;

    [SerializeField]
    private GameObject destroyBullet;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        circleCollider2D = GetComponent<CircleCollider2D>();;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDestroy && !animationDestroy)
        {
            if (animator.GetBool("Action"))
            {
                animationDestroy = true;
            }
        }
        else if (animationDestroy)
        {
            if (!animator.GetBool("Action"))
            {
                Destroy(destroyBullet);
            }
        }
        else 
        {
            if (Vector2.Distance(startPosition, transform.position) < distance)
            {
                destroyBullet.transform.Translate(direction * speed * Time.deltaTime);
            }
            else
            {
                Destroy(destroyBullet);
            }
        }





        //if (Vector2.Distance(startPosition, transform.position) < distance)
        //{
        //    Debug.Log("di chuyen1");
        //    destroyBullet.transform.Translate(direction * speed);
        //}
        //Debug.Log("truoc frame");
        ////if (Input.GetKeyDown(KeyCode.Space))
        ////{
        ////    Debug.Log("setTrigggggggggggggg");
        ////    animator.SetTrigger("Destroy");
        ////}
        //if (animator.GetBool("Action"))
        //{
        //    Debug.Log("action true");
        //}
        //else
        //{
        //    Debug.Log("action false");
        //}
        //Debug.Log("sau frame");
    }
    public void Initial(Vector2 startPosition,Vector2 direction, float speed, float distance, int damage)
    {
        this.startPosition=startPosition;
        this.direction = direction.normalized;
        this.speed = speed;
        this.distance = distance;
        this.damage = damage;
        this.transform.right = direction;
        Debug.Log(startPosition+" "+direction + " " + speed + " " + distance + " " + damage);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!circleCollider2D.enabled)
        {
            return;
        }
        if (collision.tag == "Sword")
        {
            isDestroy = true;
            animator.SetTrigger("Destroy");
            circleCollider2D.enabled = false;
        }
        else if (collision.tag == "Wall")
        {
            Destroy(destroyBullet);
        }
        else if (collision.tag == "Player")
        {
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            playerHealth.TakeDamage(damage);
            Destroy(destroyBullet);
        }
    }
}
