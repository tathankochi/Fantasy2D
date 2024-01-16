using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private GameObject slotsHolder;
    [SerializeField] private GameObject equipmentsHolder;
    //[SerializeField] private ItemClass itemToAdd;
    //Test
    //[SerializeField] private ItemClass itemToAdd2;
    //[SerializeField] public int itemAddQuantity2;
    //End Test
    //[SerializeField] public int itemAddQuantity;
    //[SerializeField] private ItemClass itemToRemove;
    //[SerializeField] public int itemRemoveQuantity;
    //Cac SlotClass trong items nay khong co thu tu tuy nhien moi SlotClass deu da co 1 gObjItem nen ko can quan tam thu tu cua cai nay
    public List<SlotClass> items= new List<SlotClass>();
    public SlotClass weapon;

    //La cac gameObject slot dung de chua cac gObj item
    public List<GameObject> itemSlots = new List<GameObject>();
    public List<GameObject> equipmentSlots = new List<GameObject>();

    [SerializeField] private GameObject itemPrefab;

    //Dung de doi weapon
    [SerializeField] private Attack weaponPlayer;

    [SerializeField] private Canvas canvasInventory;

    [SerializeField] private GameObject swordSprite;
    [SerializeField] private GameObject swordSpriteFake;

    //Tat ca prefabs items
    [SerializeField] private List<ItemClass> itemClassList;
    void Start()
    {
        //slots=new GameObject[slotsHolder.transform.childCount];
        for (int i = 0; i < slotsHolder.transform.childCount; i++)
        {
            try
            {
                itemSlots.Add(slotsHolder.transform.GetChild(i).gameObject);
            }
            catch
            {
                //
            }
        }
        for (int i = 0; i < 4; ++i)
        {
            equipmentSlots.Add(equipmentsHolder.transform.GetChild(i).gameObject);
        }
        //AddItem(itemToAdd,itemAddQuantity);
        //AddItem(itemToAdd2, itemAddQuantity2);
        //RemoveItem(itemToRemove,itemRemoveQuantity);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            canvasInventory.enabled = !canvasInventory.enabled;
            GameObject.Find("Information").GetComponent<TextMeshProUGUI>().text= GameObject.Find("Player").GetComponent<LevelPlayer>().GetInformation();
        }
    }
    //ReFresh gameobject item, dung de lien ket gObjItem voi du lieu thuc te tu item do (Lan dau la co itemIcon con may lan sau chu yeu la quantity)
    private void ReFreshUI(SlotClass itemInList)
    {
        try
        {
            //itemInList.gObjItem.transform.GetChild(0).GetComponent<Image>().enabled = true;
            itemInList.gObjItem.transform.GetChild(0).GetComponent<Image>().sprite = itemInList.GetItem().itemIcon;
            itemInList.gObjItem.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = itemInList.GetQuantity() + "";
        }
        catch
        {
            Debug.Log("InventoryManager catch");
            itemInList.gObjItem.transform.GetChild(0).GetComponent<Image>().enabled = false;
            itemInList.gObjItem.transform.GetChild(0).GetComponent<Image>().sprite = null;
            itemInList.gObjItem.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "";
        }
    }
    public void AddItem(ItemClass item, int quantity)
    {
        SlotClass slotClass = ContainsItem(item);
        if (slotClass != null)
        {
            slotClass.AddQuantity(quantity);

            ReFreshUI(slotClass);
        }
        else
        {
            SlotClass slotNew = new SlotClass(item, quantity);
            items.Add(slotNew);
            foreach (GameObject gObjSlot in itemSlots)
            {
                if (gObjSlot.transform.childCount == 0)
                {
                    GameObject gObjItem = Instantiate(itemPrefab, gObjSlot.transform);
                    slotNew.gObjItem = gObjItem;
                    ReFreshUI(slotNew);
                    return;
                }
            }
        }
    }
    public void RemoveItem(ItemClass item, int quantity)
    {
        SlotClass slotClass = ContainsItem(item);
        if (slotClass != null)
        {
            if (slotClass.GetQuantity() - quantity > 1)
            {
                slotClass.SubQuantity(quantity);

                ReFreshUI(slotClass);
            }
            else if (slotClass.GetQuantity() - quantity == 0)
            {
                Destroy(slotClass.gObjItem);
                items.Remove(slotClass);
            }
        }
        else
        {
            Debug.Log("Khong tim thay item");
            return;
        }
    }
    private SlotClass ContainsItem(ItemClass item)
    {
        foreach (SlotClass slot in items)
        {
            if (slot.GetItem() == item)
            {
                return slot;
            }
        }
        return null;
    }
    //private int IndexContainsItem(ItemClass item)
    //{
    //    for (int i=0;i<items.Count;++i)
    //    {
    //        if (items[i].GetItem() == item) {
    //            return i; 
    //        }
    //    }
    //    return -1;
    //}
    public void UpdateEquipment(GameObject gobjItem, int i)
    {
        Debug.Log("updateEq");
        if (i == 0)
        {
            int index = FindFromGObj(gobjItem);
            weaponPlayer.damageSword = items[index].GetItem().GetSword().bonusAtk;
            swordSprite.GetComponent<SpriteRenderer>().sprite= items[index].GetItem().itemIcon;
            swordSpriteFake.SetActive(true);
            swordSpriteFake.GetComponent<Image>().sprite = items[index].GetItem().itemIcon;
            weapon = items[index];
        }
    }
    public bool IsSword(GameObject gobjItem)
    {
        int index=FindFromGObj(gobjItem);
        if (index == -1)
        {
            Debug.Log("Khong tim thay trong IsSword");
            return false;
        }
        return items[index].GetItem().GetSword() != null;
    }
    public int FindFromGObj(GameObject gobjItem)
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].gObjItem == gobjItem)
            {
                return i;
            }
        }
        return -1;
    }
    public int GetQuantity(ItemClass item)
    {
        for (int i=0;i < items.Count; i++)
        {
            if (items[i].GetItem().itemName==item.itemName)
            {
                return items[i].GetQuantity();
            }
        }
        return 0;
    }
    public void SetInventoryData(List<string> items, List<int> itemsQuantity, List<string> equipments)
    {
        for (int i=0;i < items.Count;++i)
        {
            AddItem(FindItemClass(items[i]), itemsQuantity[i]);
        }
        try
        {
            AddItem(FindItemClass(equipments[0]), 1);
            GameObject weapon = ContainsItem(FindItemClass(equipments[0])).gObjItem;
            UpdateEquipment(weapon, 0);
            weapon.transform.SetParent(equipmentSlots[0].transform);
        }
        catch
        {
            Debug.Log("Khong co vu khi (IventoryManager)");
        }
    }
    private ItemClass FindItemClass(string name)
    {
        for (int i=0;i<itemClassList.Count;++i)
        {
            if (itemClassList[i].itemName==name) { return itemClassList[i]; }
        }
        Debug.Log("Khong tim thay itemmclass");
        return null;
    }
}
