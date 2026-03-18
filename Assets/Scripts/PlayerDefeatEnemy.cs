using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDefeatEnemy : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // if player jumps on enemy
        if (other.gameObject.CompareTag("Player"))
        {
            // destroy enemy
            Destroy(transform.parent.gameObject);
        }
    }
}
