using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MainHeroMovement : MonoBehaviour
{
    [SerializeField] private Camera Cam;
    [SerializeField] private float speed;
    Vector2 lastClickedPos;
    bool moving;
    void Update()
    {
        if(!Visability.IsTargetVisible(transform.position))
        {
            transform.position += new Vector3(1, 0, 0);
        }
        if(Input.GetMouseButtonDown(0))
        {
            lastClickedPos = Cam.ScreenToWorldPoint(Input.mousePosition);
            moving = true;
        }

        if(moving && (Vector2)transform.position != lastClickedPos)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, lastClickedPos, step);
        }
        else
        {
            moving = false;
        }
    }
}
