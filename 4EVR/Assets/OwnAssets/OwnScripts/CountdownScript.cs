using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float timeLeft;
    public  ParticleSystem explosion;


    void Start()
    {
        
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
                GameOver();
            }


    }

    private void GameOver(){
        explosion.Play();
    }
}
