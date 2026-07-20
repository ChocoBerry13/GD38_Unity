using System;
using TMPro;
using Unity.Hierarchy;
using UnityEngine;

public class CharacterMove_Monster : MonoBehaviour
{
   [SerializeField] Transform target;
    [SerializeField] float moveSpeed = 2.0f;
    [SerializeField] float fllowDistance = 1.0f;



    [SerializeField] SpriteRenderer spriteRenderer;

    [SerializeField] bool isSide=false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        spriteRenderer = this.GetComponent<SpriteRenderer>(); 
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isSide)
        {
            MoveSideView();
        }

        else
        {
            Move4direction();
        }

        Debug.Log(isSide);

    }

    void Move4direction()
    {

        Vector3 direction = target.position - this.transform.position;
        Vector3 lookDirection = direction.normalized; // lookDirection에 정규화된 방향 벡터를 넣었습니다.
        float distance = direction.magnitude; // float distance = Vector3.Distance(transform.position, target.position);
        // 자신과 타겟의 거리가 0이 아닌 경우에만 동작합니다.
        if (lookDirection != Vector3.zero)
        // Vector3.zero는 (0,0,0)과 같습니다.
        {
            // transform.up = lookDirection; // 객체의 위쪽 방향을 바라보는 방향으로 설정한다.
            transform.right = lookDirection;
        }
        if (distance > fllowDistance) // 혹은 Vector3.Distance(transform.position, targetTransform.position) > 1 (거리가 1보다 커야 움직이겟다)
            transform.position = Vector3.MoveTowards(this.transform.position, target.position, moveSpeed * Time.deltaTime);

    }
    void MoveSideView()
    {
        Vector3 direction = target.position - this.transform.position;
        Vector3 lookDirection = new Vector3(direction.x,0,0).normalized; // lookDirection에 정규화된 방향 벡터를 넣었습니다.

        spriteRenderer.flipX = lookDirection.x < 0; //이걸로 반전여부가 정해짐 
        //flipX와 flipY를 모두 활용할수있음매 

        // lookDirection 방향으로 moveSpeed 속도로 이동한다. (좌우로만. 사이드뷰 한계 !) 
        transform.position += lookDirection * moveSpeed * Time.deltaTime;

    }


}
