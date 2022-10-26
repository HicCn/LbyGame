using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Video;
using UnityEngine.UI;

[RequireComponent(typeof(VideoPlayer))]
//挂载后会自动把VideoPlayer组件添加到game object

public class tampPlay : MonoBehaviour
{
    public GameObject GameObject;
    private VideoPlayer videoPlayer;//声明视频播放器组件
    public VideoClip startVide;//声明视频资源
    private RawImage rawImage;//声明原始图像
    /*===注意：使用RawImage时，将使用每个存在的RawImage创建一个额外的绘制调用，因此最好只将其用于背景或临时可见的图形===*/
    float time = 0;
    bool isDel = true;
    //私有变量暴露到编辑器
    [SerializeField]
    [Range(0f, 1f)] public float 淡入速度 = 1f;//播放速度

    private void Awake()
    {
        videoPlayer = this.GetComponent<VideoPlayer>();//获取视频播放器组件
        rawImage = this.GetComponent<RawImage>();//获取原始图像组件
    }

    void Start()
    {
        videoPlayer.isLooping = false;//循环播放,如果只播放一次设置为false
        videoPlayer.clip = startVide;//视频源
    }

    void Update()
    {
        time += Time.deltaTime;
        if (time >0.5 && isDel)
        {
            isDel = false;
            Destroy(GameObject);
        }
        //把VideoPlayerd的视频渲染到UGUI的RawImage
        rawImage.texture = videoPlayer.texture;//RawImage可以显示任何纹理，而Image组件只能显示Sprite纹理||videoPlayer.texture:视频内容的内部纹理（只读）
        if (time > 3 )
        {
            
            Destroy(gameObject);
            
        }
    }

}