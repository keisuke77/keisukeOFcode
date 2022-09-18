using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item : effect
{
   
public float speedup=0.1f;
    public float effectpower;
    public float effectduration=5;
    public GameObject particle;
    public float time;
   public Itemkind Itemkind;
   public bool instanceexiqitem;
   public bool rotate;
   public float waittime=1.5f;
    public animation textanim;
    public int getscore=10;
    public int money=0;
    bool once;
    public bool jump;
    // Start is called before the first frame update
    void Start()
    {
        if (rotate)
        {
            keikei.rotate(gameObject);
        }
           }




public void execute(GameObject other){


   
if (!once)
{
    
once=true;

    
    if (speedup!=0)
    {
        other.GetComponent<UnityChanControlScriptWithRgidBody>().movespeed+=speedup;
     
       
    }
    if (money!=0)
    {
        other.GetComponent<datamanage>().addmoney(money);
    }
    
        if (particle != null)
        {
            Instantiate(particle,transform.position,Quaternion.identity);
       
        }
if (Itemkind!=null)
{ Itemkind.add(other);
    if (instanceexiqitem)
    {
other.pclass().itemmanage.itemhavingcheck(Itemkind).itemuses();
    }
     
   
}
        if (jump)
        {
            jumpgive(other.gameObject,effectpower,effectduration);
        }
         
         if (textanim!=null)
         { textanim.anim.Play();
         } 
    }
     Destroy(gameObject);
       
    }

void OnTriggerEnter(Collider obj)
{
    if (time>waittime)
    {
        if (obj.CompareTag("Player"))
    {execute(obj.gameObject);
        }
    }
    
          }



    // Update is called once per frame
    void Update()
    {
        time+=Time.deltaTime;
    }
}
