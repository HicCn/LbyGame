using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FramdCode
{
    public class MapBoxControl : MonoBehaviour
    {
        GameObject mapBox;
        static Queue<GameObject> queue = new Queue<GameObject>();
        //对象池定义
        Vector2 startPosition = new Vector2(BasicDefine.MapWidthLen+2, BasicDefine.startPositionY);

        public MapBoxControl()
        {
            mapBox = Resources.Load<GameObject>("map_box");
            MapBoxControlInitialize();
        }

        //初始化
        private void MapBoxControlInitialize()
        {
            for (int i = 0; i < BasicDefine.BoxQueueLen; i++)
            {
                var newObj = Instantiate(mapBox);
                newObj.transform.position = startPosition;
                newObj.SetActive(false);
                queue.Enqueue(newObj);
            }
        }

        //回收对象
        public static void BackToQueue(GameObject Obj)
        {
            Obj.SetActive(false);
            queue.Enqueue(Obj);
        }

        //对象池中取出对象
        public GameObject GetObject()
        {
            GameObject nextObj = queue.Dequeue();
            nextObj.transform.position = startPosition;
            nextObj.SetActive(true);
            return nextObj;
        }

    }
}