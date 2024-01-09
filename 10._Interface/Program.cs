namespace _10.Interface
{
    class Program
    {
        // 어떻게 상호작용할지 정의해 놓는 것
        // UI? user interface -> 게임과 유저가 상호작용 할 수 있도록 도와주는 것
        // interface? -> 무언가 상호작용 하기 위한 수단

        // 인터페이스 (Interface)

        // 인터페이스는 멤버를 가질 수 있지만 직접 구현하지 않음 단지 정의만을 가짐
        // 인터페이스를 가지는 클래스에서 반드시 인터페이스의 정의를 구현해야 함
        // 이를 반대로 표현하자면 인터페이스를 포함하는 클래스는
        // 반드시 인터페이스의 구성 요소들을 구현했다는 것을 보장함
        // Can-a 관계 : 클래스가 해당 행동을 할 수 있는 경우 적합함

        // <인터페이스 정의>
        // 일반적으로 인터페이스의 이름은 I로 시작함
        // 인터페이스의 함수는 직접 구현하지 않고 정의만 진행
        // 추상(abstract) 클래스와 유사
        public interface IEnterable
        {
            public void Enter();
        }

        // <인터페이스 포함>
        // 상속처럼 정의한 인터페이스를 클래스 : 붙여서 사용
        // 인터페이스는 여러개 포함 가능
        // 인터페이스를 포함하는 경우 반드시 인터페이스에서 정의한 함수를 구현해야만 함
        public interface IOpenable
        {
            public void Open(); // 인터페이스를 포함한 클래스는 반드시 해당 함수가 존재
        }
        public class Box : IOpenable
        {
            public void Open()
            {
                Console.WriteLine("박스를 엽니다.");
            }
        }
        public class Town : IEnterable
        {
            public void Enter()
            {
                Console.WriteLine("마을에 진입합니다.");
            }
        }

        // 문은 열수도 있고 들어갈 수도 있으니 EnterObject도 상속 받아야 함.
        // 하지만 상속은 하나만 가능
        // public class Door : OpenObject, EnterObject -> 오류
        // -> 이 때 인터페이스를 활용함.
        public class Door : IOpenable, IEnterable // 인터페이스는 여러 내용을 사용할 수 있음
        {
            public void Open()
            {
                Console.WriteLine("문을 엽니다.");
            }

            public void Enter()
            {
                Console.WriteLine("문에 들어갑니다.");
            }
        }
        public interface IDamagable
        {
            public void TakeHit(int damage);
        }
        // <인터페이스 사용>
        // 인터페이스를 이용하여 기능을 구현할 경우
        // 클래스의 상속관계와 무관하게 행동의 가능여부로 상호작용 가능
        public class Player
        {
            public void Open(IOpenable openable)
            {
                Console.WriteLine("플레이어가 대상을 열기 시도합니다.");
                openable.Open();
            }

            public void Enter(IEnterable enterable)
            {
                Console.WriteLine("플레이어가 대상에 들어가기 시도합니다.");
                enterable.Enter();
            }
            public void Attack(IDamagable damagable)
            {
                Console.WriteLine("플레이어가 대상을 공격하기 시도합니다.");
                damagable.TakeHit(10);
            }
        }

        public class Monster : IDamagable
        {
            public int hp;

            public void TakeHit(int damage)
            {
                hp -= damage;
            }
        }

        // public class Orc : Monster, IEnterable 가능

        static void Main(string[] args)
        {
            Player player = new Player();
            Box box = new Box();
            Town town = new Town();

            player.Open(box);
            player.Enter(town);

            Door door = new Door();

            player.Open(door);
            player.Enter(door);
        }

        // 왜? 인터페이스를 사용하는지? -> 두번 이상의 상속으로 해결하면 될텐데? -> 죽음의 다이아몬드
        // ex) 생명체 클래스, 육지 생명체 클래스, 해양 생명체 클래스, 개구리 클래스

        // 생명체 : 혈액량
        // 육지 생명체 : 숨쉬기() -> 허파, 혈액량
        // 해양 생명체 : 숨쉬기() -> 아가미, 혈액량
        // 개구리 클래스가 두개의 클래스를 상속받으면?
        // -> 숨쉬기 기능을 어떻게 이용하는지?? -> 심지어 혈액량이 육지, 해양 각각 따로 있음

        // 해당 클래스들의 상속 관계로 문제점 발생 -> 대신 인터페이스를 제공

        // 그렇다면 상속을 전부 인터페이스로 대체하면?

        // 추상 클래스와 인터페이스

    }
}
