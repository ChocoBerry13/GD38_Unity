using Unity.Mathematics;
using UnityEngine;

public class BulletMove : MonoBehaviour
{

    [SerializeField] Transform target;
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float rotateSpeed = 180f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = (target.position - this.transform.position).normalized; // 타겟까지 방향
                                                                                    //Quaternion.FromToRotation 은 타겟 방향까지 얼마나 회전해야하는지 계산시켜주는 함수
        Quaternion targetRotation = Quaternion.FromToRotation(Vector3.up, direction);
        //현재 각도에서 목표까지 rotateSpeed속도로 회전
        transform.rotation = Quaternion.RotateTowards(this.transform.rotation, targetRotation, rotateSpeed);

        //바라보는 화면으로 moveSpeed만큼 이동
        // 'rotateSpeed'는 1초 동안 회전할 수 있는 각도입니다. 
        // 값이 크면 목표 방향으로 빠르게 회전하고, 값이 작으면 넓게 휘어지며 이동합니다.
        transform.position += transform.up * moveSpeed * Time.deltaTime;
    }
}
