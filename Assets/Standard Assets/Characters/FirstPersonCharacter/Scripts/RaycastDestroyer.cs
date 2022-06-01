using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastDestroyer : MonoBehaviour
{
    private Transform cameraTransform;
    public Camera cam;



    void Start()
    {
        cameraTransform = GameObject.Find("Camera").transform;
        //cam = cameraTransform.camera;
    }
    void Update()
    {
        {
            {
                Vector3 forward = transform.TransformDirection(Vector3.forward) * 100;
                Debug.DrawRay(transform.position, forward, Color.white);
            }
        }

        {
            if (Input.GetButtonDown("East2"))
            {

                Ray ray = cam.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, 10000))
                {
                    Debug.DrawLine(ray.origin, hit.point);
                    Debug.Log("Clicked on " + hit.transform.gameObject.name);
                    Destroy(hit.transform.gameObject);


                    /*if (name.ToLower().Contains("plane"))
                    {
                        Destroy(hit.transform.gameObject);
                    }*/

                }
            }
        }
    }
    
}

