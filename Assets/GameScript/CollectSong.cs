using System.IO;
using UnityEngine;
using System.Collections.Generic;
using FramdCode;

public class CollectSong : MonoBehaviour
{
    MapBoxControl boxControl;
    float InstanceTime = 0;
    float time = 0;
    dataTimes data = new dataTimes();
    int index = 0;
    dataTime tempData =new  dataTime();
    bool isInput = false;
    float tempTime = 0;//��¼����ʱ��
    KeyCode inputKey;
    float curtime = BasicDefine.BoxWidthLen * 2 / BasicDefine.BoxSpeed*1000;//�߹�һ���ʱ��
    // Start is called before the first frame update
    void Start()
    {
        boxControl = MapBoxControl.Instance();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime * 1000;
        InstanceTime += Time.deltaTime * 1000;
        if(InstanceTime >= curtime / 2)
        {
            boxControl.GetObject();
            InstanceTime = 0;
        }
        if (Input.anyKeyDown)
        {
            isInput = true;
            tempData.Downtime = (long)time;
            tempData.id = index;
            index++;
            if (inputKey == KeyCode.End)
            {
                data.dataPack.Add(tempData);
                Save(data);
                Time.timeScale = 0;
            }
        }
        if (Input.GetKeyUp(inputKey))
        {
            isInput = false;
        }
        if (isInput)
        {
            tempTime += Time.deltaTime * 1000;
        }
        else
        {
            if(tempTime != 0)
            {
                int i = 1;
                float _tempTime = Mathf.Abs(curtime - tempTime);//��˭���ӽ���
                while(_tempTime > Mathf.Abs(curtime *(i+1) - tempTime))
                {
                    i++;
                    _tempTime = Mathf.Abs(curtime * i - tempTime);
                }
                tempData.blockLen = i;
                tempData.key = (int)inputKey;
                data.dataPack.Add(tempData);
                tempTime = 0;
                tempData = new dataTime();
            }
        }
    }
    void OnGUI()
    {
        Event e = Event.current;
        if (e.isKey)
            inputKey = e.keyCode;

    }

    void Save(dataTimes data)
    {
        string jsonInfo = JsonUtility.ToJson(data,true);
        string filePath = Application.dataPath + "/song.json";
        File.WriteAllText(filePath,jsonInfo);
    }
}
[System.Serializable]
public class dataTimes
{
    public List<dataTime> dataPack = new List<dataTime>();
}

[System.Serializable]
public class dataTime
{
    public int id;
    /// <summary>
    /// ���ʱ��
    /// </summary>
    public long Downtime;
    /// <summary>
    /// �������
    /// </summary>
    public int blockLen;
    /// <summary>
    /// ���µİ���
    /// </summary>
    public int key;
}
