using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKPractise
{
    class Recursion
    {

        public List<string> PrintAllStrings(int n)
        {
            List<string> res = new List<string>();
            res= DHelper(res,"123", "", 3);
            foreach(string s in res)
            {
                Console.WriteLine(s);
            }
            return res;
        }

        public List<string> BHelper(List<string> res, string slate, int n)
        {
            if (n == 0)
            {
                res.Add(slate);
            }
            else
            {
                BHelper(res, slate + "0", n - 1);
                BHelper(res, slate + "1", n - 1);
            }
            return res;
        }

        public List<string> DHelper(List<string> res , string s, string permute, int n)
        {
            if (n == 0)
            {
                res.Add(permute);
            }
            else
            {
                for (int i = 0; i < s.Length; i++)
                {
                    string p = s.Substring(0, i) + s.Substring(i + 1, s.Length - i - 1);
                    DHelper(res, p, permute+s[i], n - 1);

                }
            }
            return res;
        }
       
        public List<List<int>> find_Combination(int n, int k)
        {
            List<List<int>> op = new List<List<int>>();

            helper(op, n, k, new List<int>(), 1);

            return op;

        }

        public void helper(List<List<int>> op, int n, int k, List<int> slate, int idx)
        {
            if (slate.Count == k)
            {
                Console.WriteLine(String.Join(",", slate.ToArray()));
                op.Add(new List<int>(slate));
                //foreach(int i in slate)
                //{
                //    Console.Write(i);
                //}
                //Console.WriteLine();
                return;
            }
            if (idx == n + 1)
            {
                return;
            }
            else
            {
                helper(op, n, k, slate, idx + 1);
                slate.Add(idx);
                helper(op, n, k, slate, idx + 1);
                slate.RemoveAt(slate.Count - 1);
            }
        }

        public void stringpermutes(string s)
        {
            for (int i = 0; i < s.Length; i++)
            {
                string permute = s.Substring(0, i) + s.Substring(i + 1, s.Length - i - 1);
                Console.WriteLine(permute);
            }

        }

        public void Generate_Subsets(string s)
        {
            int level = s.Length;
            List<string> subsets = new List<string>();
            Subset_helper(subsets,s,0,"", level);
            Console.WriteLine(subsets.Count);
        }

        public List<string> Subset_helper(List<string> Subsets, string s, int pos, string psol, int level)
        {
            if (level == 0)
            {
                Subsets.Add(psol);
                Console.WriteLine(psol);
            }
            else
            {
                    Subset_helper(Subsets,s,pos+1, psol + s[pos], level - 1);
                    Subset_helper(Subsets,s,pos+1, psol, level - 1);
                
            }
            return Subsets;
        }

        public List<string> generate_palindromic_decompositions(string s)
        {
            List<string> res = new List<string>();
            Palindromic_helper(res, s, 0, "", s.Length);
            return res;           
        }

        public void Palindromic_helper(List<string> Palindromic_decomposition, string s, int pos, string curr_decomposition, int n)
        {
            if (pos == n)
            {
                Palindromic_decomposition.Add(curr_decomposition);
                Console.WriteLine(curr_decomposition);
                return;
            }

            else
            {
                for(int i = pos; i < n; i++)
                {
                    if(IsPalindrome(s.Substring(pos, i - pos + 1)))
                    {
                        if (pos == 0)
                        {
                            Palindromic_helper(Palindromic_decomposition, s, i + 1, s.Substring(pos, i - pos + 1),n);
                        }
                        else
                        {
                            Palindromic_helper(Palindromic_decomposition, s, i + 1, curr_decomposition + "|" + s.Substring(pos, i - pos + 1), n);
                        }

                    }

                }
            }
        }

        public bool IsPalindrome(string s)
        {
            int len = s.Length;
            for(int i = 0; i < (len)/2; i++)
            {
                if (s[i] != s[len - 1 - i])
                    return false;
            }
            return true;
        }

        public void seeRecursion(string s, int pos, string PS, int len)
        {
            if (len == 0)
            {
                Console.WriteLine(PS);

                return;
            }
            
            seeRecursion(s, pos + 1, PS + s[pos], len - 1);           
            
        }

       

    }
}
