using UnityEngine;

//public class Interactable : MonoBehaviour
//{
//    // Start is called once before the first execution of Update after the MonoBehaviour is created

//}
 public interface IInteractable  
    {
        void Interact();
    }
    //이녀석을 다른 class들에 상속 시켜서 쓴다 (아이템 '트리거')등을 인터페이스로 한꺼번에 쓰기 