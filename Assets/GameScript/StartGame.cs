using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FramdCode;

public class StartGame : MonoBehaviour
{
    public static float DecisionLine = 0;
    public static int score = 0;

    float mainTime = 0;
    int index;

    LogicalControl logicalControl;
    MapBoxControl boxControl;
    GamerControl gamerControl;

    songBasic exmSong;

    // Start is called before the first frame update
    void Start()
    {
        index = 0;
        logicalControl = LogicalControl.Instance();
        boxControl = MapBoxControl.Instance();
        exmSong = logicalControl.choiceSong(1);
        gamerControl = GamerControl.Instance();
    }

    private void Awake()
    {

    }
    // Update is called once per frame
    void Update()
    {
        //玩家操作部分
        Debug.Log(gamerControl.GetPlayerDownClick());

        //生成砖块部分
        if (index >= exmSong.GetLen())
        {
            ExitGame();
        }
        else
        {
            mainTime += Time.deltaTime * 1000;//主计时器  
            if (mainTime > exmSong.GetGenerationTime(index))
            {
                boxControl.GetObject(index);
                index++;
            }
        }
    }
    void ExitGame()
    {
        Debug.Log("单局结束");
    }
}
