using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestUi : MonoBehaviour
{
    public int PlayerHP = 100;    // �v���C���[�̗�
    public int PlayerSP = 100;    // �v���C���[�X�^�~�i

    public Slider PlayerHPBack;
    public Slider PlayerHPBar;
    public Slider PlayerSPBar;

    void Start()
    {
        if (PlayerHPBar != null)
        {
            PlayerHPBack.value = PlayerHP;
        }
        if(PlayerHPBar != null)
        {
            PlayerHPBar.value = PlayerHP;
        }
        if (PlayerSPBar != null)
        {
            PlayerSPBar.value = PlayerSP;
        }
    }

    public void Damage(int damage)
    {
        if (PlayerHP <= 0) return;

        if (PlayerHP < 100)
        {
            PlayerHPBack.value = PlayerHP;
        }

        PlayerHP -= damage;
        if(PlayerHPBar != null)
        {
            PlayerHPBar.value = PlayerHP;
        }
        if (PlayerHP <= 0)
        {
            PlayerHPBack.value = PlayerHP;
        }
    }
}
