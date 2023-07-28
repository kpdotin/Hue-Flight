using TMPro;
using UnityEngine;

public class InGameUI : MonoBehaviour
{
    public delegate void CoinCollected();
    public CoinCollected OnCoinCollected;

    int coinsCollected;
    public TextMeshProUGUI coinsText;
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
        coinsText.text = "Orbs : " + coinsCollected.ToString();
    }

    void CoinUpdater()
    {
        coinsCollected++;
    }
}
