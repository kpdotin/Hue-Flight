using Newtonsoft.Json;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
public class ShopManager : MonoBehaviour
{
    public class Status
    {
        public int Orbs { get; set; }
    }

    [SerializeField] Mesh[] meshes;
    private MeshFilter meshFilter;

    [SerializeField] MeshFilter mainFlightMesh;

    [SerializeField] TextMeshProUGUI OrbsText;

    void Start()
    {
        meshFilter = GetComponent<MeshFilter>();
        DeserilizeData();
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
    public void ClickedOK()
    {
        if(meshFilter.mesh != null)
        {
            mainFlightMesh.mesh = meshFilter.mesh;
        }
        DisplayFlight.OnUpdateRotation();
    }

    public void DeserilizeData()
    {
        Status incoming = new Status();
        if (!File.Exists(Application.persistentDataPath + "/playerData.json"))
        {
            using FileStream stream = File.Create(Application.persistentDataPath + "/playerData.json");
            stream.Close();
        }
        using StreamReader reader = new StreamReader(Application.persistentDataPath + "/playerData.json");
        {
            string line = reader.ReadToEnd();
            reader.Close();
            if (JsonConvert.DeserializeObject<Status>(line) == null)
            {
                incoming.Orbs = 0;
            }
            else
            {
                incoming = JsonConvert.DeserializeObject<Status>(line);
            }
        }
        OrbsText.text = "Orbs : " + incoming.Orbs.ToString(); 
    }
}
