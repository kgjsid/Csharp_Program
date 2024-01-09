namespace _16.Additional
{
    class Program
    {
        // C#에는 많은 기능이 있으며 있는 기능을 사용해 주는 것이 베스트
        // C#에서 제공되는 기능들은 훨씬 최적화가 잘 되어 있는 경우가 많음

        void Main1()
        {
            // 기본자료형의 함수
            // 기본자료형은 구조체 또는 클래스로 구성됨
            // 이 구조체와 클래스 안에 유용한 기능이 구현되어 있음

            // <string>
            string str = "abc def";
            str.ToLower();              // 소문자 변환
            str.ToUpper();              // 대문자 변환
            str.Split(' ');             // ' '기준으로 문자열 분리(배열)
            str.Split(' ', ',');        // 여러 기준도 가능
            str.Replace('a', 'z');      // 문자 교체(a를 z로)
            str.Replace("ID", "ABC");   // 문자열 교체(ID를 ABC로)
            // string.Join, string.IndexOf, ...

            // <array>
            int[] array = new int[5];
            int length = array.Length;  // 배열의 길이
            array.Max();                // 최대값
            array.Min();                // 최소값
            array.Average();            // 평균값


            // <기본 자료형의 static 함수>
            int volume = int.Clamp(110, 0, 100);       // 범위 지정(입력값, 최소값, 최대값)
            // int.Abs -> 절대값, int.Parse -> 변환, IsPow2 -> 2의 제곱체계인가?
            // int.Max, int.Min...

            string.Compare("abc", "cde");              // 사전 순 비교하기

            int[] values = { 5, 2, 1, 4, 3 };
            Array.Sort(values);                        // 배열 정렬
            Array.Reverse(values);                     // 배열 반전

        }



        static void Main2(string[] args)
        {

        }
    }
}
