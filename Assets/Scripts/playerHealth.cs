using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playerHealth : MonoBehaviour
{
  
    public int health = 4;
    public int numberOfBars = 4;
    
    public Image[] healthBar;
    public Sprite fullBar;
    public Sprite emptyBar;
    public Animator animator;
    

  

    private void Update()
    {

        for (int i = 0; i < healthBar.Length; i++)
        {
            if (i < health)
            { healthBar[i].sprite = fullBar; }
            else
            { healthBar[i].sprite = emptyBar; }

            if (i < numberOfBars)
            { healthBar[i].enabled = true; }
            else
            { healthBar[i].enabled = false; }
        }
    }
    private void OnParticleCollision(GameObject other)
    {

        health--;


        if (health == 0)
        {
            animator.SetTrigger("FadeOUT");
            SceneManager.LoadScene("SkyShooter");
            
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(other.transform.parent.gameObject);
            Debug.Log("hit evil man");
            health--;
            if (health == 0)
            {
                animator.SetTrigger("FadeOUT");
                SceneManager.LoadScene("SkyShooter");

            }
        }

        if (other.gameObject.tag == "EndTrigger")
        {
            Debug.Log("are we even here");
            animator.SetTrigger("FadeOUT");
        }
    }
}
