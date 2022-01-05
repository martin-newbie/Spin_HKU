using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleUIManager : MonoBehaviour
{

    [SerializeField] Text bestScore;

    [Header("Setting")]
    [SerializeField] GameObject SettingObject;
    [SerializeField] Slider background_volume_slider;
    [SerializeField] Slider effect_volume_slider;

    [Header("Description")]
    [SerializeField] GameObject DescObject;

    void Start()
    {
        InitializeValue();
        ExitSetting();
        ExitDesc();

        bestScore.text = string.Format("{0:0}", StatusManager.Instance.best_record) + "s";
    }

    void Update()
    {
    }

    void InitializeValue()
    {
        background_volume_slider.value = StatusManager.Instance.background_volume;
        effect_volume_slider.value = StatusManager.Instance.effect_volume;
    }

    public void StartGame()
    {
        SceneManager.LoadScene("InGameScene");
        SoundManager.Instance.SoundPlay(0, false);
    }

    void SetVolume()
    {
        StatusManager.Instance.background_volume = background_volume_slider.value;
        StatusManager.Instance.effect_volume = effect_volume_slider.value;
    }

    public void EnterSetting()
    {
        SettingObject.SetActive(true);
        SoundManager.Instance.SoundPlay(0, false);
    }

    public void ExitSetting()
    {
        SetVolume();
        SettingObject.SetActive(false);
        SoundManager.Instance.SoundPlay(0, false);
    }

    public void EnterDesc()
    {
        DescObject.SetActive(true);
        SoundManager.Instance.SoundPlay(0, false);
    }

    public void ExitDesc()
    {
        DescObject.SetActive(false);
        SoundManager.Instance.SoundPlay(0, false);
    }
}
