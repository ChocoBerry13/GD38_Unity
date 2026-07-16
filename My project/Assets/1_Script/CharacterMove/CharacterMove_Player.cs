using System;
using Unity.Hierarchy;
using UnityEngine;

public class CharacterMove_Player : MonoBehaviour
{
    float spawnTimer = 0f;
    
    [SerializeField] float spawnInterval = 2f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        float moveSpeed = 0.1f;
        transform.position += Vector3.right * moveSpeed * Time.deltaTime;
        spawnTimer += Time.deltaTime;

        if (spawnTimer >= spawnInterval)
        {
            SpawnMonster();
            spawnTimer -= spawnInterval;
        }
    }

    void SpawnMonster()
    {
        Debug.Log("몬스터가 스폰되었습니다");
    }
    /*
    public void MoveUp()
    {
        transform.position += new Vector3(0, 1, 0);
    }
    public void MoveDown()
    {
        transform.position += new Vector3(0, -1, 0);
    }
    public void MoveRight()
    {
        transform.position += new Vector3(1, 0, 0);
    }
    public void MoveLeft()
    {
        transform.position += new Vector3(-1, 0, 0);
    }
    */
}
