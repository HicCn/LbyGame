using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Video;
using UnityEngine.UI;

[RequireComponent(typeof(VideoPlayer))]
//挂载后会自动把VideoPlayer组件添加到game object

public class VideoPlay : MonoBehaviour
{
    Color imgColor;
    public Image logoImg;
    public Text TextTest;
    Color add = new Color(0, 0, 0, 0.001f);
    private VideoPlayer videoPlayer;//声明视频播放器组件
    public VideoClip loopVide;//声明视频资源
    private RawImage rawImage;//声明原始图像
    /*===注意：使用RawImage时，将使用每个存在的RawImage创建一个额外的绘制调用，因此最好只将其用于背景或临时可见的图形===*/
    float temp = 0;
    private void Awake()
    {
        videoPlayer = this.GetComponent<VideoPlayer>();//获取视频播放器组件
        rawImage = this.GetComponent<RawImage>();//获取原始图像组件
    }

    void Start()
    {
        videoPlayer.isLooping = true;//循环播放,如果只播放一次设置为false
        videoPlayer.clip ??= loopVide;//视频源

        videoPlayer.Pause();
    }

    void Update()
    {
        temp += Time.deltaTime;
        if(temp > 2.8 && videoPlayer.isPlaying == false)
        {
            videoPlayer.Play();
        }
        rawImage.texture = videoPlayer.texture;//RawImage可以显示任何纹理，而Image组件只能显示Sprite纹理||videoPlayer.texture:视频内容的内部纹理（只读）
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