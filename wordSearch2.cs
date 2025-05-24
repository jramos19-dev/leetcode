// given  an mxn board of charactresr and list of strings words, return all words on the board, 
// each word must be constructed from sequentially adjecent cells, horizonal or vertical neighbors
// 
/*This function searches for all words from the given list that
 can be formed by sequentially adjacent letters (horizontally or vertically)
  on the board. It uses a Trie (prefix tree) to efficiently store the word list 
  and a Depth-First Search (DFS) to explore valid paths on the board. 
  Words are added to the result only when a complete match is found in the Trie. 
  Visited cells are tracked to prevent reuse in a single word path, and matched words are marked in the Trie to avoid duplicate results.
*/
class TrieNode
{
    public Dictionary<char, TrieNode> children = new Dictionary<char, TrieNode>();
    public bool isWord;

    public void addWord(string word)
    {
        TrieNode current = this;
        foreach (var c in word)
        {
            if (!current.children.ContainsKey(c))
            {
                current.children[c] = new TrieNode();
            }
            current = current.children[c];
        }
        current.isWord = true;
    }
}




class Solution
{
    public List<string> FindWords(char[][] board, string[] words)
    {
        // we gonna use a TRIE( prefix tree) because it helps us organize words based 
        //on prefixes
        TrieNode root = new TrieNode();
        HashSet<string> results = new HashSet<string>();
        bool[,] visited;
        foreach (string word in words)
        {
            root.addWord(word);
        }
        int Rows = board.Length;
        int Columns = board[0].Length;

        visited = new bool[Rows, Columns];
        for (int r = 0; r < Rows; r++)
        {
            for (int c = 0; c < Columns; c++)
            {
                dfs(r, c, root, "");
            }
        }
        return new List<string>(results);

        void dfs(int r, int c, TrieNode node, string word)
        {
            int Rows = board.Length;
            int Cols = board[0].Length;
            if (r < 0 || c < 0 || r >= Rows || c >= Cols || visited[r, c] || !node.children.ContainsKey(board[r][c]))
            {
                return;
            }
            visited[r, c] = true;
            node = node.children[board[r][c]];
            word += board[r][c];
            if (node.isWord)
            {
                results.Add(word);
            }
            dfs(r + 1, c, node, word);
            dfs(r - 1, c, node, word);
            dfs(r, c + 1, node, word);
            dfs(r, c - 1, node, word);

            visited[r, c] = false;
        }
        


    }
}