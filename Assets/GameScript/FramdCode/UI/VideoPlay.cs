using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Video;
using UnityEngine.UI;

[RequireComponent(typeof(VideoPlayer))]
//���غ���Զ���VideoPlayer�����ӵ�game object

public class VideoPlay : MonoBehaviour
{
    Color imgColor;
    public Image logoImg;
    public Text TextTest;
    Color add = new Color(0, 0, 0, 0.001f);
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
        if(temp > 2.8 && videoPlayer.isPlaying == false)
        {
            videoPlayer.Play();
        }
        rawImage.texture = videoPlayer.texture;//RawImage������ʾ�κ�������Image���ֻ����ʾSprite����||videoPlayer.texture:��Ƶ���ݵ��ڲ�����ֻ����
        if (videoPlayer.isPlaying)
        {
            if (logoImg.color.a < 1)
            {  
                logoImg.color += add;
            }
            else
            {
                if (TextTest.color.a < 0 || TextTest.color.a > 1)
                {
                    add *= -1;
                }
                TextTest.color += (add*2);
            }
        }
    }


}