using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.OOP
{
    public class Abstraction
    {
        // 추상화(Abstraction)

        // 클래스를 정의할 당시 구체화 시킬 수 없는 기능을 추상적 표현으로 정의

        // <추상클래스 (abstract class)>
        // 하나 이상의 추상함수를 포함하는 클래스
        // 클래스가 추상적인 표현을 정의하는 경우 자식에서 구체화시켜 구현할 것을 염두하고 추상화 시킴
        // 추상클래스에서 내용을 구체화 할 수 없는 추상함수는 내용을 정의하지 않음
        // 추상클래스는 상속하는 자식클래스가 추상함수를 재정의하여 구체화한 경우 사용가능

        public abstract class Animal // 하나라도 추상 함수가 있다면 abstract 키워드 사용
        {
            public string name;
            public int age;

            // 동물이 운다??? -> 우는 행위는 확실한데 지금 당장에 구현을 할 수 없음
            // 내용이 없음.. -> 개념적인 부분이지 실체화 할 수 없음 -> 메소드의 정의만 필요 -> abstract
            // Cry는 지금 당장 구현할 수 없을거야 정의만 있고 대신 자식 클래스가 구현해 줄 거야
            // abstract는 부모 클래스에서 선언만, 실제 구현은 override로 자식 클래스에서 구현

            // Animal을 상속받는 클래스는 반드시 Cry를 구현해야 함. 하지 않으면 에러
            public abstract void Cry();

            // virtual과 차이??
            // virtual은 덮어쓸 수도 있다(선택)
            // abstract는 무조건 덮어써야 한다(강제)
        }

        public class Cat : Animal
        {
            public override void Cry()
            {
                Console.WriteLine("야옹"); // 자식클래스에서 구체화
                                         // 하지 않으면 에러 
            }
        }
        public class Dog : Animal
        {
            public override void Cry()
            {
                Console.WriteLine("멍멍");
            }
        }

        static void Main1(string[] args)
        {
            Animal cat = new Cat();

            cat.Cry();
        }

        // 추상화의 장점?

        // ex) 아이템

        public abstract class Item
        {
            public abstract void Use(); // 가상함수
        }
        public class Potion : Item
        {
            // 반드시 구현해야 하므로 실수를 매우 줄일 수 있다
            public override void Use() // 자식 클래스에서 반드시 구현
            {

            }
        }
        public class Player
        {
            // item에는 Use메소드가 반드시 구현되어 있어야 오류가 없음
            public void Use(Item item)
            {
                item.Use();
            }
        }

        // 추상화 사용의미 1
        // 객체들의 공통적인 특징을 도출하는데 의미
        // 구현을 구체화하기 어려운 상위클래스를 설계하기 위한 수단으로 사용

        // 추상화 사용의미2
        // 상위클래스의 인터페이스를 구현하기 위한 수단으로 사용
        // 추상적인 기능을 구체화시키지 않은 경우 인스턴스 생성이 불가
        // 이를 통해 자식클래스에게 추상함수의 구현을 강제하여 실수를 줄임
    }
}
