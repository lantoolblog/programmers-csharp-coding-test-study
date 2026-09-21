# 프로그래머스 C# 코딩 테스트 - 스터디

> 💡원래 다른 리포에서 진행중이였는데, 블로그와 연동해서 해볼려고 lantoolblog 리포로 옮겨왔다.
>
> 블로그에서 어떻게 할지 계획을 세워보고, 코드를 작성하면 효과가 좋을 것 같다. 👍
>
> ---
>
> 코딩 테스트 연습을 JS/TS, Java, C++, Python 환경에서 가끔씩 😅 하고 있었는데,
> C#으로도 한번 만들어보고 싶어서 만들었다.
>
> 최근에 C# 기본서 초반만 보았는데, 뭔가 .NET 환경이 프로젝트 및 테스트 프로젝트 만드는데
> 쉽고 체계적인 것을 느끼게 되어서 코딩 테스트 프로젝트를 만들어보고 싶었다



## 스터디 프로젝트 구성

### 프로젝트 구조

```
programmers-csharp-coding-test-study/
  │
  │ 🔧 스크립트
  ├── convert-utf8bom-to-utf8.bat    # UTF-8 BOM 제거 배치파일
  ├── convert-utf8bom-to-utf8.ps1    # UTF-8 BOM 제거 PowerShell Script
  │
  │ ⚙️ 설정 파일
  ├── .editorconfig              # 코드 스타일 설정
  ├── .gitignore                 # Git 제외 파일
  ├── cspell.config.yaml         # 맞춤법 검사 설정
  ├── global.json                # dotnet test 러너 지정 (MTP)
  ├── NuGet.Config               # NuGet 패키지 소스
  ├── Programmers.CSharp.Coding.Study.slnx  # 솔루션 파일 (XML 기반 신규 포맷)
  ├── README.md                  # 프로젝트 설명
  │
  ├── 📂 .vscode/                    # VS Code 작업 공간 설정
  │   ├── extensions.json            # 권장 확장 프로그램
  │   └── settings.json              # 워크스페이스 설정
  │
  ├── 📦 Programmers.Solutions/      # 프로그래머스 제출용 솔루션 프로젝트 (C# 7.0)
  │   ├── Programmers.Solutions.csproj
  │   └── Lv03/
  │       ├── Exam42892.cs           # 레벨 3 문제
  │       └── Exam92343.cs           # 레벨 3 문제
  │
  ├── 📦 Programmers.Solutions.Modern/ # 최신 C# 문법 활용한 솔루션 프로젝트
  │   ├── Programmers.Solutions.Modern.csproj
  │   ├── Practice/
  │   │   ├── Prac000001.cs          # 개인 연습문제
  │   │   └── Prac000002.cs          # 개인 연습문제
  │   │
  │   └── Lv03/
  │       ├── Exam42892.cs           # 레벨 3 문제
  │       ├── Exam42892A.cs          # 레벨 3 문제 - 재귀를 루프로 변환
  │       └── Exam92343.cs           # 레벨 3 문제
  │
  └── 🧪 Programmers.Solutions.Tests/ # 테스트 프로젝트 (MTP 실행 방식)
      ├── Programmers.Solutions.Tests.csproj
      ├── Common/
      │   └── LimitedTheoryAttribute.cs # 타임아웃(기본 10초) 적용 Theory 어트리뷰트
      │
      ├── Practice/
      │   ├── Prac000001Tests.cs     # 개인 연습문제 테스트
      │   └── Prac000002Tests.cs     # 개인 연습문제 테스트
      │
      └── Lv03/
          ├── Exam42892Tests.cs      # 레벨 3 테스트
          └── Exam92343Tests.cs      # 레벨 3 테스트
```

### 프로젝트별 C# 버전 요약

| 프로젝트                         | C# 버전              | 이유           |
|------------------------------|--------------------|--------------|
| Programmers.Solutions        | 7.0                | 프로그래머스 제출 환경 |
| Programmers.Solutions.Modern | latest (SDK 기준 14) | 최신 문법 연습     |
| Programmers.Solutions.Tests  | latest (SDK 기준 14) | 테스트 편의성      |

### 문제 풀이 규칙

* 문제 파일명: `Exam{문제번호}.cs` (예: `Exam42892.cs`, 문제번호 = 프로그래머스 문제 ID)
* 테스트 파일명: `Exam{문제번호}Tests.cs`
* 레벨별 폴더 구조: `Lv01/`, `Lv02/`, `Lv03/`, `Lv04/`, `Lv05/`
* 동일 문제 변형/최적화 버전은 접미사 추가: `Exam42892A.cs` 등
* 프로그래머스 문제가 아닌 개인 연습문제는 `Practice/` 폴더에 `Prac{일련번호 6자리}.cs`
  (예: `Prac000001.cs`, 테스트는 `Prac000001Tests.cs`)

## 개발 도구

### .NET SDK 설치

* **10.0**
  * https://dotnet.microsoft.com/ko-kr/download/dotnet/10.0

프로그래머스의 C# 컴파일러가 **Mono C# Compiler 6.10.0**인데, C# 8.0 RC 일부 기능까지만 지원한다.  
Nullable Reference Types 전체 기능 및 최신 패턴 매칭/Range 연산 등은 미지원/부분지원일 수 있다.

.NET SDK는 현시점의 최신으로 사용하면서, 문제 풀이 프로젝트는 C# 7.0으로 언어 버전을 낮춰서 쓰고,
테스트 프로젝트만 버전 제한 없이 설치된 SDK가 제공하는 C# 버전을 사용하도록 하자.

> 💡.NET 10.0은 C# 14 버전을 지원한다.
>
> **💡문제 풀이 프로젝트 C# 언어 버전 설정**
>
> 문제 풀이 프로젝트([Programmers.Solutions.csproj](Programmers.Solutions/Programmers.Solutions.csproj))는 프로그래머스 환경에 맞춰 C# 7.0으로
> 설정:
>
> ```xml
> <PropertyGroup>
>     <LangVersion>7</LangVersion>
> </PropertyGroup>
> ```
>

### .NET SDK 업그레이드

Windows 11에서는 `winget` 명령으로 간단하게 SDK 업그레이드가 가능하다.

```
C:\>winget upgrade Microsoft.DotNet.SDK.10
사용 가능한 업그레이드를 찾을 수 없습니다.
구성된 원본에서 사용할 수 있는 최신 패키지 버전이 없습니다.
C:\>
```

* 나의 경우는 이미 현시점 최신 버전이라 위처럼 나왔다. 😅

* `install`로 옵션을 바꿔서 실행하면 처음 설치도 할 수 있다.

  ```
  winget install Microsoft.DotNet.SDK.10
  ```

  

### VSCode

* https://code.visualstudio.com/

> Python도 지원이 좋았지만, C#도 만만치 않다. MS에서 나온 언어이니 당연히 좋아야겠지만.. 😊
>
> * C# Dev Kit
>   * https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csdevkit

### Rider

* https://www.jetbrains.com/ko-kr/rider/
  * Rider면 다 된다고 함 👍 Windows Forms의 WYSIWYG 개발도 되는 것 같음.



## 디펜던시 관리자 (NuGet)

.NET SDK에 포함되어있음.

테스트 프로젝트를 만들 때도, MSBuild나 xUnit 프로젝트로 별도로 만들 때, 그냥 디펜던시가 추가되고,
특별한 라이브러리를 추가할 일도 없을 것 같아서, 따로 디펜던시 관리 관련해서는 따로 할 일이 없을 것 같다.

### 라이브러리 업데이트

**권장 방법**: `dotnet-outdated-tool` 사용 **(일괄 업데이트)**

```bash
# dotnet-outdated-tool 설치 (최초 1회)
dotnet tool install --global dotnet-outdated-tool

# (선택) 설치된 도구 자체 업데이트
dotnet tool update --global dotnet-outdated-tool

# 솔루션 전체의 패키지를 최신 버전으로 자동 업데이트
dotnet outdated -u

# 업데이트 후 검증
dotnet test
```

**대안**: 기본 dotnet CLI 사용 **(개별확인 후 업데이트)**

```bash
# 업데이트 가능한 패키지 확인
dotnet list package --outdated

# 개별 패키지 업데이트 (현재 폴더의 프로젝트 1개 기준)
dotnet add package <패키지명>

# 여러 프로젝트가 있는 솔루션이라면 csproj를 명시하는 방식 권장
dotnet add <경로/프로젝트.csproj> package <패키지명>
```

**GUI 방법**: Visual Studio나 Rider의 NuGet 패키지 관리 UI를 사용하면 업데이트 가능한 패키지를 한눈에 보고 선택적으로 업데이트할 수 있다.



## 단위 테스트 프레임워크

Java와는 다르게 src/test에다 한 프로젝트에 테스트 코드를 만들지 않고,
타겟 프로젝트에 대한 테스트 전용 프로젝트를 만들어서 테스트 코드를 추가함.

C#에서 가장 보편적으로 사용되는 테스트 프레임워크인 xUnit 기반 프로젝트로 만들기로 함. (Java의 TestNG와 유사)

### MTP(Microsoft.Testing.Platform) 방식

기존 VSTest 방식(`Microsoft.NET.Test.Sdk` + `xunit.runner.visualstudio`) 대신,
테스트 프로젝트 자체가 실행 파일이 되는 **MTP** 방식을 사용한다. (xUnit v3 권장 방식)

* 테스트 프로젝트([Programmers.Solutions.Tests.csproj](Programmers.Solutions.Tests/Programmers.Solutions.Tests.csproj)): `<OutputType>Exe</OutputType>` + `xunit.v3` 패키지만 참조
* 루트의 [global.json](global.json)에서 `dotnet test`가 MTP 러너를 쓰도록 지정

  ```json
  {
    "test": {
      "runner": "Microsoft.Testing.Platform"
    }
  }
  ```

이 설정 때문에 `dotnet test`의 필터 옵션이 VSTest 시절과 달라진다. ([테스트 실행](#테스트-실행) 참고)



## 코드 포맷터

VSCode와 Rider 모두 .editorconfig를 인식하므로 해당 파일을 추가했다.

* VSCode에서는 포맷터를 C# Dev Kit으로 지정하면 .editorconfig를 자동으로 인식한다.





## 실행 방법

### 테스트 실행

이 프로젝트는 VSTest가 아닌 **MTP(Microsoft.Testing.Platform)** 방식으로 테스트를 실행한다.
([단위 테스트 프레임워크](#단위-테스트-프레임워크) 참고)

```bash
# 전체 테스트 실행
dotnet test

# 실행하지 않고 테스트 목록만 확인
dotnet test --list-tests

# 특정 레벨 테스트 (네임스페이스)
dotnet test --filter-namespace "Programmers.Solutions.Tests.Lv03"

# 특정 테스트 클래스
dotnet test --filter-class "Programmers.Solutions.Tests.Lv03.Exam42892Tests"

# 특정 테스트 메서드
dotnet test --filter-method "Programmers.Solutions.Tests.Lv03.Exam42892Tests.Solution_Modern_Test"

# 와일드카드('*'는 앞/뒤에만 사용 가능)
dotnet test --filter-method "*Modern*"

# 제외 필터 (--filter-not-class / --filter-not-method / --filter-not-namespace)
dotnet test --filter-not-class "*Practice*"

# 특성(Trait) 기준 실행
dotnet test --filter-trait "Category=Slow"

# 쿼리 필터 언어: /어셈블리/네임스페이스/클래스/메서드
dotnet test --filter-query "/*/*/Exam42892Tests/*"

# 특정 프로젝트만 실행
dotnet test --project Programmers.Solutions.Tests/Programmers.Solutions.Tests.csproj
```

> 💡 예전 VSTest 스타일 필터(`dotnet test --filter "FullyQualifiedName~Lv03"`)도 호환용으로 동작하지만,
> MTP 환경에서는 위의 `--filter-*` 옵션을 쓰는 것이 명확하다.
>
> 💡 필터 옵션은 `dotnet test` 뒤에 바로 써도 테스트 앱으로 전달된다.
> 옵션 이름이 SDK 옵션과 충돌할 때는 `dotnet test -- --filter-class "..."` 처럼 `--` 뒤에 붙이면 된다.
>
> 💡 xUnit 자체 실행 파일을 직접 실행하면 네이티브 러너의 옵션(`-class`, `-method`, `-list methods` 등)을 쓸 수 있고,
> 전체 옵션은 아래 명령으로 확인할 수 있다.
>
> ```bash
> ./Programmers.Solutions.Tests/bin/Debug/net10.0/Programmers.Solutions.Tests.exe --help
> ```

### 솔루션 빌드

```bash
dotnet build
```



## 트러블슈팅

### 빌드 오류 시

- `.NET SDK 10.0` 설치 확인: `dotnet --version`
- 설치된 SDK 상세: `dotnet --info`
- NuGet 패키지 복원: `dotnet restore`
- 캐시 강제 복원: `dotnet restore --force`
- 빌드 클린 후 재시도: `dotnet clean && dotnet build`
- `bin/` / `obj/` 폴더 수동 삭제 후 재빌드

### 테스트 실행 안 될 때

- 테스트 프로젝트만 빌드: `dotnet build Programmers.Solutions.Tests/`
- 필터 오타 확인 (대소문자 정확) — 먼저 `dotnet test --list-tests`로 실제 테스트 이름 확인
- 필터에 걸리는 테스트가 없으면 종료 코드 `5`(zero tests ran)가 나온다
- 테스트가 `[Fact]` / `[Theory]` 속성 달렸는지 확인
- 빌드를 건너뛰고 실행: `dotnet test --no-build`
- 멀티 대상 사용 시 대상 명시: `dotnet test -f net10.0`

### .NET SDK 업그레이드 시 문제

- 설치 가능한 목록: `winget search Microsoft.DotNet.SDK`
- 업그레이드: `winget upgrade --id Microsoft.DotNet.SDK.10`
- 최초 설치: `winget install --id Microsoft.DotNet.SDK.10`



## .NET  도구 사용량 데이터 수집 거부

> * NET CLI Tools telemetry: https://aka.ms/dotnet-cli-telemetry

`DOTNET_CLI_TELEMETRY_OPTOUT` 환경 변수 설정하고 그것의 값을 `1` 또는  `true`로 설정하면 데이터 수집을 거부 할 수 있음

CMD 창에서 다음과 같이 입력하면 사용자(USER) 환경변수로 영구히 등록된다.

```  bat
C:\>setx DOTNET_CLI_TELEMETRY_OPTOUT "true"

SUCCESS: Specified value was saved.

C:\>
```

현재 창에서는 바로 적용되지 않으니  열려있는 CMD창을 닫고 다시 새로 열어서 값이 적용되었는지 확인해보면 된다.

```
C:\>echo %DOTNET_CLI_TELEMETRY_OPTOUT%
true

C:\>
```

