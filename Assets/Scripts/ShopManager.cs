using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShopManager : MonoBehaviour
{
    [SerializeField] Mesh[] meshes;
    private MeshFilter meshFilter;
    
    // Start is called before the first frame update
    void Start()
    {
        meshFilter = GetComponent<MeshFilter>();
    }
    
    public void OnClick()
    {
        string objName = EventSystem.current.currentSelectedGameObject.name;
        if (objName == "2")
        {
            meshFilter.mesh = meshes[int.Parse(objName) - 1];
            transform.rotation = Quaternion.Euler(new Vector3(307.757446f, 206.930649f, 122.409653f));
        }
        else
        {
            meshFilter.mesh = meshes[int.Parse(objName) - 1];
            transform.rotation = Quaternion.Euler(new Vector3(305.474304f, 211.14621f, 293.921997f));
        }
    }

}
