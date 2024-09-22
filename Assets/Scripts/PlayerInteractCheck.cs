using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInteractCheck : MonoBehaviour
{
    [SerializeField] private GameObject interactE; // UI for showing an object is interactable
    [SerializeField] private UnityEvent _onInteractKey; //event for interaction with key
    [SerializeField] private UnityEvent _onInteractSafe; //event for interaction with safe

    [SerializeField] private GameObject ui; // Codelock UI. could be made into an array to hold other types of UI

    public string objectName; // name of object interacted with by player
    public GameObject gObject; // game object interacted with by player
    private void Update()
    {
        //make innaccesable when code lock puzzle is active
        if (ui.activeSelf == false)
        {
            // send raycast out from player to check the tag of the object infront of it
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            //if the raycast hits a safe
            if (Physics.Raycast(ray, out hit, 4) && hit.collider.tag == "Safe")
            {
                objectName = hit.collider.name;
                interactE.gameObject.SetActive(true);
                //for accesability can use variable keycode to change Button used
                // to implement this with the text a variable text must be displayed changing the key based on the keybind
                if (Input.GetKeyDown(KeyCode.E))
                {
                    //calls the safe manager script
                    _onInteractSafe?.Invoke();
                }
            }
            // if the raycast hits a key
            else if (Physics.Raycast(ray, out hit, 4) && hit.collider.tag == "Key")
            {
                gObject = hit.collider.gameObject;
                interactE.gameObject.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    //calls the safe manager script
                    _onInteractKey?.Invoke();
                }
            }
            else
            {
                interactE.gameObject.SetActive(false);
            }
        }
        else
        {
            interactE.gameObject.SetActive(false);
        }
    }
}
