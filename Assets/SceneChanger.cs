using System.Collections;
using System.Collections.Generic;
using UnityEngine; 
using UnityEngine.UI;  //tool 적용
using UnityEngine.SceneManagement; //Scene을 다루기 위해 tool적용

public class SceneChanger : MonoBehaviour
{
    public void ChangeSceneByName_asdf(string _sceneName)   //scene 바꾸는 method 생성
    {
        SceneManager.LoadScene(_sceneName);
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
