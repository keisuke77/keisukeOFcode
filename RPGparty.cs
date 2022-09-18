using UnityEngine;

[CreateAssetMenu(fileName = "party", menuName = "RPG")]
public class RPGparty : ScriptableObject
{
    public GameObject[] members;
    public string name;

}