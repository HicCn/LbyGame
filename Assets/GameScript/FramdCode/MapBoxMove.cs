using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FramdCode;

public class MapBoxMove : MonoBehaviour
{
    Vector2 dir= new Vector2(-1, 0);
    float speed = BasicDefine.BoxSpeed;
    bool lockBox = true;
    private void Start()
    {
        EventModel.AddObserver(EventId.boxMove, boxMoveContror);
    }
    private void Update()
    {
        transform.Translate(dir*speed * Time.deltaTime);
        if(transform.position.x <= -BasicDefine.MapWidthLen-BasicDefine.BoxWidthLen) MapBoxControl.BackToQueue(gameObject);
    }

    private void boxMoveContror(EventObject e)
    {
        speed = BasicDefine.BoxSpeed;
    }
}
