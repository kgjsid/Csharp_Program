using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16.Additional
{
    class Nullable
    {
        // null? -> 참조 형식에서 사용가능
        // 가지고 있는 것이 없다

        public class Item
        {
            public string name;
            public void Use() { }
        }

        void Main()
        {
            // <Nullable 타입>
            // 값형식의 자료형들은 null을 가질 수 없음
            // 값형식에도 null을 할당할 수 있는 Nullable 타입을 지원
            Item item1 = new Item();
            Item nullItem = null; // 인스턴스를 가리키고 있지 않다 -> 아무것도 없다

            // int value = null; -> 값 형식은 불가능
            int? value = null;  // 자료형 뒤에 (?)를 붙여줌으로 Nullable 타입으로 변경
            if (value.HasValue) { } // HasValue? 값을 가지고 있다면 true, 아니면 false

            // <Null 조건연산자>
            // ? 앞의 객체가 null 인 경우 null 반환
            // ? 앞의 객체가 null 이 아닌경우 접근
            Item item = new Item() { name = "포션" };

            if (item != null)
            {   // 사용에는 문제는 없으나 아이템 객체가 없다면? -> 오류 발생 -> 예외처리 필요
                // 매번 기능이 사용될 때 마다 예외처리를?? -> 귀찮으니 다른 방법으로 해결
                string name = item.name;
                item.Use();
            }

            // 다음과 같이 (?.)를 활용하여 null이 아닌 경우에만 접근
            string name1 = item?.name;
            item?.Use();


            // <Null 병합연산자>
            // ?? 앞의 객체가 null 인 경우 ?? 뒤의 객체 반환
            // ?? 앞의 객체가 null 이 아닌경우 앞의 객체 반환
            int[] array = null;

            int length = array?.Length ?? 0; // 배열이 null인 경우 0 반환, 아닌경우 배열의 크기 반환

            // <Null 병합할당연산자>
            // ??= 앞의 객체가 null 인 경우 ??= 뒤의 객체를 할당
            // ??= 앞의 객체가 null 이 아닌경우 ??= 뒤의 객체를 할당하지 않음
            Item nullClass = null;
            nullClass ??= new Item();       // nullClass가 null이므로 새로운 인스턴스 할당
            nullClass ??= new Item();       // nullClass가 null이 아니므로 새로운 인스턴스 할당이 되지 않음

        }
    }
}
