using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Image ttp;
    [SerializeField] private Image title;
    [SerializeField] GameObject MainPanel; //Parent holding both MainScreen{Panel} and Settings {Panel}
    [SerializeField] GameObject TitlePanel;
    bool titlePanel = false;
    [SerializeField] GameObject MainScreen;

    [SerializeField] GameObject Flight;

    [SerializeField] private Button[] MainScreenObjs;
    [SerializeField] private Image[] LevelScreenObjs; // its supposed to fade in and out the level select objects. UNNECESSARY. REMOVE LATER.

    [SerializeField] Image arcade;
    [SerializeField] Image endless;
    [SerializeField] Image ModeScreenBackButton;
    [SerializeField] GameObject ModeSelectPanel;

    [SerializeField] GameObject SettingsPanel;
    [SerializeField] Image SettingsBg;
    [SerializeField] Button SoundButton;


    bool SoundOn = true;
    [SerializeField] Sprite SoundON;
    [SerializeField] Sprite SoundOFF;

    [SerializeField] GameObject ShopPanel;
    [SerializeField] Image ViewPort;
    [SerializeField] GameObject ShopFlight;

    [SerializeField] GameObject LevelSelectPanel;

    private void Update()
    {
        if (ttp.color.a >= 0.9f && !titlePanel)
        {
            StartCoroutine(TestFade());
        }
        if (SoundOn)
        {
            SoundButton.image.sprite = SoundON;
        }
        else
        {
            SoundButton.image.sprite = SoundOFF;
        }
    }

    #region Breathing Effect using DOTween

    public void FadeIn(float duration)
    {
        Fade(1f, duration);
    }

    public void FadeOut(float duration)
    {
        Fade(0f, duration);
    }

    private void Fade(float endValue, float duration)
    {
        ttp.DOFade(endValue, duration);
    }

    private IEnumerator TestFade()
    {
        yield return new WaitForSeconds(0.75f);
        FadeOut(1f);
        yield return new WaitForSeconds(0.75f);
        FadeIn(1f);
    }
    #endregion 

    public void TitleAnimOut()
    {
        title.transform.DOLocalMove(new Vector3(0, 1081, 0), 0.5f).SetEase(Ease.InOutSine);
        Flight.transform.DOMove(new Vector3(0.05f, 1.46f, -8.35f), 0.5f).SetEase(Ease.InOutSine);
        title.DOFade(0, 0.5f);
        ttp.transform.DOLocalMove(new Vector3(0, -1081, 0), 0.5f).SetEase(Ease.InOutSine).OnComplete(() =>
        {
            MainPanel.SetActive(true);
            titlePanel = true;
            TitlePanel.SetActive(false);
            MainScreenIn();
        });
        ttp.DOFade(0, 0.5f);
    } //Goes to Main Screen

    private void MainScreenIn()
    {
        var sequence = DOTween.Sequence();

        foreach (var shape in MainScreenObjs)
        {
            sequence.Append(shape.image.DOFade(1, 10f));
        }
    } //Enter Anim from Title Screen

    private void MainScreenOut()
    {
        var sequence = DOTween.Sequence();

        foreach (var shape in MainScreenObjs)
        {
            sequence.Append(shape.image.DOFade(0, 10f));
        }
    } //Main Screen Fading to Zero

    public void OnPlayEnter()
    {
        MainScreenOut();
        MainPanel.SetActive(false);
        ModeSelectPanel.SetActive(true);
        endless.DOFade(1, 0.3f);
        endless.transform.DOLocalMoveX(0, 0.5f);
        arcade.DOFade(1, 0.3f);
        arcade.transform.DOLocalMoveX(0, 0.5f);
        ModeScreenBackButton.DOFade(1f, 0.3f);
    } // Goes to Mode Screen from Main Screen

    public void OnModeExit()
    {
        endless.DOFade(0, 0.3f);
        endless.transform.DOLocalMoveX(825, 0.5f);
        arcade.DOFade(0, 0.3f);
        arcade.transform.DOLocalMoveX(-825, 0.5f);
        ModeScreenBackButton.DOFade(0f, 0.3f).OnComplete(() =>
        {
            MainPanel.SetActive(true);
            MainScreenIn();
            ModeSelectPanel.SetActive(false);
        });
    } //Goes to Main Screen from Mode Screen

    public void OnSettingsEnter()
    {
        MainScreenOut();
        MainScreen.SetActive(false);
        SettingsPanel.SetActive(true);
        SettingsBg.DOFade(1, 0.5f);
        SoundButton.image.DOFade(1, 0.5f);
        SettingsBg.transform.DOLocalMoveY(0, 0.5f);
    } //Main Screen to Settings Page

    public void OnSettingExit()
    {
        SettingsBg.DOFade(0, 0.5f);
        SoundButton.image.DOFade(0, 0.5f);
        SettingsBg.transform.DOLocalMoveY(1355, 0.5f).OnComplete(() =>
        {
            MainScreenIn();
            SettingsPanel.SetActive(false);
            MainScreen.SetActive(true);
        });
    } //Settings Page to Main Screen

    public void ToggleSound() {
        SoundOn = !SoundOn;
    } 

    public void OnShopsEnter()
    {
        MainScreenOut();
        MainPanel.SetActive(false);
        Flight.transform.DOMove(new Vector3(1.26199996f, 1.46500003f, -7.91300011f), 0.5f).SetEase(Ease.InOutSine).OnComplete(() =>
        {
            ShopPanel.SetActive(true);
            ViewPort.DOFade(1f, 1f);
            ShopFlight.SetActive(true);
            Flight.transform.position = new Vector3(-0.776000023f, 1.70000005f, -8.68500042f);
            Flight.SetActive(false);
        });
        
        
    }

    public void OnShopsExit()
    {
        ShopPanel.GetComponent<Image>().DOFade(0, 0.5f).OnComplete(() =>
        {
            ViewPort.DOFade(0, 0.5f);
            ShopPanel.SetActive(false);
            Flight.SetActive(true);
            Flight.transform.DOMove(new Vector3(0.05f, 1.46f, -8.35f), 0.5f).SetEase(Ease.InOutSine);
            MainPanel.SetActive(true);
        });
        
    }

    public void LevelSelect()
    {
        string objName = EventSystem.current.currentSelectedGameObject.name;
        UnityEngine.SceneManagement.SceneManager.LoadScene(int.Parse(objName));
    }

    public void OnArcadeEnter()
    {
        endless.DOFade(0, 0.3f);
        endless.transform.DOLocalMoveX(825, 0.5f);
        arcade.DOFade(0, 0.3f);
        arcade.transform.DOLocalMoveX(-825, 0.5f);
        Flight.transform.DOMove(new Vector3(1.26199996f, 1.46500003f, -7.91300011f), 0.5f).SetEase(Ease.InOutSine).OnComplete(() => {
            Flight.transform.position = new Vector3(-0.776000023f, 1.70000005f, -8.68500042f);
            Flight.SetActive(false);
        });
        ModeScreenBackButton.DOFade(0f, 0.3f).OnComplete(() =>
        {
            ModeSelectPanel.SetActive(false);
            LevelSelectPanel.SetActive(true);
            var sequence = DOTween.Sequence();

            foreach (var shape in LevelScreenObjs)
            {
                sequence.Append(shape.DOFade(1, 10f));
            }
        });
    }
    public void OnLevelExit()
    {
        LevelSelectPanel.SetActive(false);
        var sequence = DOTween.Sequence();

        foreach (var shape in LevelScreenObjs)
        {
            sequence.Append(shape.DOFade(0, 10f));
        }
        Flight.SetActive(true);
        Flight.transform.DOMove(new Vector3(0.05f, 1.46f, -8.35f), 0.5f).SetEase(Ease.InOutSine);
        MainPanel.SetActive(true);
        MainScreenIn();
    }

    public void OnSampleLevel()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(12);
    }

}
