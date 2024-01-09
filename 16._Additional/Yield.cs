using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16.Additional
{
    class Yield
    {
        // 꼭 기억해야 함
        // Yield : 일시정지의 의미로 사용

        // <yield>
        // 반복기를 통해 데이터 집합을 하나씩 리턴할 때 사용
        // 1. 반환할 데이터의 양이 커서 한꺼번에 반환하는 것보다 분할해서 반환하는 것이 효율적인 경우
        // 2. 함수가 무제한의 데이터를 리턴할 경우
        // 3. 이전단계까지의 결과에서 다음까지만의 계산이 필요한 경우

        public int Func()
        {
            // 함수의 기본 원칙? return전까지 반드시 모든 수행을 하고 진행됨(멈추지 않음)

            return 0;
        }

        public static IEnumerable<int> GetNumber()
        {
            // 보통의 함수는 return을 만나면 끝나지만
            // yield는 일시정지
            // 이후 값을 반환하고 다시 이용한다면 yield문 아래부터 이어서 시작됨
            // 부분부분 끊어서 사용될 때 사용
            yield return 10;
            yield return 20;
            yield return 30;
            yield return 40;
            yield return 50;

            // 기본적인 return은 종료의 의미이나 yield는 일시정지의 개념이므로
            // 무한히 return도 가능함

            while (true)
            {
                yield return 1;
            }
        }

        static void Main()
        {
            // foreach 반복문은 IEnumerable 인터페이스가 포함된 데이터 집합을 반복하는 방식
            // GetNumber은 

            foreach (int num in GetNumber())
            {
                Console.WriteLine(num);
            }

            IEnumerator<int> iter = GetNumber().GetEnumerator();
            iter.Reset();
        }


        // <yield 형식>
        // yield return : 반복에서 다음을 제공
        IEnumerable<int> Repeater(int count)
        {
            for (int i = 0; i < count; i++)
            {
                yield return i;
            }
        }

        // yield break : 반복에서 끝을 제공
        IEnumerable<int> UntilPlus(IEnumerable<int> numbers)
        {
            foreach (int n in numbers)
            {
                if (n > 0)
                    yield return n;
                else
                    yield break;
            }
        }

        void Main2()
        {
            foreach (int num in Repeater(5))
                Console.WriteLine(num);     // output : 0, 1, 2, 3, 4

            foreach (int num in UntilPlus(new int[5] { 1, 3, 5, -1, 4 }))
                Console.WriteLine(num);     // output : 1, 3, 5
        }

    }
}
