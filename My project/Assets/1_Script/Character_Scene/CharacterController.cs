using UnityEngine;
using UnityEngine.UI;

public class CharacterController : MonoBehaviour
{
    public Button[] Buttons;// 유니티 버튼을 배열로 넣고 '버튼즈'라는 이름으로 관리할거임
    public ButtonAction CharacterButtonAction;//트랜스폼 하나를 선언해서 써먹을
                                                                 //까 했는데 그냥 버튼액션이란 클래스 하나로 합치기



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Buttons[0].onClick.AddListener(CharacterButtonAction.MoveUp); //button 자체가 유니티에서 만든 클래스
                       //onclick도 수도 그래서 클래스가 공통이니까 호출되는데
                       //Button 배열의 0번 인덱스에 있는 Button 컴포넌트의 Onclick 기능(버튼이 눌렸을시동작)에 Character 의 MoveLeft를 움직이게함
                       //아마 이제 이 Button에 캔버스에 넣어둔 버튼들을 할당하는 식이 될것임
        Buttons[1].onClick.AddListener(CharacterButtonAction.MoveDown);
        Buttons[2].onClick.AddListener(CharacterButtonAction.MoveLeft);
        Buttons[3].onClick.AddListener(CharacterButtonAction.MoveRight);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
