using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class IventorySlot : MonoBehaviour, IDropHandler
{
    private InventoryManager inventoryManager;
    void Start()
    {
        inventoryManager = GameObject.Find("InventoryManager").GetComponent<InventoryManager>();
    }
        //Dc goi khi mot doi tuong dc tha vao doi tuong nay
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("Chill: "+transform.childCount);
        if (transform.childCount == 0)
        {
            Debug.Log("start drop");
            //Lay doi tuong dang dc keo
            GameObject dropped = eventData.pointerDrag;
            DraggableItem draggableItem = dropped.GetComponent<DraggableItem>();

            if (draggableItem.parentAfterDrag.tag=="SwordSlot")
            {
                Debug.Log("Da set");
                GameObject.Find("SwordAnimation").GetComponent<Attack>().damageSword = 0;
                GameObject.Find("SwordSprite").GetComponent<SpriteRenderer>().sprite = null;
                GameObject.Find("DemoSwordSprite").SetActive(false);
                inventoryManager.weapon = null;
                GameObject.Find("Information").GetComponent<TextMeshProUGUI>().text = GameObject.Find("Player").GetComponent<LevelPlayer>().GetInformation();
            }
            //Dat gObj cha cua gObjItem dc tha la doi tuong hien tai
            draggableItem.parentAfterDrag = transform;
        }
        if (transform.childCount == 1)
        {
            Debug.Log("Vo day");
            //Lay doi tuong dang dc keo
            GameObject dropped = eventData.pointerDrag;
            DraggableItem draggableItem = dropped.GetComponent<DraggableItem>();
            //Hoan doi gObj cha
            transform.GetChild(0).SetParent(draggableItem.parentAfterDrag);
            draggableItem.parentAfterDrag = transform;
        }
    }
}
