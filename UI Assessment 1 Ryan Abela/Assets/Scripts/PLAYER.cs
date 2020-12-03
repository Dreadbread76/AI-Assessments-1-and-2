using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[AddComponentMenu("Game Systems/RPG/Player/Movement")]
[RequireComponent(typeof(CharacterController))]

public class PLAYER : MonoBehaviour
{
    #region Variables
    public Stats.BaseStats baseStats;
    // Start is called before the first frame update

    [Header("Physics")]
    public CharacterController controller;
    public float gravity = -20f;

    [Header("Movement ")]
    public float speed = 5f;
    public float walkSpeed = 5f;
    public float jumpSpeed = 8f;
    public float sprintSpeed = 10f;
    public float crouchSpeed = 2f;
    public bool crouching;
    public bool walking;
    public Vector3 moveDirection;

    [System.Serializable]
    public struct KeybindInputs
    {
        public KeyCode Forward;
        public KeyCode Left;
        public KeyCode Right;
        public KeyCode Backward;
        public KeyCode Jump;
        public KeyCode Sprint;
        public KeyCode Crouch;
        public KeyCode Interact;
        public KeyCode Inventory;
    }
    public KeybindInputs keybindInput;

    #endregion
    #region Start
    void Start()
    {
        keybindInput.Forward = KeybindManager.keys["Forward"];
        keybindInput.Left = KeybindManager.keys["Left"];
        keybindInput.Right = KeybindManager.keys["Right"];
        keybindInput.Backward = KeybindManager.keys["Backward"];
        keybindInput.Jump = KeybindManager.keys["Jump"];
        keybindInput.Sprint = KeybindManager.keys["Sprint"];
        keybindInput.Crouch = KeybindManager.keys["Crouch"];

        controller = this.gameObject.AddComponent<CharacterController>();
        
        
    }
    #endregion
    #region Update Function


    void Update()
    {
        if (Input.GetKey(keybindInput.Forward))
        {
            moveDirection.z = 1;
        }
        if (Input.GetKey(keybindInput.Backward))
        {
            moveDirection.z = -1;
        }
        if (Input.GetKey(keybindInput.Left))
        {
            moveDirection.x = 1;
        }
        if (Input.GetKey(keybindInput.Right))
        {
            moveDirection.x = -1;
        }
        
/*
        float horizontal = 0;
        float vertical = 0;
        if (Input.GetKey(KeybindManager.keys["Forward"]))
        {
            vertical++;
        }
        if (Input.GetKey(KeybindManager.keys["Left"]))
        {
            horizontal--;
        }
        if (Input.GetKey(KeybindManager.keys["Backward"]))
        {
            vertical--;
        }
        if (Input.GetKey(KeybindManager.keys["Right"]))
        {
            horizontal++;
        }
        */
        //MOVE WHEN GROUNDED
        if (controller.isGrounded)
        {
            moveDirection = transform.TransformDirection(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")));
            moveDirection *= speed;
            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
            }
        }

        moveDirection.y += gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);

        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W))
        {
            speed = sprintSpeed;
        }
        else if (Input.GetKeyDown(keybindInput.Crouch))
        {
            crouching = !crouching;
        }
        else
        {
            speed = walkSpeed;
        }
        if (crouching)
        {
            speed = crouchSpeed;
        }
       
    }
#endregion
    void Interact()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray ray;

            RaycastHit hitInfo;
            ray = Camera.main.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));

            int layerMask = LayerMask.NameToLayer("Interactable");

            if(Physics.Raycast(ray, out hitInfo, 5f, layerMask))
            {
                #region NPC
                if (hitInfo.collider.TryGetComponent<NPC>(out NPC npc))
                {
                    npc.Interact();
                }
                #endregion
                #region Item
                if (hitInfo.collider.CompareTag("Item"))
                {
                    Debug.Log("Pick Up Item");
                    ItemHandler handler = hitInfo.transform.GetComponent<ItemHandler>();
                    if (handler != null)
                    {
                        baseStats.quest.goal.ItemCollected(handler.itemId);
                        handler.OnCollection();
                    }
                }
                #endregion
            }
      

        }
    }
    
}
