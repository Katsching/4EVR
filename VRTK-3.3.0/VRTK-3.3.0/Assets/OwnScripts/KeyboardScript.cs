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

        public string letter;

        public GameObject textDescription;


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
            if(!string.IsNullOrWhiteSpace(letter)) {
                Debug.Log(outputOnMax);
                Text t = textDescription.GetComponent<Text>();
                t.text = t.text + letter;     
            }
            else {
                if(isDeleteButton) {
                    delete();
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
    }

    
}