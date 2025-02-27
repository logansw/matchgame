using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableDetector : MonoBehaviour
{
    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mouseWorldPos, Vector3.back);
            Collider2D collider = hit.collider;
            if (collider != null)
            {
                IInteractable interactable = collider.gameObject.GetComponent<IInteractable>();
            
                if (interactable != null)
                {
                    interactable.OnInputDown();
                }
            }
        }
    }
}
