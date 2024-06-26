﻿using Sparta2weekProject.Objects;
using Sparta2weekProject.Objects.Charactor;

namespace Sparta2weekProject.Menu
{
    internal class Inventory : MenuHandler
    {
        Charactor? charactor;
        List<Items> inven;

        public Inventory(List<Items> _inven)
        {
            inven = _inven;
            menu = 1;
        }

        // 인벤토리 메인메뉴
        public void InvenMenu(Charactor _charactor)
        {
            this.charactor = _charactor;

            Console.WriteLine("인벤토리");
            Console.WriteLine("보유 중인 아이템을 확인할 수 있습니다.\n");
            Console.WriteLine("[아이템 목록]");
            foreach (Items item in inven)
            {
                string isEquip = item.IsEquiped ? "[E] " : "";
                Console.WriteLine("- " + isEquip + item.ItemInfo(item));
            }
            Console.WriteLine("\n1. 장착 관리");
            Console.WriteLine("0. 나가기\n");

            // 선택
            choice = base.Choice(menu, true);
            switch (choice)
            {
                case 1:
                    EquipMenu();
                    break;

            }
        }
        public void ItemPortion(Charactor charactor)
        {
            Console.WriteLine("HP 포션 개수: " + charactor.PortionHP.Count);
            Console.WriteLine("Atk 포션 개수: " + charactor.PortionAtk.Count);
            Console.WriteLine("Def 포션 개수: " + charactor.PortionDef.Count);

            Console.WriteLine("어떤 포션을 사용하시겠습니까?");
            Console.WriteLine("\n0. 돌아가기");
            Console.WriteLine("1. HP 포션");
            Console.WriteLine("2. Atk 포션");
            Console.WriteLine("3. Def 포션\n");
            choice = Choice(3, true);
            switch (choice)
            {
                case 1:
                    if (charactor.PortionHP.Count > 0) //포션이있을때 
                    {
                        //아이템 설명
                        //리스트 인덱스 사용

                        // 1번째 포션 사용
                        charactor.PortionHP[0].Drink(charactor, 0);
                    }
                    else //포션이없을때
                    {
                        Console.WriteLine("사용할 포션이 없습니다 ");
                        Console.WriteLine("");
                        Thread.Sleep(1000);
                    }
                    break;
                case 2:
                    if (charactor.PortionAtk.Count > 0) //포션이있을때 
                    {
                        //아이템 설명
                        //리스트 인덱스 사용

                        // 1번째 포션 사용
                        charactor.PortionAtk[0].Drink(charactor, 0);
                    }
                    else //포션이없을때
                    {
                        Console.WriteLine("사용할 포션이 없습니다 ");
                        Console.WriteLine("");
                        Thread.Sleep(1000);
                    }
                    break;
                case 3:
                    if (charactor.PortionDef.Count > 0) //포션이있을때 
                    {
                        //아이템 설명
                        //리스트 인덱스 사용

                        // 1번째 포션 사용
                        charactor.PortionDef[0].Drink(charactor, 0);
                    }
                    else //포션이없을때
                    {
                        Console.WriteLine("사용할 포션이 없습니다 ");
                        Console.WriteLine("");
                        Thread.Sleep(1000);
                    }
                    break;
                default:
                    Console.WriteLine("잘못된 입력입니다.");
                    break;
            }

           
        }


        // 장착 메뉴
        public void EquipMenu()
        {
            while (choice != 0)
            {
                Console.WriteLine("인벤토리 - 장착 관리");
                Console.WriteLine("보유 중인 아이템을 장착할 수 있습니다.\n");
                Console.WriteLine("[아이템 목록]");

                //아이템 목록
                for (int i = 1; i <= inven.Count; i++)
                {
                    Items item = inven[i - 1];
                    string isEquip = item.IsEquiped ? "[E]" : "";
                    Console.WriteLine("- " + i + " " + isEquip + item.ItemInfo(item));
                }
                Console.WriteLine("\n0. 나가기\n");

                // 선택에 따른 로직
                choice = base.Choice(inven.Count, true);
                if (choice == 0)
                {
                    InvenMenu(charactor);
                    return;
                }

                Items choiceItem = inven[choice - 1];
                choiceItem.IsEquiped = !choiceItem.IsEquiped;
                switch (choiceItem.Type)
                {
                    case ItemType.Weapon:
                        Items currentWeapon = charactor.Weapon;
                        if (choiceItem == currentWeapon)
                        {
                            charactor.Weapon = null;
                            charactor.PlusAttack = 0;
                        }
                        else
                        {
                            if (currentWeapon != null)
                                currentWeapon.IsEquiped = !currentWeapon.IsEquiped;
                            charactor.PlusAttack = choiceItem.ItemState;
                            charactor.Weapon = choiceItem;
                        }
                        break;
                    case ItemType.Armor:
                        Items currentArmor = charactor.Armor;
                        if (choiceItem == currentArmor)
                        {
                            charactor.Armor = null;
                            charactor.PlusDefend = 0;
                        }
                        else
                        {
                            if (currentArmor != null)
                                currentArmor.IsEquiped = !currentArmor.IsEquiped;
                            charactor.PlusDefend = choiceItem.ItemState;
                            charactor.Armor = choiceItem;
                        }
                        break;



                }
            }
        }

    }
}
