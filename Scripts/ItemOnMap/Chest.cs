using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    [SerializeField] private List<GameObject> items = new List<GameObject>();
    [SerializeField] private List<int> quantity = new List<int>();
    private Animator animator;
    private bool near = false;

    //Xong map thi cho phep mo
    private bool allowOpen = false;
    //Truong da mo ch
    private bool opened = false;

    [SerializeField] private bool hide = false;
    // Start is called before the first frame update
    void Start()
    {
        animator= GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hide)
        {
            if (Input.GetKeyDown(KeyCode.O) && near && !opened)
            {
                Open();
                opened = true;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.O) && near && !opened && allowOpen)
            {
                Open();
                opened = true;
            }
        }
    }
    public void Open()
    {
        animator.SetBool("Open", true);
        for (int i = 0;i < items.Count; i++)
        {
            StartCoroutine(DropMultipleTimes(items[i], quantity[i], 0.5f));
            //for (int j = 0; j < quantity[i]; j++)
            //{
            //    Instantiate(items[i], transform.position, Quaternion.identity).GetComponent<ItemDrop>().Drop();
            //}
        }
    }
    private void Drop(GameObject go)
    {
        Instantiate(go, transform.position, Quaternion.identity).GetComponent<ItemDrop>().Drop();
    }
    IEnumerator DropMultipleTimes(GameObject go, int times, float delay)
    {
        for (int i = 0; i < times; i++)
        {
            Drop(go);
            yield return new WaitForSeconds(delay);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        near = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        near = false;
    }
    public void SetAllowOpen(bool trueOrFalse)
    {
        allowOpen = trueOrFalse;
    }
}
