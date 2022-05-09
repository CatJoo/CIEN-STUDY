using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_manager : MonoBehaviour
{
    //체력, 스테미나, 시간

    bool _isAlive = true;

    [SerializeField] UI_Manager _uimanager;  //UI manager 하청으로 넣어주기(이름 스크립트 이름이랑 같게 주의!!!!)

    [SerializeField] float _health = 100f;
    [SerializeField] float _stemina = 100f;
    [SerializeField] float _maxStemina = 100f;
    [SerializeField] float _time = 0f;
    


    // Start is called before the first frame update
    void Start()
    {
        _uimanager.SetMaxHealth(_health);
        _uimanager.SetHealth(_health);     //값 초기화하고 시작
        _uimanager.SetMaxStemina(_maxStemina);
        _uimanager.SetStemina(_stemina);     
        _uimanager.SetTime(_time); 

    }

    // Update is called once per frame
    void Update() //매 순간마다 체크
    {
        if(Input.GetAxis("Horizontal") != 0)    //x축 값을 받아서 0이 아니면, 즉 움직이면 stemina 감소
        {
            _stemina -= Time.deltaTime*5;

        }

        else if (_stemina < _maxStemina)   //stemina가 무한정 증가할 수는 없으니 최대값 설정
        {
            _stemina += Time.deltaTime*5;
        }

        _uimanager.SetStemina(_stemina);   //stemina 값이 변할 때 ui에도 적용이 되도록
        
        _time += Time.deltaTime;
        _uimanager.SetTime(_time);   

    }

    private void OnControllerColliderHit(ControllerColliderHit hit)  //부딪힌 애를 return하는 함수
    {
        Debug.Log("hit" + hit.gameObject.name);

        if (hit.gameObject.name == "fire")  //부딪힌 애의 이름이 fire이면 heath -1 
        {
            if (_health > 0)
            {
                _health -= 1;
            }
            else
            {
                _isAlive = false;
                Debug.Log("Game Over");   //Console Collapse 창에 Game Over 뜸
                Destroy(gameObject);  //오브젝트를 파괴, 여기서 gameObject는 player

            }
            _uimanager.SetHelath(_health);   //health 값이 변할 때 ui에도 적용이 되도록

        }

    }

}
