using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FramdCode;

public class StartGame : MonoBehaviour
{
    public static float DecisionLine = 0;
    public static int score = 0;
    GamerControl gamer;
    double timeIns;
    float loopTime = 0;
    MapBoxControl boxControl;
    // Start is called before the first frame update
    void Start()
    {
        timeIns = BasicDefine.BoxWidthLen / BasicDefine.BoxSpeed;
    }

    private void Awake()
    {
        gamer = new GamerControl();
        boxControl = new MapBoxControl();
    }
    // Update is called once per frame
    void Update()
    {
        loopTime += Time.deltaTime;
        if (loopTime >= timeIns)
        {
            loopTime = 0;
            boxControl.GetObject();
        }
        //�������λ������
       // DecisionLine = gamer.GetXplace();
    }
}
