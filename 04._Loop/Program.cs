namespace _04.Loop
{
    class Program
    {
        static void Main(string[] args)
        {
            // 반복문 (Iteration)

            // 블록을 반복적으로 실행하는 문장
            // 여러 내용을 반복해야 할 때 컴퓨터는 오류없이 빠르게 수행함.

            // while 반복문

            // 조건식의 true, false에 따라 블록을 반복하는 반복문

            int money = 1000;

            while (money > 0)
            {
                Console.Write("100원 동전을 꺼냅니다.\t");
                money -= 100;
                Console.WriteLine($"잔액은 {money} 입니다.");
            }

            // do while 반복문

            // 블록을 한번 실행 후 조건식의 true, false에 따라 블록을 반복하는 반복문

            int input;
            do
            {
                Console.WriteLine("1에서 9사이의 수를 입력하세요 : ");
                string text = Console.ReadLine();
                input = int.Parse(text);
            } while (input < 1 || 9 < input);
            //do while 이용 시 while 끝에 ;(세미콜론)꼭 붙여야 함

            // while과 do while?
            // while은 반복 시작 전에 조건식을 체크, do while은 반복 후 조건식을 체크
            // -> do while은 반드시 한 번을 실행하게 되어있음
            // 상황에 따라 알맞은 것을 이용할 수 있도록

            // for 반복문

            // 초기화, 조건식, 증감연산 으로 구성된 반복문
            //   for (초기화; 조건식; 증감연산)
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"{i}번 반복");
            }

            // 위의 for 반복문을 while 반복문으로 변경
            /* 
            int i = 0;
            while(i < 5)
            {
                Console.WriteLine($"{i}번 반복");
                i++;
            }*/

            for (int i = 4; i >= 0; i--)
            {
                Console.WriteLine($"{i}번 반복");
            }

            // 모든 while과 for은 서로 대체가능
            // 상황에 따라 선택이 필요함. -> while 은 조건식(될 때까지), for은 횟수(몇 번)

            // foreach 반복문

            // 반복가능한 데이터집합의 처음부터 끝까지 반복

            int[] intArray = { 1, 3, 5, 7, 9, 8, 6, 4, 2, 0 };
            foreach (int element in intArray)
            {
                Console.WriteLine($"foreach 반복문의 현재 요소 : {element}");
            }

            // 제어문

            // 프로그램의 순차적인 실행 중 다른 문으로 제어를 전송

            // 아이템(1만 종류) 사전
            // 포션(100번째) 찾아야 함
            // 0 ~ 10000 중 포션? -> 0부터 하나씩 찾아보면? -> 100번째에서 찾았지만 10000까지 찾아야 하므로 계속 반복 -> 중간에 중단할 방법은? -> 제어문 

            // break 제어문

            // 가장 가까운 반복문을 종료

            int num = 35;
            for (int i = 2; i < num; i++)
            {
                if (num % i == 0)
                {
                    Console.WriteLine($"{num}을 나눌 수 있는 가장 작은 수는 {i}입니다.");
                    break;
                }
            }

            // Continue 제어문

            // 가장 가까운 반복문의 새 반복을 시작
            // ex) 주위 100마리에게 어떠한 공격을 실행 -> 공격을 받지 않아야 하는 상황은??(무적상태, 사정거리 밖...) -> 반복을 하면 안됨.

            for (int i = 0; i < 10; i++)
            {
                if (i % 2 == 0)
                    continue; // 이 문장을 만나면 밑의 문장을 실행하지 않고 위로 올라간다
                if (i % 3 == 0)
                    continue;

                Console.WriteLine($"{i}은 2의 배수와 3의 배수가 아닙니다.");
            }

        }
    }
}