using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endScene : MonoBehaviour
{

    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(GameObject other)
    {
        animator.SetTrigger("FadeOUT");
    }
}
