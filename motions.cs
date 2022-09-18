using UnityEngine;
using System.Linq;
[CreateAssetMenu(fileName = "motion", menuName = "")]
public class motions : ScriptableObject
{
    public AnimationClip animation;

    public Effekseer.EffekseerEffectAsset effect;
    public instanceobj instanceobj;
    [Range(0,1)]
    public float timing;
    GameObject objs;
public int damagevalue;
public bodypart bodypart;
public int[] triggernumber;
 [Range(0,1)]
public float startdamagetime;
 [Range(0,1)]
public float enddamagetime;
public motions continuemotion;

   public void Play(GameObject obj){
AnimEffect(obj);
TriggerDamage(obj);

   }


public void AnimEffect(GameObject obj){

    objs=obj;
    obj.GetComponent<Animancer.AnimancerComponent>().Play(animation).Events.OnEnd = OnEnd;
  
float latetime=animation.length*timing;
    keikei.delaycall(()=>{obj.Play(effect);instanceobj.Instantiates(obj.transform);},latetime);

}


public void TriggerDamage(GameObject obj){

float starttime=animation.length*startdamagetime;
float endtime=animation.length*enddamagetime;
if (obj.GetComponentIfNotNull<triggeronoff>()!=null)
{
   
 triggeronoff trigeronoff=obj.GetComponentIfNotNull<triggeronoff>();   
if (damagevalue!=0&&trigeronoff!=null)
{
trigeronoff.obj=bodypart.Getbodypart(obj).GetComponentIfNotNull<Collider>();

trigeronoff.obj.gameObject.collset(damagevalue);

 keikei.delaycall(()=>trigeronoff.ontriger(),starttime);
 keikei.delaycall(()=>trigeronoff.offtriger(),endtime);
}

}

if (obj.GetComponentIfNotNull<trrigeronofflist>()!=null)
{
trrigeronofflist trrigeronofflist=obj.GetComponent<trrigeronofflist>();
if (trrigeronofflist!=null&&damagevalue!=0)
{
trrigeronofflist.num=triggernumber;
foreach (var item in trrigeronofflist.GetTriger())
{
   
item.gameObject.collset(damagevalue);

}

 keikei.delaycall(()=>trrigeronofflist.ontriger(),starttime);
 keikei.delaycall(()=>trrigeronofflist.offtriger(),endtime);

}
}

}


   public void OnEnd(){

objs.GetComponent<Animancer.AnimancerComponent>().Stop();
continuemotion.Play(objs);
   }
}