using System.Collections;
using UnityEngine;

public class DemonKingMove : MonoBehaviour
{
    [SerializeField]
    private float speed = 8.0f;
    private RaycastHit2D mainRay;
    private GameObject player;
    [SerializeField]
    private Rigidbody2D rg2D;
    [SerializeField]
    private Animator bodyAnimator;

    private float chaseDistance=7.0f;
    private float attackDistance = 1.5f;

    private bool isFacingRight = true;

    [SerializeField]
    private GameObject body;

    private Vector2 startPosition;

    //[SerializeField]
    //private GameObject bulletPrefab;
    //private GameObject bullet;

    private bool attack = false;
    [SerializeField]
    private int damage=10;
    [SerializeField]
    private BoxCollider2D slashHitBox;
    [SerializeField]
    private float delayTime=1.5f;
    private bool allowAttack = true;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (bodyAnimator.GetBool("IsDead"))
        {
            if (bodyAnimator.GetBool("Destroy"))
            {
                Destroy(this.gameObject);
            }
            return;
        }
        bodyAnimator.SetBool("Run", false);

        CheckMove();
    }
    private void CheckMove()
    {
        //Huong toi nhan vat
        Vector2 direction = player.transform.position - this.transform.position;
        float distance = Vector2.Distance(this.transform.position, player.transform.position);
        if (distance < chaseDistance)
        {
            Flip(direction);
            if (distance < attackDistance)
            {
                //if (bullet == null&&!bodyAnimator.GetBool("Action"))
                //{
                //    bodyAnimator.SetTrigger("Attack");
                //    //bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
                //    //BulletScript bulletScript = bullet.GetComponentInChildren<BulletScript>();
                //    //bulletScript.Initial(transform.position, direction, 5.0f, 5.0f, 5);
                //}

                if (allowAttack)
                {
                    bodyAnimator.SetTrigger("Attack");
                    slashHitBox.enabled = true;
                    allowAttack = false;
                    StartCoroutine(DelayCoroutine());
                }
            }
            else
            {
                mainRay = Physics2D.Raycast(this.transform.position, direction, 7.0f, LayerMask.GetMask("Collision"));
                Debug.DrawRay(this.transform.position, direction, Color.green);
                if (mainRay.collider != null)
                {
                    if (mainRay.collider.tag == "Player")
                    {
                        Chase(speed, direction);
                    }
                }
                else
                {
                    Debug.Log(null);
                }
            }
        }
    }
    private void Chase(float speed, Vector2 direction)
    {
        direction.Normalize();
        bodyAnimator.SetBool("Run", true);
        rg2D.AddForce(direction * speed);
    }
    private void Flip(Vector2 direction)
    {
        if (direction.x > 0 && !isFacingRight)
        {
            isFacingRight = !isFacingRight;
            body.transform.localScale = new Vector3(5, 5, 5);
        }
        else if (direction.x < 0 && isFacingRight)
        {
            isFacingRight = !isFacingRight;
            body.transform.localScale = new Vector3(-5, 5, 5);
        }
    }
    private void FixedUpdate()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Va cham");
        if (collision.tag == "Player")
        {
            Debug.Log("Tru Mau");
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            playerHealth.TakeDamage(damage);
            slashHitBox.enabled = false;
        }
    }
    IEnumerator DelayCoroutine()
    {
        yield return new WaitForSeconds(delayTime);
        allowAttack = true;
    }
}
