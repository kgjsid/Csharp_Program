namespace _14.Delegate
{
    class Program
    {
        // 대리자(Delegate)

        // 특정 매개 변수 목록 및 반환 형식이 있는 함수에 대한 참조
        // 대리자 인스턴스를 통해 함수를 호출 할 수 있음
        // 쉽게 함수 보관하는 변수라고 생각

        // <델리게이트 정의>
        // delegate 반환형 델리게이트이름(매개변수들);
        public delegate float Delegate1(float left, float right);
        public delegate void Delegate2(string str);

        public static float Add(float left, float right) { return left + right; }
        public static float Minus(float left, float right) { return left - right; }
        public static void Message(string message) { Console.WriteLine(message); }

        static void Main(string[] args)
        {
            // 변수는 값 저장 가능. 함수는? 호출하는 개념
            int value = 2;

            // 다만 함수도 저장하고 싶은 경우가 있음(ex 턴제 전투 게임 / 포켓몬스터)

            // 골랐던 함수가 어떤 함수인지 잠깐 보관할 필요가 있음
            // 함수 고른액션 = 공격함수;
            // 이렇게 함수를 자료형으로 저장하고 싶을 때 사용 -> 델리게이트(대리자)
            // 함수를 대신 호출하는 기능을 수행 -> 델리게이트는 객체

            // Delegate1 타입으로 변수 만들고 함수 집어넣기
            Delegate1 delegate1 = new Delegate1(Add);
            float result = delegate1(1.2f, 3.4f); // Add(1.2f, 3.4f)와 동일한 효과

            // float result = delegate1.invoke(1.2f, 3.4f) -> 원래는 객체이므로 이렇게 사용해야하나 변수처럼 사용 가능

            delegate1 = Minus;
            result = delegate1(3.4f, 1.2f);       // Minus(3.4f, 1.2f)와 동일한 효과

            // delegate1 = Message; -> 불가능 => 델리게이트는 반환형과 매개변수들이 일치하는 함수만 참조가능
            // 왜? -> delegate는 포함할 수 있는 함수가 정해져 있음.
            // 담을 수 있는 함수는 매개변수와 반환형이 기준이며 델리게이트와 동일해야 함.
            // 즉 delegate1은 반환형이 float, 매개변수로 2개의 float가 필요로 하는 함수만 담을 수 있음

            Delegate2 delegate2 = Message;
            delegate2("Hello");                   // Message("Hello")와 동일한 효과
        }

    }
}
