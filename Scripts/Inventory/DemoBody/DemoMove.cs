using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoMove : MonoBehaviour
{
    [SerializeField]
    private Animator bodyAnimator;
    [SerializeField]
    private GameObject demoBody;
    private GameObject demoSwordRotation;
    // Start is called before the first frame update
    void Start()
    {
        demoBody = GameObject.Find("DemoBody");
        demoSwordRotation = GameObject.Find("DemoSwordRotation");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mousePosition - Camera.main.ScreenToWorldPoint(demoSwordRotation.transform.position);
        demoSwordRotation.transform.right = direction;
        Vector2 temp = Camera.main.ScreenToWorldPoint(transform.position);
        if (mousePosition.x < temp.x)
        {
            demoBody.transform.localScale = new Vector3(-1, 1, 1);
            demoSwordRotation.transform.localScale = new Vector3(1, -1, 1);
        }
        else
        {
            demoBody.transform.localScale = new Vector3(1, 1, 1);
            demoSwordRotation.transform.localScale = new Vector3(1, 1, 1);
        }
        bodyAnimator.SetBool("isMove", false);
        if (Input.GetKey(KeyCode.W))
        {
            Debug.Log("Hmmm");
            bodyAnimator.SetBool("isMove", true);
        }
        if (Input.GetKey(KeyCode.A))
        {
            bodyAnimator.SetBool("isMove", true);
        }
        if (Input.GetKey(KeyCode.S))
        {
            bodyAnimator.SetBool("isMove", true);
        }
        if (Input.GetKey(KeyCode.D))
        {
            bodyAnimator.SetBool("isMove", true);
        }
    }
}
