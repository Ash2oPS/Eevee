using UnityEngine;

public abstract class Accessory : Item
{
    public int ID;
    public AccessoryRating Rating;
    public string AccessoryType = "";
    public Sprite Sprite;
    public string AccessoryName;
    public string Description;
    public bool IsColorable;
}

public enum AccessoryRating
{
    commun, peuCommun, rare, legendaireOMG
}