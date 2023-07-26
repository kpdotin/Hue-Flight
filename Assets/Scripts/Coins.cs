using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        FindObjectOfType<InGameUI>().OnCoinCollected();
        Destroy(gameObject);
    }

}
