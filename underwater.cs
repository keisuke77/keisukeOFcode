using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.PostProcessing;

using UnityEngine.Events;

public class underwater : MonoBehaviour
{
    public bool iswater;
    public float time;
    public Camera camera;
    public UnityEvent enterevents;
    public UnityEvent exitevents;
bool once;
public PostProcessingProfile profile;
public PostProcessingProfile defaults;
public PostProcessingBehaviour PostProcessingBehaviour;
    // Start is called before the first frame update
    void Start()
    {
        
    }

void OnTriggerEnter(Collider other)
{if (other.gameObject.CompareTag("water"))
{
    iswater=true;
}
}
void OnTriggerExit(Collider other)
{if (other.gameObject.CompareTag("water"))
{
    iswater=false;
}
}

    // Update is called once per frame
    void Update()
    {
    
if (iswater)
{keikei.playeranim.SetBool("swimming",true);
 
if (!once)
{
    enterevents.Invoke();
    camera.transform.position=gameObject.transform.position;
 
       PostProcessingBehaviour.profile=profile;
   once=true;
}
}else
{
if (once)
{
    exitevents.Invoke();
   camera.transform.position=gameObject.transform.position;
   once=false;
}
    
   keikei.playeranim.SetBool("swimming",false);
  PostProcessingBehaviour.profile=defaults;
}



        
    }
}
