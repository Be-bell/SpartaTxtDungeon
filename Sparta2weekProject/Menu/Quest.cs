using System;
using Sparta2weekProject.Interfaces;
using Sparta2weekProject.Objects;

namespace Sparta2weekProject.Menu
{
    internal class Quest : MenuHandler
    {
        // 퀘스트 전체 정보
        public List<QuestInfo> questInfos = new List<QuestInfo>();
        // 상점 아이템 정보들
        public List<Items> shopItems;
        // 퀘스트들의 정보
        Hunting hunt = new Hunting();
        EquipItem equip = new EquipItem();
        PowerUp power = new PowerUp();

        public Quest()
        {   
            questInfos.Add(hunt);
            questInfos.Add(equip);
            questInfos.Add(power);
        }

        // 모든 퀘스트 보여주기
        public void ShowQusts(Charactors chad, List<Items> items)
        {
            questInfos = RemoveQuest(questInfos);
            shopItems = items;
            Console.WriteLine("Quest!!\n\n");
            int count = 1; // 개수
            Console.WriteLine("0. 나가기");
            foreach (QuestInfo quest in questInfos)
            {
                // 수락 여부
                string accept = quest.access == true ? "O" : "X";
                Console.WriteLine($"{count}. [수락 {accept} ]{quest.questName}");
                count++;
            }
            Console.WriteLine("\n\n");
            choice = base.Choice(3, true);
            switch (choice)
            {
                case 1:
                    // 퀘스트 클리어 여부 확인
                    questInfos[0].QuestClear(chad);
                    // 입력한 퀘스트 확인
                    questInfos[0].QuestShow(chad, items);
                    // 퀘스트를 수락하고 퀘스트를 클리어하지 않았다면
                    if (questInfos[0].access && questInfos[0].clearCheak == false)
                    {
                        // 해당 퀘스트 추가(수락)
                        AcceptQuest(questInfos[0], chad);
                    }
                    break;
                case 2:
                    // 퀘스트 클리어 여부 확인
                    questInfos[1].QuestClear(chad);
                    questInfos[1].QuestShow(chad, items);
                    if (questInfos[1].access && questInfos[1].clearCheak == false)
                    {
                        AcceptQuest(questInfos[1], chad);
                    }
                    break;
                case 3:
                    // 퀘스트 클리어 여부 확인
                    questInfos[2].QuestClear(chad);
                    questInfos[2].QuestShow(chad, items);
                    if (questInfos[2].access && questInfos[2].clearCheak == false)
                    {
                        AcceptQuest(questInfos[2], chad);
                    }
                    break;
            }
        }

        // 퀘스트 갱신
        public List<QuestInfo> RemoveQuest(List<QuestInfo> quests)
        {
            // 순서
            int count = 0;
            List<QuestInfo> newQuest = new List<QuestInfo>();
            foreach(QuestInfo quest in quests)
            {
                // 보상을 못한 퀘스트만 추가
                if (!quest.rewardCheck)
                {
                    newQuest.Add(quest);
                }
                count++;
            }
            // 보상을 미획득한 퀘스트만 갱신
            return quests = newQuest;
        }

        // 퀘스트 수락
        public void AcceptQuest(QuestInfo quest, Charactors chad)
        {
            Console.WriteLine($"퀘스트: {quest.questName}를 수락하셨습니다.\n");
        }
    }
}

