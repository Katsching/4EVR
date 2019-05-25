using UnityEngine;
using System.Collections;

namespace Valve.VR.InteractionSystem.Sample
{
    public class ButtonExample : MonoBehaviour
    {
        public HoverButton hoverButton;

        public AudioClip sound;

        private AudioSource source { get { return GetComponent<AudioSource>(); } }

        private void Start()
        {
            gameObject.AddComponent<AudioSource>();
            source.clip = sound;
            hoverButton.onButtonDown.AddListener(OnButtonDown);
        }

        private void OnButtonDown(Hand hand)
        {
            PlaySound();
        }

        void PlaySound()
        {
            source.PlayOneShot(sound);
        }
    }
}