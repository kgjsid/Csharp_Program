using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace _16.Additional
{
    class Operator_Overloading
    {
        // 연산자 재정의 (Operator Overloading)

        // 사용자정의 자료형이나 클래스의 연산자를 재정의하여 여러 의미로 사용

        // <연산자 재정의>
        // 기본연산자의 연산을 함수로 재정의하여 기능을 구현
        // 기본연산자를 호환하지 않는 사용자정의 자료형에 기본연산자 사용을 구현함
        public struct Vector2
        {
            public int x;
            public int y;

            public Vector2(int x, int y)
            {
                this.x = x;
                this.y = y;
            }

            // 정적함수여야 함.
            // + 연산자를 재정의 할 예정
            // static 리턴값 operator (재정의할 연산자)(매개변수들)
            public static Vector2 operator +(Vector2 a, Vector2 b)
            {
                int x = a.x + b.x;
                int y = a.y + b.y;

                return new Vector2(x, y);
            }

            public static Vector2 operator *(Vector2 vec, int value)
            {
                return new Vector2(vec.x * value, vec.y * value);
            }
        }

        void Main()
        {
            Vector2 aVec = new Vector2(2, 1);
            Vector2 bVec = new Vector2(5, 3);

            // ex) 위로도 힘, 오른쪽으로 힘 -> 힘의 합은? 
            // ex) 벡터의 연산
            // Vector2 resultVec = aVec + bVec; // 컴퓨터가 기본적으로 판단 불가.
            // 만약 사용하고 싶다면 매번 이렇게 사용해야 함
            Vector2 resultVec1 = new Vector2(aVec.x + bVec.x, aVec.y + bVec.y);
            // 연산자 재정의
            Vector2 resultVec2 = aVec + bVec;
        }
    }
}
