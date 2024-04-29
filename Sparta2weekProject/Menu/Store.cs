using Sparta2weekProject.Objects;

namespace Sparta2weekProject.Menu
{
    internal class Store : MenuHandler
    {
        Charactors? chad;

        public List<Items> ItemList;
        Items sword1;
        Items sword2;
        Items sword3;
        Items armor1;
        Items armor2;

        // 생성자 선언 시 상점에 물건 입고.
        public Store()
        {
            menu = 2;
            sword1 = new Sword();
            sword2 = new SuperSword();
            sword3 = new UltraSword();
            armor1 = new Armor();
            armor2 = new PlateArmor();
            ItemList = new List<Items>();

            ItemList.Add(sword1);
            ItemList.Add(sword2);
            ItemList.Add(sword3);
            ItemList.Add(armor1);
            ItemList.Add(armor2);
        }

        // 상점 기본메뉴
        public void StoreMenu(Charactors _chad)
        {
            chad = _chad;
            Console.WriteLine("상점");
            Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.\n");
            Console.WriteLine("[보유 골드]");
            Console.WriteLine($"{chad.gold} G\n");
            Console.WriteLine("[아이템 목록]");

            // Item리스트 띄우기.
            foreach(Items item in ItemList)
            {
                string purchase = item.isPurchase ? "구매완료" : item.price.ToString() + " G";
                Console.WriteLine("- " + item.ItemInfo(item) + " | " + purchase);
            }

            Console.WriteLine("\n1. 아이템 구매");
            Console.WriteLine("2. 아이템 판매");
            Console.WriteLine("0. 나가기\n");

            // 선택에 따른 로직
            choice = base.Choice(menu, true);
            switch(choice)
            {
                case 1:
                    BuyMenu();
                    break;
                case 2:
                    SellMenu();
                    break;
            }
        }

        // 상점에서 구매 구현
        void BuyMenu()
        {
            while(choice!=0)
            {
                Console.WriteLine("상점 - 아이템 구매");
                Console.WriteLine("아이템을 구매할 수 있습니다. 아이템 구매 시 인벤토리로 즉시 지급됩니다.\n");
                Console.WriteLine("[보유 골드]");
                Console.WriteLine($"{chad.gold} G\n");
                Console.WriteLine("[아이템 목록]");

                // 아이템 리스트
                for (int i = 1; i <= ItemList.Count; i++)
                {
                    Items item = ItemList[i - 1];
                    string purchase = item.isPurchase ? "구매완료" : item.price.ToString() + " G";
                    Console.WriteLine("- " + i + " " + item.ItemInfo(item) + " | " + purchase);
                }

                Console.WriteLine("\n0. 나가기\n");

                // 선택에 따른 로직
                choice = base.Choice(ItemList.Count, true);
                if (choice == 0)
                {
                    StoreMenu(chad);
                    return;
                }

                Items buyItem = ItemList[choice - 1];
                if (!buyItem.isPurchase && chad.gold > buyItem.price)
                {
                    chad.gold -= buyItem.price;
                    buyItem.isPurchase = true;
                    chad.inven.Add(buyItem);
                    Console.WriteLine("\n구매를 완료하였습니다.\n");
                }
                else if (buyItem.isPurchase)
                {
                    Console.WriteLine("\n이미 구매한 상품입니다.\n");
                }
                else if (chad.gold < buyItem.price)
                {
                    Console.WriteLine("\nGold 가 부족합니다.\n");
                }
            }
            
        }

        // 상점 판매 구현
        void SellMenu()
        {
            while(choice!=0)
            {
                List<Items> inven = chad.inven;
                Console.WriteLine("상점 - 아이템 판매");
                Console.WriteLine("아이템을 판매할 수 있습니다. 아이템 판매 가격은 원가의 85%입니다.\n");
                Console.WriteLine("[보유 골드]");
                Console.WriteLine($"{chad.gold} G\n");
                Console.WriteLine("[아이템 목록]");

                // 보유 아이템 리스트 띄우기
                for (int j = 1; j <= inven.Count; j++)
                {
                    Items item = inven[j - 1];
                    string equip = item.isEquiped ? " [E] " : "";
                    Console.WriteLine("- " + j + equip + item.ItemInfo(item) + " | " + "판매 가격 : " + (int)item.price * 0.85f);
                }

                Console.WriteLine("\n0. 나가기\n");

                // 선택에 따른 로직 구현
                choice = base.Choice(inven.Count, true);
                if (choice == 0)
                {
                    StoreMenu(chad);
                    return;
                }
                    

                Items sellItem = chad.inven[choice - 1];
                if (sellItem.isEquiped)
                {
                    switch (sellItem.type)
                    {
                        case ItemType.무기:
                            chad.plusAttack -= sellItem.itemState;
                            break;
                        case ItemType.방어구:
                            chad.plusDefend -= sellItem.itemState;
                            break;
                    }
                }
                chad.gold += (int)(sellItem.price * 0.85f);
                chad.inven.Remove(sellItem);
                Console.WriteLine("\n판매가 완료되었습니다.\n");
            }
        }
    }
}
