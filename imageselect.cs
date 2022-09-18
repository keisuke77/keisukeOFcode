using UnityEngine;

using UnityEngine.Events;

using UnityEngine.UI;

using DG.Tweening;
public class imageselect : MonoBehaviour
{public int num;
public Material selectmaterial;
public keiinput keiinput;

public UnityEvent afterevents;
[System.Serializable]
public class spriteevent{
  [HideInInspector]
public Material defaultmatearial;
public Image sprite;
public UnityEvent events;

  [HideInInspector]
public Vector3 defaultscale;
}

public spriteevent[] spriteevents;
    
    
     void Start()
    {
       num+=(spriteevents.Length*100000);
    if (keiinput==null)
    {
        
        keiinput=gameObject.pclass().keiinput;

    }   
    if (keiinput.enabled==false)
    {
        keiinput.enabled=true;
    }
    
foreach (var item in spriteevents)
{item.defaultscale=item.sprite.transform.localScale;
     
    item.defaultmatearial=item.sprite.material;
}

     }
   void reset(){
foreach (var item in spriteevents)
{
    item.sprite.material=item.defaultmatearial;
    item.sprite.gameObject.transform.DOScale(item.defaultscale,0.2f);
}

   }
   void select(){
    reset();
 spriteevents[num%spriteevents.Length].sprite.material=selectmaterial;
 
 spriteevents[num%spriteevents.Length].sprite.gameObject.transform.DOScale(spriteevents[num%spriteevents.Length].defaultscale*1.2f,0.2f);
   }

bool once;
   void decide(){if (once)
   {
    return;
   }
    once=true;
 spriteevents[num%spriteevents.Length].events.Invoke();
 
foreach (var item in spriteevents)
{
    item.sprite.gameObject.transform.DOScale(0,0.1f);
}
afterevents.Invoke();
  }
   
   void Update () {

if (keiinput.add)
{
	num++;
   select();
}
if (keiinput.decide)
{
	decide();
}
if (keiinput.down)
{num--;
	 select();
}
			
	}
}
