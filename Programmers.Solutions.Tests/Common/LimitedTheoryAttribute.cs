using System.Runtime.CompilerServices;

namespace Programmers.Solutions.Tests.Common;

/// <summary>
/// 기본적으로 10초(10,000ms)의 타임아웃을 가지는 Theory 어트리뷰트
/// 데이터 기반 테스트(InlineData 등)에서 무한 루프 방지용으로 사용
/// </summary>
public sealed class LimitedTheoryAttribute : TheoryAttribute
{
    public LimitedTheoryAttribute(int timeoutMs = 10_000)
    {
        Timeout = timeoutMs;
    }

    // xUnit v3 (xUnit3003) 대응을 위한 소스 정보 수신 생성자
    // memberName은 받지만 base로는 넘기지 않음
    public LimitedTheoryAttribute(int timeoutMs, [CallerMemberName] string memberName = "", [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        : base(sourceFilePath, sourceLineNumber)
    {
        _ = memberName;  // 의도적으로 사용하지 않음을 명시 (CS0022 경고 제거)
        Timeout = timeoutMs;
    }
}
