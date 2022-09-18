using UnityEngine;

public class RPGBattleManager : Singleton<RPGBattleManager>
{
    
    public Material skybox;

    public Transform[] enemyPositions;
    public Transform[] playerPositions;
    
     public void Awake()
    {
        if (this!=Instance)
        {
            Destroy(gameObject);
            
            return;
        }
        
        transform.parent = null;
        DontDestroyOnLoad(this.gameObject);
    }


public void battleStart(PlayerParty PlayerParty,EnemyParty EnemyParty){


}
 
int i;
    public void StageSet(PlayerParty PlayerParty,EnemyParty EnemyParty){
        i=0;
RenderSettings.skybox = skybox;
foreach (var item in PlayerParty.members)
{item.Instantiate(playerPositions[i]);
    i++;
}
    }

public void PlayerTurn(){

}
public void EnemyTurn(){

}






public void TurnChange(){

}


}