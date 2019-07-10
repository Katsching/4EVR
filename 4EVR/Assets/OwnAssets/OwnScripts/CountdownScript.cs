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


    void Start()
    {
        endScreenBackGround.transform.localScale = new Vector3(0, 0, 0);
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
        endScreenBackGround.transform.localScale = new Vector3(1, 1, 1);
        Text t = endScreenDescription.GetComponent<Text>();
        t.text = "You lost!";
    }
    
}
