using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14.Delegate
{
    // 델리게이트의 사용 사례1
    // 콜백함수

    // 델리게이트를 이용하여 특정조건에서 반응하는 함수를 구현
    // 함수의 호출(Call)이 아닌 역으로 호출받을 때 반응을 참조하여 역호출(Callback)
    class Callback
    {
        // 함수는 보통 호출한다고 표현. Callback은 호출 당하다?
        // 보통 함수는 직접적으로 호출(이름 부르기)하여 진행함
        // Callback은 연결해둔 함수가 호출 당하게끔 도와주는 역할을 함
        public class Button
        {
            // 버튼 클릭했을 때 동작은?
            // 버튼에 따라 다름(공격, 점프, 일시정지...) -> virtual로 구현
            // 가상함수 -> 상속? -> 버튼이 100개라면(스킬창)...?? -> 너무 많은 상속

            public Action OnClick;

            public virtual void Click()
            {
                // 행동만 바뀐다면? -> 어떤 함수만 하는지 보관한다면? => 델리게이트
                if (OnClick != null)
                    OnClick();
            }

            // null?

            // ex) 무언가 클래스 변수가 인스턴스를 참조하고 있다 -> 참조 변수가 아무것도 가리키지 않으면? -> null
            // 참조 변수가 가리키고 있는 것이 없다로 null을 이용함
        }

        public class Player
        {
            public void Jump() { Console.WriteLine("플레이어가 점프함"); }
            public void Dash() { Console.WriteLine("플레이어가 대시함"); }
        }

        void Main4()
        {
            Player player = new Player();

            Button jumpButton = new Button();
            jumpButton.OnClick = player.Jump;
            // jumpButton의 OnClick 델리게이트에 플레이어의 Jump함수를 저장
            // 호출 당할 녀석을 지정해주는 방식
            // Player.Jump() 또한 동일한 역할이며 이 방식은 직접 함수를 호출하는 방식

            Button dashButton = new Button();
            dashButton.OnClick = player.Dash;
            // dashButton의 OnClick 델리게이트에 플레이어의 Dash함수를 저장
            // Dash 자체를 집어넣지 실행해 라는 아니므로 Dash()가 아니다

            Button voidButton = new Button();

            jumpButton.Click();
            // jumpButton의 Click()이 실행되면 OnClick에 담겨있는 함수(Jump)가 실행
            dashButton.Click();
            // jumpButton의 Click()이 실행되면 OnClick에 담겨있는 함수(Dash)가 실행
            voidButton.Click();
            // Click이 실행되어도 OnClick에 담겨있는 함수가 없으므로 실행되지 않음
        }
    }
}