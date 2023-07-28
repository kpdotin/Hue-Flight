
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StinkyCloudScript : MonoBehaviour
{
    public delegate void CloudCollision();
    public event CloudCollision OnCloudCollision;

    bool collided = false;
    float timer ;
    public float PublicTimer = 10f;

    private void Start()
    {
        timer = PublicTimer;
    }
    private void Update()
    {
        if (collided)
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;
            }
            else
            {
                collided = false;
                OnCloudCollision();
                timer = PublicTimer;
            }
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        OnCloudCollision();
        collided = true;
    }
}
