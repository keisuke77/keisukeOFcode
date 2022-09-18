using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Coffee.UIExtensions;

 
public class hpcore : MonoBehaviour{ 
    public Animator anim;
    public GameObject damageTextPrefab;
    public int maxHP = 100;
    public int HP = 100;
    public FlickerModel FlickerModel;
    public Text hptext;
    public Image hpimage; 
    public Transform hptrans;
    public bool nodamage;
    public GameObject HitParticle;
    public bool cooldown=false;
    public int cooldowntime=2;
    public GameObject healparticle;
    public Effekseer.EffekseerEffectAsset hiteffect;

    // Start is called before the first frame update

    public void Start()
    {
        SetUp();
    }
    public virtual void SetUp(){
    
    }



public virtual void hpheal(int amount){
HP=HP+amount;
warning.message("HPが"+amount.ToString()+"回復した！");
GameObject obj;
obj=Instantiate(healparticle, transform.position, Quaternion.identity)as GameObject;
obj.transform.parent=transform;
}


public　virtual void damage(int damage)
{

this.damage(damage,false,false);

}
public virtual void squencedamage(int damage)
{

this.damage(damage,false,true);

}



public virtual void damage(int damage,bool crit)
{

this.damage(damage,crit,false);

}
public　virtual void damage(int damage,bool crit,bool sequencehit)
{

   
}
public　virtual void damage(int damage,bool crit,bool sequencehit,bool anim)
{

   
}

public virtual void cooldownend(){
     cooldown=false;
}

public virtual void death(){

}
    // Update is called once per frame
    void Update()
    {
   HP = Mathf.Clamp(HP ,0,maxHP);
   if (hpimage!=null)
   {
       hpimage.fillAmount = (float)HP/maxHP;
   }if (hptext!=null)
   {
       hptext.text = maxHP+"/"+HP;
   }
    
if (HP==0)
{  
    death();
}
    }
}
