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
        ////����������Դ
        //var data = UnityFactory.factory.LoadDragonBonesData("Resources / Ů������_ske");
        //UnityFactory.factory.LoadTextureAtlasData("Resources/Ů������_tex");//����ͼ��
        ////dragon.SetDragonBones(data, 0, 0, Vector2.right);//��������
        //dragon.animation.Play("Run");//���Ŷ���
    }
    

    // Update is called once per frame
    void Update()
    {

    }
    /// <summary>
    /// ���Ŷ���
    /// </summary>
    /// <param name="animatorName">���������֣�����ʹ��AnimaotrName�����</param>
    public void PlayerAnimation(string animatorName)
    {
        dragon.animation.Play(animatorName);
    }
}
