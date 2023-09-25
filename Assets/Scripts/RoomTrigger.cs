using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTrigger : MonoBehaviour
{
    public Vector2 camMaxChange;
    public Vector2 camMinChange;

    public Vector3 playerChange;

    private CameraFollow cam;

    public GameObject Transition;

    public AudioSource sound;

    private void Start()
    {
        cam = Camera.main.GetComponent<CameraFollow>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            TransitionRoom(other);
            sound.Play();
            Transition.SetActive(true);
            StartCoroutine(FadeIn());
        }
    }

    private void TransitionRoom(Collider2D other)
    {
        cam.minPos += camMinChange;
        cam.maxPos += camMaxChange;

        other.transform.position += playerChange;
    }

    public IEnumerator FadeIn()
    {
        Transition.SetActive(true);
        Transition.GetComponent<Animator>().SetBool("FadeIn", true);
        yield return new WaitForSeconds(1);
        Transition.GetComponent<Animator>().SetBool("FadeIn", false);
        Transition.SetActive(false);
    }

    public IEnumerator FadeOut()
    {
        Transition.SetActive(true);
        Transition.GetComponent<Animator>().SetBool("FadeOut", true);
        yield return new WaitForSeconds(1);
        Transition.GetComponent<Animator>().SetBool("FadeOut", false);
    }
}
