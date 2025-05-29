public class Interval
{
    public int Start { get; set; }
    public int End { get; set; }

    public Interval(int start, int end)
    {
        Start = start;
        End = end;
    }
}

public class Intervals
{
    public int[][] Insert(int[][] intervals, int[] newInterval)
    {
        var result = new List<int[]>();

        for (int i = 0; i < intervals.Length; i++)
        {
            // Case 1: New interval comes completely before the current interval (no overlap)
            if (newInterval[1] < intervals[i][0])
            {
                // Insert newInterval before current and add the rest unchanged
                result.Add(newInterval);
                result.AddRange(intervals.Skip(i));
                return result.ToArray();
            }
            // Case 2: New interval comes completely after the current interval (no overlap)
            else if (newInterval[0] > intervals[i][1])
            {
                result.Add(intervals[i]);
            }
            // Case 3: Overlapping intervals — merge them
            else
            {
                newInterval[0] = Math.Min(intervals[i][0], newInterval[0]);
                newInterval[1] = Math.Max(intervals[i][1], newInterval[1]);
            }
        }

        // Add the last merged newInterval if not already added
        result.Add(newInterval);
        return result.ToArray();
    }

    public int[][] Merge(int[][] intervals)
    {
        //given an array of intervals where intervals[i] = [starti, endi] merge all
        //overalping intervals, and return an array of the non-overlapping intervals 
        //that cover all of the intervals in the input 
        Array.Sort(intervals, (a, b) => a[0].CompareTo(b[0]));

        // Initializes a list to hold the merged intervals
        List<int[]> result = new List<int[]>();

        // Start by adding the first interval to the result list
        result.Add(intervals[0]);

        // Iterate through each interval
        foreach (int[] interval in intervals)
        {
            // Extract the start and end of the current interval
            int start = interval[0];
            int end = interval[1];

            // Get the end of the last interval in the result list
            int lastEnd = result[result.Count - 1][1];

            // If the current interval overlaps with the last one in the result
            if (start <= lastEnd)
            {
                // Merge them by extending the last interval's end to the max of both ends
                result[result.Count - 1][1] = Math.Max(lastEnd, end);
            }
            else
            {
                // If there's no overlap, add the current interval as a new entry
                result.Add(new int[] { start, end });
            }
        }

        // Return the merged list of intervals as an array
        return result.ToArray();
    }

    public int EraseOverlapIntervals(int[][] intervals)
    {
        //return the minimum number of intervals that you have to remove to
        //avoid overlapping intervals

        int result = 0;
        Array.Sort(intervals, (a, b) => a[0].CompareTo(b[0]));
        int prevEnd = intervals[0][1];
        
        for (int i = 1; i < intervals.Length; i++)
        {
            int start = intervals[i][0];
            int end = intervals[i][1];
            if (start >= prevEnd)
            {
                prevEnd = end;
            }
            else
            {
                result++;
                prevEnd = Math.Min(end, prevEnd);
            }
        }
        return result;
    }

    public int MinMeetingRooms(List<Interval> intervals)
    {
        if (intervals == null || intervals.Count == 0)
            return 0;

        int result = 0;
        int count = 0;
        int[] startTimes = new int[intervals.Count];
        int[] endTimes = new int[intervals.Count];

        // Sort intervals by start time
        intervals.Sort((a, b) => a.Start.CompareTo(b.Start));

        // Populate start and end times
        for (int i = 0; i < intervals.Count; i++)
        {
            startTimes[i] = intervals[i].Start;
            endTimes[i] = intervals[i].End;
        }

        // Sort end times
        Array.Sort(endTimes);

        int l = 0, r = 0;

        while (l < intervals.Count)
        {
            // If current start is before current end, need a new room
            if (startTimes[l] < endTimes[r])
            {
                count++;
                l++;
            }
            else // Reuse a room, move to next end time
            {
                r++;
                count--;
            }
            result = Math.Max(result, count);
        }

        return result;
    }
}
