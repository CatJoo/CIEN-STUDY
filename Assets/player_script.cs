using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_script : MonoBehaviour
{
    public CharacterController controller;      /// ĳ���Ϳ� ��Ʈ�ѷ� �ο�
    public float _speed = 0.1f;
    public Vector3 _velocity = new Vector3(1, 1, 0);
    public Vector3 _input = new Vector3(0, 0, 0);
    public float _gravityScale = 1.5f;  //�߷�ũ��
    public float _jumpSpeed = 1.5f;

    public bool _jumpInputed = false; //jump�� ���ȴ��� ����
    public bool _isGrounded = false;  //���� ��Ҵ��� ����
    public bool _GroundedBefore = false;

    //main camera�� player�� ������ ī�޶� ����ٴ�

    // Start is called before the first frame update
    void Start() //�����Ҷ� �ѹ� ����
    {
        controller = GetComponent<CharacterController>();   //controller�� unity ��Ҹ� �޾ƿͼ� ������ �� ����
    }


    // Update is called once per frame
    void Update() //����ؼ� ����
    {
        _isGrounded = controller.isGrounded;    //controller�� �� ��Ҵ��� üũ����
        float dt = Time.deltaTime;   //update�� update ������ ����
        _input.x = Input.GetAxis("Horizontal");   //x�� �� 
        //_input.y = Input.GetAxis("Vertical");

        _jumpInputed = Input.GetButtonDown("Jump");
        _velocity = _input*_speed;


        if (_jumpInputed && _GroundedBefore)
        {
            _velocity.y = _velocity.y + _jumpSpeed; //��������
            _GroundedBefore = false;
        }
       
        if(_isGrounded)
        {
            if(!_GroundedBefore)
            {
                _GroundedBefore = true;
            }
        }
        else
        {
            if (!_GroundedBefore)
                _velocity.y = _velocity.y - (_gravityScale * dt * 9.8f);
            //�߷±���
            //���� �� ��� ������ �߷¿� ���� ������
            //�ڿ������� �߷��� ���� ������, dt�� �߷��� ������ ������ �ο��� ������ ����

        }

        controller.Move(_velocity);
    }
}
