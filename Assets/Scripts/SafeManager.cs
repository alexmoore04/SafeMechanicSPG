using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeManager : MonoBehaviour
{
    // the safes must correlate with the doors in the array order
    [SerializeField] private GameObject[] doors; // array of the safe doors
    [SerializeField] private GameObject[] safe; // array of safes

    public string objectName; // the name of the door that was interacted with

    public PlayerInteractCheck interactCheck; 


    private void Start()
    {
        interactCheck = (PlayerInteractCheck)GameObject.Find("Player").GetComponent("PlayerInteractCheck");
    }

    public void OnEPressed()
    {
        //Finds what safe/door was interacted with
        objectName = interactCheck.objectName;
        for(int i = 0; i < doors.Length; i++)
        {
            if (objectName == doors[i].name)
            {
                char type = safe[i].name[safe[i].name.Length - 1];
                //calls the safe script
                safe[i].GetComponent<Safe>().OnCall(objectName, type);
                break;
            }
        }
    }
}
