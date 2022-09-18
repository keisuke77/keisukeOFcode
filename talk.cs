using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class talk : MonoBehaviour
{Animator Animator;
Button button;
public string messagetext;
public UnityEvent kaiwaendevents;
    // Start is called before the first frame update
    void Start()
    {
        Animator=GetComponent<Animator>();
        button=keikei.communicationbutton;
    }

void OnCollisionEnter(Collision collisionInfo)
{if(collisionInfo.gameObject.transform.root.gameObject.tag=="Player"){
button.gameObject.SetActive(true);
     button.GetComponent<Button>().onClick.AddListener(() => {
         keikei.bothlook(gameObject,keikei.player);
         Animator.SetBool("communication",true);
         
         collisionInfo.gameObject.pclass().AutoRotateCamera.SetMessageAtractCamera(transform,messagetext,()=>{kaiwaendevents.Invoke();});

button.gameObject.SetActive(false);
return;
     });
  
}
    
}
void OnCollisionExit(Collision collisionInfo)
{if(collisionInfo.gameObject.transform.root.gameObject.tag=="Player"){
    
    button.GetComponent<Button>().onClick.RemoveAllListeners();
button.gameObject.SetActive(false);
    
}
    
}
    // Update is called once per frame
    void Update()
    {
        
    }
}
