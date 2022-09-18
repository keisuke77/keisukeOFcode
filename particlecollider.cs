using System.Collections.Generic;
using UnityEngine;

public class particlecollider: MonoBehaviour
{
    [SerializeField]
    GameObject spawnobj;
     [SerializeField]
    GameObject spawnobj2;
    private gameover gameover;
    public bool playerdamage=false;
    public bool enemydamage=false;
    public bool jumpeffect=true;
    public bool death=false; 

List<GameObject> spawns;
    public int damagepower=10;
public float explosionspeed=0;
     GameObject obj;
public bool objspawn=false;
public float effectpower=200;
public bool playerhitobjspawn=true;
public bool enemyhitobjspawn=false;
public bool hitobjspawn=false;
public bool childspawn;
private UnityChanControlScriptWithRgidBody unitychan;
    List<ParticleCollisionEvent> particleCollisionEventList = new List<ParticleCollisionEvent>();

 
    ParticleSystem _ParticleSystem;

    void Start()
    {  _ParticleSystem = this.gameObject.GetComponent<ParticleSystem>();
     
    }
 public void objspawns(GameObject other){
       _ParticleSystem.GetCollisionEvents(other, particleCollisionEventList);

 Vector3 collisionHitPos = particleCollisionEventList[0].intersection;
    
if (spawnobj!=null)
{ 
    spawns.Add(Instantiate(spawnobj,collisionHitPos,Quaternion.identity));

    
}if (spawnobj2!=null)
{
      spawns.Add(Instantiate(spawnobj2,collisionHitPos,Quaternion.identity));

}


if (childspawn)
{
    
foreach (var objss in spawns)
{
    objss.transform.position=Vector3.zero;
    objss.transform.SetParent(other.transform);

}

}

 }
    //パーティクルの当たった箇所でオブジェクト出現
    void OnParticleCollision(GameObject other)
    {
if (explosionspeed!=0)
{
 

        // 風速計算
        var velocity = (other.transform.position - transform.position).normalized * explosionspeed;

	   if(other.GetComponent<Rigidbody>()!=null){
         var rb = other.GetComponent<Rigidbody>();
     // 風力与える
        rb.AddForce(velocity);
 
     }else if(other.GetComponent<UnityChanControlScriptWithRgidBody>()!=null)
   {
       var rb = other.GetComponent<UnityChanControlScriptWithRgidBody>();
     // 風力与える
        rb.AddForce(velocity);
 
   }
	}
   
if (other.gameObject.transform.root.gameObject.tag=="Enemy")
        {

  


if (enemydamage)
{
     var b = other.GetComponent<enemyhp>();
b.damage(damagepower);

}


if (enemyhitobjspawn==true)
        {
         objspawns(other);
            Destroy(gameObject);
  
        }
 
        }
else if (other.gameObject.transform.root.gameObject.tag=="Player")
        { obj=other.gameObject.transform.root.gameObject;
              var unityhp = obj.GetComponent<hp>();
            var unitycon = obj.GetComponent<UnityChanControlScriptWithRgidBody>();
if (playerdamage)
{
unityhp.damage(damagepower);
}
if(playerhitobjspawn==true){
 objspawns(other);
             Destroy(gameObject);
    

}

            if (jumpeffect)
            {
                     }
        

        }
 if (other.gameObject.transform.root.gameObject.tag!="Enemy"&&other.gameObject.transform.root.gameObject.tag!="Player"&&hitobjspawn)
        {
           objspawns(other);
             Destroy(gameObject);
        }
             
    
         }
}