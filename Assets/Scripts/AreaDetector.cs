using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaDetector : MonoBehaviour
{
    [field: SerializeField]
    public bool playerInArea { get; private set; }
    public Transform player { get; private set; }
    [SerializeField] private string detectionTag = "Player";


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(detectionTag))
        {
            Debug.Log("Collision");
            playerInArea = true;
            player = collision.gameObject.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        playerInArea = false;
        player = null;
    }

}
