using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderScript : MonoBehaviour
{

    public string complementaryCubeName;
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
 
                    var otherMass = other.transform.parent.GetComponent<Rigidbody>().mass;
                    var name = other.transform.parent.name;
                    Debug.Log(name);
                    var material = other.GetComponent<MeshRenderer>().material;
                        if(name == complementaryCubeName) {
                            Debug.Log("test worked");
                }
        }
    }
}
