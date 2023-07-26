using TMPro;
using UnityEngine;

public class RailingCollision : MonoBehaviour
{
    public TextMeshProUGUI text;
    private void OnCollisionEnter(Collision collision)
    {
        Invoke("LoadScene", 0.25f);
        text.text = "uh oh, HIT!!!";
    }

    void LoadScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameOver");

    }
}
