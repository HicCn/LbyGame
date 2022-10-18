using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FramdCode;

public class StartGame : MonoBehaviour
{
    public static float DecisionLine = 0;
    public static int score = 0;

    int CreateId;


    LogicalControl logicalControl;
    MapBoxControl boxControl;
    GamerControl gamerControl;

    songBasic exmSong;

    // Start is called before the first frame update
    void Start()
    {
        CreateId = 0;
        logicalControl = LogicalControl.Instance();
        boxControl = MapBoxControl.Instance();
        exmSong = logicalControl.choiceSong(1);
        gamerControl = GamerControl.Instance();
        gamerControl.mainTime = 0;//初始化玩家开始游戏
        gamerControl.GetSong(exmSong);
    }

    private void Awake()
    {

    }
    // Update is called once per frame
    void Update()
    {
        gamerControl.mainTime += Time.deltaTime * 1000;//主计时器  

        //玩家操作部分
        gamerControl.GetPlayerDownClick();

        //生成砖块部分
        if (CreateId < exmSong.GetLen())
        {
            if (gamerControl.mainTime >= exmSong.GetGenerationTime(CreateId))
            {
                boxControl.GetObject(CreateId);
                CreateId++;
            }
        }
    }
    void ExitGame()
    {
        Debug.Log("单局结束");
        Time.timeScale = 0;
    }
}
