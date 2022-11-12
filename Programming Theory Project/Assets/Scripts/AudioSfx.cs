using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace edeastudio
{
    [RequireComponent(typeof(AudioSource))]

    public class AudioSfx : MonoBehaviour
    {
        [SerializeField]
        private AudioClip[] audioClips;
        [SerializeField]
        private bool isRandom;
        private AudioSource audioSource;
        [SerializeField]
        private AudioClip carriageClip;
        private int clipIndex;
        // Start is called before the first frame update
        void Start()
        {
            audioSource = GetComponent<AudioSource>();
            clipIndex = 0;
        }

        public void PlayCarriage()
        {
            if (carriageClip!= null && audioSource != null) { audioSource.PlayOneShot(carriageClip); }
        }


        public void PlaySound()
        {
            if (audioClips.Length == 0) return;

            if (isRandom) { clipIndex = Random.Range(0, audioClips.Length); }

            audioSource.PlayOneShot(audioClips[clipIndex]);

            clipIndex++;
            if (clipIndex > audioClips.Length) { clipIndex = 0; }


        }
    }

}