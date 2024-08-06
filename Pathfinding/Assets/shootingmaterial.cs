using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class shootingmaterial : MonoBehaviour
{
    public int score=0;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject); // Çarpılan düşmanı yok et
            Destroy(gameObject); // Mermiyi de yok et
            score = score + 5;
            PlayerPrefs.SetInt("Score", score); // Save the score
            PlayerPrefs.Save(); // Save the PlayerPrefs
            Debug.Log("Score: " + score);
            

  
        }
    }
    public void Start()
    {
        score = PlayerPrefs.GetInt("Score", 0);
    }

}

