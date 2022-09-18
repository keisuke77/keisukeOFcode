using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trans : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
          
        foreach (Transform childTransform in this.gameObject.transform)
        {
            Debug.Log(childTransform.gameObject.name); // 子オブジェクト名を出力
            foreach (Transform grandChildTransform in childTransform)
            {
               foreach (Transform grandgrandChildTransform in grandChildTransform)
            {
               
                Debug.Log(grandgrandChildTransform.gameObject.name); // 孫オブジェクト名を出力
          GameObject.Destroy(grandgrandChildTransform.gameObject.GetComponent<Rigidbody>());
            }}
        
    }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
