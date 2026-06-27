using Programmers.Solutions.Tests.Common;

namespace Programmers.Solutions.Tests.Practice;

using ModernPractice = Programmers.Solutions.Modern.Practice;

#pragma warning disable xUnit1045

public class Prac000001Tests
{
    public record TestCase(string S, Dictionary<string, int> Expected);

    public static TheoryData<TestCase> DefaultTestCases =>
    [
        new TestCase(
            S: "Csharp is fun, and Javascript is also fun. Csharp is powerful.",
            Expected: new Dictionary<string, int>
            {
                ["csharp"] = 2,
                ["is"] = 3,
                ["fun"] = 2,
                ["and"] = 1,
                ["javascript"] = 1,
                ["also"] = 1,
                ["powerful"] = 1
            }
        )
    ];

    [LimitedTheory, MemberData(nameof(DefaultTestCases))]
    public void Solution_Modern_Test(TestCase testCase)
    {
        Assert.Equal(testCase.Expected, ModernPractice.Prac000001.Solutions(testCase.S));
    }
}
#pragma warning restore xUnit1045
