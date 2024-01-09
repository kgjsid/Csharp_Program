/*
 프로그래밍의 기본. 문법? 규칙?
 
* 주석(Comment)
* 
* 소스 코드에 영향을 주지 않는 텍스트.
* 프로그래밍에 기본적으로 쓰여있는 텍스트는 의미가 있는 코드.
* 주석이 달려있는 텍스트는 의미(영향) 없으며 설명하기 위한 용도로 사용됨.
*/

// 주석 종류

// 1.  // -> 한줄 주석 : // 이후 텍스트를 주석으로 취급
// 2. /**/-> 범위 주석 : 시작(/*)에서 끝(*/)까지 모든 텍스트를 주석으로 취급
// 3. /// -> 문서 주석 : 함수 또는 클래스 앞에서 /// 입력으로 자동완성 및 Visual Studio에서 정보표시기능

/*
 * 네임 스페이스 (namespace)
 * C#은 많은 인원이 개발하는 경우가 있으며 개발 시 이름이 겹치는 경우가 존재할 수 있음
 ex) A개발자가 Player를, B개발자가 동일하게 Player라는 이름으로 사용할 수 있음
 * 실제로 이름이 겹치는 경우 컴퓨터가 구분할 수 없어 오류가 발생
 * namespace는 큰 분류를 만들어 준다고 생각.
 
 * 기능이나 구분이 비슷한 기능을 하나의 이름 아래 묶는 기능
 * 수많은 클래스 사용에 혼란이 적도록 용도/분야 별로 정리
 
 * namespace를 통해 해당 namespace.클래스명 으로 사용 가능 -> 해당 namespace를 많이 사용해야 한다면? -> 불편함?
 => using 사용
 */

using NetWork;
/* using? -> 네임스페이스 안의 기능을 아래 내용부턴 기본적으로 포함
 * NetWork안의 기능을 쓸 거다.
 * 편하긴 하되 문제점이 발생할 수 있음.
 * ex) A namespace에 Console, B namespace에 Console이 있는데 둘 다 using을 사용하면??
 * A에 있는 Console인지, B에 있는 Console인지 구분 불가능 하므로 직접적으로 구분해 줄 수 있도록 만들기
 * System, System.IO 등 기본적으로 사용하는 네임스페이스는 자동으로 사용되어 있음. 
 */

namespace _00.Programming
{
    /*
     * 클래스 (Class)
     * 
     * C# 프로그램을 구성하는 기본 단위
     * 데이터와 기능으로 구성
     */

    class Program
    {
        /*
         * Main 함수
         * 
         * 프로그램의 처음 시작지점이 되는 함수
         * C# 프로그램은 반드시 하나의 Main 함수를 포함해야 함.
         */
        static void Main(string[] args)
        {
            // 표준 입출력
            // 콘솔 : 컴퓨터와 사용자가 텍스트 형태로 소통하기 위한 수단
            // Console.WriteLine    : 콘솔에 출력하고 줄 바꿈
            // Console.Write        : 콘솔에 출력하고 줄 바꾸지 않음
            // Console.ReadLine     : 콘솔을 통해 한줄 입력받음
            // Console.ReadKey      : 콘솔을 통해 키 입력받음

            abc.Program p;
            Hong.Program h;
            Delay d; // using 문장으로 인해 Network.을 사용하지 않아도 됨.

            Console.WriteLine("Hello, World!"); // 콘솔에 한줄 내용을 출력한다

            Console.WriteLine("로그인\n\n"); // \n 출력해야 할 문장에 Enter입력
            Console.WriteLine("캐릭터 선택");
            Console.WriteLine("마을 진입");
            Console.WriteLine("아이템 사기");
            Console.WriteLine("던전 진입");
            Console.WriteLine("슬라임 사냥");
            Console.WriteLine("접속종료\n");

            Console.Write("캐릭터의 이름을 입력하세요 : ");
            Console.ReadLine(); // 콘솔을 통해 한줄 입력받기(Enter키 기준)
            Console.ReadKey();  // 콘솔을 통해 한키 입력받기
        }
    }
}

namespace abc
{
    internal class Program
    {

    }
}

namespace Hong
{
    internal class Program
    {

    }
}

namespace NetWork
{
    internal class Delay
    {

    }
    internal class IOCP
    {

    }
}