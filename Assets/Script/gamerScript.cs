using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gamerScript : MonoBehaviour
{
    // Start is called before the first frame update
    int speed = 1;//»Ø¸´ËÙ¶È
    bool move_switch = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x != 0)
        {
            move_switch = true;
        }
        else
        {
            move_switch = false;
        }
        if (move_switch)
        {
            if (transform.position.x > 0)
            transform.position = transform.position - new Vector3(speed*Time.deltaTime, 0, 0);
            else
            {
                transform.position = new Vector3(0, 0, 0);
            }
        }
    }


}
