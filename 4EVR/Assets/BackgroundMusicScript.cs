using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusicScript : MonoBehaviour
{

    public AudioClip sound;

    private AudioSource source { get { return GetComponent<AudioSource>(); } }

    // Start is called before the first frame update
    void Start()
    {
        gameObject.AddComponent<AudioSource>();
        source.volume = 0.25f;
        source.clip = sound;
        source.loop = true;
        source.Play();
        
    }

    // Update is called once per frame
    void Update()
    {
       source.volume = Mathf.Lerp(source.volume, 0.75f, 0.00166f / 4 * Time.deltaTime);
    }
}
