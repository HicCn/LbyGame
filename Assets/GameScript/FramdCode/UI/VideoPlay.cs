using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Video;
using UnityEngine.UI;

[RequireComponent(typeof(VideoPlayer))]
//���غ���Զ���VideoPlayer�����ӵ�game object

public class VideoPlay : MonoBehaviour
{
    private VideoPlayer videoPlayer;//������Ƶ���������
    public VideoClip loopVide;//������Ƶ��Դ
    private RawImage rawImage;//����ԭʼͼ��
    /*===ע�⣺ʹ��RawImageʱ����ʹ��ÿ�����ڵ�RawImage����һ������Ļ��Ƶ��ã�������ֻ�������ڱ�������ʱ�ɼ���ͼ��===*/
    float temp = 0;
    private void Awake()
    {
        videoPlayer = this.GetComponent<VideoPlayer>();//��ȡ��Ƶ���������
        rawImage = this.GetComponent<RawImage>();//��ȡԭʼͼ�����
    }

    void Start()
    {
        videoPlayer.isLooping = true;//ѭ������,���ֻ����һ������Ϊfalse
        videoPlayer.clip ??= loopVide;//��ƵԴ
        videoPlayer.Pause();
    }

    void Update()
    {
        temp += Time.deltaTime;
        if(temp > 3 && videoPlayer.isPlaying == false)
        {
            videoPlayer.Play();
        }
        rawImage.texture = videoPlayer.texture;//RawImage������ʾ�κ�������Image���ֻ����ʾSprite����||videoPlayer.texture:��Ƶ���ݵ��ڲ�����ֻ����
    }


}