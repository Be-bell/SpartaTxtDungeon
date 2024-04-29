﻿using System;
using System.ComponentModel;
using Sparta2weekProject.Menu;
using Sparta2weekProject.Objects;

internal class QuestInfo : MenuHandler
{
    // string
    public string questName;   // 이름
    public string questDescription; // 설명
    public string questGoal;   // 목표
    public string monsterName; // 목표 몬스터 이름

    // items
    public Items rewardItem = null;   // 보상 아이템

    // int
	public int clearGold;      // 보상 골드
    public int currentCount = 0; // 현재 횟수
    public int maxCount = 10000;   // 최대 횟수
    public int atk = 1000;
    public int def = 1000;

    // bool
    public bool clearCheak = false; // 클리어 여부
    public bool access = false; // 수락 여부
    public bool rewardCheck = false; // 보상 획득 여부

	// 퀘스트 정보 보여주기
	public void QuestShow(Charactors chad, List<Items> shopitems)
	{
        // 퀘스트 클리어 여부 확인
        QuestClear(chad);
        // 해당 퀘스트의 정보 출력
        Console.WriteLine("Quest");
		Console.WriteLine($"{questName}\n\n{questDescription}\n");
		// 목표 횟수가 있는 퀘스트
		if (maxCount != 0)
		{
            Console.WriteLine($"- {questGoal}");
        }
		// 목표 횟수가 없는 퀘스트
		else
		{
            Console.WriteLine($"- {questGoal}");
        }
		
        Console.WriteLine("\n- 보상 -");
		// 보상 아이템이 있다면
		if (rewardItem != null)
		{
            Console.WriteLine(rewardItem.itemName + " X 1 ");
        }
		Console.WriteLine(clearGold + "G\n");

        // 퀘스트 여부에 따른 텍스트 및 입력 변경

		// 1. 퀘스트를 클리어 했다면
		if (clearCheak && access)
		{
            Console.WriteLine("0. 돌아가기");
            Console.WriteLine("1. 보상 받기");
            // 선택에 따른 로직
            choice = base.Choice(1, true);
            if (choice == 1)
            {
                Console.WriteLine("퀘스트 보상을 획득하셨습니다.");
                rewardCheck = true;
                // 클리어 골드 획득
                chad.gold += clearGold;
                // 아이템이 존재하면
                if (rewardItem != null)
                {
                    bool cheack = false; // 아이템 골드 변환 여부
                                         // 해당 아이템을 이미 습득했다면
                    foreach (Items item in chad.inven)
                    {
                        // 플레이어의 장비 목록에 보상 장비가 있다면)
                        if (item.itemName == rewardItem.itemName)
                        {
                            Console.WriteLine("해당 아이템을 이미 습득 하셨기 때문에 골드로 지급합니다.");
                            // 보상 장비의 상점 금액으로 지급
                            chad.gold += item.price;
                            cheack = true;
                        }
                    }
                    // 아이템을 습득하지 않은 상태였다면 아이템을 획득
                    if (cheack == false)
                    {
                        foreach(Items items in shopitems)
                        {
                            if(items.itemName == rewardItem.itemName)
                            {
                                // 플레이어 장비에 아이템 추가
                                rewardItem.isPurchase = true;
                                chad.inven.Add(rewardItem);

                                // 상점에서 해당 아이템 구매 완료로 변경
                                items.isPurchase = true;
                            }
                        }
                    }
                }
            }
        }
        // 2. 퀘스트만 수락했다면
        else if (access)
        {
            Console.WriteLine("0. 돌아가기");
            // 선택에 따른 로직
            choice = base.Choice(1, true);
        }
		else
		{
            Console.WriteLine("0. 거절");
            Console.WriteLine("1. 수락");
            // 선택에 따른 로직
            choice = base.Choice(2, true);
            switch (choice)
            {
                case 1:
                    access = true;
                    break;
                case 2:
                    access = false;
                    break;
            }
        }
    }

    public void QuestClear(Charactors chad)
    {
        // 최대 횟수가 0이 아니고 currentCount가 maxCount가 아니라면
        if(maxCount <= currentCount)
        {
            clearCheak = true;
        }
        // 무기와 방어구를 모두 장착 중이라면
        else if (chad.weapon != null && chad.armor != null)
        {
            if(chad.weapon.isEquiped && chad.armor.isEquiped)
            {
                clearCheak = true;
            }
        }
        else if (chad.attack + chad.plusAttack >= def && chad.defend + chad.plusDefend >= def)
        {
            clearCheak = true;
        }
        else
        {
            clearCheak = false;
        }
    }
}

// 사냥하기
internal class Hunting : QuestInfo
{
    public Hunting()
	{
		monsterName = "미니언";
		currentCount = 0;
		maxCount = 0;
		questName = "마을을 위협하는 미니언 처치";
        questDescription = "이봐! 마을 근처에 미니언들이 너무 많아졌다고 생각하지 않나?\n마을 주민들의 안전을 위해서라도 저것들 수를 좀 줄여야 한다고!\n모험가인 자네가 좀 처치해주게!";
        questGoal = string.Format($"{monsterName} 5마리 처치 ({currentCount} / {maxCount})");
        rewardItem = new Armor(); // 방어구
        clearGold = 5;
    }
}

// 장비를 장착하기
internal class EquipItem : QuestInfo
{
	public EquipItem()
	{
        questName = "장비를 장착해보자";
		questDescription = "자네 신참 모험가가 아닌가? \n모험을 떠나기전에 장비를 구매해서 한 번 장착해보겠는가?";
        questGoal = string.Format($"무기와 방어구를 모두 장착하기");
        // rewardItem; // 보상 아이템
        clearGold = 10;
	}
}

// 더 강해지기
internal class PowerUp : QuestInfo
{
	public PowerUp()
	{
        questName = "더욱 더 강해지기";
        questDescription = "당신 아직 높은 던전에 가기에는 미숙한 거 같군";
        questGoal = string.Format($"공격력 20이상 / 방어력 25이상 ");
        // rewardItem; // 보상 아이템
        clearGold = 30;
        atk = 13;
        def = 23;
}
}
