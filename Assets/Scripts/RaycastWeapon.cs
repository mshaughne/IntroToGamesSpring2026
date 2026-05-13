using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastWeapon : MonoBehaviour
{
    [SerializeField] LayerMask layers;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Debug.DrawRay(transform.position, transform.up * 100f, Color.cyan, 1f);
            RaycastHit hit;
            if(Physics.Raycast(transform.position, transform.up, out hit, 100f, layers))
            {
                Debug.Log("Hit");

                if(hit.transform.gameObject.CompareTag("Enemy"))
                {
                    Debug.Log("Enemy hit");

                    hit.transform.gameObject.GetComponent<EnemyHealthTest>().TakeDamage(1f);
                }
            }
        }
    }
}
