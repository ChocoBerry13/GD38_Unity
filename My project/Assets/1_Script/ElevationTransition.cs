using UnityEngine;

public class ElevationTransition : MonoBehaviour
{
    [SerializeField] GameObject[] currentCollision; //현재 층
    [SerializeField] GameObject[] nextCollision;// 이동할 층
    [SerializeField] SpriteRenderer playerRenderer;//플레이어의 SortingLayer를 관리함
    [SerializeField] string nextSortingLayer; // 변경해줄 SortingLayer를 관리하 ㅁ

    void OnTriggerEnter2D(Collider2D other)
    {
        // 충돌 객체의 Tag가 Player가 아니면 함수 종료
        if (!other.CompareTag("Player")) return;
        for (int i = 0; i < currentCollision.Length; i++)
        {
            //현재 층 모든 오브젝트 Collision 비활성화
            currentCollision[i].SetActive(false);
        }
        for (int i = 0; i < currentCollision.Length; i++)
        {
            //이동할 층 모든 오브젝트 Collision 비활성화
            nextCollision[i].SetActive(true);
        }
        //Player의 SortingLayer를 이동할 층Layer로 변경
        playerRenderer.sortingLayerName = nextSortingLayer;
    }

}
