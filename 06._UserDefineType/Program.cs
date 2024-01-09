namespace _06.UserDefineType
{
    class Program
    {
        // 열거형(Enum)

        // 기본 정수 숫자의 형식의 명명된 상수 집합에 의해 정의되는 값 형식
        // 열거형 멤버의 이름으로 관리되어 코드의 가독성적인 측면에 도움이 됨

        // <열거형 기본 사용>

        // enum 열거형이름 { 멤버이름, 멤버이름, ... }
        enum Direction { Up, Down, Left, Right }
        // -> Direction은 int처럼 자료형으로 이용되며 정수에는 정수만 이용할 수 있던 것 처럼
        // -> Direction에는 Up, Down, Left, Right만 넣을 수 있음 -> 잘못 이용하는 경우를 체크해 줌 + 코드의 가독성을 높임
        // 열거형의 경우 앞에서부터 순서대로 0, 1, 2, 3, 4 ... 로 취급 -> 컴퓨터는 Direction.Up을 0으로 판단함
        // 만약 다른 숫자로 변환하고 싶다면?

        enum Season
        {
            Spring,
            Summer,
            Autumn = 20, // 2가 아닌 20으로 대체됨
            Winter
        }

        void Main1()
        {
            // 방향키? -> 어떤 자료형을 이용하지(위, 아래, 오른쪽, 아래)?
            int input = 0; // 0 : 위쪽, 1 : 아래쪽, 2 : 왼쪽, 3 : 오른쪽

            switch (input)
            {
                case 0:
                    Console.WriteLine("위로 이동");
                    break;
                case 1:
                    Console.WriteLine("아래로 이동");
                    break;
                case 2:
                    Console.WriteLine("왼쪽으로 이동");
                    break;
                case 3:
                    Console.WriteLine("오른쪽으로 이동");
                    break;
            }
            // 불가능한 일은 아님. 다만 하나씩 기억하고 있어야 쓸 수 있음
            // 숫자보다 문자로 쓰면 조금 더 편하진 않을까?

            string input1 = "위쪽";
            // 훨씬 더 직관적이지만 마찬가지로 해당 문자열을 정확히 기억해야 함 -> 위? 위쪽? Up? up?...
            // 방향이라는 자료형을 만들 수 없을까? -> 열거형 이용

            Direction input2 = Direction.Up;

            switch (input2)
            {
                case Direction.Up:
                    Console.WriteLine("위로 이동");
                    break;
                case Direction.Down:
                    Console.WriteLine("아래로 이동");
                    break;
                case Direction.Left:
                    Console.WriteLine("왼쪽으로 이동");
                    break;
                case Direction.Right:
                    Console.WriteLine("오른쪽으로 이동");
                    break;
            }
        }

        // 구조체(Struct)

        // 데이터와 관련 기능을 캡슐화할 수 있는 값 형식
        // 데이터를 저장하고 보관하기 위한 단위용도로 사용

        // struct 키워드와 함께 만들어주고 싶은 이름으로 구조체를 만들 수 있음
        struct MonsterStat
        {
            public int hp;
            public int mp;
            public int level;
            public float speed;
            public float range;
        }

        void Main2()
        {
            // 몬스터의 스탯을 만들기 위해 해당 변수를 일일이 만들어줘야 하는 상황
            int monsterHP;
            int monsterMP;
            int monsterLevel;
            float monsterSpeed;
            float monsterRange;

            // stat 구조체를 만듦으로써 위의 5개의 변수 선언을 편하게 처리할 수 있음
            // 구조체의 장점1.
            // 수정과 관리가 편함 -> 만약 추가 변수가 생긴다면? -> 위의 경우 하나씩 전부 수정해야 하지만 구조체는?
            // -> 구조체 하나를 수정함으로써 모든 구조체 변수가 수정됨
            MonsterStat stat;
            stat.hp = 10;
            stat.mp = 5;
            stat.level = 1;
            stat.speed = 1.2f;
            stat.range = 3.5f;
        }

        // 구조체의 장점 2.
        // 만약 어택이라는 기능을 만들고 몬스터의 모든 정보를 받야아 한다면?
        // 구조체 하나로 모든 정보를 넘겨줄 수 있음
        void Attack(MonsterStat stat)
        {
            int damage = 10;
            stat.hp -= damage;
        }

        // <구조체 구성>

        // struct 구조체이름 { 구조체내용 }
        // 구조체 내용으로는 변수와 함수가 포함 가능
        struct StudentInfo
        {
            public string name;
            public int math;
            public int english;
            public int science;


            public float GetAverage()
            {
                return (math + english + science) / 3.0f;
            }
        }

        void Main3()
        {
            StudentInfo A;
            A.name = "Kim";
            A.math = 90;
            A.english = 80;
            A.science = 70;
            Console.WriteLine($"{A.name}의 점수 평균은 {A.GetAverage()} 입니다.");


            StudentInfo B;
            B.name = "Lee";
            B.math = 66;
            B.english = 78;
            B.science = 55;

            //Console.WriteLine($"{A.name}의 점수 총합은 {A.GetSum()} 입니다.");
            //Console.WriteLine($"{B.name}의 점수 총합은 {B.GetSum()} 입니다.");
        }

        // <구조체 초기화>

        // 반환형이 없는 구조체이름의 함수를 초기화라 하며 구조체 변수들의 초기화를 진행하는 역할로 사용
        // 구조체의 변수가 굉장히 많은 경우 큰 도움이 되며 오류 상황을 방지할 수 있음
        // 구조체의 초기화는 new 키워드를 통해서 사용
        struct Point
        {
            public int x;
            public int y;

            public Point(int x, int y)
            {
                // x = x? -> 매개변수인지 구조체 안의 변수인지 헷갈림
                this.x = x; // this : 자기 자신을 가리킴
                this.y = y;
            }
            // 매개변수(입력)가 없는 기본 초기화 함수 -> 기본초기화 -> 자동으로 생성되며 생략 가능
            public Point()
            {
                this.x = 0;
                this.y = 0;
            }
        }

        void Main4()
        {
            Point point2 = new Point(2, 3); // 초기화
            Console.WriteLine($"{point2.x}, {point2.y}");

            Point point3 = new Point();     // x, y둘다 0으로 초기화
            Console.WriteLine($"{point3.x}, {point3.y}");

            Point point1;
            point1.x = 1;
            Console.WriteLine($"{point1.x}");
            // Console.WriteLine($"{point1.y}"); 오류 -> y값은 지정되어 있지 않음

        }

        struct PlayerStat
        {
            public int hp;
            public int mp;
            public float speed;
            public float range;

            // 구조체 초기화에서 관리해주면 매번 생성시마다 오류가 있는 경우를 방지해주며
            // 메인 코드가 길어지고, 복잡해지는 것을 방지함
            public PlayerStat(Job job)
            {
                if (job == Job.Archor)
                {
                    hp = 50;
                    mp = 30;
                    speed = 100;
                    range = 200;
                }
                else if (job == Job.Mage)
                {
                    hp = 30;
                    mp = 200;
                    speed = 50;
                    range = 150;
                }
                else if (job == Job.Knight)
                {
                    hp = 200;
                    mp = 0;
                    speed = 10;
                    range = 50;
                }
            }
        }

        enum Job { Archor, Mage, Knight }

        void Main5()
        {
            Console.WriteLine("직업을 선택하세요 : ");
            Job job = Job.Archor;

            PlayerStat playerStat = new PlayerStat(job);
        }

        struct Vector3
        {
            public float x;
            public float y;
            public float z;

            public Vector3(float x, float y, float z)
            {
                this.x = x;
                this.y = y;
                this.z = z;
            }

            public string ToString()
            {
                return $"({x}, {y}, {z})";
            }
        }

        // <구조체 복사>
        // 깊은복사 : 구조체에 대입연산자(=)를 통해 구조체 내 모든 변수들의 값이 복사됨(<-> 얕은 복사)
        static void Main(string[] args)
        {
            Vector3 source = new Vector3(1f, 2f, 3f);

            Vector3 dest = source; // 구조체는 대입되는 상황에서는 안의 내용물을 전부 복사하는 방식

            Console.WriteLine(source.ToString());
            Console.WriteLine(dest.ToString());

            source.y = 10;

            Console.WriteLine(source.ToString()); // source는 변경
            Console.WriteLine(dest.ToString());   // dest는 변경되지 않음
        }

        // <튜플> : 쓰지마
        // 쉽지만 관리가 어렵기 때문 -> 구조체 사용을 권장
        void Main7()
        {
            (int min, int max) value;
            value.min = -10;
            value.max = -10;

            (int x, int y) position;
            position = value; // 가능함. 다만 좋은 상황이 아님
        }

        static void Main8(string[] args)
        {
            Console.WriteLine("Hello, World!");

            // 열거형은 int로 형변환 가능 -> 컴퓨터에서 숫자로써 관리되고 있으니 충분히 가능함
            int value1 = 1 + (int)Direction.Up;
            Direction value2 = (Direction)2;

            Console.WriteLine(value1);
            Console.WriteLine(value2);

        }
    }
}
