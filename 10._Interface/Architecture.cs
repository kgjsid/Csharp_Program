using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.Interface
{
    class Architecture
    {
        // 추상클래스와 인터페이스

        // 인터페이스는 추상클래스의 일종으로 특징이 동일함
        // 함수에 대한 선언만 정의하고 이를 포함하는 클래스에서 구체화하여 사용
        // 하지만, 추상클래스와 인터페이스를 통해 얻는 효과는 다르며 다른 역할을 수행함
        // 개발자는 인터페이스와 추상클래스 중 더욱 상황에 적합한 것으로 구현해야 함

        // <추상클래스와 인터페이스>
        // 공통점 : 함수에 대한 선언만 정의하고 이를 포함하는 클래스에서 구체화하여 사용
        // 차이점 : 추상클래스 - 변수, 함수의 구현 포함 가능 / 다중상속 불가
        //         인터페이스 - 변수, 함수의 구현 포함 불가 / 다중포함 가능

        // 추상클래스는 상속관계, 인터페이스는 행동을 포함하는 것

        // 설계도
        // 추상클래스는 (A Is B 관계)
        // 상속 관계인 경우, 자식클래스가 부모클랫의 하위분류인 경우
        // 상속을 통해 얻을 수 있는 효과를 얻을 수 있음
        // 부모클래스의 기능을 통해 자식클래스의 기능을 확장하는 경우 사용

        // 계약서
        // 인터페이스 (A Can B 관계)
        // 행동 포함인 경우, 클래스가 해당 행동을 할 수 있는 경우
        // 인터페이스를 사용하는 모든 클래스와 상호작용이 가능한 효과를 얻을 수 있음
        // 인터페이스에 정의된 함수들을 클래스의 목적에 맞게 기능을 구현하는 경우 사용

        // ex) 건물 -> 은행 / 은행은 건물이다 => 상속
        // ex) 들어갈 수 있다 -> 차 / 차는 들어갈 수 있다 => 인터페이스

        public interface IEnterable
        {
            public void Enter();
        }

        public abstract class Building
        {
            protected int Position;
            // 구현해야 할 함수를 제외하고 기능 함수
            public abstract void Enter();
        }

        public class Bank : Building
        {
            // 만약 인터페이스를 사용하면 빌딩의 모든 기능을 다시 구현해야 함
            // 상속을 받음으로써 구현해야 할 함수를 제외하고 전부 받을 수 있음
            public override void Enter()
            {

            }
        }

        public class Car : IEnterable
        {
            // 부모의 기능이 자식에서 올바르지 않을 수도 있음 -> 상속 부적합
            public void Enter()
            {

            }
        }

        /*
        public abstract class EnterableObject
        {
            public string key;
            public abstract void Enter();
        }

        public interface IEnterable
        {
            // public string key; -> 변수 정의 불가. 행동(함수)만 정의 가능
            public void Enter();
        }
        */

        // 역할자체는 매우 비슷 -> 반드시 포함하는 클래스에서 해당 기능을 구현해야 함
        // 하지만 얻는 효과가 다르며 엄밀히 따지면 다른 역할을 수행함

        // 서로가 각자 사용하기 좋은 상황이 있음

        public class Human
        {
            public int hp;
            public string name;
        }

        public interface IHitable
        {
            public void TakeHit(int damage);
        }

        public class Player : Human, IHitable
        {
            public Player()
            {
                hp = 50;
            }

            public void TakeHit(int damage)
            {
                hp -= damage;
            }
        }

        public class NPC : Human
        {
            public NPC()
            {
                hp = 100;
            }
        }

    }
}
