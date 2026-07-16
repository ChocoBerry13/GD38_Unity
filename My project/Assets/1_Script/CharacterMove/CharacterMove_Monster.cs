using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class CharacterMove_Monster : MonoBehaviour
{
    [SerializeField] Transform targetTransform; //player 의 transform 을 가져오기위해
    [SerializeField] float moveSpd;//몬스터의 이동속도르 inspector 창에서 조절하기위해



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction =( targetTransform.position - transform.position).normalized; //transform.forward 써도됨 바라보는방향
                                //목적지에서 - 현재 내 포지션을 빼면 방향을 구할수잇음
 
        // 방향벡터 정규화하기. (힘을 제외, 방향만)
        if (direction != Vector3.zero) // Vector3.zero는 (0,0,0)과 같습니다.
        {
            transform.up = direction; // 객체의 위쪽 방향을 바라보는 방향으로 설정한다.
        }
        transform.position = Vector3.MoveTowards(transform.position, targetTransform.position, moveSpd*Time.deltaTime);
    }// 현재 위치 = 이동을 시키는 함수(현재위치에서, 목표위치까지, 1초에 movespd만큼)
}
