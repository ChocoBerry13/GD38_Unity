using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.GraphicsBuffer;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    Vector2 moveInput;//이동방향을 담음
    SpriteRenderer spriteRenderer;

    Rigidbody2D rigid;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        //inspector창 말고 코드안에서 this. 겟컴포넌트해옴
        spriteRenderer = this.GetComponent<SpriteRenderer>();
        rigid = GetComponent<Rigidbody2D>();
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
    void FixedUpdate()
    {
        rigid.linearVelocity = moveInput * moveSpeed; // 이동은 Rigidbody2D의 속도로 처리합니다.
    }

    void OnCollisionEnter2D(Collision2D collision) // Collision
    {
      //  Debug.Log($"{collision.gameObject.name}과 충돌했습니다.");
    }

    void OnTriggerEnter2D(Collider2D other) // Trigger
    {
        if (other.CompareTag("Red"))
        {
            Debug.Log($"{other.gameObject.name}, 빨간 박스 트리거에 닿았습니다.");
        }
       else if (other.CompareTag("Blue"))
        {
            Debug.Log($"{other.gameObject.name}, 파란 박스 트리거에 닿았습니다.");
        }
    }
    void OnMove(InputValue _value)
    {
        //// 매개변수로 받아온 _value 의 Vector2를 moveInput에 넣음
        moveInput = _value.Get<Vector2>();
       // UnityEngine.Debug.Log(moveInput);
    }
}
