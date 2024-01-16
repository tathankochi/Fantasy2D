using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.UI;
using UnityEngine.TextCore.Text;

public class Move : MonoBehaviour
{
    public float speed =80.0f;
    [SerializeField]
    private Animator bodyAnimator;
    [SerializeField]
    private Rigidbody2D rg2D;

    //huong di chuyen
    private Vector2 direction;
    //co the di chuyen
    private bool allowMove;

    private GameObject body;

    //Singleton Pattern start
    public static Move Instance { get; private set; }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    //Singleton Pattern end

    // Start is called before the first frame update
    void Start()
    {
        body = GameObject.Find("Body");
    }

    // Update is called once per frame
    void Update()
    {
        allowMove = false;
        bodyAnimator.SetBool("isMove", false);
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (mousePosition.x < this.transform.position.x)
        {
            body.transform.localScale= new Vector3(-1,1,1);
        }
        else
        {
            body.transform.localScale = new Vector3(1, 1, 1);
        }

        float horizontalDirection = Input.GetAxisRaw("Horizontal");
        float verticalDirection = Input.GetAxisRaw("Vertical");
        direction = new Vector2(horizontalDirection, verticalDirection);
        direction = direction.normalized;
        if (direction != Vector2.zero)
        {
            allowMove = true;
            bodyAnimator.SetBool("isMove", true);
        }
    }
    private void FixedUpdate()
    {
        if (allowMove&& direction != Vector2.zero)
        {
            rg2D.AddForce(direction * speed);
        }
    }
}
