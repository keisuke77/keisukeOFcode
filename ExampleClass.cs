using UnityEngine;
using UnityEngine.UI;	

public class ExampleClass : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("damage"))
        {
            Destroy(other.gameObject);
        }
    }
}