using UnityEngine;

[CreateAssetMenu(fileName = "RPGbattleCommand", menuName = "")]
public class RPGbattleCommand : ScriptableObject
{
    public RpgPlayerMotion[] RpgPlayerMotions;
RpgPlayerMotion nowRpgPlayerMotion;

public void battle(GameObject obj){
interactionlist interactionlist=keikei.interactionlist;
    
foreach (var item in RpgPlayerMotions)
{
     interactionlist.createinteraction(item.motionname,()=>{nowRpgPlayerMotion=item;interactionlist.Alldeleteinteraction();
     
     });
}
   
}





public void enemySelect(){

}

}