using UnityEngine;
using System.Collections;

public class PlaySound2D : MonoBehaviour
{
    public AudioClip Sound;


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            AudioSource.PlayClipAtPoint(Sound, transform.position);
        }
    }
}