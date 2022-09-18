using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxScript : MonoBehaviour
{
    public static float Speed;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + new Vector3(Time.deltaTime * Speed *-1, 0,0);
        die();
    }
    void die()
    {
        if(this.transform.position.x < -20)
        {
            Destroy(gameObject);
        }
    }           
}
