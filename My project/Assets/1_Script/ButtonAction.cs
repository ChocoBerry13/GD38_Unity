using UnityEngine;

public class ButtonAction : MonoBehaviour
{

    SpriteRenderer spriteRenderer;

    void Awake() // 가장 먼저 실행되는 함수.
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void OnEnable() // 활성화될때 실행되는 함수
    {
        transform.position = new Vector3(0, 0, 0);
    }
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //spriteRenderer.color = Color.black;
    }

    // Update is called once per frame
    void Update()
    {
       
        //오브젝트의 위치 (vector3임)에 1씩을 업데이트때마다 더해줌
        // 오브젝트의 위치를 x+1만큼씩 이동시킨다.
    }

    public void MoveUp()
    {
        transform.position += new Vector3(0, 1, 0);
    }
    public void MoveDown()
    {
        transform.position += new Vector3(0,-1, 0);
    }
    public void MoveRight()
    {
        transform.position += new Vector3(1, 0, 0);
    }
    public void MoveLeft()
    {
        transform.position += new Vector3(-1, 0, 0);
    }
}

