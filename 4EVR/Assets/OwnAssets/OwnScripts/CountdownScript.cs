using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float timeLeft;
    public  ParticleSystem explosion;

    public GameObject endScreenDescription;

    public GameObject endScreenBackGround;

    public Font myNewFont;

    public AudioClip explosionSound;

    private AudioSource explosionSource { get { return GetComponent<AudioSource>(); } }

    public bool isFirstBoard;


    void Start()
    {
        endScreenBackGround.transform.localScale = new Vector3(0, 0, 0);
        gameObject.AddComponent<AudioSource>();
        explosionSource.clip = explosionSound;
    }

    // Update is called once per frame
    void Update()
    {
            
            timeLeft -= Time.deltaTime;
            string minSec = string.Format("{0}:{1:00}", (int)timeLeft / 60, (int)timeLeft % 60); 
            Text t = gameObject.GetComponent<Text>();
            t.text = minSec.ToString();

            if ( timeLeft < 0 )
            {
                enabled = false;
                GameOver();
            }


    }

    private void GameOver(){
        explosion.Play();
        if(isFirstBoard) {
            explosionSource.PlayOneShot(explosionSound);
        }
        endScreenBackGround.transform.localScale = new Vector3(1, 1, 1);
        Text t = endScreenDescription.GetComponent<Text>();
        t.font = myNewFont;
        t.text = "You lost!";
    }
}
