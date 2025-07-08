using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 [System.Serializable]
public class Sound
{
    public string name;
    public string type;
    public AudioClip clip;

    [Range(0f, 1f)]
    public float volume;

    [Range(-3f, 3f)]
    public bool loop;

    [HideInInspector]
    public AudioSource source;
}
