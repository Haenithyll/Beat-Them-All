using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SliderValues : MonoBehaviour
{
    public TMPro.TextMeshProUGUI TextValue;
    public Slider Slider;
    public AudioMixer Mixer;

    public void OnValueChange(float newValue)
    {
        int valueInt = (int)Mathf.Round(newValue * 100.0f);
        TextValue.text = valueInt.ToString();
        MainMenu.Instance.OnMusicValueChanged(newValue);
    }

    public void OnSFXValueChange(float newValue)
    {
        int valueInt = (int)Mathf.Round(newValue * 100.0f);
        TextValue.text = valueInt.ToString();

        if (newValue < 0.01f)
            newValue = 0.01f;

        float volume = Mathf.Log10(newValue) * 20;
        Mixer.SetFloat("SFX_Volume", volume);
    }
}
