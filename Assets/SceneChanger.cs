using System.Collections;
using System.Collections.Generic;
using UnityEngine; 
using UnityEngine.UI;  //tool ����
using UnityEngine.SceneManagement; //Scene�� �ٷ�� ���� tool����

public class SceneChanger : MonoBehaviour
{
    public void ChangeSceneByName_asdf(string _sceneName)   //scene �ٲٴ� method ����
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
