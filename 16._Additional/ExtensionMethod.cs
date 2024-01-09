using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16.Additional
{
    static class ExtensionMethod
    {
        // 아쉬운거??
        // ex)string에 다른 기능이 있으면 좋겠는데...

        // <확장메서드>
        // 클래스의 원래 형식을 수정하지 않고도 기존 형식에 함수를 추가할 수 있음
        // 상속을 통하여 만들지 않고도 추가적인 함수를 구현 가능
        // 정적함수에 첫번째 매개변수를 this 키워드 후 확장하고자 하는 자료형을 작성

        public static int WordCount(this string str)
        {
            return str.Split(' ').Length;
        }

        public static void Main1(string[] args)
        {
            string str = "abc def lf";
            // 단어 수 측정?
            int count1 = WordCount(str);    // 정적함수 사용
            int count2 = str.WordCount();   // 확장메서드 표현


            int[] array = new int[] { };

            array = new int[5];

        }
    }
}
