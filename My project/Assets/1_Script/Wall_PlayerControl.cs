using UnityEngine;
using UnityEngine.InputSystem;

public class Wall_PlayerControl : MonoBehaviour
{
    [SerializeField] float moveSpd = 0.2f;
    Vector2 moveInput;
    SpriteRenderer spriteRenderer;
    Rigidbody2D rigid;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Awake()
    {
        spriteRenderer = this.GetComponent<SpriteRenderer>();
        rigid = this.GetComponent<Rigidbody2D>();
    }
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (moveInput.x != 0f) // 좌우 입력이 있을 때만 방향 전환
        {
            spriteRenderer.flipX = moveInput.x < 0f;
        }
    }
    private void FixedUpdate()
    {
        rigid.linearVelocity = moveInput * moveSpd;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
         Debug.Log($"{collision.gameObject.name}과 충돌했습니다.");

    }
    void OnTriggerEnter2D(Collider2D other) // Trigger
    {
        if (other.CompareTag("Wall"))
        {
            Debug.Log($"{other.gameObject.name}, 벽에 닿았습니다.");
        }
    }

    void OnMove(InputValue _value)
    {
        moveInput = _value.Get<Vector2>();
    }
}
