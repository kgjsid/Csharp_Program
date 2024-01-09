using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14.Delegate
{
    // 델리게이트의 사용 사례2

    // 지정자 (Specifier)

    // 델리게이트를 사용하여 미완성 상태의 함수를 구성
    // 매개변수로 전달한 지정자를 기준으로 함수를 완성하여 동작시킴
    // 기준을 정해주는 것으로 다양한 결과가 나올 수 있는 함수를 구성가능

    // <델리게이트를 지정자로 사용>
    // 매개변수로 함수에 필요한 기준을 전달
    // 전달한 기준을 통해 결과를 도출

    class Specifier
    {
        public class Item
        {
            public string name;
            public int level;
            public float weight;

            public Item(string name, int level, float weight)
            {
                this.name = name;
                this.level = level;
                this.weight = weight;
            }
        }

        void Main6()
        {
            int[] array = { 3, -2, 1, -4, 9, -8, 7, -6, 5 };

            int value = -6;
            int findIndex = -1;
            // int 배열 안에서 원하는 값의 인덱스 찾기
            // 하나하나 비교하며 찾아가는 방법
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == value)
                {
                    findIndex = i;
                    break;
                }
            }

            Item[] inventory = new Item[5];
            inventory[0] = new Item("포션", 3, 3.2f);
            inventory[1] = new Item("갑옷", 2, 1.2f);
            inventory[2] = new Item("무기", 1, 4.5f);
            inventory[3] = new Item("방패", 8, 8.8f);
            inventory[4] = new Item("폭탄", 6, 12.6f);

            findIndex = -1;
            // 원하는 아이템을 찾는 기능?
            // 1. 이름으로 찾기 
            /*
            string findName = "방패";
            for(int i = 0; i < inventory.Length; i++)
            {
                if (inventory[i].name == findName)
                {
                    findIndex = i;
                    break;
                }
            }
            // 2. 레벨로 찾기
            int findLevel = 8;
            for(int i = 0; i < inventory.Length; i++)
            {
                if (inventory[i].level == findLevel)
                {
                    findIndex = i;
                    break;
                }
            }
            // 3. 무게로 찾기
            float findWeight = 12.6f;
            for (int i = 0; i < inventory.Length; i++)
            {
                if (inventory[i].weight == findWeight)
                {
                    findIndex = i;
                    break;
                }
            }
            */
            // -> 찾는다? -> 매우 다양한 상황
            // ex)경매장 : 레벨, 아이템의 종류, 판매금액, ... 심지어 범위까지?(20 ~ 25레벨)
            // 각각 모든 상황을 전부 구현해야 함 -> 어려움
            // 모든 내용의 if 조건문 안에만 변경되면 전부 적용 가능한데?
            // if(찾는 조건) 찾는 조건에 이름, 레벨, 무게... -> 찾는 조건을 델리게이트로 지정만 한다면??

            int index1 = FindIndex(inventory, FindByName);
            // 이름(방패) 가지고 찾기

            int index2 = FindIndex(inventory, FindByWeight6);
            // 무게(6.0) 가지고 찾기

            int index3 = FindIndex(inventory, (item) => { return item.level == 3; });
            // 람다식 활용

            Item[] finded = Array.FindAll(inventory, item => item.name.Contains("포션"));
        }

        public static bool FindByName(Item inventory)
        {
            return inventory.name == "방패";
        }
        public static bool FindByWeight6(Item inventory)
        {
            return inventory.weight == 6.0f;
        }

        public static int FindIndex(Item[] inventory, Predicate<Item> predicate)
        {
            // predicate<Item> predicate? -> 매개변수 하나, 반환은 bool
            // predicate를 사용하지 않으면 deligate로 반환값만 bool로 만들어 주면 됨
            // if에 들어가야 하는 것은 bool타입
            // predicate에서 조건을 줄 예정 / predicate에 함수가 들어가게 되면 완성이 됨
            for (int i = 0; i < inventory.Length; i++)
            {       //predicate를 어떻게 주느냐에 따라 레벨, 무게, 이름... 가능함
                if (predicate(inventory[i])) // if(FindByName(inventory[i])) 와 동일한 문장
                {                            // if(inventory[i].name == "방패") 와도 동일한 문장
                    return i;
                }
            }

            return -1;
        }
    }
}
