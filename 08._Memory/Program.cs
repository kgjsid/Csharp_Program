using System.Numerics;

namespace _08.Memory
{
    class Program
    {
        // 메모리 (Memory)

        // 프로그램을 처리하기 위해 필요한 정보를 저장하는 기억장치
        // 프로그램은 메모리에 저장한 정보를 토대로 명령들을 수행함

        // 빠른 계산 (CPU) -> 뇌
        // 저장 장치 (Memory)

        // 메모리구조

        // 프로그램은 효율적인 메모리 관리를 위해 메모리 영역을 구분
        // 데이터는 각 역할마다 저장되는 영역을 달리하여 접근범위, 생존범위 등을 관리

        // <메모리 구조>

        // 코드 영역 -> 실행할 프로그램의 코드
        // 데이터 영역 -> 정적 변수
        // 힙 영역 -> 클래스 인스턴스
        // 스택 영역 -> 지역변수, 매개변수

        // <코드 영역>
        // 프로그램이 실행할 코드가 저장되는 영역
        // 데이터가 변경되지 않은 읽기 전용 데이터

        // <데이터 영역>
        // 정적변수가 저장되는 영역
        // 프로그램의 시작시 할당되며 종료시 삭제됨

        // <스택 영역>
        // 지역변수와 매개변수가 저장되는 영역
        // 함수의 호출시 할당되며 종료시 삭제됨

        // <힙 영역>
        // 클래스 인스턴스가 저장되는 영역
        // 인스턴스를 생성시 할당되며 더이상 사용하지 않을시 자동으로 삭제됨
        // 인스턴스를 참조하고 있는 변수가 없을 때 더이상 사용하지 않는다고 판단
        // 더이상 사용하지 않는 인스턴스는 가비지 컬랙터가 특정 타이밍에 수거해감

        // < 변수의 접근범위와 생존범위 >

        /*                  메모리 영역         접근 범위      생존 범위
         * 정적변수         데이터 영역          모든          프로그램 시작에서 끝까지
         * 
         * 지역변수         스택영역             블록 내부     블록 시작에서 끝까지
         * 매개변수
         * 
         * 인스턴스           힙영역            참조가능한        인스턴스 생성부터
         *                                     모든 구역     더이상 사용하지 않을때까지
         */

        // 

        // 스택 영역

        // 함수호출스택을 이용하여 호출과 종료에 연관되는 데이터를 저장하는 영역
        // 프로그램은 스택구조를 통해 함수에서 사용한 데이터들을 효율적으로 관리함

        // <함수호출스택>
        static void Stack2(int a)
        {
            int b = 1;
            a = 3;
        }
        static void Stack1(int a)
        {
            int b = 10;
            a = 2;
            Stack2(2);
        }
        static void Main1(string[] args)
        {
            int b = 20;
            int a = 1;      // 지역변수 : 블록 안에서 생성 블록 끝에서 소멸
            Stack1(a);
        }
        // 모든 a, b는 각각의 함수 영역에서만 사용됨 -> 이름은 동일하나 전혀 다른 변수들

        // 힙 영역

        // 클래스 인스턴스가 보관하는 영역
        // 프로그램은 가비지 콜렉터를 통해 더이상 사용하지 않는 인스턴스를 수거함


        // <가비지 콜렉터>
        class HeapClass { }

        static void Main2(string[] args)
        {
            // 함수 시작시
            // 지역변수 local이 스택 영역에 저장됨

            HeapClass local;            // 함수 시작시 이미 메모리에 할당되어 있음
            local = new HeapClass();    // 인스턴스를 힙영역에 생성하고 주소값을 local에 보관

            // 함수 종료시
            // 지역변수 local이 함수 종료와 함께 소멸
            // 인스턴스 new HeapClass() 는 함수 종료와 함께 더이상 사용되지 않음(더이상 참조하는 변수가 없음)
            // 인스턴스 new HeapClass() 는 가비지가 되어 가비지 컬렉터가 동작할 때 소멸됨
        }

        // <가비지컬랙터의 대상>

        // 인스턴스를 참조하고 있는 변수가 없는 경우(접근이 불가능한 경우에)

        // <데이터 영역>

        // 정적변수를 저장하는 영역
        // 프로그램은 시작시 데이터 영역을 생성하며 종료시 데이터 영역을 해제함

        // <정적 (static)>
        // 프로그램의 시작과 함께 할당, 프로그램 종료시에 소멸, 프로그램이 동작하는 동안 항상 고정된 위치에 존재
        // 정적변수 : 프로그램 전역에서 접근 가능한 변수, 클래스의 이름을 통해 접근 가능
        // 정적함수 : 인스턴스 없이도 접근 가능한 함수, 클래스의 이름을 통해 접근 가능
        // 정적클래스 : 인스턴스 없이도 접근 가능한 클래스, 정적변수와 정적함수만을 포함 가능


        public static class StaticClass // 정적클래스 StaticClass
        {
            public static int value;

            public static void Test()
            {

            }
        }
        class Player
        {
            public static int value; // 정적변수 value
            public static void Test() // 정적함수 Test
            {

            }
        }

        static void Main(string[] args)
        {
            Player.value = 10; // 어느 영역에서나 클래스의 이름을 통해 접근 가능
            Player.Test();
        }

        // static 함수에서 일반 함수는 사용불가
        // 반대로 일반 함수에서 static 함수는 사용가능
        // 스택이나 힙에서는 데이터 영역 사용가능
        // 반대로 데이터 영역에서는? -> 데이터 영역은 시작부터 있음 -> 스택이나 힙은 시작부터 없다보니 특정할 수 없음
        static void StaticFunction()
        {
            // Function(); 불가능
        }
        void Function()
        {
            StaticFunction(); // 가능
        }

        class StaticClass1
        {
            public static int staticValue;
            public int nonStaticValue;

            public static void StaticFunc()
            {
                Console.WriteLine(staticValue);
                //Console.WriteLine(nonStaticValue); 에러 : 정적함수에서 멤버변수를 사용할 수 없음

                StaticClass1 staticClass = new StaticClass1();
                Console.WriteLine(staticClass.nonStaticValue); // 사용가능 실제로 객체로 만든 것은 힙 영역에 만들어지고 이용 가능 
            }
        }
        // 기억하기?

        // 1. static은 클래스이름.으로 이용가능
        // 2. static클래스에는 static만 있을 수 있다
        // 3. static 영역에서 일반 영역 사용 불가
    }
}
