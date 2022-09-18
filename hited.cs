using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hited : MonoBehaviour
{
    public HpBarCtrl hpvar;
    // Start is called before the first frame update
    void Start()
    {
        
    }
void OnCollisionEnter(Collision collisionInfo)
{
    if(collisionInfo.gameObject.tag=="enemy"){
hpvar._hp-=0.1f;

}
    
}
    // Update is called once per frame
    void Update()
    {
        
    }
}
