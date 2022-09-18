using UnityEngine;

public class enemyattackcore : MonoBehaviour
{
    
public int basedamagevalue;

enemystatus enemystatus;

public bool attack;

void Start()
{
        enemystatus=GetComponent<enemystatusSet>().enemystatus;
 
}
public void attackon(GameObject other,float damagevalue,bool force,float CritRate,float CritMultiplier,float forcepower,bool sequencehit){

attack=true;
var crit = Random.value <= CritRate;
if (crit)
{
  warning.message(enemystatus.name.ToString()+"のクリティカル攻撃！");
}
			var damagevalues = crit == true ? (int)(damagevalue * CritMultiplier) : damagevalue;
			damagevalues+=basedamagevalue;
  other.root().GetComponent<hp>().damage((int)damagevalues,crit,sequencehit);

if (keikei.UnityChanControlScriptWithRgidBody.defences)
{
      keikei.Effspawn(keikei.effects[2],transform);
        keikei.backforce(transform.root.gameObject,20);
 
}


  if (force)
  {
      
other.root().GetComponent<Rigidbody>().AddForce(transform.forward*forcepower,ForceMode.Impulse);

  }
	
}
}