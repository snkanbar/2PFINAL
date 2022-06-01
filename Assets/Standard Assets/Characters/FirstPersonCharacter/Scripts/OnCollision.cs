using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;


public class OnCollision : MonoBehaviour
{
    
    //public GameObject trophy;
    public Text GameOverP2;
    

    // Start is called before the first frame update
    void Start()
    {
        GameOverP2.enabled = false;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameOverP2.enabled = true;
        }
    }

    /*void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
           GameOverP2.enabled = true;
        }           
        
    }*/


}


