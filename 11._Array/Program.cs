namespace _11._Array
{
    class Program
    {
        // 배열(Array)

        // 동일한 자료형의 요소들로 구성된 데이터 집합
        // 인덱스를 통하여 배열요소(Element)에 접근할 수 있음
        // 배열의 처음 요소의 인덱스는 0부터 시작함
        static void Main333(string[] args)
        {
            // <배열 기본>
            // 배열을 만들기 위해 자료형과 크기를 정하여 생성
            // 배열의 요소에 접근하기 위해 [인덱스]를 사용
            // 배열의 Length를 통해 크기를 확인
            // 자료형[] 배열이름 = new 자료형[크기];

            // <배열의 구현 원리>
            // C#의 배열은 Array 클래스를 통해 구현됨
            // 따라서 Array 클래스의 모든 특징을 가짐
            // Array 클래스의 정적 함수를 활용하여 다양한 기능 사용 가능

            int[] array = { 1, 3, 5, 4, 2 };

            // array.Length -> 길이 구하기
            // array.Max() -> 배열의 최댓값
            // array.Min() -> 배열의 최솟값.. array.메소드를 통하여 다양한 기능을 사용할 수 있음

            //Array.Sort(array);                      // 배열 정렬
            //Array.Reverse(array);                   // 배열 반전
            //int index = Array.IndexOf(array, 3);    // 배열 탐색

            int[] shallow = array;                  // 배열의 얕은 복사 : 동일한 인스턴스를 참조
            int[] deep = new int[array.Length];     // 배열의 깊은 복사 : 새로운 인스턴스를 생성하고 복사
            //Array.Copy(array, deep, array.Length);

            array[0] = 0;
            Console.WriteLine(array[0]);            // output : 0
            Console.WriteLine(shallow[0]);          // output : 0
            Console.WriteLine(deep[0]);             // output : 5

            // <다차원 배열>
            // 배열의 []괄호 안에 차원수만큼 ','를 추가
            // 배열의 크기가 차원마다 동일함

            int[,] matrix = new int[3, 4];          // 2차원 배열 선언
            matrix[2, 1] = 10;

            int[,,] cube = new int[3, 2, 4];        // 3차원 배열 선언

            // <가변 배열>
            // 배열의 []괄호를 배열 갯수만큼 추가
            // 배열의 크기를 각각 설정 가능

            int[][] jagged = new int[3][];          // int 배열을 3개 들고있다

            jagged[0] = new int[5];
            jagged[1] = new int[2];
            jagged[2] = new int[3];
            // -> 1번째에는 5칸, 2번째에는 2칸, 3번째에는 3칸

            // <배열과 반복>
            // 배열의 인덱스를 반복하여 증가시키며 사용하는 경우 배열의 모든 요소를 반복 수행하는데 용이함
            int[] ints = { 1, 2, 3, 4, 5 };

            for(int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(ints[i]);
            }

            int[,] tile = { { 1, 2, 3 }, { 4, 5, 6 } };
            for(int y = 0; y < tile.GetLength(0); y++) // GetLength(0)? GetLength(1)? => 각각 하나씩 가져옴
            {
                for(int x = 0; x < tile.GetLength(1); x++)
                {
                    Console.Write(tile[y, x]);
                }
                Console.WriteLine();
            }
        }
    }
}
