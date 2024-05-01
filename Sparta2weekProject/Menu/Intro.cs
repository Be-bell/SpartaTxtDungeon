using Sparta2weekProject.Objects.Charactor;
using System.Xml.Linq;
using static Sparta2weekProject.Objects.Charactor.Charactor;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Sparta2weekProject.Menu
{
    internal class Intro : MenuHandler
    {
        //클래스 선언했고
        
        Status status;
        Store store;
        Inventory inventory;
        Dungeon dungeon;
        Spa spa;
        DataManager dataManager;
        Charactor charactor;
        Quest quest;

        bool isGameEnd = true;
        //인트로가 생성되면 생성자가 동작한다
        public Intro()
        {
            dataManager = DataManager.getInstnace();
            menu = 8;
            status = new Status(); //new를 통해서초기화를한다(객체만들기)
            store = new Store();
            dungeon = new Dungeon();
            spa = new Spa();
            quest = new Quest();
            
        }

        // 게임 스타트
        public void GameStart()
        {
            Console.WriteLine("1. 새로시작");
            Console.WriteLine("2. 이어하기");
            choice = base.Choice(3, false);
            switch (choice)
            {
                case 1:
                    // 캐릭터 생성
                    MakeCharactor();
                    // 생성한 캐릭터 정보 저장
                    dataManager.SaveCharactorToJson(charactor);
                    break;

                case 2:
                    // 캐릭터 정보 받아오기
                    charactor = dataManager.LoadCharactorFromJson();
                    // 캐릭터 정보가 없다면
                    if (charactor == null)
                    {
                        Console.WriteLine("\n저장된 정보가 없어 새로 시작합니다.\n");
                        MakeCharactor();
                    }
                    break;
            }
            // 인벤토리 정보 받기
            inventory = new Inventory(charactor.Inven);

               
                // 게임 진행
            while (charactor.HP!=0 && isGameEnd)

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
                            charactor = new Charactor(CharactorClass.전사);
                            isCharactorMade = true;
                        }
                        break;
                    case 2:
                        Console.WriteLine("궁수를 선택하시겠습니까?");
                        Console.WriteLine("1. 예 / 2. 아니오\n");
                        choice2 = base.Choice(2, false);
                        if (choice2 == 1)
                        {
                            charactor = new Charactor(CharactorClass.궁수);
                            isCharactorMade = true;
                        }
                        break;
                }
            }
            charactor.NameCreate();
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
            Console.WriteLine("7. 퀘스트");
            Console.WriteLine("8. 회복아이템");

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
                case 7:
                    quest.ShowQusts(charactor, store.ItemList);
                    break;
                case 8:
                    inventory.ItemPortion(charactor);
                    break;
            }
        }
    }
}
