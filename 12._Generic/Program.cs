namespace _12.Generic
{
    class Program
    {
        // 일반화(Generic)

        // 클래스 또는 함수가 코드에 의해 선언되고 인스턴스화될 때까지 형식의 사양을 연기하는 디자인
        // 기능을 구현한 뒤 자료형을 사용 당시에 지정해서 사용

        // <일반화 함수>
        // 일반화를 이용하면 다른 자료형의 함수 또한 호환하도록 구현할 수 있음
        // <> 기호를 활용하여 자료형을 작성하는 방식으로 내용을 구현함(일반적으로 T)
        public static void ArrayCopy<T>(T[] source, T[] output)
        {
            for (int i = 0; i < source.Length; i++)
            {
                output[i] = source[i];
            }
        }

        void Main1()
        {
            int[] iSrc = { 1, 2, 3, 4, 5 };
            int[] iOut = new int[5];

            ArrayCopy<int>(iSrc, iOut);

            float[] fSrc = { 1.0f, 2.0f, 3.0f, 4.5f, 5.1f };
            float[] fOut = new float[5];

            ArrayCopy<float>(fSrc, fOut);
            // 에러 -> ArrayCopy는 int형을 매개변수로 받음 
            // 동일한 내용에 모든 자료형에 대하여 오버로딩이 필요한 상황 => 일반화로 해결
            // <T> -> T가 float로 변환하여 함수가 동작함

            char[] cSrc = { 'a', 'b', 'c' };
            char[] cOut = new char[3];

            ArrayCopy<char>(cSrc, cOut);

            // 일반화 자료형이 매개변수로 추측이 가능한 경우 생략도 가능함
            // ArrayCopy(iSrc, iOut); -> 매개변수가 int이므로 일반화 자료형(<T>)이 int로 추측이 가능하므로 생략가능
        }

        // <일반화 클래스>
        // 클래스에 필요한 자료형을 일반화하여 구현
        // 이후 클래스 인스턴스를 생성할 때 자료형을 지정하여 사용

        public class SafeArray<Type>
        {
            Type[] array;

            public SafeArray(int size)
            {
                array = new Type[size];
            }
            public void Set(int index, Type value)
            {
                if (index < 0 || index >= array.Length)
                    return;
                array[index] = value;
            }

            public Type Get(int index)
            {
                if (index < 0 || index >= array.Length)
                    return default(Type); // default : Type 자료형의 기본값
                                          // int : 0, float : 0.0f 처럼 노말한? 기본값이라고 생각
                return array[index];
            }
        }

        void Main2()
        {
            SafeArray<int> intArray = new SafeArray<int>(5); ;
            SafeArray<float> floatArray;
        }

        // 일반화를 사용하지 못하는 경우

        /*
        public static Type Bigger<Type>(Type left, Type right)
        {
            // 비교 불가능(bool, class...)
            // 자료형 자체를 연기해서 디자인하는 방식이므로 type에는 어떤 것이든 가능
            // 특정 자료형이 불가능한 연산이 있을 때 일반화 불가능 -> 모든 자료형이 가능해야 함
            // >, <, +, .... -> 그렇다면 대입만 가능한가? => 자료형 제약이 가능
            if(left > right)
            {
                return left;
            }
            else
            {
                return right;
            }
        }
        void Main3()
        {
            int intBigger = Bigger<int>(3, 5);
            bool boolBigger = Bigger<bool>(true, true);
            // true와 true -> 비교 불가능
        }
        */

        // <일반화 자료형 제약>
        // 일반화 자료형을 선언할 때 제약조건을 선언하여, 사용 당시 쓸 수 있는 자료형을 제한
        // where Type : 제약 조건 으로 작성하며 제약 조건으로 class, IComparable등 다양하게 사용할 수 있음
        // ex) where Type : class -> 클래스만 들어올 수 있다
        // ex) where Type : IComparable -> IComparable 인터페이스를 포함하는 자료형만 들어올 수 있다
        // ex) where Type : struct -> 구조체만 들어올 수 있다
        // ex) where Type : Player -> Player 클래스 혹은 Player를 상속하는 클래스만 들어올 수 있다...
        public static Type Bigger<Type>(Type left, Type right) where Type : IComparable
        {
            // 비교 가능한 자료형만 받으면 해당 코드가 가능해짐 -> 자료형을 제한
            // where Type : IComparable -> Type이 IComparable 인터페이스를 포함해야 함
            // IComparable 인터페이스? : 비교 가능한 자료형은 해당 인터페이스를 포함하고 있음
            // 해당 인터페이스는 CompareTo 메소드 구현을 강제하고 있고 사용법은 num1.CompareTo(num2)
            // => num1이 num2보다 크다면 0보다 큰 수, 작다면 0보다 작은 수, 같다면 0을 리턴
            if (left.CompareTo(right) < 0)
            {
                return right;
            }
            else
            {
                return left;
            }
        }

        class Player { }

        void Main3()
        {
            int intBigger = Bigger<int>(5, 3);
            float floatBigger = Bigger<float>(5.0f, 3.0f);

            // Player player = Bigger<Player>(new Player(), new Player());
            // player 클래스는 IComparable 포함하고 있지 않아 불가능

        }

        static void Main(string[] args)
        {

        }
    }
}
