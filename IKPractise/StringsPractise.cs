using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKPractise
{
   public class StringsPractise
    {
        public int get_longest_substring_length_with_exactly_two_distinct_chars(string s)
        {
            // Write your code here.
            int max_len = 0;
            int left = 0;
            int right = 0;
            int len = s.Length;
            Dictionary<char, int> countmap = new Dictionary<char, int>();
            while (right < len)
            {
                if (!countmap.ContainsKey(s[right]))
                    countmap.Add(s[right], 1);
                else
                    countmap[s[right]] += 1;

                while (countmap.Keys.Count > 2)
                {
                    if(countmap.ContainsKey(s[left])) countmap[s[left]] -= 1;
                    if(countmap[s[left]]==0)
                        countmap.Remove(s[left]);
                    left++;
                }
                if (countmap.Keys.Count == 2)
                {
                    max_len = Math.Max(max_len, right - left + 1);
                    
                }
                right++;
            }
            return max_len;
        }

    }
}
