using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public interface IDamagable
{
    void damage(int damage);
    void damage(int damage,bool crit);
}

[RequireComponent(typeof(FlickerModel))]
[RequireComponent(typeof(Animator))]
public class enemyhp : MonoBehaviour,IDamagable
{
  
    // Start is called before the first frame update
     [Range(2, 0)]
     public float timeScale=1;
   [Range(0, 100)]
	 public int downoften=100;
     public int maxHP = 100;
public int HP = 100;
public string enemyname;
public Slider hpslider; 
public Image hpImage;
public Text hptext;
    GameObject damageTextPrefab;
    public bool nodamage;
    FlickerModel FlickerModel;
    public float cooldowntime=0.5f;
    public bool cooldown=false;
    private Animator anim;
    public GameObject HitParticle;
    public Effekseer.EffekseerEffectAsset effect;
    public Transform damageTextPos; 
 GameObject killedplayer;

public motions DamageMotion;

public motions BigDamageMotion;




public Sprite icon;
    public GameObject deathparticle;
    public Effekseer.EffekseerEffectAsset deatheffect;
    Effekseer.EffekseerHandle handle;
    public float camerachangetime=0;
  public UnityEvent events;
bool once=false;
 System.Action ac;
 public string deathmessage;
 public int exp;
public itemdrops itemdrops;




    // Start is called before the first frame update
    void Start()
    {anim=GetComponent<Animator>();
       
       if (HP>maxHP)
       {
           maxHP=HP;
       }
FlickerModel=GetComponent<FlickerModel>();
       if (damageTextPrefab==null)
       {
           damageTextPrefab=(GameObject)Resources.Load("DamagePopup");
   
       } 
       
        if (damageTextPos==null)
        {
            damageTextPos=gameObject.transform;
        }
    }   




public void squencedamage(int damage,bool crit){
 ondamage(damage,crit,null,null);
}





public bool ondamage(int damage,bool crit,Collider coll,GameObject obj){




if (nodamage||cooldown||HP==0)return false;
     cooldownstart(); 
      
  killedplayer=obj;


HP = HP-damage;

anim.SetFloat("hp",HP);
anim.SetBool("collide",true);

Itemkind item=itemcurrent.instance.Itemkind;
      	if (item!=null)
        {
          item.Resitance-=damage/10;
        }

 FlickerModel.damagecolor();
 
         HitParticle?.Instantiate(coll?.ClosestPointOnBounds(transform.position)??transform.position);
         effect?.Play(coll?.ClosestPointOnBounds(transform.position)??transform.position);
    

   if (damageTextPrefab!=null)
{GameObject dmgText = Instantiate(damageTextPrefab, damageTextPos.position, Quaternion.identity);
            dmgText.GetComponent<DamagePopup>().SetUp(damage);
      if (crit)
      {
          dmgText.transform.localScale*=1.5f;
          keikei.Effspawns(0,gameObject.transform);
      }
    
}


DamageMotion.Play(gameObject);

anim.Play("allhit",0,0);
  if (keikei.kakuritu(downoften))
    {
BigDamageMotion.Play(gameObject);

anim.SetFloat("damagevalue",damage);
anim.SetInteger("damagevalue",damage);
anim.SetTrigger("damage");
	}
  return true;

}



public void damage(int damage,bool crit)
{
   this.damage(damage,crit,null,null);
}
public bool damage(int damage,bool crit,Collider coll)
{
   return this.damage(damage,crit,coll,null);
}
public bool damage(int damage,bool crit,Collider coll,GameObject obj)
{

     return ondamage(damage,crit,coll,obj);

}






public void damage(int damage){
    

this.damage(damage,false);
   

}

 public void damagestop(){
    var navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
 navMeshAgent.velocity = Vector3.zero;
        navMeshAgent.Stop();

 }
 public void recover(){
    var navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();

 navMeshAgent.Stop(false);


 }



void OnDestroy()
{
    
Time.timeScale=1;
}
void cooldownstart(){

cooldown=true;
Time.timeScale=timeScale;
Invoke("cooldownend",cooldowntime);
}

void cooldownend(){
Time.timeScale=1;
    cooldown=false;
}

     void LateUpdate()
    {

         HP = Mathf.Clamp(HP,0,maxHP);
         if (hptext)
         {
             hptext.text=enemyname+ "  "  + maxHP+"/"+HP;
         }
 if (hpImage!=null)
 {
       hpImage.fillAmount=(float)HP/maxHP;
 }
   
      if (hpslider!=null)
   {
        hpslider.maxValue=maxHP;   
         hpslider.value=HP;
   }
   
  
   
if (HP==0)
{  
  death(); 
    }
    }












public void death(){

if (!once)
{ 

if (hpslider!=null)
       {
             Destroy(hpslider.gameObject);
       }
   if (hpImage!=null)
   {
     Destroy(hpImage.gameObject);
   } 
   if (hptext!=null)
   {
     Destroy(hptext.gameObject);
   }
   



if (anim.runtimeAnimatorController!=null)
{
   anim.SetBool("death",true);anim.SetBool("dead",true);
anim.SetTrigger("death");
anim.SetTrigger("dead");
keikei.delaycall(()=>deathend(),3f);
}else{
   deathend();
}
   
        warning.message(enemyname+"を倒した！");
keikei.SetMessage(deathmessage,true,icon);
    
  
if (camerachangetime!=0)
{
    
keikei.atractcamera(camerachangetime,transform,13);
 handle= gameObject.effecseer(deatheffect,true);

}

once=true;
}
    
}

//アニメーションコントローラから実行
bool deathendonce;
public void deathend(){                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                  
if (deathendonce)return;
deathendonce=true;

if (killedplayer!=null)
{
    
killedplayer.acessdata().Getexp(exp);
killedplayer.acessdata().nowquest?.enemykill(enemyname);

}
   if (deathparticle!=null)
   {
Instantiate(deathparticle,transform.position,transform.rotation);
   }
   if(itemdrops!=null)
   {
      
itemdrops.itemdropers(gameObject);

   }
ac=delegate()
{

handle.Stop(); events.Invoke();
};

keikei.dissolvedeath(gameObject,ac);


}







}
