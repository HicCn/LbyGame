using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FramdCode
{
    public class MapBoxControl : MonoBehaviour
    {
        private static MapBoxControl mapBoxControl;

        GameObject mapBox;
        Test TestSevice = new();
        static readonly Queue<GameObject> queue = new();
        //����ض���
        Vector2 startPosition = new Vector2(BasicDefine.MapWidthLen+BasicDefine.BoxWidthLen, BasicDefine.startPositionY);

        private MapBoxControl()
        {
            mapBox = Resources.Load<GameObject>("map_box");
            MapBoxControlInitialize();
        }

        public static MapBoxControl Instance()
        {
            mapBoxControl ??= new MapBoxControl();
            return mapBoxControl;
        }

        //��ʼ��
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

        //���ն���
        public static void BackToQueue(GameObject Obj)
        {
            Obj.SetActive(false);
            queue.Enqueue(Obj);
        }

        //�������ȡ������
        public void GetObject(int id)
        {
            int index = 0;//��������ʱ��λ����
            Vector2 pos ;
            for(int i = 0; i < TestSevice.GetGenerationType(id); i++)
            {
                GameObject nextObj = queue.Dequeue();
                pos = startPosition;
                pos.x += index * 2 * BasicDefine.BoxWidthLen;
                nextObj.transform.position = pos;
                nextObj.SetActive(true);
                index++;
            }
        }
        public void GetObject()
        {
            
                GameObject nextObj = queue.Dequeue();
                nextObj.transform.position = startPosition;
                nextObj.SetActive(true);
            
        }
    }
}