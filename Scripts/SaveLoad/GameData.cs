using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
[Serializable]
public class GameData
{
    public List<string> items;
    public List<int> itemsQuantity;
    public List<string> equipments;
    //public int curHP;
    //public int maxHP;
    public float positionX;
    public float positionY;
    public int level;
    public GameData(List<string> items, List<int> itemsQuantity, List<string> equipments, float positionX, float positionY, int level) { 
        this.items = items;
        this.itemsQuantity = itemsQuantity;
        this.equipments = equipments;
        this.positionX = positionX;
        this.positionY = positionY;
        this.level = level;
    }
}
