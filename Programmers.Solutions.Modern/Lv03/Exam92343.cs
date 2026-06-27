namespace Programmers.Solutions.Modern.Lv03;

/// <summary>
/// 양과 늑대 - 92343
/// - https://school.programmers.co.kr/learn/courses/30/lessons/92343?language=csharp
/// </summary>
internal static class Exam92343
{
    private const int EmptyNodeIdx = -1;
    private const int Wolf = 1;

    /// <summary>
    /// 큐에 저장할 상태
    /// </summary>
    /// <param name="CurrentNode">현재 탐색 중인 노드</param>
    /// <param name="SheepCount">현재까지의 양의 카운트</param>
    /// <param name="WolfCount">현재까지의 늑대의 카운트</param>
    /// <param name="Candidates">다음 탐색할 후보 노드</param>
    private record State(int CurrentNode, int SheepCount, int WolfCount, HashSet<int> Candidates);


    public static int Solution(int[] info, int[,] edges)
    {
        var nodes = new int[info.Length, 2];
        for (var i = 0; i < info.Length; i++)
        {
            nodes[i, 0] = EmptyNodeIdx;
            nodes[i, 1] = EmptyNodeIdx;
        }

        // 💡 다차원 배열(int[,])에서 Length는 전체 요소의 합(행*열)을 반환하므로,
        //    행의 개수만 가져오기 위해 GetLength(0)을 사용한다.
        for (var i = 0; i < edges.GetLength(0); i++)
        {
            var (parent, child) = (edges[i, 0], edges[i, 1]);

            if (nodes[parent, 0] == EmptyNodeIdx)
            {
                nodes[parent, 0] = child;
            }
            else
            {
                nodes[parent, 1] = child;
            }
        }

        var maxSheepCount = 0;
        var queue = new Queue<State>([new State(0, 1, 0, [])]);

        while (queue.TryDequeue(out var state))
        {
            var (currentNode, sheepCount, wolfCount, currentCandidates) = state;

            maxSheepCount = Math.Max(maxSheepCount, sheepCount);

            // 현재 노드에서 갈 수 있는 자식들을 후보군에 추가 (독립된 복사본 생성)
            var nextCandidates = new HashSet<int>(currentCandidates);

            if (nodes[currentNode, 0] != EmptyNodeIdx)
            {
                nextCandidates.Add(nodes[currentNode, 0]);
            }

            if (nodes[currentNode, 1] != EmptyNodeIdx)
            {
                nextCandidates.Add(nodes[currentNode, 1]);
            }

            foreach (var targetNode in nextCandidates)
            {
                if (info[targetNode] == Wolf)
                {
                    if (sheepCount <= wolfCount + 1)
                    {
                        continue;
                    }

                    var updatedCandidates = new HashSet<int>(nextCandidates);
                    updatedCandidates.Remove(targetNode);
                    queue.Enqueue(new State(targetNode, sheepCount, wolfCount + 1, updatedCandidates));
                }
                else
                {
                    var updatedCandidates = new HashSet<int>(nextCandidates);
                    updatedCandidates.Remove(targetNode);
                    queue.Enqueue(new State(targetNode, sheepCount + 1, wolfCount, updatedCandidates));
                }
            }
        }

        return maxSheepCount;
    }
}
