using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Item", menuName ="New Item")]
public abstract class ItemClass: ScriptableObject
{
    public string itemName;
    public Sprite itemIcon;
    public abstract ItemClass GetItem();
    public abstract ToolClass GetTool();
    public abstract MiscClass GetMisc();
    public abstract SwordClass GetSword();
    public abstract ConsumableClass GetConsumable();
}
