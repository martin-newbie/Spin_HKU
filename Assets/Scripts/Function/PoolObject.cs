using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolObject : MonoBehaviour
{
    GameManager gameManager;
    public virtual void Create(GameManager manager)
    {
        gameManager = manager;
        gameObject.SetActive(false);
    }

    public virtual void Push()
    {
        gameManager.Push(this);
    }

    public virtual void InitializeValue(Vector3 spawnPos)
    {
        transform.localPosition = spawnPos;
    }
}
