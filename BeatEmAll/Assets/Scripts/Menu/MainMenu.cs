using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class MainMenu : MonoBehaviour
{
    public Image ImageFade;
    public List<MainMenuButton> Buttons;
    public GameObject Menu;
    public GameObject MenuStart;
    public CanvasGroup Options;
    public CanvasGroup Credits;
    public Animator MenuStartAnimator;
    public Animator MainMenuAnimator;
    public AudioSource BackgroundMusic;

    private static MainMenu _instance;

    public static MainMenu Instance { get { return _instance; } }


    private void Awake()
    {
        Screen.fullScreen=true;
        Cursor.visible = true;
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }
    public void OnClickPlay()
    {
        ImageFade.DOFade(1, 0.8f).OnComplete(FadeComplete);
        for (int i = 1; i < Buttons.Count; i++)
        {
            Buttons[i].Hide(0.1f);
        }
    }

    public void FadeComplete()
    {
        SceneManager.LoadScene("MainGame");
    }

    public void OnClickOptions()
    {
        Options.gameObject.SetActive(true);
        Options.alpha = 0;
        Options.DOFade(1, 0.2f);
    }

    public void OnClickCredits()
    {
       Credits.gameObject.SetActive(true);
        Credits.alpha = 0;
        Credits.DOFade(1, 0.2f);
    }

    public void OnMusicValueChanged(float newValue)
    {
        BackgroundMusic.volume = newValue;
    }

    public void OnResolutionChanged(int newValue)
    {
        if (newValue == 0)
            Screen.SetResolution(1920, 1080, true);
        if (newValue == 1)
            Screen.SetResolution(1024, 768, true);
        if (newValue == 2)
            Screen.SetResolution(1280, 720, true);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            MenuStartAnimator.SetTrigger("OnFade");
            MainMenuAnimator.SetTrigger("OnFadeMenu");
        }

        if (Input.GetKeyDown(KeyCode.Escape) && Options.gameObject.activeInHierarchy)
        {
            Options.DOFade(0, 0.2f).OnComplete(() => { Options.gameObject.SetActive(false); });
        }

        if (Input.GetKeyDown(KeyCode.Escape) && Credits.gameObject.activeInHierarchy)
        {
            Credits.DOFade(0, 0.2f).OnComplete(() => { Credits.gameObject.SetActive(false); });
        }
    }
    public void Quit()
    {
        Application.Quit();
    }
}
