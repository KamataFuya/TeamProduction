using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    // �ϐ��錾
    private float speed = 25.0f; // �v���C���[�̈ړ����x
    private float dashSpeed = 8.0f; // �v���C���[�̃_�b�V���X�s�[�h

    private float hp = 100;
    private float stamina = 100;

    private float dodgeSpeed = 5f; // ����̑��x
    private float dodgeDuration = 0.5f; // ����̎�������
    private float invincibilityDuration = 10f / 60f; // ���G���ԁi�t���[����b�ɕϊ��j
    private bool isDodging = false; // ��𒆂��ǂ����̔��ʃt���O
    private bool isInvincible = false; // ���G�����ǂ����̔��ʃt���O
    private float dodgeTime = 0f;
    private float invincibilityTime = 0f; // ���G����

    public GameObject ballPrefab; // ������{�[���̃v���n�u
    public Transform throwPoint; // �{�[���𓊂���ʒu
    public float throwForce = 150f; // �������
    public float throwAngle = 80f; // ������p�x�i�x�j

    private Rigidbody rb;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // �������
        if (Input.GetKeyDown(KeyCode.Space) && !isDodging)
        {
            StartCoroutine(DodgeAction());
        }
        if (isInvincible)
        {
            invincibilityTime -= Time.deltaTime;
            if (invincibilityTime <= 0f)
            {
                isInvincible = false;
            }
        }
        else
        {
            // �ړ�����
            Move();
        }

        // ���̓{�[��������
        if (Input.GetKeyDown(KeyCode.F))
        {
            ThrowMagneBall();
        }
    }

    //�ړ��֐�
    private void Move()
    {
        if (Input.GetKey(KeyCode.B))
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                transform.position += new Vector3(0, 0, dashSpeed) * Time.deltaTime;
            }

            if (Input.GetKey(KeyCode.DownArrow))
            {
                transform.position += new Vector3(0, 0, -dashSpeed) * Time.deltaTime;
            }

            if (Input.GetKey(KeyCode.LeftArrow))// ��
            {
                transform.position += new Vector3(-dashSpeed, 0, 0) * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.RightArrow))// �E
            {
                transform.position += new Vector3(dashSpeed, 0, 0) * Time.deltaTime;
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                transform.position += new Vector3(0, 0, speed) * Time.deltaTime;
            }

            if (Input.GetKey(KeyCode.DownArrow))
            {
                transform.position += new Vector3(0, 0, -speed) * Time.deltaTime;
            }

            if (Input.GetKey(KeyCode.LeftArrow))// ��
            {
                transform.position += new Vector3(-speed, 0, 0) * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.RightArrow))// �E
            {
                transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;
            }
        }
        
    }

    // ���
    private IEnumerator DodgeAction()
    {
        isDodging = true;
        isInvincible = true;
        invincibilityTime = invincibilityDuration;

        // ��𒆂̓���
        float startTime = Time.time;
        while (Time.time < startTime + dodgeDuration)
        {
            transform.position += transform.forward * dodgeSpeed * 0.01f;
            yield return null;
        }

        // ����I��
        isDodging = false;
    }

    // ���̓{�[���Ԃ񓊂���
    private void ThrowMagneBall()
    {
        // �{�[���̐���
        throwPoint.position = transform.position;
        throwPoint.rotation = transform.rotation;
        GameObject ball = Instantiate(ballPrefab, throwPoint.position, throwPoint.rotation);

        // �{�[���ɗ͂�������
        Rigidbody rb = ball.GetComponent<Rigidbody>();
        Vector3 throwDirection = CalculateThrowDirection(throwPoint.forward, throwAngle);
        rb.AddForce(throwDirection * throwForce, ForceMode.VelocityChange);
    }

    // ���̓{�[���̋O���v�Z
    private Vector3 CalculateThrowDirection(Vector3 forward, float angle)
    {
        // �p�x�����W�A���ɕϊ�
        float radians = angle * Mathf.Deg2Rad;

        // ���������Ɛ��������̐������v�Z
        Vector3 horizontal = forward * Mathf.Cos(radians);
        Vector3 vertical = Vector3.up * Mathf.Sin(radians);

        // �����x�N�g���𐳋K�����č���
        return (horizontal + vertical).normalized;
    }
}
