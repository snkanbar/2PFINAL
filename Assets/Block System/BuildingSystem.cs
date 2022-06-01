using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSystem : MonoBehaviour
{
    public LayerMask Mask;
    public LayerMask DontDestroy;
    public GameObject BlockGUIPrefab;
    public GameObject BlockPrefab;

    public Camera _camera;
    private GameObject _blockGUI;
    private bool _canBuild = false;
    private BlockSystem _blockSystem;
    private Vector3 _buildPos;
    private int typeSelect = 0;
    private GameObject Nono;
    // Start is called before the first frame update
    private void Start()
    {
        _blockSystem = GetComponent<BlockSystem>();
        _blockGUI = Instantiate(BlockGUIPrefab, _buildPos, Quaternion.identity);
    }

    // Update is called once per frame
    private void Update()
    {
        //find block build location
        RaycastHit hit;

        if (Physics.Raycast(_camera.ScreenPointToRay(new Vector3(Screen.width / 4, Screen.height / 2, 0)), out hit, 10, Mask))
        {
            Vector3 pos = hit.point;
            _buildPos = new Vector3(Mathf.Round(pos.x), Mathf.Round(pos.y), Mathf.Round(pos.z));
            _canBuild = true;
            Nono = hit.transform.gameObject;
        }
        else
        {
            _canBuild = false;
        }

        //loop through types
        if (Input.GetButtonDown("South"))
        {
            typeSelect++;
            if (typeSelect >= _blockSystem.Blocks.Count)
            { 
                typeSelect = 0; 
            }
        }

        
        //build block
        if (_canBuild == true)
        {
            _blockGUI.transform.position = _buildPos; //update transparent location

            if (Input.GetButtonDown("South"))
            {
                PlaceBlock();                
            }

            if (Input.GetButtonDown("North"))
            {
                DestroyBlock();
            }
        }
    }

    private void PlaceBlock()
    {
        GameObject block = Instantiate(BlockPrefab, _buildPos, Quaternion.identity);
        Block type = _blockSystem.Blocks[typeSelect];
        block.name = type.BlockName;
        block.GetComponent<MeshRenderer>().material = type.BlockMaterial;
    }
    private void DestroyBlock()
    {
        Destroy(Nono);        
    }
}