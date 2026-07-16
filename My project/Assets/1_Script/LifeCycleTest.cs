using UnityEngine;

public class LifeCycleTest : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        Debug.Log("awake 함수 호출");
        
    }
    void OnEnable() // 활성화될때 실행되는 함수
    {
        Debug.Log("onEnable 함수는 활성화 될때마다 호출");

    }

    void Start()
    {

        Debug.Log("Start 함수 호출");

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("update는매 프레임 반복해서 호출");

    }

    void OnDisable()
    {
        Debug.Log("OnDisabl은 비활성화될때마다 호출");

    }
}
