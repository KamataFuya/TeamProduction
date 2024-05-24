using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Boss_horming : MonoBehaviour
{

    // �^�[�Q�b�g�I�u�W�F�N�g�� Transform�R���|�[�l���g���i�[����ϐ�
    public Transform target;
    // �I�u�W�F�N�g�̈ړ����x���i�[����ϐ�
    public float moveSpeed;
    // �I�u�W�F�N�g����~����^�[�Q�b�g�I�u�W�F�N�g�Ƃ̋������i�[����ϐ�
    public float stopDistance;
    // �I�u�W�F�N�g���^�[�Q�b�g�Ɍ������Ĉړ����J�n���鋗�����i�[����ϐ�
    public float moveDistance;

    float speed;

    private Animator boss_Animator;

    // Start is called before the first frame update
    void Start()
    {
        boss_Animator = GetComponent<Animator>();
       
    }

    // Update is called once per frame
    void Update()
    {

        // �ϐ� targetPos ���쐬���ă^�[�Q�b�g�I�u�W�F�N�g�̍��W���i�[
        Vector3 targetPos = target.position;
        // �������g��Y���W��ϐ� target ��Y���W�Ɋi�[
        //�i�^�[�Q�b�g�I�u�W�F�N�g��X�AZ���W�̂ݎQ�Ɓj
        targetPos.y = transform.position.y;
        // �ϐ� distance ���쐬���ăI�u�W�F�N�g�̈ʒu�ƃ^�[�Q�b�g�I�u�W�F�N�g�̋������i�[
        float distance = Vector3.Distance(transform.position, target.position);
        // �I�u�W�F�N�g�ƃ^�[�Q�b�g�I�u�W�F�N�g�̋�������
        // �ϐ� distance�i�^�[�Q�b�g�I�u�W�F�N�g�ƃI�u�W�F�N�g�̋����j���ϐ� moveDistance �̒l��菬�������
        // ����ɕϐ� distance ���ϐ� stopDistance �̒l�����傫���ꍇ�A
        if (distance < moveDistance && distance > stopDistance && !boss_Animator.GetBool("attack01"))
        {
            // �ϐ� moveSpeed ����Z�������x�ŃI�u�W�F�N�g��O�����Ɉړ�����
            transform.position = transform.position + transform.forward * speed * Time.deltaTime;
          
                // �I�u�W�F�N�g��ϐ� targetPos �̍��W�����Ɍ�������
                transform.LookAt(targetPos);
            
            
        }
        else
        {
           �@//�U��������A�ēx�v���C���[�Ɋp�x�����킹��
            if (!boss_Animator.GetBool("attack01"))
            {
                // �I�u�W�F�N�g��ϐ� targetPos �̍��W�����Ɍ�������
                transform.LookAt(targetPos);
            }
            //�G���A���ɓ�������U���J�n
            boss_Animator.SetTrigger("attack01");
        }

        //�A�j���[�V�������͕K���~�܂�悤�ɂ���
        if (boss_Animator.GetBool("attack01"))
        {
            speed = 0;
        }
        else
        {
            speed = moveSpeed;
        }
    }

}
