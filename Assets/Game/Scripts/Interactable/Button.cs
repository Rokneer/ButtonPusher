using System;
using UnityEngine;

public class Button : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.CompareTag("Player") && collider.GetComponent<Interact>().InteractedThisFrame)
        {
            collider.GetComponent<Points>().AddPoint();
            Deactivate();
        }
    }

    private void Activate()
    {
        gameObject.SetActive(true);
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
