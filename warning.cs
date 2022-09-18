using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System;

using System.Linq;
using TMPro;
public class warning : MonoBehaviour
{
   public static GameObject[] messages;
   public TextMeshProUGUI TextMeshProUGUI;
   public static GameObject news;
   
public static string newstext;
   
public static void message(string text){
message(text,0);


}
public static void warn(string text){
message(text,1);


}
public static void message(string text,int number){


  var a= Instantiate(messages[number],messages[number].transform.position,Quaternion.identity);

  
a.GetComponentsInChildren<TextMeshPro>().ToList().ForEach(n=>n.SetText(text));




if (a.GetComponentInChildren<Text>()!=null)
{
  
a.GetComponentInChildren<Text>().text=text;

}else if(a.GetComponentInChildren<TextMeshProUGUI>()!=null)
{


  

}
Destroy(a,4);

} 

public static void newsadd(string text){


newstext+=text;
news.GetComponentInChildren<Text>().text=newstext;



} 

}