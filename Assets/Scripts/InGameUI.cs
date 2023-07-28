using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InGameUI : MonoBehaviour
{
    public delegate void CoinCollected();
    public CoinCollected OnCoinCollected;

    public Button colorChangeButton;
    public Sprite RedButton;
    public Sprite BlueButton;

    private ColorChange colorChangeScript;
    int coinsCollected;
    public TextMeshProUGUI orbsText;

    public GameObject pausePanel;

    public TextMeshProUGUI displayTimer;

    //ShieldPower shieldPower;
    AsteroidRotate obstacleCollision;
    public bool shieldTimerOn = false;
    int shieldTimer = 10;
    private void Start()
    {
        obstacleCollision = FindObjectOfType<AsteroidRotate>();
        //shieldPower = FindObjectOfType<ShieldPower>();
        colorChangeScript = FindObjectOfType<ColorChange>();
    }
    private void OnEnable()
    {
        OnCoinCollected += CoinUpdater;
        //shieldPower.shieldEvent += ShieldToggle;
    }
    private void OnDisable()
    {
        OnCoinCollected -= CoinUpdater;
        //shieldPower.shieldEvent -= ShieldToggle;
    }
    // Update is called once per frame
    void Update()
    {
        orbsText.text = "Orbs : " + coinsCollected.ToString();

        if (shieldTimerOn)
        {
            if(shieldTimer > 0)
            {
                displayTimer.text ="Shield Time Left : " + shieldTimer.ToString();
                shieldTimer -= (int)Time.deltaTime;
            }
            else
            {
                ShieldToggle();
                shieldTimer = 10;
                obstacleCollision.shieldOn = false;
            }
        }

        if (colorChangeScript.toggleColor)
        {
            colorChangeButton.image.sprite = RedButton;
        }
        else
        {
            colorChangeButton.image.sprite = BlueButton;
        }
    }

    void CoinUpdater()
    {
        coinsCollected++;
    }

    public void PauseGame()
    {
        pausePanel.SetActive(true);
        colorChangeButton.interactable = false;
        colorChangeButton.image.enabled = false;
        Time.timeScale = 0f;
    }
    public void ResumeGame()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
        colorChangeButton.interactable = true;
        colorChangeButton.image.enabled = true;

    }

    public void Back()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }

    void ShieldToggle()
    {
        shieldTimerOn = !shieldTimerOn;
    }
}
