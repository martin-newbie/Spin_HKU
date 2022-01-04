using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMainController : MonoBehaviour
{

    [SerializeField] float speed;
    [SerializeField] float offset;

    Vector3 firstPos;
    Vector3 lastPos;

    void Start()
    {

    }

    void Update()
    {
        if (GameManager.Instance.state == GameState.GameActive)
            DragLogic();
    }

    void DragLogic()
    {
        if (Input.GetMouseButtonDown(0))
        {
            firstPos = Input.mousePosition;
        }
        if (Input.GetMouseButton(0))
        {
            lastPos = Input.mousePosition;

            float angle = Mathf.Atan2(lastPos.x - firstPos.x, lastPos.y - firstPos.y) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.Euler(angle, 90, -90);
        }
    }
}
