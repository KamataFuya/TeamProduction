using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player; // �v���C���[��Transform
    public Vector3 offset = new Vector3(0, 5, -10); // �v���C���[����̃I�t�Z�b�g
    public float rotationSpeed = 5f; // �J�����̉�]���x

    private Vector3 initialOffset; // �����I�t�Z�b�g

    void Start()
    {
        // �����I�t�Z�b�g��ݒ�
        initialOffset = offset;
        Cursor.lockState = CursorLockMode.None; // �Q�[���J�n���̓}�E�X�J�[�\�������b�N���Ȃ�
        Cursor.visible = true; // �J�[�\����\��
    }

    void Update()
    {
        // ���N���b�N�������Ă���ԂɃJ��������]
        if (Input.GetMouseButton(0))
        {
            float horizontal = Input.GetAxis("Mouse X") * rotationSpeed;
            float vertical = -Input.GetAxis("Mouse Y") * rotationSpeed;

            // �J�������v���C���[�̎���ŉ�]������
            Quaternion camTurnAngle = Quaternion.AngleAxis(horizontal, Vector3.up);
            offset = camTurnAngle * offset;

            // ���������̉�]�𐧌�����i�Ⴆ�΁A������������Ȃ��悤�ɂ���j
            offset = Quaternion.AngleAxis(vertical, transform.right) * offset;
        }

        // �J�����̈ʒu���X�V
        Vector3 desiredPosition = player.position + offset;
        transform.position = Vector3.Slerp(transform.position, desiredPosition, 0.1f);
        transform.LookAt(player.position);

        // �J�����ʒu�����Z�b�g
        if (Input.GetKeyDown(KeyCode.K))
        {
            ResetCameraPosition();
        }
    }

    void ResetCameraPosition()
    {
        // �I�t�Z�b�g�������l�Ƀ��Z�b�g
        offset = initialOffset;
    }
}
