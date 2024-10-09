using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGate : MonoBehaviour
{
    public static SpawnGate Instance;

    // Specify the tag for the player
    public string playerTag = "Player"; // Make sure to set this tag in your player GameObject

    // Called before Start, ensures the instance is set before anything else
    void Awake() 
    {
        Instance = this;

        gameObject.SetActive(false); // Hide the gate initially
    }

    // Show the gate when this method is called
    public void ShowGate()
    {
        gameObject.SetActive(true);
    }
}
