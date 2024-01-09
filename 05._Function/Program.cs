namespace _05.Function
{
    class Program
    {
        // 함수(function)

        // 미리 정해진 동작을 수행하는 코드 묶음
        // 어떤 처리를 미리 함수로 만들어 두면 다시 반복적으로 사용 가능

        // 점프구현?
        // 1. 위쪽 방향을 가리키게 한뒤
        // 2. 가리킨 방향으로 힘을가한다
        // 3. 가해진 힘이 중력보다 크면
        // 4. 그만큼 속도를 갖는다
        // 점프를 100번하면 100번의 코드...?? => 미리 함수로 묶어서 사용하자!

        // <함수 구성>

        // 일련의 코드를 하나의 이름 아래에 묶음
        // 반환형(->출력) 함수이름(매개변수들(->입력들)) { 함수내용 }
        // => 출력 이름(입력들) { 동작 }

        static int Plus(int left, int right)
        {
            Console.WriteLine($"Input : {left}, {right}");
            int result = left + right;
            Console.WriteLine($"Out : {result}");
            // return? 함수가 끝난 시점에 결과를 들고 다시 원래 위치(호출된 위치)로 돌아간다
            return result;

            //위의 return을 만나면 그 즉시 함수가 종료되어서 아래 문장은 실행되지 않음
            Console.WriteLine("Hi~");
        }

        // <함수 사용>

        // 함수로 구성해둔 코드를 이름으로 불러 사용함

        static void Main(string[] args)
        {
            // 만약에 함수가 없다면..?
            /*
            Console.WriteLine($"Input : {1}, {3}");
            int result1 = 1 + 2;
            Console.WriteLine($"Output : {1 + 3}");
            int value1 = result1;

            Console.WriteLine($"Input : {2}, {4}");
            int result2 = 2 + 4;
            Console.WriteLine($"Output : {2 + 4}");
            int value2 = result2;

            Console.WriteLine($"Input : {6}, {83}");
            int result3 = 6 + 83;
            Console.WriteLine($"Output : {6 + 83}");
            int value3 = result3
            */
            // 매 번 해당 과정을 만들어야 함 -> 너무 귀찮음 => 함수로 해결
            // 미리 필요한 기능을 만들어두고 필요할 때 마다 함수를 불러줌(함수 이름)으로 쉽게 만든 기능을 이용할 수 있음
            // 함수를 사용함으로써 위의 코드와 동일한 결과를 매우 간편하게 만들 수 있음
            int value1 = Plus(1, 3);
            int value2 = Plus(2, 4);
            int value3 = Plus(6, 83);

            PrintProfile("홍길동", "010-1234-5678");

            int value4 = Minus(20, 10);
            int value5 = Minus(30, 10);

            int totalDamage = TripleShot();

        }

        // <반환형 (Return Type)>

        // 함수의 결과(출력) 데이터의 자료형
        // 함수가 끝나기 전까지 반드시 return으로 반환형(자료형)에 맞는 데이터를 출력해야함
        // 함수 진행 중 return을 만나는 경우 그 즉시 결과 데이터를 반환하고 함수가 종료됨
        // 함수의 결과(출력)이 없는 경우 반환형은 void이며 return을 생략 가능

        // => 함수의 일련의 과정 끝에 어떻게 출력이 되는지 결정해주는 역할
        // => 반환형이 존재하는데 return이 없거나 올바르지 않은 데이터면 오류!! 

        static void PrintProfile(string name, string phone)
        {
            Console.WriteLine($"이름 : {name}");
            Console.WriteLine($"번호 : {phone}");

            // 반환형이 void이니 return은 생략가능
            // 의도에 따라 return을 사용하는 경우도 있음
        }

        // <매개변수 (Parameter)>

        // 함수에 추가(입력)할 데이터의 자료형과 변수명
        // 같은 함수에서도 매개변수 입력이 다름에 따라 다른 처리가 가능

        static int Minus(int left, int right)
        {
            // 함수의 입력으로 넣어준 매개변수 left, right에 따라 함수가 동작
            return left - right;
        }

        // <함수 호출 순서>

        // 함수는 호출되었을 때 해당 함수블록으로 제어가 전송되며 완료되었을 때 원위치로 제어가 전송됨

        // 내부의 프로시저를 보면
        // -> TripleShot 호출 -> TripleShot() 함수 위치로 이동 -> TripleShot에서 Attack()함수 호출 -> Attack()함수 위치로 이동
        // -> Attack()이 끝나면(return) -> TripleShot()으로 이동 -> TripleShot()이 끝나면 -> 호출한 위치로 이동
        static int TripleShot()
        {
            int damage = 0;
            for (int i = 0; i < 3; i++)
            {
                damage += Attack();
            }

            return damage;
        }

        static int Attack()
        {
            Console.WriteLine("공격!");

            return 10;
        }

        // <함수 오버로딩>

        // 같은 이름의 함수를 매개변수를 달리하여 다른 함수로 재정의하는 기술
        // 같은 이름의 함수를 호출하여도 매개변수의 자료형에 따라 함수를 달리 호출할 수 있음
        // 이름은 동일하더라도 매개변수는 반드시 달라야 함 / 반환값은 상관없음

        // ex) Console.WriteLine() / ()안에 1, 1.1, "ab" ... 다양한 형태로 이용됨
        // 왜? -> 만약에 곱하기 함수를 각 자료형마다 만든다면??
        int Multi(int left, int right) { return left * right; }
        float Multi(float left, float right) { return left * right; }
        double Multi(double left, double right) { return left * right; }


        static void Func2()
        {                   // 1
                            // 2
        }                   // 3

        static void Func1()
        {                   // 4
            Func2();        // 5
        }                   // 6

        static void Main()
        {                   // 7
            Func1();        // 8
        }                   // 9

        // 함수 호출 순서 : 7 -> 8 -> 4 -> 5 -> 1 -> 2 -> 3 -> 6 -> 9
    }
}
