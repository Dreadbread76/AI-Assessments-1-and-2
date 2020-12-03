using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public List<Item> chestInv = new List<Item>();
    public Item selectedItem;
    public bool showChestInv;
    public Vector2 scr;
    private void Start()
    {
        chestInv.Add(ItemData.CreateItem(Random.Range(0, 2)));
        chestInv.Add(ItemData.CreateItem(Random.Range(100, 102)));
    }
    private void OnGUI()
    {
        scr.x = Screen.width / 16;
        scr.y = Screen.height / 9;

        if (showChestInv)
        {
            //DISPLAY OF THE CHEST ITEMS
            for (int i = 0; i < chestInv.Count; i++)
            {
                if(GUI.Button(new Rect(12.5f *scr.x, 0.25f * scr.y + i, 3* scr.x, 0.25f * scr.y), chestInv[i].Name))
                {
                    selectedItem = chestInv[i];
                }
            }
            if (selectedItem != null)
            {
                GUI.Box(new Rect(4f * scr.x, 0.25f * scr.y, 3.5f * scr.x, 7f * scr.y), "");
               // GUI.Box(new Rect(4.25f * scr.x, 0.5f * scr.y, 3f * scr.x, 3f * scr.y), selectedItem.Icon);
                GUI.Box(new Rect(4.55f * scr.x, 3.5f * scr.y, 2.5f * scr.x, 0.5f * scr.y), selectedItem.Name);
                GUI.Box(new Rect(4.25f * scr.x, 4f * scr.y, 3f * scr.x, 3f * scr.y),selectedItem.ItemDescription +  "\nValue: ");
                if (GUI.Button(new Rect(10.5f *  scr.x, 6.75f * scr.y, scr.x,0.25f * scr.y), "Take Item"))
                {
                    LinearInventory.inv.Add(ItemData.CreateItem(selectedItem.ID));
                    chestInv.Remove(selectedItem);
                    selectedItem = null;
                    return;
                }
            }

            //DISPLAYS ITEMS IN PLAYER INVENTORY
        }
    }

}
