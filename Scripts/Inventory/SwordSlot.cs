using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class SwordSlot : MonoBehaviour, IDropHandler
{
    [SerializeField] private InventoryManager inventoryManager;
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("dropEq");
        if (transform.childCount == 0)
        {
            int type = transform.GetSiblingIndex();
            GameObject dropped = eventData.pointerDrag;
            if (type == 0 && inventoryManager.IsSword(dropped))
            {
                DraggableItem draggableItem = dropped.GetComponent<DraggableItem>();
                draggableItem.parentAfterDrag = transform;
                Debug.Log("nameSl: " + draggableItem.parentAfterDrag.name);
                inventoryManager.UpdateEquipment(dropped, type);
                GameObject.Find("Information").GetComponent<TextMeshProUGUI>().text = GameObject.Find("Player").GetComponent<LevelPlayer>().GetInformation();
            }
        }
    }
}
