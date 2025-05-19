// using System.ComponentModel;
// using System.ComponentModel.DataAnnotations;
// using System.Globalization;
// using System.Net;
// using System.Runtime.CompilerServices;
// using System.Runtime.InteropServices;
// using System.Runtime.Intrinsics.Arm;
// using System.Runtime.Intrinsics.X86;
// using System.Security.AccessControl;
// using System.Security.Cryptography.X509Certificates;
// using System.Text;

// string[] strs = ["neet", "code", "love", "you"];



// // string Encode(IList<string> strs)
// // {
// //     Dictionary<int, string> encodedWords = new Dictionary<int, string>();
// //     StringBuilder encodedString = new StringBuilder();
// //     foreach (string word in strs)
// //     {
// //         encodedString.Append($"{word.Length}╝{word}");
// //     }

// //     return encodedString.ToString();
// // }

// // var encodedString = Encode(strs);

// // List<string> Decode(string s)
// // {
// //     List<string> results = new List<string>();

// //     int i = 0;
// //     while (i < s.Length)
// //     {
// //         int delimterIndex = s.IndexOf('╝', i);
// //         int wordLength = int.Parse(s.Substring(i, delimterIndex - i));
// //         i = delimterIndex + 1;
// //         results.Add(s.Substring(i, wordLength));
// //         i += wordLength;
// //     }
// //     return results;
// // }


// // List<string> results = Decode(encodedString);

// // foreach (string word in results)
// // {
// //     Console.WriteLine(word);
// // }

// // int [] nums = [-1,0,1,2,3];

// // int[] ProductExceptSelf(int[] nums)
// // {
// //     int[] results = new int[nums.Length];

// //     int[] prefixFactor = new int[nums.Length];
// //     int[] suffixFactor = new int[nums.Length];

// //     prefixFactor[0] = 1;
// //     for (int i = 1; i < nums.Length; i++)
// //     {
// //         prefixFactor[i] = prefixFactor[i - 1] * nums[i - 1];
// //     }

// //     suffixFactor[nums.Length - 1] = 1;
// //     for (int i = nums.Length - 2; i >= 0; i--)
// //     {
// //         suffixFactor[i] = suffixFactor[i + 1] * nums[i + 1];
// //     }

// //     for (int i = 0; i < nums.Length; i++)
// //     {
// //         results[i] = prefixFactor[i] * suffixFactor[i];
// //     }

// //     return results;

// // }

// // int LongestConsecutive(int[] nums) {


// //         int longestStreak=0;
// //         foreach (int num in nums ){

// //            bool isStartOfSequence = nums.Contains(num-1);
// //            if (!isStartOfSequence){
// //                int currentNum = num;
// //                int currentStreak = 1;

// //                while (nums.Contains(currentNum + 1)){
// //                    currentNum += 1;
// //                    currentStreak += 1;
// //                }

// //                longestStreak = Math.Max(longestStreak, currentStreak);
// //             }



// //         }

// // bool IsPalindrome(string s) {

// //     int left = 0;  
// //     int right = s.Length - 1;

// //     while(left < right){

// //         while( left < right &&!char.IsLetterOrDigit(s[left])){
// //             //if the character on the left is not a letter or digit, move the pointer to the right
// //             left++;
// //         } 

// //         while(right > left && !char.IsLetterOrDigit(s[right])){
// //             //if the character on the right is not a letter or digit, move the pointer to the left
// //             right--;
// //         }

// //         if(char.ToLower(s[left]) != char.ToLower(s[right])){
// //             return false;
// //         }

// //         left++;
// //         right--;

// //     }

// //     List<List<int>> ThreeSum(int[] nums) {
// //         Array.Sort(nums);
// //         List<List<int>> results = new List<List<int>>();

// //         int n = nums.Length;

// //         for (int i = 0; i < n-2; i++){
// //             if(i > 0 && nums[i]== nums[i-1]){
// //                 continue;
// //             }

// //             int left = i + 1;
// //             int right = n -1 ;

// //             while (left < right ) {
// //                 int sum = nums[i] + nums[left] + nums[right];

// //                 if(sum == 0){
// //                     results.Add(new List<int> {nums[i], nums[left], nums[right]});

// //                     while (left < right && nums[left] == nums[left + 1]){
// //                         left++;
// //                     }
// //                     while(left< right && nums[right] == nums[right-1]){
// //                         right--;
// //                     }

// //                     left++;
// //                     right--;
// //                 }else if (sum < 0 ){
// //                     left ++;

// //                 }else{
// //                     right --;
// //                 }
// //             }




// //         }

// //       return results;



// //     }

// // int [] heights=[1,7,2,5,12,3,500,500,7,8,4,7,3,6];



// // int MaxArea(int[] heights)
// // {

// //     int left = 0 , right = heights.Length - 1;
// //     int largestSum = 0;

// //     while (left < right){
// //         int area = (Math.Min(heights[left], heights[right]) * (right-left));
// //         largestSum= Math.Max(area, largestSum);

// //         if(heights[left]<= heights[right]){
// //             left++;
// //         }
// //         else{
// //             right--;
// //         }
// //     }
// //     return largestSum;

// // }

// // var largest = MaxArea(heights);
// // Console.WriteLine(largest);
// // int [] prices = [10,1,5,6,7,1];

// // int MaxProfit(int[] prices)
// // {


// //     int maxP = 0;
// //     int minBuy = prices[0];

// //     foreach (int sell in prices)
// //     {
// //         maxP = Math.Max(maxP, sell - minBuy);
// //         minBuy = Math.Min(minBuy, sell);
// //     }
// //     return maxP;
// // }

// // MaxProfit(prices);



// //     string s="thequickbrownfoxjumpsoverthelazydogthequickbrownfoxjumpsovert";

// //     int LengthOfLongestSubstring(string s) {

// //         int l= 0; 
// //         HashSet<char> results = new HashSet<char>();
// //         int maxCount = 0;
// //         for(int r = 0 ; r < s.Length; r++){
// //             while(results.Contains(s[r])){
// //                 results.Remove(s[l]);
// //                 l++;
// //             }
// //             results.Add(s[r]);
// //             maxCount = Math.Max(maxCount, r-l+1);


// //         }
// //         return maxCount;

// //     }

// //    Console.WriteLine(LengthOfLongestSubstring(s));


// // string s = "XYYX"; 
// // int k = 2;

// // int CharacterReplacement(string s, int k)
// // {

// //     Dictionary<char, int> letterDistribution = new Dictionary<char, int>();
// //     int max = 0, l=0, result=0;

// //     for (int r = 0; r < s.Length; r++)
// //     {

// //         if (letterDistribution.ContainsKey(s[r]))
// //         {
// //             letterDistribution[s[r]]++;        
// //         }
// //         else
// //         {
// //             letterDistribution[s[r]] = 1;
// //         }
// //         max = Math.Max(max, letterDistribution[s[r]]);

// //         while ((r - l + 1) - max > k)
// //         {
// //             letterDistribution[s[l]]--;
// //             l++;
// //         }
// //         result = Math.Max(result, r - 1 + 1);
// //     }

// //     return result;
// // }

// // string  s="]";

// // bool IsValid(string s)
// // {
// //     Stack<char> stack = new Stack<char>();
// //     for (int c = 0; c < s.Length; c++)
// //     {
// //         if (s[c] == '(' || s[c] == '{' || s[c] == '[')
// //         {
// //             stack.Push(s[c]);
// //         }
// //         else
// //         {
// //             if (stack.Count == 0) return false;
// //             switch (s[c])
// //             {
// //                 case ')':
// //                     if (stack.Peek() == '(') stack.Pop();
// //                     else return false;
// //                     break;
// //                 case '}':
// //                     if (stack.Peek() == '{') stack.Pop();
// //                     else return false;
// //                     break;
// //                 case ']':
// //                     if (stack.Peek() == '[') stack.Pop();
// //                     else return false;
// //                     break;
// //             }
// //         }
// //     }
// //     return stack.Count == 0;

// // }

// // Console.Write(IsValid(s));


// // string MinWindow(string s, string t)
// // {
// //     Dictionary<char, int> count = new Dictionary<char, int>();
// //     Dictionary<char, int> Tfreqs = new Dictionary<char, int>();

// //     string shortestString

// //     foreach (char c in t)
// //     {
// //         if (Tfreqs.ContainsKey(t[c]))
// //         {
// //             Tfreqs[t[c]]++;
// //         }
// //         else
// //         {
// //             Tfreqs[t[c]] = 1;
// //         }
// //     }

// //     int l = 0;

// //     for (int r = 0; r < s.Length; r++)
// //     {

// //         if (Tfreqs.ContainsKey(s[r]) && count.ContainsKey(s[r]))
// //         {
// //             count[s[r]]++;
// //         }
// //         else if (Tfreqs.ContainsKey(s[r]) && !count.ContainsKey(s[r]))
// //         {
// //             count[s[r]] = 1;
// //         }


// //     }

// // }
// // int HammingWeight(uint n)
// // {

// //     int counter = 0;
// //     for (int i = 0; i < 32; i++)
// //     {
// //         int mask = 1 << i;

// //         if ((n & mask) != 0)
// //             counter++;
// //     }
// //     return counter;
// // }


// ///<summary>Definition for singly-linked list.</summary>

// // ListNode ReverseList(ListNode head)
// // {
// // ListNode? prev = null, current = head;

// // while (current != null){

// //     var next = current.Next;
// //     current.Next = prev;
// //     prev = current;
// //     current = next;


// // }
// // return prev;



// // }

// //  ListNode MergeTwoLists(ListNode list1, ListNode list2) {

// //     ListNode dummy= new ListNode(0);
// //     ListNode current = dummy;

// //     while(list1 != null && list2 != null){

// //         if(list1.value < list2.value){

// //             current.next =list1;
// //             list1 = list1.next; 
// //         }
// //         else{
// //             current.next = list2;
// //             list2 = list2.next;
// //         }

// //         current = current.next;
// //     }

// //     current.next = list1 ?? list2;

// //     return dummy.next;
// // }


// // bool HasCycle(ListNode head) {


// // }


// // class ListNode
// // {
// //     public int value;
// //     public ListNode next;

// //     public ListNode(int value)
// //     {
// //         this.value = value;     // Holds the value or data of the node
// //         this.next = null;       // Points to the next node in the linked list; default is null
// //     }
// // }


// // TreeNode InvertTree(TreeNode root) {

// //     if(root ==null) return null;
// //     Stack<TreeNode> stack = new Stack<TreeNode>();
// //     stack.Push(root);

// //     while(stack.Count > 0 ){
// //         TreeNode node = stack.Pop();
// //         TreeNode temp = node.left;
// //         node.left = node.right;
// //         node.right = temp;
// //         if(node.left != null) stack.Push(node.left);
// //         if(node.right != null) stack.Push(node.right);


// //     }
// //     return root;


// // }


// // TreeNode InvertTree(TreeNode root) {
// //     if (root == null) return null;

// //     TreeNode temp = root.left;
// //     root.left = root.right;
// //     root.right = temp;

// //     InvertTree(root.left);
// //     InvertTree(root.right);

// //     return root;
// // }

// // int MaxDepth(TreeNode root)
// // {
// //     int maxDepth = 0;

// //     if (root == null) return 0;

// //     else
// //     {
// //         int left, right;

// //         left = MaxDepth(root.left);
// //         right = MaxDepth(root.right);
// //         maxDepth = 1 + Math.Max(left, right);
// //     }

// //     return maxDepth;
// // }

// // TreeNode p = new TreeNode(1,
// //     new TreeNode(2),
// //     new TreeNode(3)
// // );
// // TreeNode q = new TreeNode(1,
// //     new TreeNode(2),
// //     new TreeNode(3)
// // );


// // bool IsSameTree(TreeNode p, TreeNode q) {

// //     if ((p != null && q == null) || (p == null && q != null) || (p != q))
// //     {
// //         return false;
// //     }
// //     else
// //     {

// //         var left = IsSameTree(p.left, q.left);
// //         var right = IsSameTree(p.right, q.right);

// //         if (!left || !right)
// //         {
// //             return false;
// //         }

// //     }
// //     return true;

// // }

// // // Console.WriteLine(IsSameTree(p,q));
// // public class Solution {
// //     bool IsSameTree(TreeNode p, TreeNode q) {

// //     if(p == null && q ==null ){
// //         return true;
// //     }
// //     if ((p != null && q == null) || (p == null && q != null) || (p.val != q.val))
// //         {
// //             return false;
// //         }
// //     else
// //         {


// //             var True = true;
// //             var left = IsSameTree(p.left, q.left);
// //             var right = IsSameTree(p.right, q.right);

// //             if (!left || !right)
// //             {
// //                 return false;
// //             }

// //         }
// //     return true;
// //     }
// // }

// //  int DiameterOfBinaryTree(TreeNode root) {

// //     var diameter = 0; 

// //     int dfs(TreeNode curr){

// //         if(curr == null){
// //             return 0;
// //         }
// //         var left = dfs(curr.left);
// //         var right = dfs(curr.right);

// //         diameter = Math.Max(diameter, left + right);
// //         return 1 + Math.Max(left,right);

// //     }

// //     dfs(root);

// //     return diameter;

// //     //dfs traversal

// //     //calculate left height 
// //     //calculate right heith 
// // }


// // bool IsSubtree(TreeNode root, TreeNode subRoot)
// // {
// //     if (subRoot == null)
// //     {
// //         return true;
// //     }
// //     if (root == null)
// //     {
// //         return false;
// //     }
// //     if (sameTree(root, subRoot))
// //     {
// //         return true;
// //     }
// //     return IsSubtree(root.left, subRoot) ||
// //     IsSubtree(root.right, subRoot);
// // }
// // bool sameTree(TreeNode root1, TreeNode root2)
// // {
// //     if (root1 == root2)
// //     {
// //         return true;
// //     }
// //     if (root1 != null && root2 != null && root1.val == root2.val)
// //     {
// //         return sameTree(root1.left, root2.left) && sameTree(root1.right, root2.right);
// //     }

// //     return false;
// // }




// // public class TreeNode
// // {
// //     public int val;
// //     public TreeNode left;
// //     public TreeNode right;
// //     public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
// //     {
// //         this.val = val;
// //         this.left = left;
// //         this.right = right;
// //     }
// // }
// // int[][] matrix = [
// //  [1,2,3],
// //   [4,5,6],
// //   [7,8,9]
// // ];

// // public void Rotate(int[][] matrix) {


// // int l = 0;
// // int t = 0;
// // int b = matrix.GetLength(0) -1;
// // int r = matrix.GetLength(0) - 1;

// // while (l < r)
// // {
// //     var limit = r-l;
// //     for (int i = 0; i < limit; i++)
// //     {

// //         // save top left
// //         var temp = matrix[t][l+i];

// //         //move bottom left to top left
// //         matrix[t][l+i] = matrix[b - i][l];

// //         //bottom right to bottom left
// //         matrix[b-i][l] = matrix[b][r - i];

// //         // top right to bottom right
// //         matrix[b][r -i] = matrix[t + i][r];

// //         //temp to to top right 
// //         matrix[t+i][r] = temp;





// //     }
// //     l++;
// //     t++;
// //     b--;
// //     r--;

// // }

// // return; 
// // }


// // Rotate(matrix);





// // public class Solution {
// //     public void Rotate(int[][] matrix) {
// //         // Reverse the matrix vertically
// //         Array.Reverse(matrix);

// //         // Transpose the matrix
// //         for (int i = 0; i < matrix.Length; i++) {
// //             for (int j = i; j < matrix[i].Length; j++) {
// //                 (matrix[i][j], matrix[j][i]) = (matrix[j][i], matrix[i][j]);
// //             }
// //         }
// //     }
// // }



// // Console.WriteLine(!(!true));

// //  List<int> SpiralOrder(int[][] matrix) {

// // }
// // }


// // uint ReverseBits(uint n)
// // {
// //     uint result=0; 

// //     for(int i =0 ; i < n; i++){

// //         var extractedBit = ((n>>i)) & 1;
// //         if(extractedBit==1){
// //            result |= (1u<<(31-i));
// //         }

// //     }

// //     return result;

// // }

// // uint n = 6;
// // uint res = 0;

// // for (int i = 0; i < 32; i++) {
// //     uint bit = (n >> i) & 1;              // Extract bit at position i
// //     uint reversed = (bit << (31 - i));    // Place it in reversed position
// //     res += reversed;          

// //         // Convert result to 32-bit binary string
// //     string binaryString = Convert.ToString(res, 2).PadLeft(30, '0');

// //     Console.WriteLine("Result in bits: " + binaryString);           // Add it to the result
// // }


// // bool CanAttendMeetings(List<Interval> intervals)
// // {
// //     bool result = true;
// //     intervals.Sort((a, b) => a.start.CompareTo(b.start));
// //     for (int i = 0; i < intervals.Count - 1; i++)
// //     {
// //         if (intervals[i + 1].start < intervals[i].end)
// //         {
// //             return false; // Overlap found
// //         }
// //     }

// //     return true;


// // }

// // List<Interval> intervals = new List<Interval>
// // {
// //     new Interval(0, 30),
// //     new Interval(5, 10),
// //     new Interval(15, 20)
// // };


// // public class Interval
// // {
// //     public int start, end;
// //     public Interval(int start, int end)
// //     {
// //         this.start = start;
// //         this.end = end;
// //     }
// // }




// // int[] CountBits(int n) {

// //     int[] results = [n + 1];

// //     var  offset = 1 ; 
// //     for(int i = 1; i < n + 1 ; i++){
// //         offset = offset * 2 == i ? i : offset;
// //         results[i]= 1+ results[i-offset];
// //     }



// //     return results;
// // }



// // int n = 4;

// // var res = CountBits(n);

// // foreach(int num in res){
// //     Console.Write(num);
// // }

// //  int ClimbStairs(int n) {     
// //      var (one, two) = (1,1);
// //     for(int i =0; i < n-1 ; i++){
// //        var temp = one;
// //        one = one+two;
// //        two = temp;



// //     }
// // return one;
// // }


// string MinWindow(string s, string t)
// {

//     if (t == "") return "";

//     Dictionary<char, int> Tset = new Dictionary<char, int>();
//     Dictionary<char, int> window = new Dictionary<char, int>();

//     foreach (char c in t)
//     {
//         if (Tset.ContainsKey(c))
//         {
//             Tset[c]++;
//         }
//         else
//         {
//             Tset[c] = 1;
//         }
//     }

//     int have = 0, need = Tset.Count;
//     int[] results = { -1, -1 };
//     int resultLength = int.MaxValue;

//     int l = 0;
//     for (int r = 0; r < s.Length; r++)
//     {
//         char c = s[r];
//         if (window.ContainsKey(c))
//         {
//             window[c]++;
//         }
//         else
//         {
//             window[c] = 1;
//         }

//         if (Tset.ContainsKey(c) && window[c] == Tset[c])
//         {
//             have++;
//         }

//         while (have == need)
//         {
//             if ((r - l + 1) < resultLength)
//             {
//                 resultLength = r - l + 1;
//                 results[0] = l;
//                 results[1] = r;
//             }

//             // shrink window we take the character at the left pointer, then we 
//             // take one from the value of the dictionary at that key , and remove one from 
//             // the have variable which tells us how many of the required characters we have 
//             // and then we move the left pointer up . 
//             char leftChar = s[l];
//             window[leftChar]--;
//             if (Tset.ContainsKey(leftChar) && window[leftChar] < Tset[leftChar])
//             {
//                 have--;
//             }
//             l++;
//         }
//     }
//     //int max value is just a way of saying , i started with the maximum value an int variable could hold
//     // and if i didnt find a possible answer it will remain really large, standard safe way to find a minimum. 
//     return resultLength == int.MaxValue ? "" : s.Substring(results[0], resultLength);
// }

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design.Serialization;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Swift;
using System.Runtime.Intrinsics;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Transactions;

// int MissingNumber(int[] nums) {

//     int result = nums.Length;
//     for(int i =0 ; i < nums.Length; i++){
//         result += (i-nums[i]);

//     }
//     return result;



//     }

// int GetSum(int a, int b) {

// while(b !=0 ){
//     int carry = (a&b) <<1;
//     a = a^b;
//     b= carry;

// }
// return a;


// }



// void ReorderList(ListNode head) {
//     ListNode slow = head, fast = head.next;
//     //fast and slow

//     while(fast!=null && fast.next !=null){
//         slow= slow.next;
//         fast= fast.next.next;




//     }
//     var second = slow.next;
//     var prev = slow.next= null;
//     while (second != null){
//         var temp = second.next;
//         second.next = prev;
//         prev = second;
//         second = temp;
//     }

//     ListNode first=head;
//     second = prev;

//     while (second != null){
//         ListNode temp1 = first.next;
//         ListNode temp2 = second.next;
//         first.next = second;
//         second.next = temp1;
//         first = temp1;
//         second= temp2;
//     }




// }

// ListNode RemoveNthFromEnd(ListNode head, int n) {

// ListNode dummy = new ListNode(0);
// dummy.next= head;
// ListNode left =dummy;
// ListNode right = head;

// while (n > 0 && right != null){
//     right = right.next;
//     n = n-1;

// }
// while(right != null){
//     left = left.next;
//     right= right.next;
// }

// //delete the node 
// //it just jumps the node that we want to remove
// left.next = left.next.next;

// return dummy.next;



// }

// ListNode MergeKLists(ListNode[] lists)
// {
//     if (lists == null || lists.Length == 0) { return null; }

//     for (int i = 1; i < lists.Length; i++)
//     {
//         lists[i] = mergeList(lists[i], lists[i - 1]);
//     }
//     return lists[lists.Length - 1];
// }

// ListNode mergeList(ListNode l1, ListNode l2)
// {
//     ListNode dummy = new ListNode(0);
//     ListNode tail = dummy;
//     while (l1 != null && l2 != null)
//     {
//         if (l1.val < l2.val)
//         {
//             tail.next = l1;
//             l1 = l1.next;
//         }
//         else
//         {
//             tail.next = l2;
//             l2 = l2.next;
//         }
//     }
//     if (l1 != null)
//     {
//         tail.next = l1;
//     }
//     if (l2 != null)
//     {
//         tail.next = l2;
//     }
//     return dummy.next;
// }

// public class ListNode
// {
//     public int val;
//     public ListNode next;
//     public ListNode(int val = 0, ListNode next = null)
//     {
//         this.val = val;
//         this.next = next;
//     }
// }


// string LongestPalindrome(string s)
// {
//     int resultLength = 0;
//     string results = "";

//     for (int i = 0; i < s.Length; i++)
//     {
//         //odd length
//         int l = i, r = i;
//         while (l >= 0 && r < s.Length && s[l] == s[r])
//         {
//             if (r - l + 1 > resultLength)
//             {
//                 results = s[l..(r + 1)];
//                 resultLength = r - l + 1;
//             }
//             l--;
//             r++;
//         }
//         l = i;
//         r = i + 1;
//         while (l >= 0 && r < s.Length && s[l] == s[r])
//         {
//             if (r - l + 1 > resultLength)
//             {
//                 results = s[l..(r + 1)];
//                 resultLength = r - l + 1;

//             }
//             l--;
//             r++;
//         }

//     }
//     return results;

// }




// bool IsValidBST(TreeNode root)
// {

//     bool valid(TreeNode node, int left, int right)
//     {
//         if (node == null)
//         {
//             return true;
//         }
//         if (!(node.val < right && left < node.val))
//         {
//             return true;
//         }

//         return valid(node.left, left, node.val) &&
//         valid(node.right, node.val, right);



//     }



//     return valid(root,int.MinValue, int.MaxValue);

// }

// int KthSmallest(TreeNode root, int k)
// {

//     int count = 0;
//     Stack<TreeNode> stack = new Stack<TreeNode>();
//     stack.Push(root);
//     TreeNode curr = root;
//     while (stack.Count > 0 && curr != null)
//     {
//         while (curr != null)
//         {
//             stack.Push(curr);
//             curr = curr.left;
//         }
//         stack.Pop();
//         count++;
//         if (count == k)
//         {
//             return curr.val;
//         }
//         curr = curr.right;

//     }

    

// TreeNode BuildTree(int[] preorder, int[] inorder)
// {
//     if (preorder == null || inorder == null || preorder.Length == 0 || inorder.Length == 0)
//     {
//         return null;
//     }
//     TreeNode root = new TreeNode(preorder[0]);
//     var mid = Array.IndexOf(inorder,preorder[0]);
//     root.left = BuildTree(preorder[1..(mid + 1)], inorder[0..mid]);
//     root.right = BuildTree(preorder[(mid + 1)..], inorder[(mid + 1)..]);

//     return root;
// }


// class TreeNode
// {
//     public int val; public TreeNode left;
//     public TreeNode right;
//     public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
//     {
//         this.val = val; this.left = left;
//         this.right = right;
//     }
// }


// int Search(int[] nums, int target)
// {
//     int l = 0, r = nums.Length - 1;

//     while (l < r)
//     {
//         int middle = (l + r) / 2;
//         if (target == nums[middle])
//         {
//             return middle;
//         }

//         //left sorted 
//         if (nums[l] <= nums[middle])
//         {
//             if (target > nums[middle])
//             {
//                 l = middle + 1;
//             }
//             else
//             {
//                 r = middle - 1;
//             }

//         }
//         else
//         {
//             if (target < nums[middle] || target > nums[r])
//             {
//                 r = middle - 1;
//             }
//             else
//             {
//                 l = middle + 1;
//             }
//         }
//     }
//     return -1;

// }