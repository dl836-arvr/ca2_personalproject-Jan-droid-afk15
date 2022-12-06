using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameMenuManager : MonoBehaviour
{
    //Tracks Player head to spawn menu
    public Transform head;

    //Sets min distance from head to 2
    public float spawnDistance = 2;

    //refrences GameMenu gameobject
    public GameObject menu;

    public InputActionProperty showButton;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // If show button is pressed, menu activates.
    void Update()
    {
        if (showButton.action.WasPressedThisFrame())
        {
            menu.SetActive(!menu.activeSelf);

            //Takes position of player's head and moves menu horizontally where a player is looking at
            menu.transform.position = head.position + new Vector3(head.forward.x, 0, head.forward.z).normalized * spawnDistance;

        }
        //Ensures that menu is always looking at player's head
        menu.transform.LookAt(new Vector3(head.position.x, menu.transform.position.y, head.position.z));

        //Flips Menu to always face player
        menu.transform.forward *= -1;
    
    }
}
