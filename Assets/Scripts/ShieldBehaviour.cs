using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldBehaviour : MonoBehaviour
{
    AsteroidRotate obstacleCondition;
    InGameUI timerCondition;
    ShieldPower shieldEvent;
    bool shieldIsOn = false;
    public GameObject sphere;
    // Start is called before the first frame update
    void Start()
    {
        obstacleCondition = FindObjectOfType<AsteroidRotate>();
        timerCondition = FindObjectOfType<InGameUI>();
        shieldEvent = FindObjectOfType<ShieldPower>();
    }

    private void OnEnable()
    {
        shieldEvent.shieldEvent += ShieldIsOn;
    }
    private void OnDisable()
    {
        shieldEvent.shieldEvent -= ShieldIsOn;
    }
    // Update is called once per frame
    void Update()
    {

        if (!obstacleCondition.shieldOn || !timerCondition.shieldTimerOn)
        {
            ShieldIsOn();
        }
        if (shieldIsOn)
        {
            sphere.SetActive(true);
        }
    }

    void ShieldIsOn()
    {
        shieldIsOn = !shieldIsOn;
    }


}
