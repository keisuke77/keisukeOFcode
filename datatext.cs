using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class datatext : MonoBehaviour
{
    public data data;
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        text.text="所持金:"+data.money.ToString();
    }
}
