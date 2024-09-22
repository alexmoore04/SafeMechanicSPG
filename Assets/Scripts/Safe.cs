using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Safe : MonoBehaviour
{

    [SerializeField] private UnityEvent _onOpen; //event to open the safe door

    [Header("Key Safe")] 
    [SerializeField] private string keyName = "x"; //the name of the key required to unlock safe
    [SerializeField] private string keyCode; // the name of the key the player is holding
    public Pickup pickup; 

    [Header("Code Safe")]
    [SerializeField] private GameObject ui; // the codelock UI
    [SerializeField] private string code; // the code needed to unlock the safe
    public CodeLockManager codeLockManager; 

    private void Start()
    {
        pickup = (Pickup)GameObject.Find("Player").GetComponent("Pickup");
        codeLockManager = (CodeLockManager)ui.GetComponent("CodeLockManager");
    }

    public void OnCall(string objectName, char type)
    {
        //determines what type of safe based on last character of safes name
        if (type == '1')
        {
            Debug.Log("called1");
            KeyLock(objectName);
        }
        else if (type == '2')
        {
            Debug.Log("called2");
            CodeLock(objectName);
        }
    }

    private void KeyLock(string objectName)
    {
        //checks if the player has the key
        if (pickup.itemHeld.name != null)
            keyName = pickup.itemHeld.name;
        if (keyName == keyCode)
        {
            //currently sets door inactive however could be used to play animation for the door and invoke audio
            _onOpen?.Invoke();
        }
    }

    private void CodeLock(string objectName)
    {
        if (codeLockManager.unlocked == true)
        {
            //currently sets door inactive however could be used to play animation for the door and invoke audio
            _onOpen?.Invoke();
            codeLockManager.unlocked = false;
        }
        else
        {
            //calls codelock manager to activate the codelock mechanic
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            ui.SetActive(true);
            codeLockManager.OnCode(code, objectName, gameObject);
        }
    }
}
