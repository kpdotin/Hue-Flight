using UnityEngine;
using UnityEngine.SceneManagement;

public class ColorChange : MonoBehaviour
{
    public bool toggleColor = false;
    private Material playerMat;
    [SerializeField] Material Red;
    [SerializeField] Material Blue;
    Scene scene;
    private void Awake()
    {
        playerMat = GetComponent<Renderer>().material;
        
    }
    public void ChangeColor()
    {
        toggleColor = !toggleColor;
    }

    private void Update()
    {
        if (!toggleColor)
        {
            playerMat.color = Red.color;
        }
        else
        {
            playerMat.color = Blue.color;
        }
    }
}
