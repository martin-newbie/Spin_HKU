using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{

    List<AudioClip> clipList = new List<AudioClip>();

    public void SoundPlay(int index, bool _loop)
    {
        GameObject sound_object = new GameObject(clipList[index].name);
        AudioSource audio_source = sound_object.AddComponent<AudioSource>();
        audio_source.clip = clipList[index];
        audio_source.loop = _loop;
        audio_source.Play();

        Destroy(sound_object, clipList[index].length);
    }

    public void SoundPlay(AudioClip _clip, bool _loop)
    {
        GameObject sound_object = new GameObject(_clip.name);
        AudioSource audio_source = sound_object.AddComponent<AudioSource>();
        audio_source.clip = _clip;
        audio_source.loop = _loop;
        audio_source.Play();

        Destroy(sound_object, _clip.length);
    }
}
