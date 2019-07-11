namespace OwnScripts
{
    using UnityEngine;
    using UnityEngine.UI;
    using VRTK.Controllables;
    using System.Collections;

    public class MusicButtonReactor : MonoBehaviour
    {
        public VRTK_BaseControllable controllable;
        public Text displayText;
        public string outputOnMax = "Maximum Reached";
        public string outputOnMin = "Minimum Reached";

        public AudioClip fastSound;

        public AudioClip slowSound;

        public GameObject backgroundSoundGameObject;

        private AudioSource fastSource { get { return GetComponent<AudioSource>(); } }

         private AudioSource slowSource { get { return GetComponent<AudioSource>(); } }

        public bool isSlow;


        private void Start()
        {
            gameObject.AddComponent<AudioSource>();
            fastSource.clip = fastSound;

            gameObject.AddComponent<AudioSource>();
            slowSource.clip = slowSound;
        }
    
        protected virtual void OnEnable()
        {
            controllable = (controllable == null ? GetComponent<VRTK_BaseControllable>() : controllable);
            controllable.ValueChanged += ValueChanged;
            controllable.MaxLimitReached += MaxLimitReached;
            controllable.MinLimitReached += MinLimitReached;
        }

        protected virtual void ValueChanged(object sender, ControllableEventArgs e)
        {
            if (displayText != null)
            {
                displayText.text = e.value.ToString("F1");
            }
        }

        protected virtual void MaxLimitReached(object sender, ControllableEventArgs e)
        {
            if (outputOnMax != "")
            {

                Debug.Log(outputOnMax);
                
                StartCoroutine(Example());
                
            }
        }

        protected virtual void MinLimitReached(object sender, ControllableEventArgs e)
        {
            if (outputOnMin != "")
            {
                Debug.Log(outputOnMin);
            }
        }

        IEnumerator Example()
        {
       
            AudioSource backgroundAudiSource =  backgroundSoundGameObject.GetComponent<AudioSource>();
            float formerBackgroundSound = backgroundAudiSource.volume;
            backgroundAudiSource.volume = 0f;
            if(isSlow) {
                isSlow = false;
                slowSource.PlayOneShot(slowSound);
                yield return new WaitForSeconds(6);
            } else {
                isSlow = true;
                fastSource.PlayOneShot(fastSound);
                yield return new WaitForSeconds(3);            
            }
            backgroundAudiSource.volume = formerBackgroundSound;
        }
    }

    
}