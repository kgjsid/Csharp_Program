using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static _09.OOP.Inheritance;

namespace _09.OOP
{
    public class Inheritance
    {
        // 상속 (Inheritance)

        // 부모클래스의 모든 기능을 가지는 자식클래스를 설계하는 방법
        // is-a 관계 : 부모클래스가 자식클래스를 포함하는 상위개념일 경우 상속관계가 적합함

        // <상속>
        // 부모클래스를 상속하는 자식클래스에게 부모클래스의 모든 기능을 부여
        // class 자식클래스이름 : 부모클래스이름
        public class Monster
        {
            public string name;
            public int hp;

            public void TakeHit(int damage)
            {
                hp -= damage;
                Console.WriteLine($"{name} 이/가 데미지를 받아 체력이 {hp}가 되었습니다.");
            }
        }

        public class Dragon : Monster
        {
            public Dragon()
            {
                name = "드래곤";
                hp = 100;
            }

            public void Breath()
            {
                Console.WriteLine($"{name} 이/가 화염을 뿜습니다.");
            }
        }

        public class Slime : Monster
        {
            public Slime()
            {
                name = "슬라임";
                hp = 25;
            }

            public void Split()
            {
                Console.WriteLine($"{name} 이/가 분열합니다.");
            }
        }

        public class Orc : Monster
        {
            public Orc()
            {
                name = "오크";
                hp = 50;
            }
            public void Rage()
            {
                Console.WriteLine($"{name} 이/가 분노합니다.");
            }
        }

        public class OrcChief : Orc
        {
            public OrcChief()
            {
                name = "오크족장";
                hp = 100;
            }
        }

        public class Hero
        {
            int damage = 3;

            public void Attack(Monster monster) // 상속과 업캐스팅으로 인하여 가능한 구문
            {
                monster.TakeHit(damage);

                if (monster is Dragon)
                {
                    Dragon dragon = (Dragon)monster;
                }
            }
            // 만약 상속이 없다면..?
            // Attack을 몬스터 종류마다 만들어 주어야 함.(Dragon dragon, Slime slime...)
        }

        static void Main3()
        {
            Dragon dragon = new Dragon();
            dragon.TakeHit(10);
            dragon.Breath();

            Slime slime = new Slime();
            slime.TakeHit(10);
            slime.Split();

            OrcChief chief = new OrcChief();
            chief.TakeHit(10);
            chief.Rage();

            Hero hero = new Hero();
            hero.Attack(dragon); // 원래는 Monster 클래스가 들어가야 하나 Momster 클래스를 상속받은
            hero.Attack(slime);  // Dragon, Slime, ... 들은 해당 내용에 들어갈 수 있음 -> 업캐스팅
            hero.Attack(chief);
            // 상위 클래스와 상호작용 하고자 한다면 자식 클래스들은 전부 상위 클래스의 내용이 있으므로
            // 같은 상호작용이 가능함.

            // 업캐스팅 : 자식클래스를 부모위치에 보관 (묵시적 / 자동으로)
            Monster monster1 = new Dragon();
            Monster monster2 = new Slime();

            monster1.TakeHit(20);
            //monster1.Breath(); -> 불가 / 자식만의 기능은 사용할 수 없음
            // 부모가 가리키는 인스턴스는 자식만의 기능을 수행할 수 없음
            // -> 해당 자리에 어떠한 자식이 들어올 지 모르며 오류가 발생할 수 있기 때문에

            // => 다운캐스팅(수동)을 통해 특정 자식으로 변경해야 해당 기능을 사용
            Dragon dra = (Dragon)monster1;

            // 위험부담이 있는 다운캐스팅
            // Slime sli = (Slime)monster1; 드래곤이 있는 인스턴스에 슬라임으로 형변환 : error!!

            // 다운캐스팅은 100% 확신이 있을 때 명시적으로 다운캐스팅 가능
            // 확신이 없다면? -> is 키워드로 안전하게 실시
            if (monster1 is Dragon)
            {
                Dragon d = (Dragon)monster1;
                Console.WriteLine("monster1은 드래곤입니다.");
            }
            else
            {
                Console.WriteLine("monster1은 드래곤이 아닙니다.");
            }
            if (monster2 is Dragon)
            {

                Dragon d2 = (Dragon)monster2;
                Console.WriteLine("monster2은 드래곤입니다.");
            }
            else
            {
                Console.WriteLine("monster2은 드래곤이 아닙니다.");
            }

            // as키워드로 쉽게 확인도 가능 -> 가능하면 해주고 아니라면 null값 리턴
            Dragon asDragon = monster1 as Dragon;
            Slime asSlime = monster1 as Slime;

        }
        // <상속 사용의미 1>
        // 상속을 진행하는 경우 부모클래스의 소스가 자식클래스에서 모두 적용됨
        // 부모클래스와 자식클래스의 상속관계가 적합한 경우 부모클래스에서의 기능 구현이 자식클래스에서도

        class Fruit
        {
            // 부모클래스에서 기능을 구현할 경우 모든 부모를 상속하는 자식클래스에 기능을 구현하는 효과
        }

        class Apple : Fruit
        {
            // 자식클래스에서 자식클래스만의 기능을 구현 
        }

        // <상속 사용의미 2>
        // 업캐스팅을 통해 자식클래스는 부모클래스로 형변환이 가능함
        // 자식클래스는 부모클래스의 요구하는 곳에서 동일한 기능을 수행할 수 있음



        // <상속의 구현 원리>
        // 자식 클래스는 메모리에 할당 될 때, 부모클래스를 생성 후 이어 자식만의 추가 기능을 붙여서 할당됨.
        // 그래서 부모 클래스 변수가 자식 인스턴스를 가리킬 수 있으며 다만 이 때 자식의 추가 기능만큼은 사용하지 못함
    }
}
