using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//secondbranch hibranch에서 수정
public class Player_manager : MonoBehaviour
{
    //ü��, ���׹̳�, �ð�

    bool _isAlive = true;

    [SerializeField] UI_Manager _uimanager;  //UI manager ��û���� �־��ֱ�(�̸� ��ũ��Ʈ �̸��̶� ���� ����!!!!)

    [SerializeField] float _health = 100f;
    [SerializeField] float _stemina = 100f;
    [SerializeField] float _maxStemina = 100f;
    [SerializeField] float _time = 0f;
    


    // Start is called before the first frame update
    void Start()
    {
        _uimanager.SetMaxHealth(_health);
        _uimanager.SetHealth(_health);     //�� �ʱ�ȭ�ϰ� ����
        _uimanager.SetMaxStemina(_maxStemina);
        _uimanager.SetStemina(_stemina);     
        _uimanager.SetTime(_time); 

    }

    // Update is called once per frame
    void Update() //�� �������� üũ
    {
        if(Input.GetAxis("Horizontal") != 0)    //x�� ���� �޾Ƽ� 0�� �ƴϸ�, �� �����̸� stemina ����
        {
            _stemina -= Time.deltaTime*5;

        }

        else if (_stemina < _maxStemina)   //stemina�� ������ ������ ���� ������ �ִ밪 ����
        {
            _stemina += Time.deltaTime*5;
        }

        _uimanager.SetStemina(_stemina);   //stemina ���� ���� �� ui���� ������ �ǵ���
        
        _time += Time.deltaTime;
        _uimanager.SetTime(_time);   

    }

    private void OnControllerColliderHit(ControllerColliderHit hit)  //�ε��� �ָ� return�ϴ� �Լ�
    {
        Debug.Log("hit" + hit.gameObject.name);

        if (hit.gameObject.name == "fire")  //�ε��� ���� �̸��� fire�̸� heath -1 
        {
            if (_health > 0)
            {
                _health -= 1;
            }
            else
            {
                _isAlive = false;
                Debug.Log("Game Over");   //Console Collapse â�� Game Over ��
                Destroy(gameObject);  //������Ʈ�� �ı�, ���⼭ gameObject�� player

            }
            _uimanager.SetHelath(_health);   //health ���� ���� �� ui���� ������ �ǵ���

        }

    }

}
