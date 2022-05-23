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
    Vector3 _targetPos;  //target이 어디로 갈 것인가

    [SerializeField]
    float _duration;  //얼마나 지속

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
            //_targetRect.DOAnchorPos(_targetPos, _duration);  //위치 이동시키기
            //_image.DOColor(_targetColor, _duration);  //색상 바꾸기
            _tween = _targetRect.DOShakeAnchorPos(_duration); //흔들기
        }
        else if(Input.GetKeyUp(_triggercode))
        {
            // _targetRect.DOAnchorPos(new Vector3(), _duration);
            // _image.DOColor(_originColor, _duration);
            _tween.Kill();  //이상한 곳으로 이동함....
            _targetRect.DOAnchorPos(new Vector3(), _duration); //그래서 이거 써주기..

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
