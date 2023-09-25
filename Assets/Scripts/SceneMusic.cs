//SceneMusic.cs by Joseph Panara for A Tiny Mystery
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneMusic : MonoBehaviour
{
    public AudioSource Music;
    void Start()
    {
        Music.Play();
    }
}
