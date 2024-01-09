using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16.Additional
{
    class Indexer
    {
        // <인덱서 정의>
        // this[]를 속성으로 정의하여 클래스의 인스턴스에 인덱스 방식으로 접근 허용

        // 내가 만든 클래스에서 대괄호 가지고 넣은 값 쓰기 

        public class IndexerArray
        {
            private int[] array = new int[10];

            // this뒤에 프로퍼티 구현 
            public int this[int index]
            {
                get
                {
                    if (index < 0 || index >= array.Length)
                        throw new IndexOutOfRangeException();
                    else
                        return array[index];
                }
                set
                {
                    if (index < 0 || index >= array.Length)
                        throw new IndexOutOfRangeException();
                    else
                        array[index] = value;
                }
            }
        }

        void Main()
        {
            // 배열은 기본적으로 인덱스([]) 지원
            int[] array = new int[5];
            array[0] = 2;

            // 클래스의 인덱스??
            IndexerArray array1 = new IndexerArray();
            array1[2] = 1;
            // -> 인덱서 set으로 들어가게 됨? -> 내가 만든 객체에서 대괄호를 정의?
            // this[2] set 접근
            int i = array[2]; // this[2] get 접근
        }


        // <인덱서 자료형>
        // 인덱서는 다른 자료형 사용도 가능
        // 열거형을 통해 인덱서를 사용하는 경우도 빈번

        public enum Parts { Head, Body, Feet, Hand, SIZE }

        public class Equipment
        {
            string[] parts = new string[(int)Parts.SIZE]; // 열거형을 배열 요소 인덱스로 활용

            // 인덱서를 int가 아닌 열거형으로 이용
            public string this[Parts type]
            {
                get
                {
                    return parts[(int)type];
                }
                set
                {
                    parts[(int)type] = value;
                }
            }
        }

        void Main2()
        {
            Equipment equipment = new Equipment();

            equipment[Parts.Head] = "낡은 헬멧";
            equipment[Parts.Hand] = "낡은 장갑";
            equipment[Parts.Feet] = "가죽 장화";

            Console.WriteLine($"착용하고 있는 신발 : {equipment[Parts.Feet]}");

        }
    }
}
