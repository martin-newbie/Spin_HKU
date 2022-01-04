using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleUIManager : MonoBehaviour
{
    [Header("Setting")]
    [SerializeField] GameObject SettingObject;
    [SerializeField] Slider background_volume_slider;
    [SerializeField] Slider effect_volume_slider;

    void Start()
    {
        InitializeValue();
        ExitSetting();
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
    }

    void SetVolume()
    {
        StatusManager.Instance.background_volume = background_volume_slider.value;
        StatusManager.Instance.effect_volume = effect_volume_slider.value;
    }

    public void EnterSetting()
    {
        SettingObject.SetActive(true);
    }

    public void ExitSetting()
    {
        SetVolume();
        SettingObject.SetActive(false);
    }
}
