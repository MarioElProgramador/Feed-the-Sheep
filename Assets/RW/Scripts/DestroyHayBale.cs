using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyHayBale : MonoBehaviour
{
    public string tagFilter;

    private void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag(tagFilter)) 
        {
            Destroy(other.gameObject); 
        }
    }
}
