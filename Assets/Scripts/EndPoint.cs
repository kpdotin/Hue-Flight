using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPoint : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(11);
    }
}
