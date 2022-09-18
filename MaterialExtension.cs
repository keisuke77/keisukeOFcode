using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public static class MaterialExtension
{
    
public static List<Renderer> meshRenderers;

public static List<Renderer> GetRender(this GameObject obj){
 meshRenderers= new List<Renderer>();
         foreach (var item in getallchildren.GetAll(obj))
     {
         if ((item.GetComponent<SkinnedMeshRenderer>()||item.GetComponent<MeshRenderer>())&&item.tag!="Nodissolve")
     { 
          meshRenderers.Add(item.GetComponent<Renderer>());
     }
     }
     return meshRenderers;
}


public static List<Material> GetMaterial(this GameObject obj){

return null;
}
}