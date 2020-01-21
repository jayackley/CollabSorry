﻿using UnityEngine;

[CreateAssetMenu(menuName = "Item")]

public class Item : ScriptableObject 
{
    public string objectName;
    public Sprite sprite;
    public int quantity;
    public bool stackable;
    public bool sword;
    public enum ItemType{
        COIN,
        HEALTH,
        SWORD
    }
    public ItemType itemType;
}