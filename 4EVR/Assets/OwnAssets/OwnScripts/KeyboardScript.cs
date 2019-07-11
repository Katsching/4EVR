namespace OwnScripts
{
    using UnityEngine;
    using UnityEngine.UI;
    using VRTK.Controllables;

    public class KeyboardScript : MonoBehaviour
    {
        public VRTK_BaseControllable controllable;
        public Text displayText;
        public string outputOnMax = "Maximum Reached";
        public string outputOnMin = "Minimum Reached";

        public bool isDeleteButton = false;

        public bool isEnterButton = false;

        public string letter;

        public GameObject textDescription;

        public GameObject cube;

        public string resultString;


        private void Start()
        {

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
            Text t = textDescription.GetComponent<Text>();
            if(!string.IsNullOrWhiteSpace(letter)) {
                Debug.Log(outputOnMax);
                if(t.text.Equals("CRRCT!")) {
                }
                
                else if(t.text.Equals("WRNG!")) {
                    t.text = letter;
                } 
                else if(t.text.Length < 6) {
                        t.text = t.text + letter;    
                }
            }
            else {
                if(isDeleteButton) {
                    if(t.text.Equals("WRNG!")) {
                        t.text = "";
                    }
                    else if(!t.text.Equals("CRRCT!")) {
                        delete();
                    } 
                  
                }
                if(isEnterButton) {
                    enter();
                }
            }

        }

        protected virtual void MinLimitReached(object sender, ControllableEventArgs e)
        {
            Debug.Log(outputOnMin);
   
        }

        protected void delete(){
            Text t = textDescription.GetComponent<Text>();
            t.text = t.text + letter;
            t.text = t.text.Substring(0, t.text.Length - 1);
        }

        protected void enter(){
            Text text = textDescription.GetComponent<Text>();
            if(text.text.Equals(resultString)){
                text.text = "CRRCT!";
                MeshRenderer render = cube.GetComponentInChildren<MeshRenderer>();
                render.enabled = true;
            } else {
                text.text = "WRNG!";
            }
        }
    }

    
}