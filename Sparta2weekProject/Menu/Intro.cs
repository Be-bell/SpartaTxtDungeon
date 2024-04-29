using Sparta2weekProject.Objects;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Sparta2weekProject.Menu
{
    internal class Intro : MenuHandler
    {

        Status status;
        Store store;
        Inventory inventory;
        Dungeon dungeon;
        Spa spa;
        DataManager dataManager;
        Charactors charactor;

        bool isGameEnd = true;

        public Intro()
        {
            dataManager = DataManager.getInstnace();
            menu = 6;
            status = new Status();
            store = new Store();
            dungeon = new Dungeon();
            spa = new Spa();
        }

        // 게임 스타트
        public void GameStart()
        {
            charactor = dataManager.LoadCharactorFromJson();
            if(charactor == null )
            {
                MakeCharactor();
            }
            inventory = new Inventory(charactor.inven);
            while (charactor.health!=0 && isGameEnd)
            {
                IntroMenu();
            }
        }

        // 캐릭터 제작창
        void MakeCharactor()
        {
            bool isCharactorMade = false;
            while(!isCharactorMade)
            {
                Console.WriteLine("게임에 오신 것을 환영합니다!");
                Console.WriteLine("캐릭터를 선택하세요.");
                Console.WriteLine("1. 전사");
                Console.WriteLine("2. 궁수\n");

                // 선택
                choice = base.Choice(2, false);
                int choice2;
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("전사를 선택하시겠습니까?");
                        Console.WriteLine("1. 예 / 2. 아니오\n");
                        choice2 = base.Choice(2, false);
                        if (choice2 == 1)
                        {
                            charactor = new Charactors(Chad.전사);
                            isCharactorMade = true;
                        }
                        break;
                    case 2:
                        Console.WriteLine("궁수를 선택하시겠습니까?");
                        Console.WriteLine("1. 예 / 2. 아니오\n");
                        choice2 = base.Choice(2, false);
                        if (choice2 == 1)
                        {
                            charactor = new Charactors(Chad.궁수);
                            isCharactorMade = true;
                        }
                        break;
                }
                
            }
        }

        // 인트로(마을)
        public void IntroMenu()
        {
            Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
            Console.WriteLine("이곳에서 던전으로 들어가기 전 활동을 할 수 있습니다.\n");
            Console.WriteLine("1. 상태 보기");
            Console.WriteLine("2. 인벤토리");
            Console.WriteLine("3. 상점");
            Console.WriteLine("4. 던전입장");
            Console.WriteLine("5. 온천 : 휴식하기");
            Console.WriteLine("6. 저장하기");
            Console.WriteLine("");
            Console.WriteLine("0. 게임종료");
            Console.WriteLine("");

            //선택
            choice = base.Choice(menu, true);
            switch(choice)
            {
                case 0:
                    Console.WriteLine("게임이 종료되었습니다.");
                    isGameEnd = false;
                    return;
                case 1:
                    status.StatusMenu(charactor);
                    break;
                case 2:
                    inventory.InvenMenu(charactor);
                    break;
                case 3:
                    store.StoreMenu(charactor);
                    break;
                case 4:
                    dungeon.DungeonMenu(charactor);
                    break;
                case 5:
                    spa.SpaMenu(charactor);
                    break;
                case 6:
                    dataManager.SaveCharactorToJson(charactor);
                    break;
            }
        }
    }
}
