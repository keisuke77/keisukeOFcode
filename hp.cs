using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Coffee.UIExtensions;

 
public class hp : hpcore{ 
    
    public flashscrean flashscrean;
    ShinyEffectForUGUI m_shiny;
    bool once;
     public itemdrop itemdrop;
    public float shakepower=1;
    playerdeath playerdeath;
    public Effekseer.EffekseerEffectAsset hiteffect;
   public bool damageshake;
    public int defence;
   		datamanage datamanage;
    // Start is called before the first frame update
    void Awake()
    {
        if (HP==0)
        {
         HP=maxHP;   
        }
    }     
  public void muteki(float time,System.Action ac){
nodamage=true;
keikei.delaycall(()=>{nodamage=false;ac();},time);
  }
  public void muteki(float time){
    muteki(time,null);
  }
    
    public override void SetUp(){
         if (damageTextPrefab==null)
       {
           damageTextPrefab=("DamagePopup").ResourcesLoad();
   
       } if (HP>maxHP)
       {
        maxHP=HP;
       }
        hpimage=gameObject.FindAllChild("hpimage")?.GetComponentIfNotNull<Image>();
       hptext=gameObject.FindAllChild("hptext")?.GetComponentIfNotNull<Text>();
    
 anim=GetComponent<Animator>();
         if (GetComponent<navchaise>()==null)
         {
             damageshake=true;
         }
datamanage=GetComponent<datamanage>();
          playerdeath=GetComponent<playerdeath>();
FlickerModel=GetComponent<FlickerModel>();
if (hpimage!=null)
{
    
m_shiny=hpimage.gameObject.GetComponent<ShinyEffectForUGUI>();
hptrans=hpimage.GetComponent<Transform>();
 
}  
    }
public override void hpheal(int amount){
HP=HP+amount;
warning.message("HPが"+amount.ToString()+"回復した！");
GameObject obj;
obj=Instantiate(healparticle, transform.position, Quaternion.identity)as GameObject;
obj.transform.parent=transform;
}

public void hpitemheal(){

    hpheal(itemuse.instance.Itemkind.GetPower());
    itemuse.instance.itemused();
}
         
      



public override void damage(int damage)
{

this.damage(damage,false,false);

}
public override void squencedamage(int damage)
{

this.damage(damage,false,true);

}
public override void damage(int damage,bool crit,bool sequencehit)
{

this.damage(damage,crit,sequencehit,true);
}
public override void damage(int damage,bool crit,bool sequencehit,bool damageanim)
{
    if (HP==0||anim.GetBool("dead")||nodamage)
    {
        return;
    }
    if (!cooldown||sequencehit)
    {damage-=defence;
     damage = Mathf.Clamp(damage,1,9999);
     HP = HP-damage; 

     if (hpimage!=null)
{
     keikei.uijump(hptrans,damage*6);}
     if (damageshake)
     {
ShakeableTransform.m_shakeable.InduceStress((float)damage*shakepower);
     }if (damage>1&&damageanim)
     {
anim.SetTrigger("damage");
anim.SetFloat("damagevalue",damage);
	
flashscrean?.damage();
           FlickerModel.damagecolor();
     } 

     
if (damageTextPrefab!=null)
{GameObject dmgText = Instantiate(damageTextPrefab, transform.position, Quaternion.identity);
            dmgText.GetComponent<DamagePopup>().SetUp(damage);
      
    if (crit)
      {
          dmgText.transform.localScale*=1.5f;
          dmgText.GetComponent<Text>().material.color=Color.red;
          keikei.Effspawns(0,gameObject.transform);
      }
}
//武器のコライダを切る
      GetComponent<triggeronoff>().trigerswich(false);
   
 cooldown=true;
Invoke("cooldownend",cooldowntime);
    
   if (HitParticle!=null)
     {
         Instantiate(HitParticle,transform.position,transform.rotation);
  
     } if (hiteffect!=null)
     {
        keikei.Effspawn(hiteffect,transform);
     }


     
    }
   
}

void cooldownend(){
     cooldown=false;
}

void OnCollisionEnter(Collision collisionInfo)
{
    if(collisionInfo.gameObject.tag=="enemy"){


}
    
}
public override void death(){

  Destroy(hpimage.gameObject);
       if (itemdrop!=null)
    {
        
    keikei.itemspawnexplosion(gameObject,itemdrop);

    
    }
      HP=maxHP;
      
   
    if (playerdeath!=null)
    {
        playerdeath.death();
 
    }
      Destroy(this);

}
   
}
