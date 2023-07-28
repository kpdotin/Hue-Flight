using DG.Tweening;
using TMPro;
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

    
    private void Start()
    {
        colorChangeScript = FindObjectOfType<ColorChange>();
    }
    private void OnEnable()
    {
        OnCoinCollected += CoinUpdater;
    }
    private void OnDisable()
    {
        OnCoinCollected -= CoinUpdater;
    }
    // Update is called once per frame
    void Update()
    {
        orbsText.text = "Orbs : " + coinsCollected.ToString();
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
    }
}
