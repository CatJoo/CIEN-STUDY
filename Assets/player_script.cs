using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_script : MonoBehaviour
{
    public CharacterController controller;      /// 캐릭터에 컨트롤러 부여
    public float _speed = 0.1f;
    public Vector3 _velocity = new Vector3(1, 1, 0);
    public Vector3 _input = new Vector3(0, 0, 0);
    public float _gravityScale = 1.5f;  //중력크기
    public float _jumpSpeed = 1.5f;

    public bool _jumpInputed = false; //jump가 눌렸는지 여부
    public bool _isGrounded = false;  //땅을 밟았는지 여부
    public bool _GroundedBefore = false;

    //main camera를 player에 넣으면 카메라가 따라다님

    // Start is called before the first frame update
    void Start() //시작할때 한번 선언
    {
        controller = GetComponent<CharacterController>();   //controller로 unity 요소를 받아와서 관리할 수 있음
    }


    // Update is called once per frame
    void Update() //계속해서 선언
    {
        _isGrounded = controller.isGrounded;    //controller가 땅 밟았는지 체크해줌
        float dt = Time.deltaTime;   //update와 update 사이의 간격
        _input.x = Input.GetAxis("Horizontal");   //x축 값 
        //_input.y = Input.GetAxis("Vertical");

        _jumpInputed = Input.GetButtonDown("Jump");
        _velocity = _input*_speed;


        if (_jumpInputed && _GroundedBefore)
        {
            _velocity.y = _velocity.y + _jumpSpeed; //점프구현
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
            //중력구현
            //땅을 안 밟고 있으면 중력에 의해 떨어짐
            //자연스러운 중력을 위해 곱해줌, dt는 중력을 간격을 나눠서 부여한 것으로 생각

        }

        controller.Move(_velocity);
    }
}
