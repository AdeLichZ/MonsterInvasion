using System;
using UnityEngine;
using UnityEngine.Audio;

namespace General
{
    class AudioManager : MonoBehaviour
    {
        public Sound[] sounds;

        private void Awake()
        {
            foreach (Sound s in sounds)
            {
                s.source = gameObject.AddComponent<AudioSource>();
                s.source.clip = s.clip;
                s.source.volume = s.volume;
                s.source.pitch = s.pitch;
            }
        }
        public void Play(string name)
        {
            Sound s = Array.Find(sounds, sound => sound.name == name);
            s.source.Play();
        }
        public void PlayOneShot(string name)
        {
            Sound s = Array.Find(sounds, sound => sound.name == name);
            if (!s.source.isPlaying)
            {
                s.source.Play();  // to do make not repeating
                s.source.loop = false;
                s.source.playOnAwake = false;
            }
        }
    }
}
