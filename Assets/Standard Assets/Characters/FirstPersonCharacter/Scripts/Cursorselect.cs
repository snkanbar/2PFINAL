using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class Cursorselect : MonoBehaviour
{
    //global variables
    public float Speed = 10.0f;

    public LayerMask SelectMask;
    public LayerMask PlaceMask;
    private RectTransform rect;

    // Start is called before the first frame update
    private void Start()
    {
        rect = GetComponent<RectTransform>();
        //UpdateAllNavMesh();
    }

    private bool _isRelocating = false;
    private GameObject _selectedFactory;

    // Update is called once per frame
    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(rect.position);
        Debug.DrawRay(ray.origin, ray.direction * 100, Color.black);

        RaycastHit hit;
        if (_isRelocating) //has picked up selectable item
        {
            if (Physics.Raycast(ray.origin, ray.direction, out hit, Mathf.Infinity, PlaceMask))
            {
                float yy = _selectedFactory.transform.localScale.y / 2.0f;
                _selectedFactory.transform.position = hit.point + new Vector3(0, yy, 0);
                if (Input.GetButtonDown("East2")) //drop/place item

                {
                    RaycastDestroyer r1 = _selectedFactory.GetComponent<RaycastDestroyer>();
                   
                }
            }
        }
        else //test for selectable item
        {
            if (Physics.Raycast(ray.origin, ray.direction, out hit, Mathf.Infinity, SelectMask))
            {
                Debug.Log("Factory");
                if (Input.GetButtonDown("South")) //pick up item
                {
                    _selectedFactory = hit.transform.gameObject;
                   RaycastDestroyer R2= _selectedFactory.GetComponent<RaycastDestroyer>();
                   
                    _isRelocating = true;
                }
            }
        }


                }
    }




