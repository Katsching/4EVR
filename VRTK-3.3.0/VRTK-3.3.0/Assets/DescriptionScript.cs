using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DescriptionScript : MonoBehaviour
{

    public GameObject cube;
    public string resultString;
    // Start is called before the first frame update
    void Start()
    {
        MeshRenderer render = cube.GetComponentInChildren<MeshRenderer>();
        render.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        Text text = gameObject.GetComponent<Text>();
        if(text.text.Equals(resultString)){
            MeshRenderer render = cube.GetComponentInChildren<MeshRenderer>();
            render.enabled = true;
        }
    }
}
