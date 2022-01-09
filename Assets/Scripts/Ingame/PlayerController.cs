using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    [SerializeField] Image HPbar;

    public Renderer m_Renderer;
    public float hp = 100;

    [SerializeField] ParticleSystem Hit;
    [SerializeField] ParticleSystem Heal;

    void Start()
    {
        m_Renderer.material = GameManager.Instance.object_materials[Random.Range(0, 3)];
    }

    void Update()
    {
        HPbar.fillAmount = hp / 100;

        if (hp <= 0) GameManager.Instance.state = GameState.GameOver;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Object"))
        {
            if (other.GetComponent<MeshRenderer>().material.color == m_Renderer.material.color)
            {
                hp += 10;
                SoundManager.Instance.SoundPlay(2, false);
                Heal.Play();
            }
            else
            {
                hp -= 10;
                SoundManager.Instance.SoundPlay(3, false);
                StartCoroutine(HitSlow(0.2f));
                GameManager.Instance.object_movespeed = 3f;
                GameManager.Instance.spawnTime = 3f;
                Hit.Play();
            }
            
            other.GetComponent<Collider>().enabled = false;
            hp = Mathf.Clamp(hp, 0, 100);
        }
    }

    IEnumerator HitSlow(float duration)
    {
        Time.timeScale = 0.2f;
        yield return new WaitForSecondsRealtime(duration);
        Time.timeScale = 1;
    }
}
