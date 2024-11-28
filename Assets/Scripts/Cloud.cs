using System;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 1.0f;

    private void Update()
    {
        // Move the cloud to the left
        transform.Translate(Vector3.left * (_moveSpeed * Time.deltaTime));
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // If the cloud hits the cloud barrier, reset it
        if (other.gameObject.CompareTag("CloudBarrier"))
        {
            ResetCloud();
        }
    }

    // If the cloud hits the player, reset it
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ResetCloud();
        }
    }
    
    // Set its position back to zero and hide it 
    private void ResetCloud()
    {
        gameObject.SetActive(false);
        transform.localPosition = Vector3.zero;
    }

}