using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float lifetime = 1f;

    // Update is called once per frame
    void Update()
    {
        if(lifetime > 0f)
        {
            lifetime -= Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player")) // or "Enemy"
        {
            // do damage etc.
        }

        //Instantiate(particlePrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
