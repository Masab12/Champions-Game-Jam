using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewMovement : MonoBehaviour
{
    [SerializeField] float playerSpeed = 5f;
    [SerializeField] float maxPosition = 4.10f; 

    private bool isDragging; // Flag to indicate if dragging
    private Vector2 dragStartPos; // Store the initial drag position

    void Update()
    {
        HandleTouchInput();
    }

    void HandleTouchInput()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                isDragging = true;
                dragStartPos = touch.position; 
            }
            else if (touch.phase == TouchPhase.Moved && isDragging) 
            {
                DragMovement(touch);
            }
            else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
            {
                isDragging = false;
            }
        }
    }

    void DragMovement(Touch touch)
    {
        float touchDeltaX = (touch.position.x - dragStartPos.x) / Screen.width;

        // Adjust sensitivity if desired
        touchDeltaX *= 2f; 

        float movementOnX = transform.position.x + touchDeltaX * playerSpeed * Time.deltaTime;
        movementOnX = Mathf.Clamp(movementOnX, -maxPosition, maxPosition);

        Vector3 playerMovement = new Vector3(movementOnX, transform.position.y, transform.position.z);
        transform.position = playerMovement;
    }
}