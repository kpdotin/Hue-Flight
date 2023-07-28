using UnityEngine;
using System.Collections;

public class AsteroidRotate : MonoBehaviour
{
    [SerializeField]
    private float tumble = 1;
    ShieldPower shieldPower;
    InGameUI timerCondition;
    public bool shieldOn = false;
    void Start()
    {
        GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere * tumble;
        //shieldPower = FindObjectOfType<ShieldPower>();
        //timerCondition = FindObjectOfType<InGameUI>();
    }

    private void OnEnable()
    {
        //shieldPower.shieldEvent += ShieldToggle;
    }

    private void OnDisable()
    {
        //shieldPower.shieldEvent -= ShieldToggle;
    }
    void ShieldToggle()
    {
        shieldOn = !shieldOn;
    }

    //private void OnCollisionEnter(Collision collision)
    //{
        //if (!shieldOn || !timerCondition.shieldTimerOn)
        //{
        //    UnityEngine.SceneManagement.SceneManager.LoadScene(10);
        //}
        //else
        //{
        //    ShieldToggle();
        //}
        //UnityEngine.SceneManagement.SceneManager.LoadScene(10);
    //}
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(10);
        }
    }
}