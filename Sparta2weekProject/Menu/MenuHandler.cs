using Sparta2weekProject.Interfaces;

namespace Sparta2weekProject.Menu
{
    internal class MenuHandler : IMenu
    {
        #region Field
        // 각 메뉴 기본창에서 메뉴 선택지 개수
        protected int menu;
        private int choiceMinValue;

        // Choice 메소드 실행 시 리턴받는 값. 초기값은 -1로 고정.
        protected int choice = -1;
        #endregion Field

        public int Choice(int _menuCount, bool _isZeroContain)
        {
            bool isNumber = false;

            // 0이 메뉴 상에 포함되나 포함이 안되나 검사.
            // 0은 나가기로 해주세요!!
            choiceMinValue = _isZeroContain ? 0 : 1;

            // 숫자 입력받기
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">>");
            isNumber = int.TryParse(Console.ReadLine(), out choice);

            // 입력받은 값이 숫자가 아니거나, 범위값에 포함이 되지 않으면 반복.
            if (isNumber == false || (choice < choiceMinValue || choice > _menuCount))
            {
                Console.WriteLine("잘못된 입력입니다.\n");
                return Choice(_menuCount, _isZeroContain);
            }

            Console.Clear();
            return choice;

        }
    }
}
