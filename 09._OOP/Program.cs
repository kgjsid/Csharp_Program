namespace _09.OOP
{

    class Program
    {
        // 객체지향 프로그래밍(Object Oriented Programming)

        // 프로그램 설계방법론이자 개념의 일종
        // 프로그램을 서로 상호작용하는 객체를 기본 단위로 구성하는 방식

        // <절차지향과 객체지향>
        // 절차지향 : 프로그램의 순차적인 처리를 위주로 설계하는 방법론
        // 객체지향 : 서로 상호작용하는 객체를 기본 단위로 구성하는 방법론

        // <객체지향의 등장배경>
        // 물리적인 하드웨어의 발전이 빠르게 진행되었으며, 소프트웨어의 중요성이 빠르게 올라감
        // 기존 절차지향의 방식으로는 복잡한 구조에 대한 설계가 힘들어졌으며 객체지향의 방식이 대안이 됨

        // <객체지향의 장단점>
        // 장점 1. 객체단위로 관리하기 때문에 디버깅이 유리함
        // 장점 2. 클래스 단위로 모듈화 시켜 관리하므로 대규모 프로젝트에 적합
        // 장점 3. 코드의 재사용성이 좋음
        // 단점 1. 설계에 시간이 많이 소비되며 신중해야함

        // <객체지향 4특징>
        // 캡슐화 : 객체의 상태와 기능으로 묶는 것을 의미하며, 객체의 내부 상태와 기능을 숨기고, 허용한 기능만의 엑세스 허용
        // 다형성 : 부모클래스의 함수를 자식클래스에서 재정의하여 자식클래스의 다른 반응을 구현
        // 추상화 : 관련 특성 및 엔터티의 상호 작용을 클래스로 모델링하여 시스템의 추상적 표현을 정의
        // 상속   : 부모클래스의 모든 기능을 가지는 자식클래스를 설계하는 방법

        // <객체설계 5원칙>
        // (S)단일 책임 원칙        : 객체는 오직 하나의 책임을 가져야 함
        // (O)개방 폐쇄 원칙        : 객체는 확장에 대해서는 개방적이고 수정에 대해서는 폐쇄적이어야 함
        // (L)리스코프 치환 원칙    : 자식클래스는 언제나 자신의 부모클래스를 대체할 수 있어야 함
        // (I)인터페이스 분리 원칙  : 인터페이스는 작은 단위들로 분리시켜 구성하며, 사용하지 않는 함수는 포함하지 않아야 함
        // (D)의존성 역전 원칙      : 객체는 하위클래스(상위클래스를 구현한 객체)보다 상위클래스(추상성이 높은 상위 개념)에 의존해야함

        class Player
        {
            // 1. 객체가 가지고 있는 데이터(=> 변수)
            // 2. 객체가 할 수 있는 행동(=> 함수)
            public int hp = 100;
            public int damage = 20;

            public void Attack(Monster monster)
            {
                monster.TakeHit(damage);
            }

            public void Use(Potion potion)
            {
                potion.Use(this);
            }
        }

        class Monster
        {
            public int hp = 50;

            public void TakeHit(int damage)
            {
                hp -= damage;
            }
        }

        class Potion
        {
            public int regen = 10;

            public void Use(Player user)
            {
                user.hp += regen;
            }
        }

        static void Main1(string[] args)
        {
            Player player = new Player();
            Monster monster = new Monster();
            player.Attack(monster); // player attack monster
                                    // 주어.동사(목적어) -> 플레이어가 몬스터와 상호작용하는 코드
                                    // 즉 절차가 아닌 객체를 이용하여 서로 상호작용하며 프로그래밍 하는 방식
                                    // 플레이어와 몬스터. 
                                    //player.Use(potion);     // player use potion

        }
    }
}
