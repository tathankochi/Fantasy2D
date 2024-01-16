using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlTemp : MonoBehaviour
{
    private Vector3 direction;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalDirection = Input.GetAxisRaw("Horizontal");
        float verticalDirection = Input.GetAxisRaw("Vertical");
        direction = new Vector3(horizontalDirection, verticalDirection,0);
        direction = direction.normalized;
        transform.position += direction * Time.deltaTime;
    }
}
