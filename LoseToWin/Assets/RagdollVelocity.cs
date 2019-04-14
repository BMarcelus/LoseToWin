using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollVelocity : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        foreach(Rigidbody rb in GetComponentsInChildren<Rigidbody>()) {
          rb.velocity = -transform.forward*10 + Vector3.down*2;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
