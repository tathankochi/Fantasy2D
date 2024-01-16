using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Recipe
{
    public ItemClass item;
    public List<ItemClass> materials=new List<ItemClass>();
    public List<int> quantity=new List<int>();
    //public Recipe() { 
    //    quantity = 0;
    //}
    //public Recipe(ItemClass item, ItemClass materials, int quantity)
    //{
    //    this.item = item;
    //    this.quantity = quantity;
    //    this.materials = materials;
    //}
}
