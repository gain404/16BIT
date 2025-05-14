# 16BIT

![image](https://github.com/user-attachments/assets/238223dc-f6f9-4f91-a2e2-28800518fb96)

안녕하세요, 저희는 이번 **냥즈 어드벤처: 집나가면 냥고생** 게임을 제작하게 된 16비트☆입니다.
<br>
<br>
<br>


<h2>:cat: 목차</h2>

<table>
  <tr>
    :cat: <a href="#프로젝트-소개"><strong>프로젝트 소개</strong></a></td><br><br>
  </tr>
  <tr>
    :smile_cat: <a href="#초기-게임-구상"><strong>초기 게임 구상</strong></a></td><br><br>
  </tr>
  <tr>
    :smile_cat: <a href="#게임-로직-설명"><strong>게임 로직 설명</strong></a></td><br><br>
  </tr>
  <tr>
    :heart_eyes_cat: <a href="#사용-기술"><strong>사용 기술</strong></a></td><br><br>
  </tr>
  <tr>
    :joy_cat: <a href="#트러블-슈팅"><strong>트러블 슈팅</strong></a></td><br><br>
  </tr>
  <tr>
    :smiley_cat: <a href="#만든-사람들"><strong>만든 사람들</strong></a></td><br><br>
  </tr>
</table>


---

## 프로젝트 소개
[:cat: Team Notion](https://www.notion.so/teamsparta/16-1e42dc3ef514809f9794c73bd868587a)

**각기 다양한 컨셉을 가진 3가지의 맵을 클리어해보세요!**

<img src="https://github.com/user-attachments/assets/76ba128c-828b-4dd2-8c6b-54da0beddf9b" width="500"><br>
<img src="https://github.com/user-attachments/assets/0762b029-9267-4efc-9312-e8009350ce33" width="500"><br>
<img src="https://github.com/user-attachments/assets/4f7b61e7-1e6b-4ff9-bc3e-6752cee4e516" width="500"><br>

<table>
  <tr>
    <td>게임명</td>
    <td><strong>냥즈 어드벤처: 집나가면 냥고생</strong><br>
  </tr>
   <tr>
    <td>장르</td>
    <td><strong>2D 플랫포머, 퍼즐</strong><br>
  </tr>
    <tr>
    <td>개발 환경</td>
    <td><strong>Unity 2022.3.17f</strong><br>
  </tr>
   <tr>
    <td>타겟 플랫폼</td>
    <td><strong>Window</strong><br>
  </tr>
  <tr>
    <td>제작 기간</td>
    <td><strong>2025.05.08 ~ 2025.05.15</strong><br>
  </tr>
</table>
<br>
<br>
<br>

## 초기 게임 구상
<img src="https://github.com/user-attachments/assets/42c6be19-ed4a-467a-9ed4-86fcf7bec0e9" width="300">
<img src="https://github.com/user-attachments/assets/7a194b15-ff9f-4b91-b08f-bd7cffed4b56" width="300"><br>
<img src="https://github.com/user-attachments/assets/9f3f431e-3ad8-4cac-a476-3a2212d816b3" width="300">
<img src="https://github.com/user-attachments/assets/1d909905-11dc-4d51-a7f1-c6cc3d916f55" width="300"><br>
<img src="https://github.com/user-attachments/assets/43d51d57-5eab-4b51-a6cf-1030fe845cfd" width="600"><br>
<img src="https://github.com/user-attachments/assets/95ea4185-707e-4a17-a8ff-6386f0f438f6" width="300"><br>

- Fireboy & Watergirl 게임을 기반으로 제작
- 해당 게임에서 나오는 오브젝트들 위주로 구상
- 추가 오브젝트 구상
- 레벨 디자인 및 UI 구상
- 컨셉에 따른 맵 디자인 구상
- 캐릭터 디자인 구상
<br>
<br>
<br>

## 게임 로직 설명


<img src="https://github.com/user-attachments/assets/233c80ee-030b-41e0-aae3-5d9ad4a72100" width="700"><br><br><br>
<img src="https://github.com/user-attachments/assets/bb7d950b-5782-4775-b037-bc78fa5afb0d" width="700">

🔥💧 **냥즈 어드벤처: 집나가면 냥고생** 게임 로직 요약
<br>
<br>
🎮 1. 두 캐릭터 조작
<br>
각각 플레이어 1과 플레이어 2가 조작 (또는 혼자서 두 캐릭터 번갈아 조작)
<br>

- 각자 다른 키 입력으로 움직임 (예: WASD vs 방향키)
- 일정 키로 오브젝트와의 상호작용 가능(Q,R 등)
<br>
<br>

🌊🔥 2. 속성에 따른 충돌 처리

<img src="https://github.com/user-attachments/assets/68ef1b3c-8cd3-477a-a084-3dd90221be3f" width="300"><br>

예를 들어 불 캐릭터(FireCat)는 물 웅덩이에 닿으면 사망하지만, 물 캐릭터(WaterCat)는 물 통과 가능합니다.

**많은 캐릭터가 있으니 직접 플레이하면서 경험해보세요!**
<br>
<br>

🧠 3. 협동 퍼즐 시스템

<br>
<img src="https://github.com/user-attachments/assets/bea2a284-e163-4710-a83e-3973b05c2752" width="300">
<br>
스위치, 문, 버튼, 박스 등 다양한 오브젝트를 통해 퍼즐을 해결해야합니다. 예: FireCat이 버튼을 밟으면 WaterCat의 길이 열림<br>
<br>
<br>

🚪 4. 목표: 둘 다 탈출구 도달

<br>
<img src="https://github.com/user-attachments/assets/0a9fc7a3-9cc2-4297-85bc-ddd7180c19b0" width="300"><br>

각각 자기 색깔 출구에 도달해야 **클리어!** 퍼즐을 해석하며 끝까지 도달해보세요.

<br>
<br>


<br>
<br>
<br>


## 사용 기술

설명…
<br>
<br>
<br>

## 트러블 슈팅

설명…
<br>
<br>
<br>


## 만든 사람들

설명...
<br>
<br>
<br>
