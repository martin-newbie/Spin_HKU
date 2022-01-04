using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Renderer m_Renderer;
    public float hp = 100;

    void Start()
    {
        m_Renderer.material = GameManager.Instance.object_materials[Random.Range(0, 3)];
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Object"))
        {
            if (other.GetComponent<MeshRenderer>().material.color == m_Renderer.material.color)
            {
                hp += 10;
            }
            else
            {
                hp -= 10;
                other.GetComponent<Collider>().enabled = false;
                StartCoroutine(HitSlow(0.2f));
            }

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
