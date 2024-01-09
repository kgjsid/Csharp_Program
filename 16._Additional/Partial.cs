using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16.Additional
{
    class Partial
    {
        /*public class Player
        {
            // 만약 해당 내용이 1000줄정도 되면?
            // -> 하나의 파일에는 작성이 어려움 -> 분리시켜서 작성

            // <Partial Type>
            // 클래스, 구조체, 인터페이스를 분할하여 구현하는 방법
            // 대규모 프로젝트에서 작업하는 경우 분산하여 구현에 유용
            // 실제로 사용할 때 합쳐짐  
        }
        */
        // 전투담당자 Player 소스
        public partial class Player
        {
            private int hp;
            public int Hp { get => hp; set => hp = value; }
            public void Attack() { }
        }

        // 아이템 담당자 Player 소스
        public partial class Player
        {
            private int weight;

            public void GetItem() { }
        }

        // <Partial Method>
        // Partial Type에서 Partial Method가 포함될 수 있음
        // 선언부와 구현부를 분리하여 구현함으로서 구현부를 숨길 수 있음

        // 선언부 : 함수가 있다는 것만 표시(설명서)
        public partial class Monster
        {
            public partial void Attack();
        }

        // 구현부 : 함수를 실제로 구현
        public partial class Monster
        {
            public partial void Attack()
            {
                // 실제 함수 구현
            }
        }

    }
}
