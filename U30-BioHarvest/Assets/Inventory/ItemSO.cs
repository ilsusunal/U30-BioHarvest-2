using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "ScriptableObjects/Item")]
public class ItemSO : ScriptableObject
{
    public Sprite itemSprite;
    public ItemNames itemName;
    public int goalCount;

    public enum ItemNames
    {
        Seed,
        Seed2,
        Seed3,
        SeaShell,
        Pearl,
        LifeCrytal
    }
}
