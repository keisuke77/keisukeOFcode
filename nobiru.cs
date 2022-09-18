using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nobiru : MonoBehaviour
{
    private Vector3 bairitu;
    // Start is called before the first frame update
    void Start()
    {
        bairitu = this.transform.localScale;
       
    }

    // Update is called once per frame
    void Update()
    {
        bairitu = bairitu *  1.1f;
         Debug.Log(bairitu);
       this.transform.localScale = bairitu;
    }
}
