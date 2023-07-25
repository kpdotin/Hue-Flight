using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndlessScore : MonoBehaviour
{
    float score = 0;
    public TextMeshProUGUI text;
    

    // Update is called once per frame
    void Update()
    {
        text.text = "Score : " + (int)score;
        score += 20 * (Time.deltaTime);
    }
}
