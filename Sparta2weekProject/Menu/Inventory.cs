﻿using Sparta2weekProject.Objects;

namespace Sparta2weekProject.Menu
{
    internal class Inventory : MenuHandler
    {
        Charactors? chad;
        List<Items> inven;

        public Inventory(List<Items> _inven)
        {
            inven = _inven;
            menu = 1;
        }

        // 인벤토리 메인메뉴
        public void InvenMenu(Charactors _chad)
        {
            this.chad = _chad;

            Console.WriteLine("인벤토리");
            Console.WriteLine("보유 중인 아이템을 확인할 수 있습니다.\n");
            Console.WriteLine("[아이템 목록]");
            foreach(Items item in inven)
            {
                string isEquip = item.isEquiped ? "[E] " : "";
                Console.WriteLine("- " + isEquip + item.ItemInfo(item));
            }
            Console.WriteLine("\n1. 장착 관리");
            Console.WriteLine("0. 나가기\n");

            // 선택
            choice = base.Choice(menu, true);
            switch(choice)
            { 
                case 1:
                    EquipMenu();
                    break;

            }
        }

        // 장착 메뉴
        public void EquipMenu()
        {
            while(choice!=0)
            {
                Console.WriteLine("인벤토리 - 장착 관리");
                Console.WriteLine("보유 중인 아이템을 장착할 수 있습니다.\n");
                Console.WriteLine("[아이템 목록]");

                //아이템 목록
                for (int i = 1; i <= inven.Count; i++)
                {
                    Items item = inven[i - 1];
                    string isEquip = item.isEquiped ? "[E]" : "";
                    Console.WriteLine("- " + i + " " + isEquip + item.ItemInfo(item));
                }
                Console.WriteLine("\n0. 나가기\n");

                // 선택에 따른 로직
                choice = base.Choice(inven.Count, true);
                if (choice == 0)
                {
                    InvenMenu(chad);
                    return;
                }

                Items choiceItem = inven[choice - 1];
                choiceItem.isEquiped = !choiceItem.isEquiped;
                switch (choiceItem.type)
                {
                    case ItemType.무기:
                        Items currentWeapon = chad.weapon;
                        if (choiceItem == currentWeapon)
                        {
                            chad.weapon = null;
                            chad.plusAttack = 0;
                        }
                        else
                        {
                            if (currentWeapon != null)
                                currentWeapon.isEquiped = !currentWeapon.isEquiped;
                            chad.plusAttack = choiceItem.itemState;
                            chad.weapon = choiceItem;
                        }
                        break;
                    case ItemType.방어구:
                        Items currentArmor = chad.armor;
                        if (choiceItem == currentArmor)
                        {
                            chad.armor = null;
                            chad.plusDefend = 0;
                        }
                        else
                        {
                            if (currentArmor != null)
                                currentArmor.isEquiped = !currentArmor.isEquiped;
                            chad.plusDefend = choiceItem.itemState;
                            chad.armor = choiceItem;
                        }
                        break;
                }
            }
        }
    }
}
