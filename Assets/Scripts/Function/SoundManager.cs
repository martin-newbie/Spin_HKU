using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{

    [SerializeField] List<AudioClip> clipList = new List<AudioClip>();
    [SerializeField] List<AudioClip> background_list = new List<AudioClip>();

    [SerializeField] AudioSource BackgroundMusic;

    private void Awake()
    {
        DontDestroyOnLoad(this);
        BackgroundMusic = GetComponent<AudioSource>();
    }

    private void Update()
    {
        BackgroundMusic.volume = StatusManager.Instance.background_volume;
    }

    public void SoundPlay(int index, bool _loop = false)
    {
        GameObject sound_object = new GameObject(clipList[index].name);
        AudioSource audio_source = sound_object.AddComponent<AudioSource>();
        audio_source.volume = StatusManager.Instance.effect_volume;
        audio_source.clip = clipList[index];
        audio_source.loop = _loop;
        audio_source.Play();

        Destroy(sound_object, clipList[index].length);
    }

    public void SoundPlay(AudioClip _clip, bool _loop = false)
    {
        GameObject sound_object = new GameObject(_clip.name);
        sound_object.transform.SetParent(this.transform);
        AudioSource audio_source = sound_object.AddComponent<AudioSource>();
        audio_source.volume = StatusManager.Instance.effect_volume;
        audio_source.clip = _clip;
        audio_source.loop = _loop;
        audio_source.Play();
        Destroy(sound_object, _clip.length);
    }

    public void BackgroundPlay(int index, bool _loop = true)
    {
        BackgroundMusic.clip = background_list[index];
        BackgroundMusic.loop = _loop;
        BackgroundMusic.Play();
    }
}
