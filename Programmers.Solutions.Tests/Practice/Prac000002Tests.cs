using Programmers.Solutions.Tests.Common;

namespace Programmers.Solutions.Tests.Practice;

using ModernPractice = Programmers.Solutions.Modern.Practice;

#pragma warning disable xUnit1045

public class Prac000002Tests
{
    public record TestCase(string S, bool Expected);

    public static TheoryData<TestCase> DefaultTestCases =>
    [
        new TestCase(
            S: "(){}[]",
            Expected: true
        ),
        new TestCase(
            S: "([)]",
            Expected: false
        ),
        new TestCase(
            S: "{[()]}",
            Expected: true
        ),
        new TestCase(
            S: "}])",
            Expected: false
        )
    ];

    [LimitedTheory, MemberData(nameof(DefaultTestCases))]
    public void Solution_Modern_Test(TestCase testCase)
    {
        Assert.Equal(testCase.Expected, ModernPractice.Prac000002.Solutions(testCase.S));
    }
}
#pragma warning restore xUnit1045
