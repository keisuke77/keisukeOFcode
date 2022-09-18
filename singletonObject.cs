using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class singletonObject : MonoBehaviour
{public static List<string> obj;
   void Awake()
   {
    if (obj.Contains(gameObject.name))
    {
        Destroy(this.gameObject);
    }else
    {
        obj.Add(gameObject.name);
        DontDestroyOnLoad(this.gameObject);
    }
   } // Start is called before the first frame update
    /// <summary>
    /// This function is called when the behaviour becomes disabled or inactive.
    /// </summary>
    private void OnDisable()
    {
        this.enabled=true;
    }
}
