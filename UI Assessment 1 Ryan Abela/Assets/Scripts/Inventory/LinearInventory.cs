using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LinearInventory : MonoBehaviour
{
    public Stats.BaseStats player;
    public static List<Item> inv = new List<Item>();
    public static List<Button> invButton = new List<Button>();
    public Item selectedItem;
    public static bool showInv;
    public GUIStyle style;
    public GUISkin skin;

    public Vector2 scr;
    public Vector2 scrollPos;
    public string sortType = "";
    public string[] enumTypesForItems;
    public static int money;

    #region Item UI Variables
   [SerializeField] public Image itemImage;
   [SerializeField] public Text itemName;
   [SerializeField] public Text itemValue;
   [SerializeField] public Text itemDescription;
   [SerializeField] private ItemType type;
   [SerializeField] public Text itemHealDmgArm;
    public Text itemUsage;
    #endregion
    public Button itemUseButton;
    public Button inventoryContent;
    public GameObject inventoryScreen;
    public GameObject objectInfo;
    public GameObject inventoryTab;
    public bool showInfo;
    public RectTransform content;
    

    public Transform dropLocation;
    [System.Serializable]
    public struct Equipment
    {
        public string slotName;
        public Transform equipLocation;
        public GameObject currentItem;
        public Item item;
    };
    public Equipment[] equipmentSlots;


    public static Chest currentChest;
    public static Shop currentShop;
    // Start is called before the first frame update

    void Start()
    {
        
        player = this.gameObject.GetComponent<Stats.BaseStats>();
        enumTypesForItems = new string[] { "All", "Food", "Weapon", "Apparel", "Crafting", "Ingredients", "Potions", "Scrolls", "Quest" };
        AddItem(ItemData.CreateItem(0));
        AddItem(ItemData.CreateItem(1));
        AddItem(ItemData.CreateItem(300));
        objectInfo.SetActive(false);
        inventoryScreen.SetActive(false);
        showInv = false;
       // Display();
    }

    // Update is called once per frame
    void Update()
    {
        
        scr.x = Screen.width / 16;
        scr.y = Screen.height / 9;
       
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (currentShop == null)
            {
               showInv = !showInv;

                if (showInv)
                {
                    Time.timeScale = 0;
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                    inventoryScreen.SetActive(true);
                    return;
                }
                else
                {
                    Time.timeScale = 1;
                    Cursor.lockState = CursorLockMode.Locked;
                    Cursor.visible = false;
                    //currentChest.showChestInv = false;
                    currentChest = null;
                    inventoryScreen.SetActive(false);
                    return;
                }
            }
            

        }
            
     
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            
            showInv = !showInv;
            
            if (showInv)
            {
                
                Time.timeScale = 0;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                inventoryScreen.SetActive(true);

                
                /*int CountOfItemtypes = Enum.GetNames(typeof(ItemType)).Length;
                {
                    for (int i = 0 < CountOfItemtypes; i++)
                    {
                        Instantiate(Button, 0,0,0);
                    }
                }
                */
                return;
            }
            else
            {
                Time.timeScale = 1;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                currentChest.showChestInv = false;
                currentChest = null;
                inventoryScreen.SetActive(false);
                return;
            }
        }
        if (selectedItem != null)
        {
            if (selectedItem.Amount < 1 || selectedItem == null)
            {
                objectInfo.SetActive(false);
            }
            else
            {
                objectInfo.SetActive(true);
            }
        }
       
#if UNITY_EDITOR
        if (Input.GetKey(KeyCode.I))
        {
            AddItem(ItemData.CreateItem(Random.Range(0, 1)));
            AddItem(ItemData.CreateItem(Random.Range(200, 202)));

        }
        if (Input.GetKey(KeyCode.N))
        {
            sortType = "Food";
        }
        if (Input.GetKey(KeyCode.M))
        {
            sortType = "All";
        }
        
#endif
    }
    public void Display(string sortingType)
    {
        sortType = sortingType;
        //SORTING
        if (sortType == "All"  || sortType == "")
        {

            if (inv.Count <= 34)
            {
               
                
            }
            else
            {
                scrollPos = GUI.BeginScrollView(new Rect(0, 0.25f * scr.y, 3.75f, 8.5f * scr.y), scrollPos, new Rect(0, 0, 0, 8.5f * scr.y + (inv.Count - 34)), false, true);
                  
                  
                 

                ItemType type = (ItemType)System.Enum.Parse(typeof(ItemType), sortType);
                int a = 0;
                int s = 0;
                for (int i = 0; i< inv.Count; i++)
                {
                    if(inv[i].Type == type)
                    {
                        a++;
                    }
                }
                if (a <= 34)
                {
                    for (int i = 0; i < inv.Count; i++)
                    {
                        if (inv[i].Type == type)
                        {
                            if (GUI.Button(new Rect(0.5f * scr.x, 0.25f * scr.y + s * (0.25f * scr.y), 3f * scr.x, 0.25f * scr.y),inv[i].Name))
                            {
                                selectedItem = inv[i];
                            }
                            s++;
                        }
                    }

                }
                else
                {
                    scrollPos = GUI.BeginScrollView(new Rect(0, 0.25f * scr.y, 3.75f, 8.5f * scr.y), scrollPos, new Rect(0, 0, 0, 8.5f * scr.y + (inv.Count - 34)), false, true);
                    for (int i = 0; i < inv.Count; i++)
                    {
                        if (inv[i].Type == type)
                        {
                            if (GUI.Button(new Rect(0.5f * scr.x,  s * (0.25f * scr.y), 3f * scr.x, 0.25f * scr.y), inv[i].Name))
                            {
                                selectedItem = inv[i];
                            }
                            s++;
                        }
                    }

                    GUI.EndScrollView();
                }
            }
        }
        
    }
   
    #region Chest
    void UseItem()
    {
        
        if (currentChest != null)
        {
           
                for (int i = 0; i < equipmentSlots.Length; i++)
                {
                    if (equipmentSlots[i].currentItem != null && selectedItem.Name == equipmentSlots[i].currentItem.name)
                    {
                        Destroy(equipmentSlots[i].currentItem);
                    }
                }
            currentChest.chestInv.Add(selectedItem);
            if (selectedItem.Amount > 1)
            {
                selectedItem.Amount--;
            }
            else
            {
                inv.Remove(selectedItem);
                selectedItem = null;
                return;
            }
        }
        GUI.skin = null;


        switch (selectedItem.Type)
        {

            #region Food
            case ItemType.Food:
                GUI.Box(new Rect(8.25f * scr.x, 4f * scr.y, 3 * scr.x, 3 * scr.y), selectedItem.ItemDescription + "\nValue: " + selectedItem.Value + "\nAmount: " + selectedItem.Amount);

                objectInfo.SetActive(true);
                itemImage.sprite = Sprite.Create(selectedItem.Icon, new Rect(0, 0, selectedItem.Icon.width, selectedItem.Icon.height), Vector2.zero);
                itemName.text = selectedItem.Name + " x" + selectedItem.Amount;
                itemValue.text = "Value: " + selectedItem.Value.ToString();
                itemDescription.text = selectedItem.ItemDescription;
                itemHealDmgArm.text = "Heal: " + selectedItem.Heal.ToString();
                itemUsage.text = "Eat";


                if (player.characterStatus[0].currentValue < player.characterStatus[0].maxValue)
                {
                    if (GUI.Button(new Rect(10.25f * scr.x, 6.75f * scr.y, scr.x, 0.25f * scr.y), "Eat"))
                    {
                        selectedItem.Amount--;
                        player.characterStatus[0].currentValue += selectedItem.Heal;
                       
                        if(selectedItem.Amount <= 0)
                        {
                            inv.Remove(selectedItem);
                            selectedItem = null;
                            break;
                        }
                    }
                }


                break;
            #endregion
            #region Weaponry
            case ItemType.Weapon:
                GUI.Box(new Rect(8.25f * scr.x, 4f * scr.y, 3 * scr.x, 3 * scr.y), selectedItem.ItemDescription + "\nValue: " + selectedItem.Value + "\nAmount: " + selectedItem.Amount);

                objectInfo.SetActive(true);
                itemImage.sprite = Sprite.Create(selectedItem.Icon, new Rect(0, 0, selectedItem.Icon.width, selectedItem.Icon.height), Vector2.zero);
                itemName.text = selectedItem.Name + " x" + selectedItem.Amount;
                itemValue.text = "Value: " + selectedItem.Value.ToString();
                itemDescription.text = selectedItem.ItemDescription;
                itemHealDmgArm.text = "Damage: " + selectedItem.Damage.ToString();
                itemUsage.text = "Equip";

                if (equipmentSlots[2].currentItem == null || selectedItem.Name != equipmentSlots[2].currentItem.name)
                {
                    if (GUI.Button(new Rect(10.25f * scr.x, 6.75f * scr.y, scr.x, 0.25f * scr.y), "Equip"))
                    {
                        if (equipmentSlots[2].currentItem != null)
                        {
                            Destroy(equipmentSlots[2].currentItem);
                        }
                        GameObject curItem = Instantiate(selectedItem.Mesh, equipmentSlots[2].equipLocation);
                        equipmentSlots[2].currentItem = curItem;
                        curItem.name = selectedItem.Name;

                    }
                }
                else
                {
                    Destroy(equipmentSlots[2].currentItem);
                    equipmentSlots[2].item = null;
                    
                }
                break;
            #endregion
            #region Apparel
            case ItemType.Apparel:
                GUI.Box(new Rect(8.25f * scr.x, 4f * scr.y, 3 * scr.x, 3 * scr.y), selectedItem.ItemDescription + "\nValue: " + selectedItem.Value + "\nAmount: " + selectedItem.Amount);

                objectInfo.SetActive(true);
                itemImage.sprite = Sprite.Create(selectedItem.Icon, new Rect(0, 0, selectedItem.Icon.width, selectedItem.Icon.height), Vector2.zero);
                itemName.text = selectedItem.Name + " x" + selectedItem.Amount;
                itemValue.text = "Value: " + selectedItem.Value.ToString();
                itemDescription.text = selectedItem.ItemDescription;
                itemHealDmgArm.text = "Armour: " + selectedItem.Armour.ToString();
                itemUsage.text = "Equip";

                if (equipmentSlots[3].currentItem == null || selectedItem.Name != equipmentSlots[3].currentItem.name)
                {
                    if (GUI.Button(new Rect(10.25f * scr.x, 6.75f * scr.y, scr.x, 0.25f * scr.y), "Equip"))
                    {
                        if (equipmentSlots[3].currentItem != null)
                        {
                            Destroy(equipmentSlots[3].currentItem);
                        }
                        GameObject curItem = Instantiate(selectedItem.Mesh, equipmentSlots[3].equipLocation);
                        equipmentSlots[3].currentItem = curItem;
                        curItem.name = selectedItem.Name;

                    }
                }
                else
                {
                    if (GUI.Button(new Rect(10.25f * scr.x, 6.75f * scr.y, scr.x, 0.25f * scr.y), "Equip"))
                    {
                        Destroy(equipmentSlots[3].currentItem);
                    }
                }
                break;
            #endregion
            #region Crafting
            case ItemType.Crafting:
                GUI.Box(new Rect(10.25f * scr.x, 4f * scr.y, 3 * scr.x, 3 * scr.y), selectedItem.ItemDescription + "\nValue: " + selectedItem.Value + "\nAmount: " + selectedItem.Amount);

                objectInfo.SetActive(true);
                itemImage.sprite = Sprite.Create(selectedItem.Icon, new Rect(0, 0, selectedItem.Icon.width, selectedItem.Icon.height), Vector2.zero);
                itemName.text = selectedItem.Name + " x" + selectedItem.Amount;
                itemValue.text = "Value: " + selectedItem.Value.ToString();
                itemDescription.text = selectedItem.ItemDescription;
                itemHealDmgArm.text = "";
                itemUsage.text = "Use";
                if (GUI.Button(new Rect(6.25f * scr.x, 6.75f * scr.y, scr.x, 0.25f * scr.y), "Use"))
                {

                }
                break;
            #endregion
            #region Ingredients
            case ItemType.Ingredients:
                GUI.Box(new Rect(4.25f * scr.x, 4f * scr.y, 3 * scr.x, 3 * scr.y), selectedItem.ItemDescription + "\nValue: " + selectedItem.Value + "\nAmount: " + selectedItem.Amount);

                objectInfo.SetActive(true);
                itemImage.sprite = Sprite.Create(selectedItem.Icon, new Rect(0, 0, selectedItem.Icon.width, selectedItem.Icon.height), Vector2.zero);
                itemName.text = selectedItem.Name + " x" + selectedItem.Amount;
                itemValue.text = "Value: " + selectedItem.Value.ToString();
                itemDescription.text = selectedItem.ItemDescription;
                itemHealDmgArm.text = "";
                itemUsage.text = "Use";

                if (GUI.Button(new Rect(6.25f * scr.x, 6.75f * scr.y, scr.x, 0.25f * scr.y), "Use"))
                {

                }
                break;
            #endregion
            #region Potions

            case ItemType.Potions:
                GUI.Box(new Rect(4.25f * scr.x, 4f * scr.y, 3 * scr.x, 3 * scr.y), selectedItem.ItemDescription + "\nValue: " + selectedItem.Value + "\nAmount: " + selectedItem.Amount);

                objectInfo.SetActive(true);
                itemImage.sprite = Sprite.Create(selectedItem.Icon, new Rect(0, 0, selectedItem.Icon.width, selectedItem.Icon.height), Vector2.zero);
                itemName.text = selectedItem.Name + " x" + selectedItem.Amount;
                itemValue.text = "Value: " + selectedItem.Value.ToString();
                itemDescription.text = selectedItem.ItemDescription;
                itemHealDmgArm.text = "Heal: " + selectedItem.Heal.ToString();
                itemUsage.text = "Drink";

                if (GUI.Button(new Rect(6.25f * scr.x, 6.75f * scr.y, scr.x, 0.25f * scr.y), "Drink"))
                {

                }
                break;

            #endregion
            #region Scrolls
            case ItemType.Scrolls:
                GUI.Box(new Rect(4.25f * scr.x, 4f * scr.y, 3 * scr.x, 3 * scr.y), selectedItem.ItemDescription + "\nValue: " + selectedItem.Value + "\nAmount: " + selectedItem.Amount);

                objectInfo.SetActive(true);
                itemImage.sprite = Sprite.Create(selectedItem.Icon, new Rect(0, 0, selectedItem.Icon.width, selectedItem.Icon.height), Vector2.zero);
                itemName.text = selectedItem.Name + " x" + selectedItem.Amount;
                itemValue.text = "Value: " + selectedItem.Value.ToString();
                itemDescription.text = selectedItem.ItemDescription;
                itemHealDmgArm.text = "Heal: " + selectedItem.Heal.ToString();
                itemUsage.text = "Use";
                break;
                
            #endregion
            #region Quest
            case ItemType.Quest:
                break;
            #endregion
            #region Money
            case ItemType.Money:
                break;
            #endregion
            default:
                break;
        }
        //DISCARD BUTTON
        if (GUI.Button(new Rect(8.25f * scr.x, 4f * scr.y, 3f * scr.x, 1f * scr.y), "Discard"))
        {
            for (int i = 0; i < equipmentSlots.Length; i++)
            {
                if (equipmentSlots[i].currentItem != null && selectedItem.Name == equipmentSlots[i].currentItem.name)
                {
                    Destroy(equipmentSlots[i].currentItem);
                }
            }
            GameObject droppedItem = Instantiate(selectedItem.Mesh, dropLocation.position, Quaternion.identity);
            droppedItem.name = selectedItem.Name;
            droppedItem.AddComponent<Rigidbody>().useGravity = true;
            droppedItem.GetComponent<ItemHandler>().enabled = true;
            if (selectedItem.Amount > 1)
            {
                selectedItem.Amount--;
            }
            else
            {
                inv.Remove(selectedItem);
                selectedItem = null;
                return;
            }
        }

    }
    #endregion
    public void Discard()
    {
        selectedItem.Amount--;
        
        if (selectedItem.Mesh != null)
        {
            Instantiate(selectedItem.Mesh, null).transform.position = dropLocation.transform.position ;
        }
        

        if (selectedItem.Amount <= 0)
        {
            inv.Remove(selectedItem);

        }

    }
    public void ShowProperties(Item itemSelected)
    {
        selectedItem = itemSelected;
        Debug.Log("Inventory Clicked");
        objectInfo.SetActive(true);
        if(selectedItem != null)
        {
            if (currentChest != null)
            {
                Text invItemName = inventoryContent.GetComponentInChildren<Text>();
                

                for (int i = 0; i < equipmentSlots.Length; i++)
                {
                    /*
                    if (equipmentSlots[i].currentItem != null && selectedItem.Name == equipmentSlots[i].currentItem.name)
                    {
                        Destroy(equipmentSlots[i].currentItem);
                    }
                    */
                }
                currentChest.chestInv.Add(selectedItem);
                if (selectedItem.Amount > 1)
                {
                    selectedItem.Amount--;
                }
                else
                {
                    inv.Remove(selectedItem);
                    selectedItem = null;
                    return;
                }
            }
            switch (selectedItem.Type)
            {

                #region Food
                case ItemType.Food:

                    Debug.Log("Food");
                    objectInfo.SetActive(true);
                    itemImage.sprite = Sprite.Create(selectedItem.Icon, new Rect(0, 0, selectedItem.Icon.width, selectedItem.Icon.height), Vector2.zero);
                    itemName.text = selectedItem.Name + " x" + selectedItem.Amount;
                    itemValue.text = "Value: " + selectedItem.Value.ToString();
                    itemDescription.text = selectedItem.ItemDescription;
                    itemHealDmgArm.text = "Heal: " + selectedItem.Heal.ToString();
                    itemUsage.text = "Eat";



                    if (player.characterStatus[0].currentValue < player.characterStatus[0].maxValue)
                    {
                        itemUseButton.onClick.AddListener(Eat);
                    }


                    break;
                #endregion
                #region Weaponry
                case ItemType.Weapon:
                    GUI.Box(new Rect(8.25f * scr.x, 4f * scr.y, 3 * scr.x, 3 * scr.y), selectedItem.ItemDescription + "\nValue: " + selectedItem.Value + "\nAmount: " + selectedItem.Amount);

                    objectInfo.SetActive(true);
                    itemImage.sprite = Sprite.Create(selectedItem.Icon, new Rect(0, 0, selectedItem.Icon.width, selectedItem.Icon.height), Vector2.zero);
                    itemName.text = selectedItem.Name + " x" + selectedItem.Amount;
                    itemValue.text = "Value: " + selectedItem.Value.ToString();
                    itemDescription.text = selectedItem.ItemDescription;
                    itemHealDmgArm.text = "Damage: " + selectedItem.Damage.ToString();
                    itemUsage.text = "Equip";

                    if (equipmentSlots[2].currentItem == null || selectedItem.Name != equipmentSlots[2].currentItem.name)
                    {
                        if (GUI.Button(new Rect(10.25f * scr.x, 6.75f * scr.y, scr.x, 0.25f * scr.y), "Equip"))
                        {
                            if (equipmentSlots[2].currentItem != null)
                            {
                                Destroy(equipmentSlots[2].currentItem);
                            }
                            GameObject curItem = Instantiate(selectedItem.Mesh, equipmentSlots[2].equipLocation);
                            equipmentSlots[2].currentItem = curItem;
                            curItem.name = selectedItem.Name;

                        }
                    }
                    else
                    {
                        if (GUI.Button(new Rect(8.25f * scr.x, 6.75f * scr.y, scr.x, 0.25f * scr.y), "Equip"))
                        {
                            Destroy(equipmentSlots[3].currentItem);
                        }
                    }
                    break;
                #endregion
                #region Apparel
                case ItemType.Apparel:
                    

                    objectInfo.SetActive(true);
                    itemImage.sprite = Sprite.Create(selectedItem.Icon, new Rect(0, 0, selectedItem.Icon.width, selectedItem.Icon.height), Vector2.zero);
                    itemName.text = selectedItem.Name + " x" + selectedItem.Amount;
                    itemValue.text = "Value: " + selectedItem.Value.ToString();
                    itemDescription.text = selectedItem.ItemDescription;
                    itemHealDmgArm.text = "Armour: " + selectedItem.Armour.ToString();
                    itemUsage.text = "Equip";

                    if (equipmentSlots[3].currentItem == null || selectedItem.Name != equipmentSlots[3].currentItem.name)
                    {
                        if (GUI.Button(new Rect(10.25f * scr.x, 6.75f * scr.y, scr.x, 0.25f * scr.y), "Equip"))
                        {
                            if (equipmentSlots[3].currentItem != null)
                            {
                                Destroy(equipmentSlots[3].currentItem);
                            }
                            GameObject curItem = Instantiate(selectedItem.Mesh, equipmentSlots[3].equipLocation);
                            equipmentSlots[3].currentItem = curItem;
                            curItem.name = selectedItem.Name;

                        }
                    }
                    else
                    {
                        if (GUI.Button(new Rect(10.25f * scr.x, 6.75f * scr.y, scr.x, 0.25f * scr.y), "Equip"))
                        {
                            Destroy(equipmentSlots[3].currentItem);
                        }
                    }
                    break;
                #endregion
                #region Crafting
                case ItemType.Crafting:


                    objectInfo.SetActive(true);
                    itemImage.sprite = Sprite.Create(selectedItem.Icon, new Rect(0, 0, selectedItem.Icon.width, selectedItem.Icon.height), Vector2.zero);
                    itemName.text = selectedItem.Name + " x" + selectedItem.Amount;
                    itemValue.text = "Value: " + selectedItem.Value.ToString();
                    itemDescription.text = selectedItem.ItemDescription;
                    itemHealDmgArm.text = "";
                    itemUsage.text = "Use";
                    break;

                #endregion
                #region Ingredients
                case ItemType.Ingredients:


                    objectInfo.SetActive(true);
                    itemImage.sprite = Sprite.Create(selectedItem.Icon, new Rect(0, 0, selectedItem.Icon.width, selectedItem.Icon.height), Vector2.zero);
                    itemName.text = selectedItem.Name + " x" + selectedItem.Amount;
                    itemValue.text = "Value: " + selectedItem.Value.ToString();
                    itemDescription.text = selectedItem.ItemDescription;
                    itemHealDmgArm.text = "";
                    itemUsage.text = "Use";
                    break;
                #endregion
                #region Potions

                case ItemType.Potions:


                    objectInfo.SetActive(true);
                    itemImage.sprite = Sprite.Create(selectedItem.Icon, new Rect(0, 0, selectedItem.Icon.width, selectedItem.Icon.height), Vector2.zero);
                    itemName.text = selectedItem.Name + " x" + selectedItem.Amount;
                    itemValue.text = "Value: " + selectedItem.Value.ToString();
                    itemDescription.text = selectedItem.ItemDescription;
                    itemHealDmgArm.text = "Heal: " + selectedItem.Heal.ToString();
                    itemUsage.text = "Drink";
                    break;


                #endregion
                #region Scrolls
                case ItemType.Scrolls:


                    objectInfo.SetActive(true);
                    itemImage.sprite = Sprite.Create(selectedItem.Icon, new Rect(0, 0, selectedItem.Icon.width, selectedItem.Icon.height), Vector2.zero);
                    itemName.text = selectedItem.Name + " x" + selectedItem.Amount;
                    itemValue.text = "Value: " + selectedItem.Value.ToString();
                    itemDescription.text = selectedItem.ItemDescription;
                    itemHealDmgArm.text = "Heal: " + selectedItem.Heal.ToString();
                    itemUsage.text = "Use";
                    break;

                #endregion
                #region Quest
                case ItemType.Quest:
                    break;
                #endregion
                #region Money
                case ItemType.Money:
                    break;
                #endregion
                default:
                    break;
            }
        }
        
        
    }
    public void Eat() 
    {
        player.characterStatus[0].currentValue += selectedItem.Heal;
        if (selectedItem.Amount > 1)
        {
            selectedItem.Amount--;
        }
        else
        {
            selectedItem.Amount--;
            inv.Remove(selectedItem);
            selectedItem = null;
            return;
        }
    }


    public void SortInventory(string sortingType)
    {
        sortType = sortingType;
    }
    public void AddItem(Item item)
    {
        //FINDS ITEM IN GAME
        Item foundItem = inv.Find(invItem => invItem.Name == invItem.Name);

        if(inv.Exists(x => x.Name == item.Name))
        {
            foundItem.Amount++;
        }
        else
        {
            //ADDS ITEM
            Item newItem = new Item(item, 1);
            inv.Add(newItem);

            Text invItemName = inventoryContent.GetComponentInChildren<Text>();
            invItemName.text = newItem.Name;

            //ADDS BUTTON FOR ITEM
            Button displayButton = Instantiate(inventoryContent, content);
            invButton.Add(inventoryContent);
            displayButton.onClick.AddListener(delegate { ShowProperties(newItem); });

        }
    }
    public Item FindItem(string itemName)
    {
        Item foundItem = inv.Find(findItem => findItem.Name == itemName);

        return foundItem;
    }
}
