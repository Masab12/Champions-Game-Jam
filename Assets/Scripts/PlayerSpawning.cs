using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class PlayerSpawning : MonoBehaviour
{


    [SerializeField] GameObject copPrefab;
    public List<GameObject> copList;
    public bool isGameOver = false;
    

    [SerializeField] float spawnDelay = 0.001f; // Delay between spawns
    [SerializeField] float groundCheckDistance = 0.5f; // Distance for ground check

    private void Start() 
    { 
            

        
    }

    public void Spawn(int gateValue, GateType gateType)
    {
        if (gateType == GateType.ADDITION)
        {
            StartCoroutine(SpawnMultiple(gateValue));
        }
        else if (gateType == GateType.MULTIPLY)
        {
            StartCoroutine(SpawnMultiple(copList.Count * (gateValue - 1))); 
        }
    }

    IEnumerator SpawnMultiple(int count)
    {
        for (int i = 0; i < count; i++)
        {
            GameObject playerInstance = Instantiate(copPrefab, GetPlayerPosition(), Quaternion.identity, transform);
            CorrectGroundPosition(playerInstance); // Ensure player is on the ground
            copList.Add(playerInstance);
            yield return new WaitForSeconds(spawnDelay); 
        }
    }

    private Vector3 GetPlayerPosition()
    {
        int spawnIndex = copList.Count; // Get the index of the next player to be spawned
        int spawnSide = spawnIndex % 2 == 0 ? -1 : 1; // Alternate left and right
        int spawnRow = spawnIndex / 2; // Calculate row based on index

        float spacing = 2.5f; // Adjust for desired spacing

        Vector3 basePosition = transform.position + transform.forward * 1.0f;
        Vector3 offset = new Vector3(spawnSide * spacing * 0.5f, 0, spawnRow * spacing);
        return basePosition + offset;
    }

    private void CorrectGroundPosition(GameObject player)
    {
        RaycastHit hit;
    if (Physics.Raycast(player.transform.position + Vector3.up, Vector3.down, out hit, groundCheckDistance + 0.2f)) 
    {
        // Adjust slightly if the player is embedded in the ground
        if (hit.distance < 0.1f) 
        {
            player.transform.position += Vector3.up * (0.1f - hit.distance); 
        }
        else 
        {
            player.transform.position = hit.point + Vector3.up * 0.1f;  
        }
    }
    }

    public void RemoveFromList(GameObject cop)
    {
        copList.Remove(cop);
        Destroy(cop);
        
        CheckGameOver(); 

    }
    

    public int CopsNumber()
    {
        return copList.Count;
    }

    public GameObject getCop(int i)
    {
        return copList[i];
    }
    public void CheckGameOver()
    {
        if (copList.Count <= 0)
        {
            isGameOver = true;
            // Do Game Over stuff here (e.g., display UI, play sound)
            Debug.Log("Game Over!");
            AudioManager.Instance.PlayGameOverSound(); 
        }
    }
}