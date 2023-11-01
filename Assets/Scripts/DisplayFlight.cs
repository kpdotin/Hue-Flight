using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayFlight : MonoBehaviour
{
    [SerializeField] Mesh primaryMesh;
    [SerializeField]GameObject fireTrail;
    MeshFilter shipMeshFilter;

    public delegate void UpdateRotation();
    public static UpdateRotation OnUpdateRotation;
    // Start is called before the first frame update
    void Start()
    {
        shipMeshFilter = GetComponent<MeshFilter>();
        OnUpdateRotation += UpdateRotationOfFlight;
    }

    
    // Update is called once per frame
    void UpdateRotationOfFlight()
    {
        if(shipMeshFilter.mesh.GetInstanceID() == primaryMesh.GetInstanceID())
        {
            transform.localEulerAngles = new Vector3(-116,-316,-60);
        }
        else
        {
            transform.localEulerAngles = new Vector3(-128,-320,118);
        }
    }
}
