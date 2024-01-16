using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Sword", menuName = "Item/Sword")]
public class SwordClass : ItemClass
{
    [Header("Sword")]
    public int bonusAtk;
    public override ItemClass GetItem() { return this; }
    public override ToolClass GetTool() { return null; }
    public override MiscClass GetMisc() { return null; }
    public override SwordClass GetSword() { return this; }
    public override ConsumableClass GetConsumable() { return null; }
}
