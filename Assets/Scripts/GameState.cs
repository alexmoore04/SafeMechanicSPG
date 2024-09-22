using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    [SerializeField] private string[] state; // list of states
    [SerializeField] private bool[] currentState; // completed stated

    // updates the state of the game when called
    public void StateUpdate(string stateName)
    {
        for(int i = 0; i < state.Length; i++)
        {
            if (state[i] == stateName)
            {
                currentState[i] = true;
                Debug.Log(state[i]);
                break;
            }
        }
    }
}
