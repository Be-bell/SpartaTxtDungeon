# SpartaTextDungeon (스파르타 텍스트 던전)
   
스파르타 텍스트 던전은 C# 콘솔을 기반으로 한 Text RPG입니다.
</br>
다음 사항들을 구현했습니다!
</br>
## 1. 캐릭터 선택창 : 전사, 궁수를 선택할 수 있습니다.
전사는 공격력과 방어력, 체력이 고루 밸런스가 갖춰진 캐릭터입니다.
</br>
궁수는 체력과 방어력이 약하지만, 공격력이 강합니다.
</br>
</br>

## 2. 마을 : 마을은 여러 행동을 취할 수 있습니다.
캐릭터를 처음 생성하게 되면, 마을로 도착하게 됩니다.
</br>
마을에서는 다음과 같은 행동을 취할 수 있습니다.
  1) 스탯창 보기
  2) 인벤토리 보기
  3) 상점 가기
</br>

## 3. 스탯창 : 스탯창은 자신의 현재 상태를 볼 수 있습니다. 
스탯창에서 볼 수 있는 목록은 다음과 같습니다.
  1) 현재 레벨
  2) 자신의 직업
  3) 공격력
  4) 방어력
  5) 체력
  6) 현재 골드
</br>

## 4. 인벤토리 : 인벤토리는 자신이 현재 보유한 무기와 방어구들을 볼 수 있습니다.
장착이 되면 아이템 옆에 [E] 라는 표시와 함께 장착이 완료됩니다.
</br>
아이템이 장착되면, 자신의 스탯을 올릴 수 있습니다.
</br>
</br>

## 5. 상점 : 상점에서는 물품을 구매할 수가 있습니다.
물품을 구매할 경우, 바로 인벤토리 창으로 지급이 됩니다.
</br>
또한, 이미 구매한 상품이거나, 돈이 없는 경우 물품을 구매할 수 없습니다.
</br>
</br>

## 6. 던전 : 던전을 돌면 골드를 벌 수 있습니다.
자신의 방어력에 따라 성공확률이 높은 던전이 나뉩니다.
</br>
방어력이 낮아도 성공할 수도 있지만, 매우 힘듭니다.
</br>
자칫하면 죽을수도 있지만.. 열심히 레벨업하면 되겠죠?
</br>
</br>

## 7. 온천 : 잠시 쉬어가세요.
체력이 낮다면 온천에서 잠시 쉬어가는 것도 방법입니다.
</br>
가격이 비싸지만 체력을 많이 채울 수 있는 유일한 수단입니다.
</br>
</br>

## 8. 저장 및 불러오기
게임을 하시다가 피곤하시면 저장하시면 됩니다!</br>
당신의 데이터는 잘 간직해뒀다가 다시 돌아올때 불러오면 되니까요!</br>
(*저장 파일 경로 : Documents\SpartaGameFolder\Charactor.txt)

