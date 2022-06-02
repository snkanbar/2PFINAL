using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastDestroyer : MonoBehaviour
{
    private Transform cameraTransform;
    public Camera cam;
    public GameObject cam1;





    void Start()
    {
        cameraTransform = GameObject.Find("Camera").transform;
        //cam = cameraTransform.camera;
        cam1.SetActive(false);
            
       
        
    }
    void Update()
    {
        {
            {
                Vector3 forward = transform.TransformDirection(Vector3.forward) * 100;
                Debug.DrawRay(transform.position, forward, Color.red);
                
            }
        }

        {
            if (Input.GetButtonDown("East2"))
            {
                cam1.SetActive(true);
                Ray ray = cam.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, 10000))
                {
                    Debug.DrawLine(ray.origin, hit.point);
                    Debug.Log("Clicked on " + hit.transform.gameObject.name);

                    
                    
                    Destroy(hit.transform.gameObject);
                    //cam1.SetActive(true);




                    /*if (name.ToLower().Contains("plane"))
                    {
                        Destroy(hit.transform.gameObject);
                    }*/

                }
                cam1.SetActive(true);
            }
        }
    }
    
}

