using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnMove(InputValue _value)
    {
        //
        Vector2 movePosition = _value.Get<Vector2>();
        UnityEngine.Debug.Log(movePosition);
    }
}
