using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatePrevention : MonoBehaviour
{
    public string playerTag = "Player"; // Make sure to set this tag in your player GameObject

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // Method to detect collision with the player
    private void OnTriggerEnter(Collider other)
    {
        // Check if the collided object has the player tag
        if (other.CompareTag(playerTag))
        {
            // Prevent the player from passing through the gate
            Debug.Log("Player detected! Cannot pass through the gate.");
            // Optional: You can add additional logic here, such as stopping movement or showing a message
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Optional: Handle when the player leaves the gate area
        if (other.CompareTag(playerTag))
        {
            Debug.Log("Player exited the gate area.");
        }
    }
}
