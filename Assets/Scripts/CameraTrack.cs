using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrack : MonoBehaviour
{
    [SerializeField] Transform player;

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player);

        // this is all the same thing
        //gameObject.transform.LookAt(player);
        //this.gameObject.transform.LookAt(player);
    }
}
