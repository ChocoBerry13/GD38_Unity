using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.GraphicsBuffer;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    Vector2 moveInput;//이동방향을 담음
    SpriteRenderer spriteRenderer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        //inspector창 말고 코드안에서 this. 겟컴포넌트해옴
        spriteRenderer = this.GetComponent<SpriteRenderer>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (moveInput != Vector2.zero)
        {
            //v2입력을v3로 포지셔에 전달
            //
            Vector3 moveDirection = new Vector3(moveInput.x, moveInput.y, 0f);
            transform.position += moveDirection * moveSpeed * Time.deltaTime;



            // lookDirection.X가 0보다 작다 = 타겟이 왼쪽에 있다 → flipX를 true로 설정한다.
            spriteRenderer.flipX = moveDirection.x < 0;
        }
    }

    void OnMove(InputValue _value)
    {
        //// 매개변수로 받아온 _value 의 Vector2를 moveInput에 넣음
        moveInput = _value.Get<Vector2>();
        UnityEngine.Debug.Log(moveInput);
    }
}
