using System;
using System.Collections.Generic;
using Sparta2weekProject.Interfaces;
using Sparta2weekProject.Objects;

namespace Sparta2weekProject.Menu
{
    internal class Quest : MenuHandler
    {
        // 퀘스트 전체 정보
        public List<QuestInfo> QuestInfos = new List<QuestInfo>();
        // 퀘스트들의 정보
        Hunting hunt = new Hunting();
        EquipItem equip = new EquipItem();
        PowerUp power = new PowerUp();

        public Quest()
        {   
            QuestInfos.Add(hunt);
            QuestInfos.Add(equip);
            QuestInfos.Add(power);
        }
        public Quest(List<QuestInfo> quests)
        {
            QuestInfos = quests;
        }

        // 모든 퀘스트 보여주기
        public void ShowQusts(Charactors _charactor, List<Items> _items)
        {
            bool Restart = false;
            QuestInfos = RemoveQuest(QuestInfos);
            int aa = QuestInfos.Count;
            Console.WriteLine("Quest!!\n\n");
            int count = 1; // 개수
            Console.WriteLine("0. 나가기");
            foreach (QuestInfo quest in QuestInfos)
            {
                // 수락 여부
                string accept = quest.access == true ? "O" : "X";
                Console.WriteLine($"{count}. [수락 {accept} ]{quest.questName}");
                count++;
            }
            Console.WriteLine("\n\n");
            choice = base.Choice(aa, true);
            switch (choice)
            {
                case 1:
                    // 퀘스트 클리어 여부 확인
                    QuestInfos[0].QuestClear(_charactor);
                    // 입력한 퀘스트 확인
                    Restart = QuestInfos[0].QuestShow(_charactor, _items, Restart);
                    // 퀘스트를 수락하고 퀘스트를 클리어하지 않았다면
                    if (QuestInfos[0].access && QuestInfos[0].clearCheak == false)
                    {
                        // 해당 퀘스트 추가(수락)
                        AcceptQuest(QuestInfos[0], _charactor);
                    }
                    break;
                case 2:
                    // 퀘스트 클리어 여부 확인
                    QuestInfos[1].QuestClear(_charactor);
                    Restart = QuestInfos[1].QuestShow(_charactor, _items, Restart);
                    if (QuestInfos[1].access && QuestInfos[1].clearCheak == false)
                    {
                        AcceptQuest(QuestInfos[1], _charactor);
                    }   
                    break;
                case 3:
                    // 퀘스트 클리어 여부 확인
                    QuestInfos[2].QuestClear(_charactor);
                    Restart = QuestInfos[2].QuestShow(_charactor, _items, Restart);
                    if (QuestInfos[2].access && QuestInfos[2].clearCheak == false)
                    {
                        AcceptQuest(QuestInfos[2], _charactor);
                    }
                    break;
            }
            // 돌아가기를 눌렀다면 재귀 함수 시작
            if (Restart)
            {
                ShowQusts(_charactor, _items);
            }
        }

        public List<QuestInfo> RemoveQuest(List<QuestInfo> _quests)
        {
            // 순서
            int count = 0;
            List<QuestInfo> newQuest = new List<QuestInfo>();
            foreach(QuestInfo quest in _quests)
            {
                // 보상을 못한 퀘스트만 추가
                if (!quest.rewardCheck)
                {
                    newQuest.Add(quest);
                }
                count++;
            }
            // 보상을 미획득한 퀘스트만 갱신
            return _quests = newQuest;
        }

        // 퀘스트 수락
        public void AcceptQuest(QuestInfo _quest, Charactors _charactor)
        {
            Console.WriteLine($"퀘스트: {_quest.questName}를 수락하셨습니다.\n");
        }
    }
}

