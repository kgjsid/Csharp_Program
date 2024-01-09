using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15.Event
{
    class Architecture
    {
        public class Call
        {
            // <Call 방식>
            // 일련의 사건이 발생한 순간에 대상의 함수를 호출하여 진행
            // 장점 : 불필요한 연산 없이 일련의 사건이 발생한 타이밍에 처리 가능
            // 단점 : 추가 기능 개발시 클래스를 수정해야하는 개방폐쇄의 원칙을 위반함

            // -> 혼자가 아닌 여러명이 만들면? -> 만약 기능이 추가되면 player 클래스 내부의 소스를 변경해야 함
            // 추가 개발시 마다 기존에 있던 Player의 소스가 변경이 필요해짐
            // 게임은 항상 추가 기능이 필요해지고 그 때마다 기존의 소스가 영향을 받으면 클래스 수정이 필요함
            // 클래스 내부 수정이 아닌 추가되는 기능만 수정하면?

            // Polling? -> 계속 쳐다보고 있다
            //  <Polling 방식>
            // 대상에서 일련의 사건 발생을 확인하기 위해 계속해서 변경사항을 확인
            // 장점 : 추가 기능 개발시에도 클래스를 수정하지 않아 개방폐쇄의 원칙을 준수함
            // 단점 : 변경사항이 없는 경우에도 계속 확인해야하는 불필요한 연산이 발생

            // 클래스 수정은 하지 않아도 괜찮음
            // 다만 변경사항이 생겼을 때 마다 플레이어가 변경사항을 계속 전달하여야 함 -> UI가 지속해서 체크
            // => 너무 불필요한 연산이 실행됨(변경되지 않아도 주기적으로 실행해야 하므로)

            // <Event 방식>
            // 일련의 사건이 발생하였을 때 반응할 대상을 참조하고 사건 발생시 호출하여 진행
            // 장점 : 개방폐쇄의 원칙이 지켜지며, 불필요한 연산을 필요로 하지 않음
            // 단점 : 이벤트를 구성하기 위한 추가적인 소스를 작성해야 하며 실시간 연산에는 매우 느림

            // Event가 가장 좋은가???
            // -> 위치와 같이 실시간 연산이 필요한 경우에는 Event방식이 느리며 Polling방식을 사용하는 것이 좋음 
            // -> 보통 이벤트 처리는 호출에 있어 다른 방식보다 조금 느림

            // => 세 방식의 장단점은 뚜렷하며 상황에 따라 올바른 방식을 이용할 수 있음
            public class Player
            {
                public int hp = 100;

                public UI ui;

                public event Action OnChangeHp;

                public void Hit(int damage)
                {
                    hp -= damage;
                    Console.WriteLine($"Hit! Current Hp : {hp}");

                    // 클래스에서 연관된 기능들을 직접 호출해야함
                    // 만약 새로운 기능이 추가되는 경우 계속해서 수정될 부분
                    ui.SetHp();

                    if (OnChangeHp != null)
                        OnChangeHp();
                }
            }

            // <Call 방식>
            public class UI
            {
                public void SetHp()
                {
                    Console.WriteLine("UI SetHp가 실행됨");
                }
            }

            // <Polling 방식>
            public class SFX
            {
                public Player player;
                // SFX를 갱신하기 위해 주기적으로 실행해야 함
                // 갱신이 늦을 경우 SFX에서 확인하는 내용이 실제 데이터와 다를 수 있음
                // 계속 체크해야 함.
                public void PlayerSound()
                {
                    // 플레이어를 계속 체크
                }
            }

            // <Event 방식>
            public class VFX
            {
                // 이벤트가 발생하였을 때 실행될 함수
                // 다만 Main에서 해당 함수를 할당해주어야 함.
                public void PlayerEffect()
                {

                }
            }

            static void Main()
            {
                Player player = new Player();
                VFX vfx = new VFX();
            }
        }
    }
}
