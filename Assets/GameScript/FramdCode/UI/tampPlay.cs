using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Video;
using UnityEngine.UI;

[RequireComponent(typeof(VideoPlayer))]
//���غ���Զ���VideoPlayer�����ӵ�game object

public class tampPlay : MonoBehaviour
{
    public GameObject GameObject;
    private VideoPlayer videoPlayer;//������Ƶ���������
    public VideoClip startVide;//������Ƶ��Դ
    private RawImage rawImage;//����ԭʼͼ��
    /*===ע�⣺ʹ��RawImageʱ����ʹ��ÿ�����ڵ�RawImage����һ������Ļ��Ƶ��ã�������ֻ�������ڱ�������ʱ�ɼ���ͼ��===*/
    float time = 0;
    bool isDel = true;
    //˽�б�����¶���༭��
    [SerializeField]
    [Range(0f, 1f)] public float �����ٶ� = 1f;//�����ٶ�

    private void Awake()
    {
        videoPlayer = this.GetComponent<VideoPlayer>();//��ȡ��Ƶ���������
        rawImage = this.GetComponent<RawImage>();//��ȡԭʼͼ�����
    }

    void Start()
    {
        videoPlayer.isLooping = false;//ѭ������,���ֻ����һ������Ϊfalse
        videoPlayer.clip = startVide;//��ƵԴ
    }

    void Update()
    {
        time += Time.deltaTime;
        if (time >0.5 && isDel)
        {
            isDel = false;
            Destroy(GameObject);
        }
        //��VideoPlayerd����Ƶ��Ⱦ��UGUI��RawImage
        rawImage.texture = videoPlayer.texture;//RawImage������ʾ�κ�������Image���ֻ����ʾSprite����||videoPlayer.texture:��Ƶ���ݵ��ڲ�����ֻ����
        if (time > 3 )
        {
            
            Destroy(gameObject);
            
        }
    }

}