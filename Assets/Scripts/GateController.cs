using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum GateType { MULTIPLY, ADDITION };

public class GateController : MonoBehaviour
{
    // Configurable values
    public int gateValue = 2;
    public GateType gateType;
    public TextMeshPro text;

    // References to other components
    private PlayerSpawning playerSpawning;
    private GateHolderController gateController;

    // Flag to control triggering
    private bool isPlayerTouchGate = true; 

    void Start()
    {
        playerSpawning = GameObject.Find("Player Spawner").GetComponent<PlayerSpawning>();
        gateController = transform.parent.gameObject.GetComponent<GateHolderController>();
        UpdateText();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && isPlayerTouchGate)
        {
            isPlayerTouchGate = false; // Prevent multiple triggers
            gateController.CloseGate();
            playerSpawning.Spawn(gateValue, gateType);
            Destroy(gameObject); // Remove the gate after it's triggered
        }
    }

    private void UpdateText()
    {
        switch (gateType)
        {
            case GateType.MULTIPLY:
                text.text = "X" + gateValue.ToString();
                break;
            case GateType.ADDITION:
                text.text = "+" + gateValue.ToString();
                break;
            default: 
                // Handle any unexpected GateType values if needed
                break; 
        }
    }
}