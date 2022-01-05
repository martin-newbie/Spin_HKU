using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : PoolObject
{
    [SerializeField] GameObject[] obstacle_count;

    void Start()
    {
        InitializeObstacle(Random.Range(0, obstacle_count.Length));
    }

    void Update()
    {
        transform.Translate(Vector3.back * Time.deltaTime * GameManager.Instance.object_movespeed);
    }

    private void OnBecameInvisible()
    {
        Push();
    }

    GameObject InitializeObstacle(int n)
    {
        foreach (var item in obstacle_count)
        {
            item.SetActive(false);
        }
        obstacle_count[n].SetActive(true);

        var boxes = obstacle_count[n].GetComponentsInChildren<MeshRenderer>();
        foreach (var item in boxes)
        {
            int rand = Random.Range(0, GameManager.Instance.object_materials.Length);
            item.material = GameManager.Instance.object_materials[rand];
            item.GetComponent<Collider>().enabled = true;
        }

        return obstacle_count[n];
    }

    public override void InitializeValue(Vector3 spawnPos)
    {
        base.InitializeValue(spawnPos);
        int rand_cnt = Random.Range(0, obstacle_count.Length);
        GameObject temp = InitializeObstacle(rand_cnt);

        float rand_rot = Random.Range(0, 360);
        temp.transform.localRotation = Quaternion.Euler(0, 0, rand_rot);

        var colliders = GetComponentsInChildren<Collider>();
        foreach (var item in colliders)
        {
            item.enabled = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("EndPos"))
        {
            Push();
        }
    }
}
