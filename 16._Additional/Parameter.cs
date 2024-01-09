using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16.Additional
{
    class Parameter
    {
        // <Name Parameter>
        // 함수의 매개변수 순서와 무관하게 이름을 통해 호출
        void Profile(int id, string name, string phone) { }

        void Main1()
        {
            // 기존 함수의 호출은 매개변수 순서대로 호출
            Profile(10, "감자", "010-1234-5678");
            // 함수 호출 시 매개변수 이름을 명명하고 순서와 상관없이 호출 가능
            Profile(phone: "010-1234-5678", id: 1, name: "홍길동");
        }

        // <Optional Parameter>
        // 함수의 매개변수가 초기값을 갖고 있다면, 함수 호출시 생략하는 것을 허용하는 방법

        void AddStudent(string name, string home = "서울", int age = 8) { }
        // Optional Parameter은 반드시 뒤에부터 초기값을 적용해야 함
        // void AddStudent1(string name, string home = "서울", int age) { }
        // error : 초기값이 있는 경우 뒤부터 할당해야 함

        void Main2()
        {
            // 기본은 모든 매개변수 전달. 하지 않으면 에러
            AddStudent("당근", "서울", 8);
            // age변수에 값을 넣지 않아도 자동으로 8값이 들어감
            AddStudent("고구마", "서울");
            // 값을 변경할 수 있음
            AddStudent("양파", "서울", 10);
            // 등등 다양하게 이용가능
            AddStudent("토마토", age: 9);
        }

        // <Params Parameter>
        // 매개변수의 갯수가 정해지지 않은 경우, 매개변수의 갯수를 유동적으로 사용하는 방법

        // parmas? 처리는 배열처럼 크기는 유동적으로
        int Sum(params int[] values)
        {
            int sum = 0;
            for (int i = 0; i < values.Length; i++) sum += values[i];
            return sum;
        }

        void Main3()
        {
            Sum(1, 3, 5, 7, 9);
            Sum(3, 5, 7);
            Sum();
        }


        // <out Parameter>
        // 매개변수를 출력전용으로 설정
        // 함수의 반환값 외에 추가적인 출력이 필요할 경우 사용

        // 출력이 하나가 아닌 여러개 일 때 사용
        // 매개변수의 입력에 out 키워드가 있다면 해당 매개변수는 입력이 아닌 출력값으로 처리해야 함
        void Divide(int left, int right, out int quotient, out int remainder)
        {
            quotient = left / right;
            remainder = left % right;

            // 함수의 종료전까지 out 매개변수에 값이 할당 안되는 경우 오류
            // 만약 out 키워드에 값을 전달하지 않으면 오류
        }

        void Main5()
        {
            int quotient;
            // 직접적으로 변수를 전달하여도, 만들면서 전달해도 됨
            Divide(5, 3, out quotient, out int remainder);
            Console.WriteLine($"{quotient}, {remainder}");  // output : 1, 2
        }

        // <in Paramter>
        // 매개변수를 입력전용으로 설정
        // 함수의 처음부터 끝까지 동일한 값을 보장하게 됨
        int WordCount(in string str)
        {
            return str.Split(' ').Length;
        }

        // 왜?? -> 예를들어 클래스를 매개변수로 받으면??
        // 클래스는 얕은 복사로 참조가 전달되어 원본이 변경될 위험이 있음
        // 내부에서 변경될 때 곤란한 경우 in 파라미터를 사용 -> 안에서 변경되면 에러
        public class Player
        { }

        public void Test(in Player player)
        {
            // player = null; 
            // 에러 : in키워드는 내부에서 수정 불가능
        }

        void Main4()
        {
            Player player = new Player();
            Test(in player);
            // player;
        }

        // <ref Paramter>
        // 매개변수를 원본참조로 전달
        // 매개변수가 값형식인 경우에도 함수를 통해 원본값을 변경하고 싶을 경우 사용
        // 구조체는 값만 전달하나 ref 키워드를 통해 해당 주소를 전달해 줄 수 있음
        void Swap(ref int left, ref int right)
        {
            int temp = left;
            left = right;
            right = temp;
        }

        void Main6()
        {
            int left = 10;
            int right = 20;
            Swap(ref left, ref right); // 10, 20 값이 아닌 left, right 그 자체를 전달(참조) 
            Console.WriteLine($"{left}, {right}"); // 값에 의한 호출이 아닌 참조에 의한 호출로 변경
        }
    }
}
