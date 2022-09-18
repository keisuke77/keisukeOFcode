using UnityEngine;
using System.Collections;
public class scalefix : MonoBehaviour 
{
    public Vector3 defaultScale = Vector3.zero;

    void Start () 
    {
        defaultScale = transform.localScale;
    }
    
    void Update () 
    {
        
        transform.localScale = defaultScale;
    }
}