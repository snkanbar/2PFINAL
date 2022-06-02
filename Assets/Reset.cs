using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reset : MonoBehaviour
{

    // Update is called once per frame
    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.R))
        if(Input.GetButtonDown("West"))
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name, LoadSceneMode.Single);

        }

        if (Input.GetButtonDown("West2"))
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name, LoadSceneMode.Single);

        }
    }
}