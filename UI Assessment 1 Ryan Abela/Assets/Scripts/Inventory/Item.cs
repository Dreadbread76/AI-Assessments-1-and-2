using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum ItemType
{
    Food,
    Weapon,
    Apparel,
    Crafting,
    Ingredients,
    Potions,
    Scrolls,
    Quest,
    Money
}


public class Item
{
    #region Private Variables
    private int _id;
    private string _itemName;
    private string _itemDescription;
    private int _value;
    private int _amount;

    private Texture2D _icon;
    private GameObject _mesh;
    private ItemType _type;
    private int _heal;
    private int _damage;
    private int _armour;
    #endregion
    #region Public Properties
    public int ID
    {
        get { return _id; }
        set { _id = value; }
    }
    public string Name
    {
        get { return _itemName; }
        set { _itemName = value; }
    }
    public string ItemDescription
    {
        get { return _itemDescription; }
        set { _itemDescription = value; }
    }
    public int Value
    {
        get { return _value; }
        set { _value = value; }
    }
    public int Amount
    {
        get { return _amount; }
        set { _amount = value; }
    }

    public Texture2D Icon
    {
        get { return _icon; }
        set { _icon = value; }
    }
    public GameObject Mesh
    {
        get { return _mesh; }
        set { _mesh = value; }
    }
    public ItemType Type
    {
        get { return _type; }
        set { _type = value; }
    }
    public int Heal
    {
        get { return _heal; }
        set { _heal = value; }
    }
    public int Damage
    {
        get { return _damage; }
        set { _damage = value; }
    }
    public int Armour
    {
        get { return _armour; }
        set { _armour = value; }
    }
    #endregion
    public Item()
    {

    }
    public Item(Item copyItem, int copyAmount)
    {
        _itemName = copyItem.Name;
        _itemDescription = copyItem.ItemDescription;
        _value = copyItem.Value;
        _amount = copyAmount;
        _icon = copyItem.Icon;
        _mesh = copyItem.Mesh;
        _type = copyItem.Type;
        _heal = copyItem.Heal;
        _damage = copyItem.Damage;
        _armour = copyItem.Armour;




    }
        


}


