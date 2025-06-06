# 🧙‍♂️ HelperTool Template (기본 Unity 프로젝트 템플릿)

## 📌 소개
이 프로젝트는 모든 Unity 프로젝트의 시작점을 위해 만들어진 템플릿입니다.  
반복적인 설정, 구조 구성, 패키지 설치 없이 이 템플릿에서 시작하세요!

---

## 📁 프로젝트 구성

| 폴더 | 설명 |
|------|------|
| `Assets/` | 기본 스크립트, 프리팹, 설정 등이 담길 공간 |
| `Packages/` | 사용 중인 Unity 패키지 리스트 (`manifest.json`) |
| `ProjectSettings/` | 물리, 인풋, 태그 등 Unity 세팅 정보 |

---

## 📦 포함 패키지

- ✅ Unity Input System (`com.unity.inputsystem`)
- ✅ Newtonsoft Json.NET (`com.unity.nuget.newtonsoft-json`)
- ✅ TextMeshPro (`com.unity.textmeshpro`)
- ✅ Timeline (`com.unity.timeline`)
- ✅ Unity Visual Scripting (`com.unity.visualscripting`)
- ✅ 기타 모듈: 2D/Physics/Video/VR/Analytics 등 기본 Unity 모듈 포함

---

## ⚙️ 사용 방법

1. 이 템플릿을 복사하여 새 폴더에 붙여넣습니다.
2. 프로젝트 이름 변경 후 Unity Hub 또는 에디터에서 열기
3. 필요에 따라 `Assets/`에 게임 로직 추가

---

## 🧾 참고 사항

- `Assets/`에 ScriptableObject나 JSON을 활용한 데이터 중심 구조 설계 가능
- Git 저장소에 올릴 때는 `.Library`, `.Temp`, `.obj`, `Build` 폴더는 제외하세요
- Rider / VSCode 등 외부 IDE 환경 최적화는 선택 사항입니다

---

## 👤 제작자: 가람쥐의 헬퍼 하린이 🐿️🌿