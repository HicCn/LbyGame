using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DragonBones;

public class PlayerAnimator : MonoBehaviour
{
    UnityArmatureComponent dragon;
    private void Awake()
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        dragon = GetComponentInChildren<UnityArmatureComponent>();
        dragon.animation.Play(AnimatorName.Stand);
        ////加载龙骨资源
        //var data = UnityFactory.factory.LoadDragonBonesData("Resources / 女主动画_ske");
        //UnityFactory.factory.LoadTextureAtlasData("Resources/女主动画_tex");//加载图集
        ////dragon.SetDragonBones(data, 0, 0, Vector2.right);//加载龙骨
        //dragon.animation.Play("Run");//播放动画
    }
    

    // Update is called once per frame
    void Update()
    {

    }
    /// <summary>
    /// 播放动画
    /// </summary>
    /// <param name="animatorName">动画的名字，可以使用AnimaotrName类帮助</param>
    public void PlayerAnimation(string animatorName)
    {
        dragon.animation.Play(animatorName);
    }
}
