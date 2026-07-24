using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine;
using UnityEngine.InputSystem;
public class SideViewPlayer : MonoBehaviour
{
    Rigidbody2D rigid;
        //속성
    [SerializeField] float moveSpd = 1.5f;
    [SerializeField] float JumpPower = 1.5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    Vector3 moveDirection;
    SpriteRenderer spriteRenderer;


    [SerializeField] float jumpPower = 8f; // 캐릭터 점프 파워
    [SerializeField] float coyoteTime = 0.1f; // 발판에서 떨어진 뒤에도 점프할 수 있는 짧은 시간

    float coyoteTimeCounter; // 코요테 타임 남은 시간
    bool isJumping; // 점프 중인지 확인

    [SerializeField] float groundCheckDistance = 0.05f; // 바닥을 확인하기 위한 거리
    [SerializeField] LayerMask groundLayer; // 바닥을 구분하기 위한 Layer
    Collider2D bodyCollider; // Collider2D는 CapsuleCollider2D의 부모 타입으로 모두 받아올 수 있음
    void Awake()
    {
        rigid = this.GetComponent<Rigidbody2D>();
        spriteRenderer = this.GetComponent<SpriteRenderer>();

        bodyCollider = GetComponent<Collider2D>();
    }
    // update, lateUpdate, FixedUpdate
    //어디서 이동하느냐? 
    private void Update()
    {

        if (IsGrounded() == true && isJumping == false)
        {
            coyoteTimeCounter = coyoteTime;
        }
        else
        {
            coyoteTimeCounter -= Time.deltaTime;
        }

        if (IsGrounded() == false)
        {
            isJumping = false;
        }
    }
    private void FixedUpdate()
    {
        Move();
    }

    bool IsGrounded()
    {
        Bounds bounds = bodyCollider.bounds; // 콜라이더의 범위

        Vector2 origin = new Vector2(bounds.center.x, bounds.min.y); // 중앙 하단을 기준으로 합니다.
        Vector2 size = new Vector2(bounds.size.x * 0.9f, 0.05f);

        RaycastHit2D hit = Physics2D.BoxCast(origin, size, 0f, Vector2.down, groundCheckDistance, groundLayer);

        return hit.collider != null;
    }
    void Move()
    {
        rigid.linearVelocity = new Vector2((moveDirection.x * moveSpd), rigid.linearVelocity.y);
        //사이드 뷰 코드니까 x좌표 좌-우만 신경씀
    }

   

    void OnJump()
    {
        if (coyoteTimeCounter <= 0f) return; // 코요테 타임이 남아 있지 않다면 점프하지 않습니다.

        coyoteTimeCounter = 0f; // 점프를 사용했으므로 코요테 타임을 비웁니다.
        isJumping = true; // 점프중 : true

        rigid.linearVelocity = new Vector2(rigid.linearVelocity.x, 0f); // Y 이동값을 0으로 초기화 합니다.
        rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
    }
    void OnMove(InputValue _value) //on ~ 를 붙여서 game input 컨트롤/ move 는 벡터 값 받아옴 
    {
      //   Vector2 temp = _value.Get<Vector2>();
      //    moveDirection = new Vector3(temp.x, temp.y, 0);

      //  Debug.Log($"ㅎㅇ,");

       moveDirection = _value.Get<Vector2>(); // vec3 에 vec2넣어도되나?
        Debug.Log(moveDirection);
        if (moveDirection.x != 0f)
        {
            spriteRenderer.flipX = moveDirection.x < 0f;
        }
    }
}
