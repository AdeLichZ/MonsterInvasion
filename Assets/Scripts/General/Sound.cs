using UnityEngine;
using UnityEngine.Audio;

namespace General
{
    [System.Serializable]
    class Sound
    {
        public AudioClip clip;

        public string name;
        [Range(0f,1f)] public float volume;
        [Range(.1f,3f)] public float pitch;

        [HideInInspector]
        public AudioSource source;
    }
}
