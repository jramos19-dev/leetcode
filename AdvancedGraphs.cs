public class AdvancedGraph {
    public string foreignDictionary(string[] words)
    {
        //topological sort
        //sorted words 
        //if no solution we return empty string
        // two strings s t 
        //we check the first differing letter , 
        Dictionary<char, HashSet<char>> adjacent;
        Dictionary<char, bool> visited;
        List<char> result;

        adjacent = new Dictionary<char, HashSet<char>>();
        foreach (var word in words)
        {
            foreach (var letter in word)
            {
                if (!adjacent.ContainsKey(letter))
                {
                    adjacent[letter] = new HashSet<char>();
                }
            }
        }

        for (int i = 0; i < words.Length - 1; i++)
        {
            var w1 = words[i];
            var w2 = words[i + 1];
            int minLen = Math.Min(w1.Length, w2.Length);
            if (w1.Length > w2.Length && w1.Substring(0, minLen) == w2.Substring(0, minLen))
            {
                return "";
            }
            for (int j = 0; j < minLen; j++)
            {
                if (w1[j] != w2[j])
                {
                    adjacent[w1[j]].Add(w2[j]);
                    break;
                }
            }
        }

        visited = new Dictionary<char, bool>();
        result = new List<char>();
        foreach (var c in adjacent.Keys)
        {
            if (dfs(c))
            {
                return "";
            }
        }


        bool dfs(char c)
        {
            if (visited.ContainsKey(c))
            {
                return visited[c];
            }

            visited[c] = true;
            foreach (var next in adjacent[c])
            {
                if (dfs(next))
                {
                    return true;
                }
            }

            visited[c] = false;
            result.Add(c);
            return false;

        }


    }
}
