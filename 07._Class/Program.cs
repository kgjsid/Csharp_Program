namespace _07.Class
{
    // 클래스(class)

    // 데이터와 관련 기능을 캡슐화할 수 있는 참조 형식
    // 객체지향 프로그래밍에 객체를 만들기 위한 설계도
    // 클래스는 객체를 만들기 위한 설계도이며, 만들어진 객체는 인스턴스라 함
    // 참조 : 원본을 가리키고 있음 == 원본의 주소를 가지고 있음
    // C# 프로그램을 구성하는 기본 단위


    class Program
    {
        // <클래스 구성>

        // class 클래스이름 { 클래스내용 }
        // 클래스 내용으로는 변수와 함수가 포함 가능 -> 구조체와 무슨 차이가??
        // 가장 큰 차이점? -> 구조체와 클래스는 '값' 형식과 '참조' 형식의 차이
        class Student
        {
            public string name;
            public int math;
            public int english;
            public int science;

            public float GetAverage()
            {
                return (math / english / science) / 3.0f;
            }
        }

        void Main1()
        {
            Student kim = new Student();
            kim.name = "감자";
            kim.math = 10;
            kim.english = 10;
            kim.science = 100;

            float average = kim.GetAverage();
        }

        // <클래스 생성자>

        // 반환형이 없는 클래스이름의 함수를 생성자라 하며 클래스의 인스턴스를 만들 때 호출되는 역할로 사용
        // 인스턴스의 생성자는 new 키워드를 통해서 사용
        class Car
        {
            public string name;
            public string color;
            public int year;

            public Car(string name, string color)
            {
                this.name = name;
                this.color = color;
            }

            public Car() { }
            // 원하는 변수만 만드는 작업도 가능함
            // Car aCar = new Car() { name = "aCar", color = "blue" };
            // Car aCar = new Car() { color = "blue" }

            public Car(string name, string color, int year) : this(name, color) // 위의 생성자 이용
            {
                // 생성자 위임
                this.year = year;
            }
        }

        void Main2()
        {
            Car car; // 객체를 가리키고 있지 않음. 

            // car.name = "차"; 오류 -> 구조체는 가능했는데?
            // 구조체는 데이터 집합을 만드는 것. 실제로 값을 들고 있는 녀석이므로 접근이 가능함(값)
            // 클래스는 상황이 다름. 클래스는 객체를 만들기 위한 방식 -> 클래스는 객체를 만들어서 그 객체를 가리키는 방식(참조 / 주소지)
            // 실제로 car 인스턴스는 name과 color를 가지고 있는 것이 아닌 주소지를 가지고 있음 
            // 원본은 따로 있으며 클래스 변수로 접근하는 것은 주소지를 따라가서 위치를 따라가서 거기에 있는 변수에 접근

            // 정리

            // 구조체는 정말 그 변수를 가지고 있는 경우
            // 클래스는 정말 그 변수를 가지고 있는 것이 아닌 그 객체의 주소지를 가지고 있는 것.
            // 값은 실제로 들고 있다 / 참조는 객체는 따로 있으며 그 것을 가리키고 있는 경우
            // Car car은 객체를 가리킬 수 있는 주소지를 담을 수 있는 변수를 만드는 것. new Car은 실제 객체를 생성하는 것

            car = new Car("차", "파"); // 생성자를 통하여 객체를 만들고 그 객체의 주소를 가리킬 수 있도록 해줘야 함

            Car truck = new Car("트럭", "파란색"); // 클래스는 생성한다고 표현 -> 새로 만들어서 어디있는지 가리키게 해주는 경우

            Console.WriteLine($"{truck.name}, {truck.color}"); // 트럭, 파란색 -> 트럭이 가리키고 있는 곳의 색상과 이름을 가져옴

            // 코드 이해

            // Car truck;에서 truck은 만들어진 인스턴스를 가리키기 위한 클래스 변수
            // new Car();을 통해서 만들어 진 것 : 객체(인스턴스)
            // Car truck = new Car("트럭", "파란색"); 은 인스턴스를 하나 만들꺼고, car은 해당 인스턴스의 주소를 가지고(가리키고) 있다

            // Car car;
            // car.name = "차"; -> 오류인 이유 : car이 가리키는 객체가 없음. 생성자를 이용하지 않아서 실제 만들어진 인스턴스가 없음.

            Car aCar = new Car() { name = "aCar", color = "blue" };

        }

        // <클래스 얕은복사>

        // 클래스에 대입연산자(=)를 통해 같은 인스턴스를 참조함
        // 데이터의 안 속까지 들어가지 않고 주소지만 복사한다(얕은 복사)
        // 왜 이렇게까지 해야할까? -> 원본을 만들어두고 다같이 사용하는 경우가 좋은 경우가 많음.
        class MyClass
        {
            public int value1;
            public int value2;
        }

        static void Main4(string[] args)
        {
            MyClass s = new MyClass();
            s.value1 = 1;
            s.value2 = 2;

            MyClass t = s;              // t가 s가 가리키는 인스턴스를 가리킴 -> t와 s는 같은 인스턴스를 가리키는 변수
            t.value1 = 3;

            Console.WriteLine(s.value1);
            Console.WriteLine(s.value2);

            Console.WriteLine(t.value1);
            Console.WriteLine(t.value2);
        }
        // 값형식, 참조형식

        // 값형식(Value type) : 복사할 때 실제값이 복사됨(깊은 복사)
        // 구조체는 값형식, boxing

        // 참조형식(Reference type) : 복사할 때 객체주소가 복사됨(얕은 복사)
        // 클래스는 참조형식, unboxing

        struct ValueType
        {
            public int value;

            void swap(ValueType left, ValueType right)
            {
                int temp;

                temp = left.value;
                left.value = right.value;
                right.value = temp;
            }
        }

        class RefType
        {
            public int value;

            void swap(RefType left, RefType right)
            {
                int temp;

                temp = left.value;
                left.value = right.value;
                right.value = temp;
            }
        }

        // <값형식과 참조형식의 차이>

        // 값형식 : 데이터가 중요한 경우 사용, 값이 복사됨
        // 참조형식 : 객체가 중요한 경우 사용, 객체주소가 복사됨

        // <값에 의한 호출, 참조에 의한 호출>

        // 값에 의한 호출 (Call by value) : 값형식의 데이터가 전달되며 데이터가 복사되어 전달됨
        // 함수의 매개변수로 전달하는 경우 복사한 값이 전달되며 원본은 유지됨

        // 참조에 의한 호출 (Call by reference) : 참조형식의 데이터가 전달되며 주소가 복사되어 전달됨
        // 함수의 매개변수로 전달하는 경우 주소가 전달되며 주소를 통해 접근하기 때문에 원본을 전달하는 효과 

        static void Main(string[] args)
        {
            ValueType valueType1 = new ValueType() { value = 10 };
            ValueType valueType2 = valueType1;      // 값이 복사
            valueType2.value = 20;                  // 값을 대입해도 원본에는 영향 없음
            Console.WriteLine(valueType1.value);    // output : 10

            RefType refType1 = new RefType() { value = 10 };
            RefType refType2 = refType1;            // 메모리 주소가 복사 
            refType2.value = 20;                    // 해당 메모리 주소안의 value값 변경
            Console.WriteLine(refType1.value);      // output : 20
        }

        // <얕은복사, 깊은복사>

        // 얕은복사 (Shallow copy) : 객체를 복사할 때 주소값만을 복사하여 같은 원본을 가리키게 함
        // 깊은복사 (Deep copy)    : 객체를 복사할 때 주소값 안의 원본을 복사하여 다른 객체를 가지고 가리키게 함


    }
}
