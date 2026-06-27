using Programmers.Solutions.Tests.Common;

namespace Programmers.Solutions.Tests.Lv03;

using LegacyLv03 = Programmers.Solutions.Lv03;
using ModernLv03 = Programmers.Solutions.Modern.Lv03;

#pragma warning disable xUnit1045
public class Exam92343Tests
{
    public record TestCase(int[] Info, int[,] Edges, int Expected);

    public static TheoryData<TestCase> DefaultTestCases =>
    [
        new TestCase(
            Info: [0, 0, 1, 1, 1, 0, 1, 0, 1, 0, 1, 1],
            // 💡 다차원 배열(int[,])은 C# 12의 컬렉션 식(Collection Expression, [])을 지원하지 않는다.
            Edges: new[,]
            {
                { 0, 1 }, //
                { 1, 2 }, //
                { 1, 4 }, //
                { 0, 8 }, //
                { 8, 7 }, //
                { 9, 10 }, //
                { 9, 11 }, //
                { 4, 3 }, //
                { 6, 5 }, //
                { 4, 6 }, //
                { 8, 9 }
            },
            Expected: 5
        ),
        new TestCase(
            Info: [0, 1, 0, 1, 1, 0, 1, 0, 0, 1, 0],
            Edges: new[,]
            {
                { 0, 1 }, //
                { 0, 2 }, //
                { 1, 3 }, //
                { 1, 4 }, //
                { 2, 5 }, //
                { 2, 6 }, //
                { 3, 7 }, //
                { 4, 8 }, //
                { 6, 9 }, //
                { 9, 10 }
            },
            Expected: 5
        )
    ];


    [LimitedTheory, MemberData(nameof(DefaultTestCases))]
    public void Solution_Modern_Test(TestCase testCase)
    {
        Assert.Equal(testCase.Expected, ModernLv03.Exam92343.Solution(testCase.Info, testCase.Edges));
    }

    [LimitedTheory, MemberData(nameof(DefaultTestCases))]
    public void Solution_Legacy_Test(TestCase testCase)
    {
        Assert.Equal(testCase.Expected, new LegacyLv03.Exam92343().solution(testCase.Info, testCase.Edges));
    }
}
#pragma warning restore xUnit1045
