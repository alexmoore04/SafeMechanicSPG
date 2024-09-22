using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public GameObject itemHeld; // current item

    public GameObject gObject; // item thats about to be picked up

    public PlayerInteractCheck interactCheck;

    private void Start()
    {
        interactCheck = (PlayerInteractCheck)GameObject.Find("Player").GetComponent("PlayerInteractCheck");
    }

    public void OnPickup()
    {
        // drops the current item held by player and picks up the new one
        gObject = interactCheck.gObject;
        if (itemHeld != null)
        {
            itemHeld.transform.position = transform.position; // sets the held items position to the players
            itemHeld.SetActive(true);
        }
        itemHeld = gObject; 
        itemHeld.SetActive(false);
    }

}
