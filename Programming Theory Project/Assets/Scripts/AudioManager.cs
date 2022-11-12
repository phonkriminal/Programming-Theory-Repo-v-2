using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace edeastudio
{
    [RequireComponent(typeof(AudioSource))]
    public class AudioManager : MonoBehaviour
    {
        protected AudioSource audioSource;

        public AudioClip[] audioClips;

        // Start is called before the first frame update
        public virtual void Start()
        {
            audioSource= GetComponent<AudioSource>();
        }

        //  POLYMORPHISM
        public virtual void PlayMusic(AudioClip audioClip)
        {
            audioSource.clip = audioClip;
            audioSource.Play();
        }
        public virtual  void PlayMusic(AudioClip audioClip, bool loop)
        {
            audioSource.clip = audioClip;
            audioSource.loop = loop;
            audioSource.Play();
        }

        public virtual void PlayMusic(int audioClip)
        {
            if (audioClips == null || audioClips.Length == 0) { return; }
            audioSource.clip = audioClips[audioClip];
            audioSource.Play();
        }
        public virtual void PlayMusic(int audioClip, bool loop)
        {
            if (audioClips == null || audioClips.Length == 0) { return; }
            audioSource.clip = audioClips[audioClip];
            audioSource.loop = loop;
            audioSource.Play();
        }

        public virtual void StopMusic()
        {
            audioSource.Stop();
        }

    }

}