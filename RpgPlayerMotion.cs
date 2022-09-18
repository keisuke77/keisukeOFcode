using UnityEngine;
using System;
[CreateAssetMenu(fileName = "RpgPlayerMotion", menuName = "")]
public class RpgPlayerMotion : motions
{
  public GameObject hitparticle;
  public motions missmotion;
public string motionname;

    public void Play(GameObject player,GameObject enemy){
AnimEffect(player);

bool missonce;
keiinput keiinput=player.pclass().keiinput;
 
 keikei.delayAndwhilecall(()=>{

if (keiinput.attack)
{
if (enemy.GetComponent<enemyhp>().damage(damagevalue,false,null,player))
{
    
}else
{missonce=true;
missmotion.Play(player);
}
    
}
 },startdamagetime,enddamagetime-startdamagetime);



    }


}