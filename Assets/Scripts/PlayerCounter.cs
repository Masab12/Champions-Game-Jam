using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PlayerCounter : MonoBehaviour
{
    public Text playerCountText; 
    private Vector3 initialScale; // Store initial scale
    private int currentPlayerCount;

    void Start()
    {
       if (playerCountText != null)
        initialScale = playerCountText.transform.localScale;
        currentPlayerCount=+1; 

    UpdatePlayerCount();
    }

    void Update()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
    int newPlayerCount = players.Length;

    if (currentPlayerCount != newPlayerCount) 
    {
        AnimateCountChange();
        currentPlayerCount = newPlayerCount;
    }
    }

    private void AnimateCountChange()
    {
        if (playerCountText != null)
        {
            // Tween the scale for animation effect
            playerCountText.transform.DOScale(initialScale * 1.2f, 0.3f)
                                     .OnComplete(() => playerCountText.transform.DOScale(initialScale, 0.2f)); 

            playerCountText.text = "" + currentPlayerCount.ToString(); 
        }
    }
    private void UpdatePlayerCount() // New function
{
    GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
    int newPlayerCount = players.Length;

    if (currentPlayerCount != newPlayerCount) 
    {
        AnimateCountChange();
        currentPlayerCount = newPlayerCount;
    }
}
}