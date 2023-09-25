using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Make sure to add this, or you can't use SceneManager
using UnityEngine.SceneManagement;


public class Level_Change : MonoBehaviour
{
    private int levelIndex = 0;
    void OnTriggerEnter2D(Collider2D other)
    {
        //other.name should equal the root of your Player object
        if (other.tag == "Player")
        {
            //The scene number to load (in File->Build Settings)
            GameObject.FindGameObjectWithTag("SceneManager").GetComponent<GameSceneManager>().LoadScene(levelIndex);
        }
    }
}