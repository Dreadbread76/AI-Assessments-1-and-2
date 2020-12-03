using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class ItemData
{
    public static  Item CreateItem(int itemID)
    {
        string _name = "";
        string _description = "";
        int _value = 0;
        int _amount = 0;
        
        string _icon = "";
        string _mesh = "";
        ItemType _type = ItemType.Apparel;
        int _heal = 0;
        int _damage = 0;
        int _armour = 0;
        switch (itemID)
        {
            #region Food 0-99
            case 0:
                _name = "Apple";
                _description = "Steve Job's son";
                _value = 1;
                _amount = 1;
                _icon = "Food/Apple";
                _mesh = "Food/Apple";
                _type = ItemType.Food;
                _heal = 10;
                break;
            case 1:
                _name = "Meat";
                _description = "Ve-gone";
                _value = 10;
                _amount = 1;
                _icon = "Food/Meat";
                _mesh = "Food/Meat";
                _type = ItemType.Food;
                _heal = 25;
                break;
            #endregion
            #region Weapon 100-199
            case 100:
                _name = "Axe";
                _description = "I'll shave it for later";
                _value = 150;
                _amount = 1;
                _icon = "Weapon/Axe";
                _mesh = "Weapon/Axe";
                _type = ItemType.Weapon;
                _damage = 50;
                break;
            case 101:
                _name = "Bow";
                _description = "I used to be an adventurer like you";
                _value = 150;
                _amount = 1;
                _icon = "Weapon/Bow";
                _mesh = "Weapon/Bow";
                _type = ItemType.Weapon;
                _damage = 15;
                break;
            case 102:
                _name = "Sword";
                _description = "Stick em with the pointy end";
                _value = 150;
                _amount = 1;
                _icon = "Weapon/Sword";
                _mesh = "Weapon/Sword";
                _type = ItemType.Weapon;
                _damage = 30;
                break;
            #endregion
            #region Apparel 200-299
            case 200:
                _name = "Armor";
                _description = "Tis but a scratch";
                _value = 200;
                _amount = 1;
                _icon = "Apparel/Armour/Armor";
                _mesh = "Apparel/Armour/Armor";
                _type = ItemType.Apparel;
                _armour = 4;
                break;
            case 201:
                _name = "Boots";
                _description = "Pumped up kicks";
                _value = 200;
                _amount = 1;
                _icon = "Apparel/Armour/Boots";
                _mesh = "Apparel/Armour/Boots";
                _type = ItemType.Apparel;
                _armour = 1;
                break;
            case 202:
                _name = "Bracers";
                _description = "Armbands";
                _value = 200;
                _amount = 1;
                _icon = "Apparel/Armour/Bracers";
                _mesh = "Apparel/Armour/Bracers";
                _type = ItemType.Apparel;
                _armour = 1;
                break;
            case 203:
                _name = "Helmet";
                _description = "Nice hat";
                _value = 200;
                _amount = 1;
                _icon = "Apparel/Armour/Helmet";
                _mesh = "Apparel/Armour/Helmet";
                _type = ItemType.Apparel;
                _armour = 2;
                break;
            case 204:
                _name = "Pauldron";
                _description = "Shoulder the burden";
                _value = 200;
                _amount = 1;
                _icon = "Apparel/Armour/Pauldron";
                _mesh = "Apparel/Armour/Pauldron";
                _type = ItemType.Apparel;
                _armour = 2;
                break;
            case 205:
                _name = "Shield";
                _description = "Don't Hurt Me";
                _value = 200;
                _amount = 1;
                _icon = "Apparel/Armour/Shield";
                _mesh = "Apparel/Armour/Shield";
                _type = ItemType.Apparel;
                _armour = 5;
                break;
            #endregion
            #region Crafting 300-399
            case 300:
                _name = "Gem";
                _description = "Don't Drop in Lava";
                _value = 300;
                _amount = 1;
                _icon = "Crafting/Gem";
                _mesh = "Crafting/Gem";
                _type = ItemType.Crafting;
                break;
            case 301:
                _name = "Ingot";
                _description = "Iron";
                _value = 30;
                _amount = 1;
                _icon = "Crafting/Ingot";
                _mesh = "Crafting/Ingot";
                _type = ItemType.Crafting;
                break;

            #endregion
            #region Ingredients 400-499

            #endregion
            #region Potions 500-599
            case 500:
                _name = "Health Potion";
                _description = "I need healing";
                _value = 70;
                _amount = 1;
                _icon = "Potions/HealthPotion";
                _mesh = "Potions/HealthPotion";
                _type = ItemType.Potions;
                _heal = 50;
                break;
            case 501:
                _name = "Mana Potion";
                _description = "Refreshing";
                _value = 50;
                _amount = 1;
                _icon = "Potions/ManaPotion";
                _mesh = "Potions/ManaPotion";
                _type = ItemType.Potions;
                _heal = 20;
                break;
            #endregion
            #region Scrolls 600-699
            case 600:
                _name = "Book";
                _description = "The new Harry Potter";
                _value = 100;
                _amount = 1;
                _icon = "Scrolls/Book";
                _mesh = "Scrolls/Book";
                _type = ItemType.Scrolls;
                _heal = 10;
                break;
            case 601:
                _name = "Scroll";
                _description = "It says right here u ded";
                _value = 100;
                _amount = 1;
                _icon = "Scrolls/Scroll";
                _mesh = "Scrolls/Scroll";
                _type = ItemType.Scrolls;
                _heal = 30;
                break;
            #endregion
            #region Quest 700-799
            #endregion


            default:
                break;
        }
        Item temp = new Item
        {
            ID = itemID,
            Name = _name,
            ItemDescription = _description,
            Value = _value,
            Amount = _amount,
            Type = _type,
           
            Icon = Resources.Load("Icon/" + _icon) as Texture2D,
            Mesh = Resources.Load("Mesh/" + _mesh) as GameObject,
            Heal = _heal,
            Damage = _damage,
            Armour = _armour,
        };
        return temp;

    }
}
