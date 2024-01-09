using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace _16.Additional
{
    class Property
    {
        public class Player
        {
            // 접근 제한자? 
            private int hp;     // 확인 Ok, 수정 No

            // private변수에 접근하기 위해 Get, Set메소드를 두는 것이 일반적

            // public은? 둘 다 public으로 메소드를 만들기보다 변수를 public으로 하면??
            // -> 권장하지 않는 방법 -> 소스 코드 중 잘못된 처리를 찾기 어려움(어디에서 연산이 잘못되었는지??)
            // 함수를 제공하면 해당 함수를 통해서만 진행할 수 있고 수정하는 타이밍을 확인할 수 있음(breakPoint)

            // => 그래서 보통은 멤버 변수에 접근하기 위한 메소드(Get, Set)를 제공함

            // <Getter Setter>
            // 멤버변수가 외부객체와 상호작용하는 경우 Get & Set 함수를 구현해 주는 것이 일반적
            // 1. Get & Set 함수의 접근제한자를 설정하여 외부에서 멤버변수의 접근을 캡슐화함
            // 2. Get & Set 함수를 거쳐 멤버변수에 접근할 경우 호출스택에 함수가 추가되어 변경시점을 확인 가능

            // -> 매번 만드는 행동 -> 길게 사용하기 보다 프로퍼티(property) 제공

            public int GetHP()
            {
                return hp;
            }

            private void SetHP(int hp)
            {
                this.hp = hp;
            }

            // <속성 (property)>
            // Get & Set 함수의 선언을 간소화

            public event Action<int> OnChangeMp;

            private int mp;
            public int MP               // mp 멤버변수의 Get & Set 속성
            {
                get { return mp; }                      // get : Get함수와 역할동일
                set { mp = value; OnChangeMp(mp); }     // set : Set함수와 역할동일, 매개변수는 value

                // 팁? 셋 함수에 이벤트 붙여놓기
            }

            public int AP { get; set; }                 // AP 멤버변수를 선언과 동시에 Get & Set 속성
            public int Sp { get; } = 10;                // 읽기전용 속성(상수와 똑같음. 굳이??)
            public int DP { get; private set; }         // 속성의 접근제한자를 통한 캡슐화(Set은 외부에서 접근 불가)


        }

        void Main()
        {
            Player player = new Player();
            int playerHp = player.GetHP(); // 확인은 가능
            // player.SetHP(100);             수정은 불가능

            // 프로퍼티의 사용은 변수처럼 사용
            int playerMp = player.MP;       // get
            player.MP = 10;                 // set

            int playerAp = player.AP;
            player.AP = 10;

            int playerDp = player.DP;
            // player.DP = 20;              // 설정불가
        }
    }

}
