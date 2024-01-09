using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.OOP
{

    class Polymorphism
    {
        // 다형성(Polymorphism)

        // 객체의 속성이나 기능이 상황에 따라 여러가지 형태를 가질 수 있는 성질

        // <다형성>
        // 부모클래스의 멤버를 자식클래스가 상황에 따라 여러가지 형태를 가질 수 있는 성질

        class Car
        {
            protected string name;
            protected int speed;

            public void Move()
            {
                Console.WriteLine($"{name} 이/가 {speed} 의 속도로 이동합니다.");
            }
        }

        class Truck : Car
        {
            public Truck()
            {
                name = "트럭";
                speed = 30;
            }
        }

        class SportCar : Car
        {
            public SportCar()
            {
                name = "스포츠카";
                speed = 100;
            }
        }

        static void Main1(string[] args)
        {
            Car car1 = new Truck();
            Car car2 = new SportCar();

            car1.Move();    // 트럭이 30의 속도로 이동
            car2.Move();    // 스포츠카가 100의 속도로 이동
        }

        // <가상함수와 오버라이딩>
        // 가상함수 : 부모클래스의 함수 중 자식클래스에 의해 재정의 할 수 있는 함수를 지정
        // 오버라이딩 : 부모클래스의 가상함수를 같은 함수이름과 같은 매개변수로 재정의하여 자식만의 반응을 만들어 냄.
        public class Skill
        {
            protected float coolTime;
            public virtual void Execute() // virtual 키워드
            {
                Console.WriteLine("스킬 재사용 대기시간을 진행시킴");
            }
        }

        public class FireBall : Skill
        {
            public FireBall()
            {
                coolTime = 3f;
            }

            public override void Execute() // override : 가상함수를 재정의
            {
                base.Execute(); // base는 부모를 의미. 부모의 Execute()를 실행
                Console.WriteLine("불덩이 날리기");
            }
        }

        public class Heal : Skill
        {
            public Heal()
            {
                coolTime = 15f;
            }

            public void Execute()
            {
                Console.WriteLine("스킬 재사용 대기시간을 진행시킴");
                Console.WriteLine("체력 회복");
            }
        }

        static void Main2341(string[] args)
        {
            Skill fireBall = new FireBall();

            fireBall.Execute();


            Console.WriteLine("\n\n");
            Skill heal = new Heal();
            heal.Execute();

            Console.WriteLine("\n\n");

            FireBall fireBall2 = new FireBall();
            Heal heal2 = new Heal();

            fireBall2.Execute();
            heal2.Execute();

            // fireball은 override했더니 fireball용 execute만 호출
            // heal은 Skill에 담거나 Heal에 담았을 때 각각 다른 execute만 호출
        }

        // 자식 클래스에서 재정의(override) 하고 싶다면 반드시 부모 클래스에서 가상함수(virtual)로 만들어 주어야 함
        // 클래스가 특정 기능에 대하여 자식마다 다른 기능을 원한다면 가상함수와 오버라이딩을 이용할 것!!!

        // 원리는 어려워.. -> 알고싶으면? -> 가상함수테이블 조사하기

        /*
            몬스터 변수? → 드래곤, 슬라임, 오크 가능

            왜? 기본적으로 상속받은 클래스를 할당하고 이어서 자기 자신만의 메모리를 붙여 만드니까

            스킬 상황은? → 비슷함 기본 부모 함수를 만들고 이어서 자신의 함수를 붙임

            만약 가상함수를 사용하지 않은 상황은?
           
            -> 상속의 경우와 거의 동일함
            -> skill을 상속받은 fireball은 skill의 함수를 만들고 자신만의 함수를 이어붙임
            -> skill클래스 변수는 fireball의 execute를 모름 -> skill의 execute를 사용
            -> fireball의 execute를 쓰고싶다면 fireball 클래스로 만들어야 함    

            만약 가상함수를 사용한 상황은??
                
            -> 가상함수는 만약에 자식에서 Execute를 새로 만들면, 부모에 기존에 있던 가상함수를 지우고 대신 자식의 해당 함수를 사용하는 구조
            -> override는 가상함수를 대체하여 자신으로 덮어쓰겠다는 의미
            -> 스킬을 사용하여도 자식의 함수를 사용할 수 있도록 연결해주는 역할

        => 부모의 함수를 덮어쓰는 원리가 가상함수와 오버라이드
        => 대체 가능한 함수는 가상함수로 만들어주자
        -> 해당 위치에 있는 함수가 아닌 다른 위치의 함수를 실행시킨다(메모리 주소 갈아끼우면 가능!!!)
        
        */

        // <다형성 사용의미 1>
        // 새로운 클래스를 추가하거나 확장할 때 기존 코드에 영향을 최소화함
        public class Player
        {
            protected Skill skill;
            // 스킬을 사용하는 클래스가 확장되어도 그냥 놔두어도 됨
            // 무슨 스킬인지 중요한게 아닌 스킬을 사용한다로 해당 스킬을 받아 사용하기만 됨
            public void SetSkill(Skill skill)
            {
                this.skill = skill;
            }

            public void UseSkill()
            {
                skill.Execute();
            }
        }
        // <다형성 사용의미 2>
        // 클래스 간의 의존성을 줄여 확장성은 높임
        class SkillContents : Skill { } // 프로그램의 확장을 위해 상위클래스를 상속하는 클래스를 개발
        // 상속받는 것으로 해당 스킬을 사용할 수 있음

        public class NewChampion : Player
        {
            public NewChampion()
            {
                SetSkill(new NewSkill());
            }
        }

        public class NewSkill : Skill
        {
            public override void Execute()
            {
                base.Execute();
                // 새로운 스킬이 동작하는 구현
            }
        }
    }
}
