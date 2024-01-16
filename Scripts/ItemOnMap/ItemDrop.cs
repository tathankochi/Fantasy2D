using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDrop : MonoBehaviour
{

    [SerializeField] private float verticalVelocity = 6.0f;     // Vận tốc dọc (nhảy và rớt)
    [SerializeField] private float gravity = -9f;      // Trọng lực ảnh hưởn đến tốc độ nảy và rơi của item
    [SerializeField] private float velocityReducer = 1.5f;   // Độ giảm vận tốc mà item nảy lên sau khi chạm đất
    [SerializeField] private float directionVelocityReducer = 1.5f;   // Độ giảm vận tốc hướng 
    [SerializeField] private int maxBounces = 3;        // Số lần nảy tối đa trước khi dừng lại

    private Vector3 direction;
    public bool collide = false;

    private float afterVelocity;
    private int bounceCount = 0;     // Đếm số lần loot đã nảy
    private bool isGround = true;  // Cờ để kiểm tra xem loot có đang rơi không

    private Transform t_parent;
    private Transform t_body;
    private Transform t_shadow;

    private SpriteRenderer sr_Caster;
    private SpriteRenderer sr_Body;
    private SpriteRenderer sr_Shadow;

    bool canCollect=false;
    [SerializeField] private ItemClass item;
    void Start()
    {
        CreateBody();
        CreateShadow();
        afterVelocity = verticalVelocity;

        //test
        //Drop();
    }

    void Update()
    {
        if (!isGround)
        {
            // Cập nhật vận tốc để mô tả trọng lực
            verticalVelocity += gravity * Time.deltaTime;
            if (!collide) 
            {
                //Di chuyen item theo huong
                t_parent.position += direction * Time.deltaTime;
            }

            // Kiểm tra va chạm với mặt đất
            if (t_body.position.y < t_shadow.position.y)
            {
                UnityEngine.Debug.Log("1");
                t_body.position = t_shadow.position;
                bounceCount++;
                if (bounceCount >= maxBounces)
                {
                    UnityEngine.Debug.Log("2");
                    // Dừng rơi và nảy nếu đạt tối đa số lần nảy
                    isGround = true;
                    verticalVelocity = 0;

                    //Bật va chạm
                    GetComponent<CircleCollider2D>().enabled = true;
                    canCollect = true;
                }
                else
                {
                    UnityEngine.Debug.Log("3");
                    direction /= directionVelocityReducer;
                    afterVelocity /= velocityReducer;
                    // Giam van toc
                    verticalVelocity = afterVelocity;
                }
            }

            // Di chuyển phần boby theo chiều dọc (lên và xuống tùy thuộc vào verticalVelocity)
            t_body.position += new Vector3(0, verticalVelocity, 0) * Time.deltaTime;
        }
    }

    void CreateBody()
    {
        t_parent = transform;
        t_body = new GameObject().transform;
        t_body.parent = t_parent;
        t_body.gameObject.name = "Body";
        t_body.localRotation = Quaternion.identity;
        t_body.localPosition = Vector3.zero;
        sr_Caster = GetComponent<SpriteRenderer>();
        sr_Body = t_body.gameObject.AddComponent<SpriteRenderer>();
        sr_Body.sortingLayerName = sr_Caster.sortingLayerName;
        sr_Body.sortingOrder = sr_Caster.sortingOrder;
        sr_Body.sprite = sr_Caster.sprite;
    }
    void CreateShadow()
    {
        t_parent = transform;
        t_shadow = new GameObject().transform;
        t_shadow.parent = t_parent;
        t_shadow.gameObject.name = "Shadow";
        t_shadow.localRotation = Quaternion.identity;
        t_shadow.localPosition = Vector3.zero;
        sr_Caster = GetComponent<SpriteRenderer>();
        sr_Shadow = t_shadow.gameObject.AddComponent<SpriteRenderer>();
        sr_Shadow.sortingLayerName = sr_Caster.sortingLayerName;
        sr_Shadow.sortingOrder = sr_Caster.sortingOrder - 1;
        sr_Shadow.color = Color.black;
        sr_Shadow.sprite = sr_Caster.sprite;
    }
    public void Drop()
    {
        isGround = false;
        direction = new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), 0);
        if (direction.x>0)
        {
            direction.x +=0.5f;
        }
        else
        {
            direction.x -= 0.5f;
        }
        if (direction.y > 0)
        {
            direction.y += 0.5f;
        }
        else
        {
            direction.y -= 0.5f;
        }

        GetComponent<CircleCollider2D>().enabled = false;
        GetComponent<SpriteRenderer>().enabled = false;
        Debug.Log("Drop");
        Debug.Log(direction.x+""+direction.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Va cham");
        if (canCollect)
        {
            if (collision.CompareTag("Player"))
            {
                Destroy(gameObject);
                GameObject.Find("InventoryManager").GetComponent<InventoryManager>().AddItem(item,1);
            }
        }
    }
}
