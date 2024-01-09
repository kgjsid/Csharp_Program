using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14.Delegate
{
    class Lambda
    {
        // <무명 메서드와 람다식>

        // 델리게이트 변수에 할당하기 위한 함수를 소스코드 구문에서 생성하여 전달
        // 전달하기 위한 함수가 간단하고 일회성으로 사용될 경우에 간단하게 작성
        void Main()
        {
            Action<string> action;

            // <함수를 통한 할당>
            // 클래스에 정의된 함수를 직접 할당
            // 클래스의 멤버함수로 연결하기 위한 기능이 있을 경우 적합
            action = Message;

            // 함수자체가 필요하긴 하다만 1회용으로 잠시 쓰기 위한 함수? 쓰고 버리는 용도?
            // 기본적으로 함수는 코드 영역에 작성되어 있음
            // 코드 영역은 프로그램 끝까지 계속 남아 있음 -> 잠시 쓰고 버릴 수 없는지??

            // <무명메서드>
            // 함수를 통한 연결은 함수가 직접적으로 선언되어 있어야 사용 가능
            // 할당하기 위한 함수가 간단하고 자주 사용될수록 비효율적
            // 간단한 표현식을 통해 함수를 즉시 작성하여 전달하는 방법
            // 전달하기 위한 함수가 간단하고 일회성으로 사용될 경우에 적합
            action = delegate (string str) { Console.WriteLine(str); };

            // 반환형과 이름 없이, 매개변수와 내용으로 잠시 사용하기 위함
            action("메세지");

            // <람다식>
            // 무명메서드의 간단한 표현식
            // (매개변수 => 내용) 의 형식으로 작성함
            action = (str) => Console.WriteLine(str);
            action = str => Console.WriteLine(str);

            // 한번 사용하고 버려버림
            action = null;

        }

        void Message(string message)
        {
            Console.WriteLine(message);
        }

        bool Less1(int value)
        {
            return value < 1;
        }
        // Less2, Less3, ...


        // 람다식 예제
        void Main7()
        {
            int[] array = { 2, 5, -4, 3, 10, -9, -8 };

            // 기본 배열의 오름차순
            Array.Sort(array);

            // 내림차순은?
            Array.Sort(array, Comparer<int>.Create((a, b) => { return b - a; }));

            // 절댓값 정렬
            Array.Sort(array, Comparer<int>.Create((a, b) => { return Math.Abs(a) - Math.Abs(b); }));

            // 절댓값 5이하 기준 찾기
            int[] find = Array.FindAll(array, value => { return Math.Abs(value) < 5; });
        }
    }
}
