﻿using System;
using System.Collections.Generic;
using Sparta2weekProject.Interfaces;
using Sparta2weekProject.Objects;
using Sparta2weekProject.Objects.Charactor;

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

        // 새로시작 시 퀘스트 생성
        public Quest(bool check)
        {   
            QuestInfos.Add(hunt);
            QuestInfos.Add(equip);
            QuestInfos.Add(power);
        }
        // 이어하기 시 퀘스트 로드
        public Quest()
        {
            // 저장된 퀘스트의 오버로딩
        }
        // ShowQuest를 Quest클래스에서 사용하기 위해서
        public Quest(List<QuestInfo> quests)
        {
            QuestInfos = quests;
        }

        // 모든 퀘스트 보여주기
        public void ShowQusts(Charactor _charactor, List<Items> _items)
        {
            bool Restart = false;
            QuestInfos = RemoveQuest(QuestInfos);
            int questCount = QuestInfos.Count; // 현재 퀘스트 개수
            Console.WriteLine("Quest!!\n\n");
            int count = 1; // foreach 개수
            Console.WriteLine("0. 나가기");
            foreach (QuestInfo quest in QuestInfos)
            {
                // 수락 여부
                string accept = quest.access == true ? "O" : "X";
                Console.WriteLine($"{count}. [수락 {accept} ]{quest.questName}");
                count++;
            }
            Console.WriteLine("\n\n");
            choice = base.Choice(questCount, true);
            switch (choice)
            {
                case 1:
                    // 입력한 퀘스트 확인
                    Restart = QuestInfos[0].QuestShow(_charactor, _items, Restart);
                    break;
                case 2:
                    Restart = QuestInfos[1].QuestShow(_charactor, _items, Restart);
                    break;
                case 3:
                    QuestInfos[2].QuestClear(_charactor);
                    Restart = QuestInfos[2].QuestShow(_charactor, _items, Restart);
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
    }
}

