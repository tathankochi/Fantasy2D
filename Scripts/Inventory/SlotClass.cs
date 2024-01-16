using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SlotClass
{
    [SerializeField]
    private ItemClass item;
    [SerializeField]
    private int quantity = 0;

    //test
    public GameObject gObjItem;
    //endtest

    public SlotClass()
    {
        item = null;
        quantity = 0;
    }
    public SlotClass(ItemClass item, int quantity)
    {
        this.item = item;
        this.quantity = quantity;
    }
    public ItemClass GetItem()
    {
        return this.item;
    }
    public int GetQuantity()
    {
        return this.quantity;
    }
    public void AddQuantity(int quantity)
    {
        this.quantity+= quantity;
    }
    public void SubQuantity(int quantity)
    {
        this.quantity -= quantity;
    }
}
