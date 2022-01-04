using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InGameUIManager : MonoBehaviour
{

    [SerializeField] GameObject PauseObj;

    [SerializeField] Slider background_volume;
    [SerializeField] Slider effect_volume;

    void Start()
    {
        InitializeValue();
        PauseObj.SetActive(false);
    }

    void Update()
    {

    }

    void InitializeValue()
    {
        background_volume.value = StatusManager.Instance.background_volume;
        effect_volume.value = StatusManager.Instance.effect_volume;
    }

    void SetValue()
    {
        StatusManager.Instance.background_volume = background_volume.value;
        StatusManager.Instance.effect_volume = effect_volume.value;
    }

    public void OnPause()
    {
        if (GameManager.Instance.state == GameState.GameActive)
        {
            Time.timeScale = 0f;
            PauseObj.SetActive(true);
            GameManager.Instance.state = GameState.GamePaused;
        }
    }

    public void OffPause()
    {
        Time.timeScale = 1f;
        GameManager.Instance.state = GameState.GameActive;
        SetValue();
        PauseObj.SetActive(false);
    }

    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("TitleScene");
    }

    public void Replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
