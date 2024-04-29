using Sparta2weekProject.Interfaces;

namespace Sparta2weekProject.Menu
{
    internal class MenuHandler : IMenu
    {
        protected int menu { get; set; } // 각 메뉴 기본창에서 메뉴 선택지 개수
        protected int choice = -1;  // Choice 메소드 실행 시 리턴받는 값. 초기값은 -1로 고정.

        public int Choice(int menuCount, bool isZeroContain)
        {
            bool res = false;
            // 0이 메뉴 상에 포함되나 포함이 안되나 검사.
            int choiceMinValue = isZeroContain ? 0 : 1;

            // 입력받은 값이 숫자가 아니거나, 범위값에 포함이 되지 않으면 반복.
            while(!res || (choice < choiceMinValue || choice > menuCount))
            {
                Console.WriteLine("원하시는 행동을 입력해주세요.");
                Console.Write(">>");
                res = int.TryParse(Console.ReadLine(), out choice);
                if(!res || (choice < choiceMinValue || choice > menuCount))
                {
                    Console.WriteLine("잘못된 입력입니다.\n");
                }
            }

            Console.Clear();
            return choice;

        }
    }
}
