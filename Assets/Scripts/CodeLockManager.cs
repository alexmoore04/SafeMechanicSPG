using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CodeLockManager : MonoBehaviour
{
    private string entered; //player entered code
    public bool unlocked = false; // checks whether the door is unlocked or not
    private string pinCode; //the actual code
    private string current; //player inputed code
    private string objectName; //safe door name

    [SerializeField] private TextMeshProUGUI textDisplay;

    private GameObject safeObject; //the safe game object
    private Safe safe; 

    private void Update()
    {
        //closes UI when escape is pressed
        if (gameObject.activeSelf)
        {
            //could be changed using variable keys in the menu
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                End();
                current = "";
            }
        }
    }

    private void TextUpdate()
    {
        //updates the text to the current code
        textDisplay.SetText(current);
    }

    public void OnCode(string code, string name, GameObject _safe)
    {
        //collects the code, name and the object which are being used
        pinCode = code;
        objectName = name;
        safeObject = _safe;
        safe = (Safe)safeObject.GetComponent("Safe");

        TextUpdate();
    }

    private void End()
    {
        //closes the UI and re-locks the mouse
        gameObject.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void OnKeyPress(string key)
    {
        // adds a character onto the players entered code (can be any character/symbol for endless codes)
        if (current == null)
            current = key;
        else
            current = current.Insert(current.Length, key);
        TextUpdate();
    }

    public void OnClear()
    {
        //clears the current entered code
        current = "";
        TextUpdate();
    }

    public void OnEnter()
    {
        //enters a code to be checked against the actual code
        entered = current;
        // if it is correct closes the UI and calls the safe script's OnCall function
        if (entered == pinCode)
        {
            unlocked = true;
            End();
            safe.OnCall(objectName, '2');
        }
    }
}
