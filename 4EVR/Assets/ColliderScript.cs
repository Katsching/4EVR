using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     private void OnTriggerEnter(Collider other)
    {
        {
            if(other.GetComponent<Rigidbody>() != null)
                {
                    var otherMass = other.GetComponent<Rigidbody>().mass;
                    if(otherMass > 10) {
                     Debug.Log("entered with 10");
                }
         }
            Debug.Log("entered no 10");
        }
    }
}
