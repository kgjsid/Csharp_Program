using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static _14.Delegate.Program;

namespace _14.Delegate
{
    // 일반화 델리게이트

    // 개발과정에서 많이 사용되는 델리게이트의 경우 일반화된 델리게이트를 사용

    class Generic
    {
        // <Func 델리게이트>
        int Plus(int left, int right) { return left + right; }
        int Minus(int left, int right) { return left - right; }

        float AAA(int left, double right) { return 0f; }

        // <Func 델리게이트>
        // 반환형과 매개변수를 지정한 델리게이트
        // Func<매개변수1, 매개변수2, ..., 반환형>
        void Main1()
        {
            Func<int, int, int> func; // 첫번째 매개변수, 두번째 매개변수, 반환형 순서
            func = Plus;
            func = Minus;

            Delegate1 delegate1 = new Delegate1(Add);

            float result = delegate1.Invoke(1.2f, 3.2f);

            Func<int, int, int>[] func2 = new Func<int, int, int>[4]; // 배열 선언도 가능
            func2[0] = Plus;

            Func<int, double, float> func1;
            func1 = AAA;
            // 반환형이 void는 Func 델리게이트 불가 -> Action 델리게이트
        }

        // <Action 델리게이트>
        // 반환형이 void이며 매개변수를 지정한 델리게이트
        // Action<매개변수1, 매개변수2, ...>
        void Message(string message) { Console.WriteLine(message); }

        void Main2()
        {
            Action<string> action;
            action = Message;
        }

        // <Predicate 델리게이트>
        // 반환형이 bool, 매개변수가 하나인 델리게이트
        bool IsSentence(string str) { return str.Contains(' '); }

        void Main3()
        {
            Predicate<string> predicate;
            predicate = IsSentence;

            int[] array = new int[5];
            // Array.Find() -> predicate 요구
        }
    }
}
