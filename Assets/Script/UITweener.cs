using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UITweener : MonoBehaviour
{
    [SerializeField]
    RectTransform _targetRect;

    [SerializeField]
    Image _image;

    [SerializeField]
    Vector3 _targetPos;  //target�� ���� �� ���ΰ�

    [SerializeField]
    float _duration;  //�󸶳� ����

    [SerializeField]
    KeyCode _triggercode;  

    [SerializeField]
    Color _originColor, _targetColor;

    Tween _tween;

    // Start is called before the first frame update
    void Start()
    {
        _tween = _targetRect.DOAnchorPos(new Vector3(), _duration);   
    }

    // Update is called once per frame
    private void Update()
    {
        if(Input.GetKeyDown(_triggercode))
        {
            //_targetRect.DOAnchorPos(_targetPos, _duration);  //��ġ �̵���Ű��
            //_image.DOColor(_targetColor, _duration);  //���� �ٲٱ�
            _tween = _targetRect.DOShakeAnchorPos(_duration); //����
        }
        else if(Input.GetKeyUp(_triggercode))
        {
            // _targetRect.DOAnchorPos(new Vector3(), _duration);
            // _image.DOColor(_originColor, _duration);
            _tween.Kill();  //�̻��� ������ �̵���....
            _targetRect.DOAnchorPos(new Vector3(), _duration); //�׷��� �̰� ���ֱ�..

        }
    }

    /*public void ShakeIt()
    {
        if(_tween.IsPlaying())
        {
            _tween.Kill();  
            _targetRect.DOAnchorPos(new Vector3(), 0.1f);
        }
        _tween = _targetRect.DOShakeAnchorPos(_duration);
    }
    */


}
