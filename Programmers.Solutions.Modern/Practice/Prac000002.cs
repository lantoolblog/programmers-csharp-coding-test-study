namespace Programmers.Solutions.Modern.Practice;

/// <summary>
/// Gemini가 출제한 문제: 유효한 괄호열 판단
///
/// 문자열 s가 주어집니다.
/// 이 문자열은 오직 (, ), {, }, [, ] 여섯 가지 괄호로만 구성되어 있습니다.
/// 이 괄호열이 유효한지 판단하는 함수를 작성하세요.
///
/// 이건 프로그래머스에의 문제는 이 문제를 좀 더 꼬았던 것 같다.
/// </summary>
internal static class Prac000002
{
    public static bool Solutions(string s)
    {
        var pairs = new Dictionary<char, char>
        {
            ['('] = ')', //
            ['['] = ']',
            ['{'] = '}'
        };


        Stack<char> stack = new();
        foreach (var c in s)
        {
            if (pairs.ContainsKey(c))
            {
                stack.Push(c);
            }
            else
            {
                // 💢 스택이 비어있다면, 짝이 없는 닫는 괄호
                if (stack.Count == 0)
                {
                    return false;
                }

                var k = stack.Pop();
                if (pairs[k] != c)
                {
                    return false;
                }
            }
        }

        return stack.Count == 0;
    }
}
