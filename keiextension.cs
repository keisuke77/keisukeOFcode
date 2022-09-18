using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using DG.Tweening;
using System.Linq;
using UnityEngine.SceneManagement;
using System;
[System.Serializable]
public class animstringbool{
public string boolname;
public bool check;

}
 [System.Serializable]
    public class targeteffect{ public Transform target;
    
   public bodypart part;
    public Effekseer.EffekseerEffectAsset effect=null;
    public Vector3 rot;
    public bool parent;
    public GameObject particle;
    public damagevalue damagevalue;
    }
[System.Serializable]
public class damagevalue{
public bool ondamage;
public int value;
public bool player;

}

[System.Serializable]
public class ItemIconText{
public Image icon;
public Text explain;
public Text name;
public Text number;
}





public enum bodypart 
{
   no,righthand,lefthand,rightfoot,leftfoot,weapons
    
}
public enum direction 
{
   forward,back,left,right,up,down
    
}

  
/// <summary>
/// Listの拡張クラス
/// </summary>
public static class keiextension { public static Effekseer.EffekseerHandle handle;
   
   
   
    public static Effekseer.EffekseerHandle Play(this GameObject obj,Effekseer.EffekseerEffectAsset effect){

return obj.EffspawnPlayer(effect);
    }
  public static Effekseer.EffekseerHandle EffspawnPlayer(this GameObject obj,Effekseer.EffekseerEffectAsset effect){
if (effect!=null)
{
handle= effect.Play(obj.transform);;
}
    // transformの回転を設定する。
 return handle;
    }   
    public static Effekseer.EffekseerHandle EffspawnPlayer(this GameObject obj,Effekseer.EffekseerEffectAsset effect,float during){
   handle= obj.EffspawnPlayer(effect);

 keikei.delaycall(()=>handle.Stop(),during);

 
return handle;
    // transformの回転を設定する。
    } 


public static void scalechange(this GameObject target,float num,float speed){
    target.transform.DOScale(
    target.transform.localScale*num, // スケール値
    speed                    // 演出時間
); 
}
public static void scalechange(this GameObject target,float num){
   target.scalechange(num,1);
}


    public static void delay(this Action action,float time){
keikei.delaycall(action,time);
    }
     public static void EffspawnPlayerStop(this GameObject obj){
 obj.pclass().playeremitter.Stop();
 
    // transformの回転を設定する。
    } 

public static int stringindexScene(this string name){
  
   return SceneManager.GetSceneByName(name).buildIndex-1;
}


 public static float GetAxis(this string axis){

try
{
return Input.GetAxis(axis);
}
catch (System.Exception e)
{
 return 0;
}

}


  public static GameObject CreateImage(this Sprite sprite,GameObject obj){
var im=("CustomImage").ResourcesLoad();
im= im.Instantiate(obj.transform);
im.GetComponent<Image>().sprite=sprite;
im.transform.parent=obj.transform;
return im;

  }
public static GameObject ResourcesLoad(this string name){
  
return (GameObject)Resources.Load(name);
}
 public static float GetAxis(this string[] axis){

  foreach (var item in axis)
  {
    float n=item.GetAxis();
    if (n!=0)
    {
      return n;
    }
  }
 return 0;
}



  public static bool keydown(this KeyCode[] keycodes){
  foreach (var item in keycodes)
  {
   if (item.keydown())
   {
     return true;
   } 
  }
  return false;
}
public static bool keyup(this KeyCode[] keycodes){
  foreach (var item in keycodes)
  {
   if (item.keyup())
   {
     return true;
   }  }
  return false;
}

 public static void boolset(this GameObject obj,animstringbool animstringbool){
obj.GetComponent<Animator>().SetBool(animstringbool.boolname,animstringbool.check);
 }
 public static void boolsets(this GameObject obj,animstringbool[] animstringbools){
   foreach (var animstringbool in animstringbools)
   {
     
obj.GetComponent<Animator>().SetBool(animstringbool.boolname,animstringbool.check);

   } }

 public static T2 Childremovecomponentandattach<T1,T2>(this GameObject obj){


foreach (var item in obj.GetAll())
{

item.removecomponentandattach<T1,T2>();

  
}           
return default(T2);
 }



public static bool keydown(this KeyCode KeyCode){
return Input.GetKeyDown(KeyCode);
}
public static bool keyup(this KeyCode KeyCode){
return Input.GetKeyUp(KeyCode);
}
public static bool keyhold(this KeyCode KeyCode){
return Input.GetKey(KeyCode);
}
 public static T1 AddComponentIfnull<T1>(this GameObject obj){

if (obj.GetComponent<T1>()==null)
{obj.AddComponent(typeof(T1));
  return obj.GetComponent<T1>();
}else
{return obj.GetComponent<T1>();
  
}

 }


 public static T2 ForceChildremovecomponentandattach<T1,T2>(this GameObject obj){


if (obj.Childremovecomponentandattach<T1,T2>()==null)
{
  obj.AddComponent(typeof(T2));
  return obj.GetComponent<T2>();
}else
{
  return obj.Childremovecomponentandattach<T1,T2>();
}

 }

 public static T2 removecomponentandattach<T1,T2>(this GameObject obj){

  if (obj.GetComponent<T1>()!=null)
    {
       
obj.AddComponent(typeof(T2));
keikei.Destroys(obj.GetComponent<T1>()as Component);  
return obj.GetComponent<T2>();
 }       
return default(T2);
 }

public static GameObject Instantiate(this GameObject obj,Transform trans){

 return keikei.instantiate(obj,trans.position,trans.rotation);
}
public static GameObject Instantiate(this GameObject obj,Vector3 trans){

 return keikei.instantiate(obj,trans,Quaternion.identity);
}
public static void spawn(this Collider col,Transform trans,GameObject effect){

if (col!=null)
{
Vector3 hitPos = col.ClosestPointOnBounds(trans.position);
keikei.instantiate(effect,hitPos,Quaternion.identity);
  if (hitPos==null)
  {
      keikei.instantiate(effect,col.transform.position,Quaternion.identity);
  }
}
}
public static data acessdata(this GameObject obj){
  return obj.root().pclass().datamanage.data;

}
  /// <summary>
  /// 渡されたメソッドを指定時間後に実行する
  /// </summary>
  public static IEnumerator DelayMethod(this MonoBehaviour mono, float waitTime, Action action)
  {
    yield return new WaitForSeconds(waitTime);
    action();
  }



public static Vector3 To(this Vector3 vec,Vector3 to,float rate){
Vector3 move=to-vec;

return vec+(move*rate);
}
public static void effekseerspawn(this targeteffect targeteffect){
    var a=targeteffect;
GameObject obj;
if(a.effect)
{
    if (a.target!=null)
      {
        a.target.gameObject.effecseer(a.effect,a.parent).SetRotation(Quaternion.Euler(a.rot));
      }else
      {
        a.part.Getbodypart().effecseer(a.effect,a.parent).SetRotation(Quaternion.Euler(a.rot));
      }
}
    

if (a.particle)
{
if (a.target)
      { 
        obj=  keikei.instantiate(a.particle,a.target,a.parent);
        }else
      {
 obj=keikei.instantiate(a.particle,a.part.Getbodypart().transform,a.parent);
     

            }

if (a.damagevalue.ondamage)
{


 
    if (a.damagevalue.player)
  {obj.ForceChildremovecomponentandattach<playerdamage,enemyattack>();
    
 obj.AddComponent(typeof(enemyattack));
 
 obj.GetComponent<enemyattack>().damagevalue=a.damagevalue.value;
  }else
  {
    
  }
  
    
 obj.AddComponent(typeof(playerdamage));

 obj.GetComponent<playerdamage>().damagevalue=a.damagevalue.value;
  
}
   
}
    
}

public static T debug<T>(this T t){

Debug.Log(t);
return t;
}

public static float grounddistances(this Transform trans,LayerMask targetLayer)
{
RaycastHit hitInfo;
if (Physics.SphereCast(trans.position+trans.up, 0.1f,Vector3.down, out hitInfo, Mathf.Infinity, targetLayer))
{

    

return trans.position.y-hitInfo.point.y;

}else
{
	
return Mathf.Infinity;
}
}



public static void destroy(this GameObject obj,float time)
{
keikei.destroy(obj,time);
}
public static void fadedestroy(this GameObject obj,float time)
{
keikei.fadedeath(obj,time);
}
public static void destroy(this GameObject obj)
{
obj.destroy(0);
}
public static void destroyObject(this GameObject obj)
{
    var random = new System.Random();
    var min = -3;
    var max = 3;
    obj.GetComponentsInChildren<Rigidbody>().ToList().ForEach(r => {
        r.isKinematic = false;
        r.transform.SetParent(null);
        r.gameObject.fadedestroy(2f);
        var vect = new Vector3(random.Next(min, max), random.Next(0, max), random.Next(min, max));
        r.AddForce(vect, ForceMode.Impulse);
        r.AddTorque(vect, ForceMode.Impulse);
    });
    obj.destroy();
}
public static void PlayerDamage(this GameObject obj,int damagevalue){


    if (obj.proottag()){

    obj.gameObject.GetComponent<hp>().damage(damagevalue);
   
}
}
public static Camera Getplayercamera(this GameObject obj){

 return obj.root().GetComponent<playerclass>().AutoRotateCamera.GetComponent<Camera>();
}

  public static GameObject SetActive(this Component com,bool bools) {
  com.gameObject.SetActive(bools);
    return com.gameObject;
  }
  public static bool nullchecks(this Effekseer.EffekseerEffectAsset obj){

      if (obj)
      {
        return true;
      }else
      {
        return false;
      }
  }  
    public static string total(this List<string> list){

return string.Join("", list);;
    
}
public static void playerstop(this GameObject obj)=>keikei.playerstop(obj);


  
  public static void fadeinout(this Behaviour obj,bool actives){

     obj.gameObject.fadeinout(actives);
     
       }
  public static void fadeinout(this GameObject obj,bool actives){

      Fade.Instance.FadeIn(1f,()=>{obj.fadeoutactives(actives);});
      
  }
  
  
  
  public static T rootaddcomponent<T>(this GameObject obj){
  GameObject objs= obj.transform.root.gameObject;
if (objs.GetComponent<T>()==null)
{
  objs.AddComponent(typeof(T));
 return objs.GetComponent<T>();
}

 return objs.GetComponent<T>();
  }
  public static Effekseer.EffekseerHandle effecseer(this GameObject obj,Effekseer.EffekseerEffectAsset effect,bool parent){

     if (parent)
{ if(!obj.GetComponent<Effekseer.EffekseerEmitter>()){
 obj.AddComponent(typeof(Effekseer.EffekseerEmitter));
   
}
 return obj.GetComponent<Effekseer.EffekseerEmitter>().Play(effect);

}else
{
   return keikei.Effspawn(effect,obj.transform);
}
  }public static void effecseerstop(this GameObject obj){
  obj.GetComp<Effekseer.EffekseerEmitter>().Stop();


     
  }

public static Component Getreturn(this Component obj,GameObject objs){
return objs.GetComponent(obj.GetType())as Component;
}

public static void Get(this Component obj,GameObject objs){
obj= obj.Getreturn(objs);

}


  public static T GetComp<T>(this GameObject obj){
if (obj.GetComponent<T>()!=null)
{
  return obj.GetComponent<T>();
}else
{
  return default(T);
}


  }

  
  public static List<T> replace<T>(this List<T> objs,T ob,T obs){

int a=objs.IndexOf(ob);
int b=objs.IndexOf(obs);

objs[a]=obs;
objs[b]=ob;

return objs;
  }public static iteminventory getinventory(this GameObject col){
    return col.acessdata().saveiteminventory;
  }
  public static bool ptag(this Collision col){

       return col.gameObject.CompareTag("Player");
        
  }
  public static bool proottag(this Collision col){

       return col.gameObject.transform.root.gameObject.CompareTag("Player");
        
  }
   public static float NotMini(this float num){
if (num<0.1f&&num>-0.1f)
{
  num=0;
  
}
return num;
   }
  public static playerclass pclass(this GameObject obj){
return obj.root().GetComponentIfNotNull<playerclass>();
  }
  public static bool ptag(this Collider col){

       return col.gameObject.CompareTag("Player");
        
  }
public static void addforce(this GameObject obj,int forcepowers,Transform trans){

  
Rigidbody rb=obj.GetComponent<Rigidbody>();
if (rb!=null)
{if (obj.GetComponent<navchaise>())
{
  obj.GetComponent<navchaise>().agent.enabled=false;
rb.AddForce(trans.forward*forcepowers,ForceMode.Impulse); 
obj.GetComponent<navchaise>().agent.enabled=true;
}else
{
  rb.AddForce(trans.forward*forcepowers,ForceMode.Impulse); 
}
}

    
}
  public static bool ptag(this GameObject col){

       return col.CompareTag("Player");
        
  }
  public static bool proottag(this Collider col){

       return col.gameObject.proottag();
        
  }
  public static bool proottag(this GameObject col){

       return col.root().ptag();
        
  }
  
  public static GameObject root(this GameObject obj){
    if (obj.transform.root.gameObject!=null)
    {
      
return obj.transform.root.gameObject;
    }
    return obj;
      
  } public static GameObject root(this Collider obj){
return obj.gameObject.root();
  }
  
 
public static void fadeoutactives(this GameObject obj){
fadeoutactives(obj,true);
}
public static void fadeoutactives(this GameObject obj,bool actives){

obj.SetActive(actives);
Fade.Instance.FadeOut(1f);
}
public static void fadeoutactives(this Behaviour obj,bool actives){
fadeoutactives(obj.gameObject,true);
}

  public static void ratecheck(float rate){
var ran=UnityEngine.Random.value;
if (rate>ran)
{
  return;
}
  }

    
 public static List<T> GetComponent<T>(this List<GameObject> objs){
  
 List<T> coms=new List<T>();
foreach (GameObject item in objs)
{
  coms.Add(item.GetComponent<T>());
}
return coms;

 }
public static void whilecall(this System.Action action,float time){
 bool duration=true;
 while (duration)
 {
  action();
  keikei.delaycall(()=>duration=false,time);
 }

} 

public static void collset(this GameObject obj,int damagevalue){
if (obj.GetComponent<Collider>()==null)
{
	
var col	=obj.AddComponent(typeof(BoxCollider))as Collider;
		col.isTrigger=true;
		col.enabled=false;
}
if (obj.proottag())
{
obj.AddComponentIfnull<attackunitychan>().damagevalue=damagevalue;
}else
{
obj.AddComponentIfnull<enemyattack>().damagevalue=damagevalue;
}
}



public static void damageset(this GameObject obj,int damagevalue){
  if (true)
  {
    
  }
obj.GetComponentIfNotNull<attackunitychan>().damagevalue=damagevalue; 
obj.GetComponentIfNotNull<enemyattack>().damagevalue=damagevalue; 

}


     public static GameObject Getbodypart(this bodypart bodypart){

   return bodypart.Getbodypart(keikei.player);
    }
    
     public static GameObject Getbodypart(this bodypart bodypart,GameObject obj){

      
switch (bodypart)
{
    case bodypart.righthand:

   return obj.GetComponent<GetBodyPart>().GetRightHand().GetComponent<Collider>().gameObject;
        break;
  case bodypart.lefthand:

return obj.GetComponent<GetBodyPart>().GetLeftHand().GetComponent<Collider>().gameObject;
  break;   case bodypart.rightfoot:

   return obj.GetComponent<GetBodyPart>().GetRightFoot().GetComponent<Collider>().gameObject;
        break;
        case bodypart.leftfoot:
return obj.GetComponent<GetBodyPart>().GetLeftFoot().GetComponent<Collider>().gameObject;
     break;
   case bodypart.weapons:
   return obj.GetComponent<objectchange>().Getobj().GetComponent<Collider>().gameObject;  
   break;
  case bodypart.no:
   return null;  
   break;
    default:
    return null;
        break;
}
    }

     public static void setA(this Image col,int a){
Color c=col.color;
c.a=a;
col.color=c;
     }

    public static GameObject spawn(this enemystatus enemystatus,Transform trans){

    GameObject obj= keikei.instantiate(enemystatus.enemy,trans.position,trans.rotation);
    if ( obj.GetComponent<enemystatusSet>()==null)
    {
        obj.AddComponent(typeof(enemystatusSet));
    
    }
    obj.GetComponent<enemystatusSet>().enemystatus=enemystatus;
    return obj;
    } 
    
static List<GameObject> objs;

    
    public static List<GameObject> spawn(this enemysSet enemysSet,Transform trans){
objs=new List<GameObject>(30);
foreach (enemysSet.enemy item in enemysSet.enemys)
{
if(item.enemystatus!=null){
for (var i = 0; i < item.number; i++)
{
  objs.Add(item.enemystatus.spawn(trans)); 
}
}
     
}
  return objs;
     }

public static message acessmessage(this GameObject obj){

  return obj.pclass()?.AutoRotateCamera.message;
}
public static void enabled(this Canvas can,bool boo){

can.enabled=boo;
}

public static float GetAnimationClipLength(this Animator animator, string clipName) 
{
    float clipLength = 0f;

    var rac = animator.runtimeAnimatorController;
    var clips = rac.animationClips.Where (x => x.name == clipName);
    foreach (var clip in clips) {
        clipLength = clip.length;
    }
    return clipLength;
}
public static void deatheventset(this GameObject self,UnityEvent events){
self.AddComponent(typeof(deathevent));
self.GetComponent<deathevent>().events=events;
    }
  public static void itemdroper(this GameObject gameObject,itemdrop itemdrop){



foreach (var item in itemdrop.GetItemdropLists())
                {
                    if (keikei.kakuritu(item.perdrop))
                    {
                       var a= keikei.instantiate(item.itemdropelement,gameObject.transform.position,Quaternion.identity);
             keikei.itemappendRandom(a,6);
                      }
                  }
  }

  public static void itemdroper(this GameObject gameObject,GameObject obj){

                       var a= keikei.instantiate(obj,gameObject.transform.position,Quaternion.identity);
             keikei.itemappend(a);    
  }
  public static void itemchestdroper(this GameObject gameObject,itemdrop itemdrop){


 var a = keikei.instantiate(keikei.treasure,gameObject.transform.position,Quaternion.identity);
     
a.GetComponent<GIE.Chest>().itemdrop=itemdrop;
 
  }
public static GameObject FindAllChild(this GameObject obj,string objname){


foreach (GameObject item in obj.GetAll())
{if (item.name==objname)
{
  return item;
}
}
return null;
}
  public static GameObject NearserchTag(this GameObject nowObj,string tagName){
        float tmpDis = 0;           //距離用一時変数
        float nearDis = 0;          //最も近いオブジェクトの距離
        //string nearObjName = "";    //オブジェクト名称
        GameObject targetObj = null; //オブジェクト

        //タグ指定されたオブジェクトを配列で取得する
        foreach (GameObject obs in  GameObject.FindGameObjectsWithTag(tagName)){
            //自身と取得したオブジェクトの距離を取得
            tmpDis =(obs.transform.position- nowObj.transform.position).sqrMagnitude;

            //オブジェクトの距離が近いか、距離0であればオブジェクト名を取得
            //一時変数に距離を格納
            if (nearDis == 0 || nearDis > tmpDis){
                nearDis = tmpDis;
                //nearObjName = obs.name;
                targetObj = obs;
            }

        }
        //最も近かったオブジェクトを返す
        //return GameObject.Find(nearObjName);
        return targetObj;
    }
}