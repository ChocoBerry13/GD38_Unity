using UnityEngine;

public class Obj_Box : MonoBehaviour, IInteractable //여기서 인터페이스 상속받음
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Interact()
    {
        Debug.Log("상자를 엽니다.");
    }
}
