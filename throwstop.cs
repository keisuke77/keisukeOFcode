using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class throwstop : MonoBehaviour
{
    Rigidbody rb;
public bool parent;
    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody>();
    }
void OnCollisionStay(Collision collisionInfo)
{if (!collisionInfo.gameObject.CompareTag("Player"))
{if (parent)
     {
         transform.parent=collisionInfo.transform;
     }
     rb.velocity=Vector3.zero;
     rb.isKinematic=true;
     
}
   
}
    // Update is called once per frame
    void Update()
    {
        
    }
}
