using System;
using TMPro;
using Unity.Hierarchy;
using UnityEngine;

public class CharacterMove_Monster : MonoBehaviour
{
   [SerializeField] Transform target;


   [SerializeField] float moveSpeed = 2.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = target.position - this.transform.position;
        Vector3 lookDirection = direction.normalized; // lookDirection에 정규화된 방향 벡터를 넣었습니다.
        float distance = direction.magnitude; // float distance = Vector3.Distance(transform.position, target.position);
        // 자신과 타겟의 거리가 0이 아닌 경우에만 동작합니다.
        if (lookDirection != Vector3.zero) // Vector3.zero는 (0,0,0)과 같습니다.
        {
            transform.up = lookDirection; // 객체의 위쪽 방향을 바라보는 방향으로 설정한다.
        }
       transform.position = Vector3.MoveTowards(this.transform.position, target.position, moveSpeed * Time.deltaTime);

    }


}
