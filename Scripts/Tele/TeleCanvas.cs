using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleCanvas : MonoBehaviour
{
    [SerializeField]
    private Canvas teleCanvas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            teleCanvas.enabled = true;
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            teleCanvas.enabled = false;
        }
    }
}
