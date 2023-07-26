using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TitleScreen : MonoBehaviour
{

    [SerializeField] private Image ttp;

    #region Breathing Effect using DOTween
    private void Update()
    {
        if (ttp.color.a >= 0.9f)
        {
            StartCoroutine(TestFade());
        }
    }
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
        //if (fadeTween != null)
        //{
        //    fadeTween.Kill(false);
        //}

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

    public void OnTap()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainScreen");
    }
}
