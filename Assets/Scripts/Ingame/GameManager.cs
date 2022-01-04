using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public enum GameState
{
    GameActive,
    GameOver,
    GamePaused
}

public class GameManager : Singleton<GameManager>
{
    [SerializeField] PlayerController player;
    public Stack<PoolObject> obstacle_pool = new Stack<PoolObject>();
    [SerializeField] ObstacleController object_prefab;
    [SerializeField] int object_count = 10;

    public float object_movespeed = 5f;
    [SerializeField] Transform object_spawn_parent;
    [SerializeField] Vector3 v_objectSpawnPosition;

    [SerializeField] float spawnTime;
    Coroutine cur_play_routine;
    bool isGameOver;

    int randKind = 0;

    public Material[] object_materials;
    [SerializeField] TextMesh score_txt;
    float score = 0;

    public GameState state = 0;

    [SerializeField] GameObject GameOverObj;
    [SerializeField] Text GameResult;

    [SerializeField] Image BestScoreImg;

    void Start()
    {
        InitializeStack();
        cur_play_routine = StartCoroutine(ObstacleSpawn());
        GameOverObj.SetActive(false);
        BestScoreImg.gameObject.SetActive(false);
    }

    void Update()
    {
        switch (state)
        {
            case GameState.GameActive:
                if (isGameOver)
                {
                    StopCoroutine(cur_play_routine);
                    state = GameState.GameOver;
                }

                score += Time.deltaTime;
                score_txt.text = ((int)score).ToString() + "s";
                break;
            case GameState.GameOver:
                GameOverObj.SetActive(true);
                GameResult.text = "Your Score: " + ((int)score).ToString() + "s";

                if (StatusManager.Instance.best_record < score)
                {
                    BestScoreImg.gameObject.SetActive(true);
                    StatusManager.Instance.best_record = score;
                }
                object_movespeed = 0;
                break;
            case GameState.GamePaused:
                break;
            default:
                break;
        }
    }

    IEnumerator ObstacleSpawn()
    {
        while (!isGameOver)
        {
            int rand = Random.Range(1, 8);

            Pop();
            randKind++;
            yield return new WaitForSeconds(spawnTime);

            if (randKind % rand == 0)
            {
                int randcnt = Random.Range(0, object_materials.Length);
                player.m_Renderer.material = object_materials[randcnt];
                randKind = 0;
            }
        }
    }

    void InitializeStack()
    {
        for (int i = 0; i < object_count; i++)
        {
            PoolObject pool_temp = Instantiate(object_prefab, v_objectSpawnPosition, Quaternion.identity, object_spawn_parent);
            pool_temp.Create(this);
            obstacle_pool.Push(pool_temp);
        }
    }

    public PoolObject Pop()
    {
        PoolObject obj_temp = obstacle_pool.Pop();
        obj_temp.gameObject.SetActive(true);
        obj_temp.InitializeValue(v_objectSpawnPosition);
        return obj_temp;
    }

    public void Push(PoolObject obj)
    {
        obj.gameObject.SetActive(false);
        obstacle_pool.Push(obj);
    }
}
