using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14.Delegate
{
    class Chain
    {
        // 델리게이트 체인

        // 델리게이트 변수에 여러개의 함수를 참조하는 방법

        // 델리게이트의 목적 : 함수를 가지고, 델리게이트를 실행하면 해당 함수가 호출되는 형식

        // <델리게이트 체인>
        // 하나의 델리게이트 변수에 여러 개의 함수를 할당하는 것이 가능
        // +=, -= 연산자를 통해 할당을 추가하고 제거할 수 있음
        // = 연산자를 통해 할당할 경우 이전의 다른 함수들을 할당한 상황이 사라짐

        void Main()
        {
            int value = 2;
            value += 3;

            Action action;
            action = Func2;     // 델리게이트 인스턴스를 Func2로 초기화
            action += Func1;    // 델리게이트 인스턴스에 Func1 추가 참조
            action += Func3;    // 델리게이트 인스턴스에 Func3 추가 참조
            action();           // Func2, Func1, Func3 이 호출됨

            action -= Func1;    // 델리게이트 인스턴스에 Func1 참조 제거
            if (action != null) // 델리게이트 인스턴스에서 참조를 제거할 경우 참조하고 있던 Func1만 제거
                action();       // Func2, Func3 이 호출됨

            action += Func2;    // 같은 함수를 여러번 참조한 경우 여러번 호출됨
            action += Func2;
            action();           // Func2 3회, Func3 1회 호출됨

            action -= Func1;    // 델리게이트 인스턴스에 참조되지 않은 함수를 제거? -> 무시됨

            action = Func1;     // 델리게이트 인스턴스에 = 을 통해 할당할 경우 이전의 참조된 상황이 사라짐
            action();           // Func1만 1회 호출됨

        }
        void Func1() { }
        void Func2() { }
        void Func3() { }
    }
}
