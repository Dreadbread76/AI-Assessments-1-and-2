using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] public List<Item> shopInv = new List<Item>();
    public Item selectedItem;
    [SerializeField] public bool showShopInv;
    public Vector2 scr;
    public ApprovalDialogue dlg;

    private LinearInventory playerInventory;
    private void Start()
    {
       playerInventory = (LinearInventory) FindObjectOfType<LinearInventory>();
        shopInv.Add(ItemData.CreateItem(Random.Range(0, 2)));
        shopInv.Add(ItemData.CreateItem(Random.Range(100, 102)));
    }
    private void OnGUI()
    {
        scr.x = Screen.width / 16;
        scr.y = Screen.height / 9;

        if (showShopInv)
        {
            //DISPLAY OF THE CHEST ITEMS
            for (int i = 0; i < shopInv.Count; i++)
            {
                if (GUI.Button(new Rect(12.5f * scr.x, 0.25f * scr.y + i, 3 * scr.x, 0.25f * scr.y), shopInv[i].Name))
                {
                    selectedItem = shopInv[i];
                }
            }
            if (selectedItem != null)
            {
                GUI.Box(new Rect(4f * scr.x, 0.25f * scr.y, 3.5f * scr.x, 7f * scr.y), "");
               // GUI.Box(new Rect(4.25f * scr.x, 0.5f * scr.y, 3f * scr.x, 3f * scr.y), selectedItem.Icon);
                GUI.Box(new Rect(4.55f * scr.x, 3.5f * scr.y, 2.5f * scr.x, 0.5f * scr.y), selectedItem.Name);
                GUI.Box(new Rect(4.25f * scr.x, 4f * scr.y, 3f * scr.x, 3f * scr.y), selectedItem.ItemDescription + "\nValue: ");
                if(LinearInventory.money >= selectedItem.Value)
                {
                    if (GUI.Button(new Rect(10.5f * scr.x, 6.75f * scr.y, scr.x, 0.25f * scr.y), "Take Item"))
                    {
                        LinearInventory.money -= selectedItem.Value;
                        //ADD TO PLAYER
                        LinearInventory.inv.Add(ItemData.CreateItem(selectedItem.ID));
                        //REMOVE FROM SHOP
                        
                        selectedItem.Amount--;
                        if (selectedItem.Amount <= 0)
                        {
                            shopInv.Remove(selectedItem);
                            selectedItem = null;
                        }
                        
                        return;
                    }
                }
               
            }
            if (GUI.Button(new Rect(0.25f*scr.x,8.5f *scr.y, scr.x,0.5f *scr.y), "Exit Shop"))
            {
                showShopInv = false;
                LinearInventory.showInv = false;
                LinearInventory.currentShop = null;
                dlg.showDlg = true;
            }
            GUI.Box(new Rect(0.25f * scr.x, 8.5f * scr.y, scr.x, 0.5f * scr.y), "yes");
            {

            }
            //DISPLAYS ITEMS IN PLAYER INVENTORY
            
        }
        
    }
}
