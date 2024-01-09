namespace _03.Conditional
{
    // 제어문
    class Program
    {
        static void Main(string[] args)
        {
            // 조건문(Conditional)

            // 조건에 따라 실행이 달라지게 할 때 사용하는 문장
            // 문법은 쉬우나 활용이 어려움 -> 연습이 반드시 필요!!!

            // if 조건문

            // 조건식의 true, false에 따라 실행할 블록을 결정하는 조건문

            // <if 조건문 기본>

            // if 키워드로 시작하여 if(조건식){}의 형식으로 사용
            if (true) // 조건이 true인 경우 바로 아래의 블록이 실행됨
            {
                Console.WriteLine("True");
            }
            else     // 조건이 false인 경우 바로 아래의 블록이 실행됨
            {
                Console.WriteLine("False");
            }

            int playerHP = 10;
            int monstarAtk = 20;

            if (playerHP > monstarAtk)
            {
                // 조건식의 결과가 true 라면 실행됨
                Console.WriteLine("플레이어가 데미지를 받습니다.");
                playerHP -= monstarAtk;
            }
            else
            {
                // 조건식의 결과가 false 라면 실행됨
                Console.WriteLine("플레이어가 쓰러집니다.");
                playerHP = 0;
            }

            bool isJumpPressed = true;
            bool isGround = true;
            if (isGround && isJumpPressed)
            {
                Console.WriteLine("점프한다.");
            }
            /* else -> 필요 없는 경우에는 생략이 가능함 
            {
                Console.WriteLine("아무것도 안한다.");
            }*/

            // 가위바위보?
            // 승리 / 패배 + 무승부
            string input = "가위";
            if (input == "가위")
            {
                Console.WriteLine("입력한 값이 가위일때 처리");
            }
            else if (input == "바위")
            {
                Console.WriteLine("입력한 값이 바위일때 처리");
            }
            else if (input == "보")
            {
                Console.WriteLine("입력한 값이 보일때 처리");
            }
            else
            {
                Console.WriteLine("입력한 값이 셋다 아닐때 처리");
            }

            int score = 87; // 60이하 아이언, 61~70 브론즈, 71~80 실버, 81~90 골드, 91~100 플레

            if (score <= 60)
            {
                Console.WriteLine("아이언");
            }
            else if (score <= 70)    // 만약 else if가 아니라면?? -> if(61 <= score && score <= 70)으로 작성하여야 함
            {
                Console.WriteLine("브론즈");
            }
            else if (score <= 80)
            {
                Console.WriteLine("실버");
            }
            else if (score <= 90)
            {
                Console.WriteLine("골드");
            }
            else
            {
                Console.WriteLine("플레");
            }

            // if - else if - else의 주의점?
            // 위의 코드의 순서가 바뀌면 생각한 결과가 나오지 않을 수도 있음 -> 꼭 범위 생각해서 사용하기!!

            // switch 조건문

            // 조건'값'에 따라 실행할 시작지점을 결정하는 조건문

            //<switch 조건문 기본>
            char c = 'B';

            switch (c)   // 조건값 지정
            {
                case 'A':
                    Console.WriteLine("조건값이 A인 경우 실행");
                    break;
                case 'B':
                    Console.WriteLine("조건값이 B인 경우 실행");
                    break;
                case 'C':
                    Console.WriteLine("조건값이 C인 경우 실행");
                    break;
                default: // switch에서의 else
                    Console.WriteLine("값은 그 외");
                    break;
            }
            // 모든 switch를 if로 변환 가능, if는 switch로 변환 불가능(범위)
            // 왜 switch를 쓰는지??? -> 조건'값'
            // 값만 따지고 볼 때 switch, 식이 필요한 경우에는 if -> 상황에 따라 선택해서 사용해야 함

            // 조건값에 따라 동일한 실행이 필요한 경우 묶어서 사용 가능 -> if로 가능하되 귀찮아짐
            char key = 'W';
            switch (key)
            {
                case 'w':
                case 'W':
                case 'ㅈ':
                    Console.WriteLine("위쪽으로 이동");
                    break;
                case 's':
                case 'S':
                case 'ㄴ':
                    Console.WriteLine("아래쪽으로 이동");
                    break;
            }

            // 삼항 연산자

            // 간단한 조건문을 빠르게 작성

            int left = 11;
            int right = 22;

            int bigger;

            if (left > right)
            {
                bigger = left;
            }
            else
            {
                bigger = right;
            }

            // 조건 ? true일때 : false일때
            bigger = left > right ? left : right; // 위의 if문을 한 줄로 대체가능

        }
    }
}
