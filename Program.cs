using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Assignment_1___Programming_Introduction

{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 5;
            PrintTriangle(n);

            int n2 = 5;
            PrintSeriesSum(n2);

            int[] A = new int[] { 1, 2, 2, 6 }; 
            bool check = MonotonicCheck(A);
            Console.WriteLine(check);
            Console.ReadKey();

            int[] nums = new int[] { 3, 1, 4, 1, 5 };
            int k = 2;
            int pairs = DiffPairs(nums, k);
            Console.WriteLine(pairs);
            Console.ReadKey();


            string keyboard = "abcdefghijklmnopqrstuvwxyz";
            string word = "dis";
            int time = BullsKeyboard(keyboard, word);
            Console.WriteLine(time);
            Console.ReadKey();


            string str1 = "goulls";
            string str2 = "gobulls";
            int minEdits = StringEdit(str1, str2);
            Console.WriteLine(minEdits);
            Console.ReadKey();
        }
       

        public static void PrintTriangle(int x)
        {
            try
            {
                for (int i = 1; i <= x; i++)
                {
                    for (int j = 0; j < x - i; j++)
                    {
                        Console.Write(" ");
                    }
                    for (int j = 0; j < 2 * i - 1; j++)
                    {
                        Console.Write("*");
                    }

                    Console.WriteLine();
                }
                Console.ReadKey();


            }
            catch
            {
                Console.WriteLine("Exception occured while computing PrintTriangle()");
            }
        }
      

        public static void PrintSeriesSum(int n)
        {
            try
            {
                int i, sum = 0;

                Console.Write("\nThe odd numbers are :");
                for (i = 1; i <= n; i++)
                {
                    Console.Write("{0} ", 2 * i - 1);
                    sum += 2 * i - 1;
                }
                Console.Write("\nThe Sum of odd number is : " + sum);
                Console.ReadLine();
                Console.ReadKey();
            }

            catch
            {
                Console.WriteLine("Exception occured while computing PrintSeriesSum()");
            }
        }

       

        public static bool MonotonicCheck(int[] A)
        {
            try
            {
                if (A[0] <= A[A.Length - 1])
                {
                    for (int i = 1; i < A.Length; i++)
                    {
                        if (A[i - 1] > A[i])
                        {
                            return false;
                        }
                    }
                }
                else
                {
                    for (int i = 1; i < A.Length; i++)
                    {
                        if (A[i - 1] < A[i])
                        {
                            return false;
                        }
                    }
                }
                return true;
                
            }
            catch
            {
                Console.WriteLine("Exception occured while computing MonotonicCheck()");
                
            }

            return false;
            
        }

        public static int DiffPairs(int[] J, int k)
        {
            try
            {
                if (k < 0)
                {
                    return 0;
                }

                var processed = new Dictionary<int, int>();
                for (int i = 0; i < J.Length; i++)
                {
                    var count = 0;
                    processed.TryGetValue(J[i], out count);
                    processed[J[i]] = count + 1;
                }

                var pairs = new HashSet<int>();
                for (int i = 0; i < J.Length; i++)
                {
                    var key = k + J[i];

                    if ((k == 0 && processed[key] > 1) || (k > 0 && processed.ContainsKey(key)))
                    {
                        pairs.Add(key);
                    }
                }

                return pairs.Count;



            }
            catch
            {
                Console.WriteLine("Exception occured while computing DiffPairs()");
                
            }

            return 0;
        }






        public static int BullsKeyboard(string keyboard, string word)
        {
            try
            {

                int count = 0;
                char[] chars = word.ToCharArray();
                int index = 0;
                foreach (char i in chars)
                {
                    count += Math.Abs(keyboard.IndexOf(i) - index);
                    index = keyboard.IndexOf(i);


                }

                return count;


            }
            catch
            {
                Console.WriteLine("Exception occured while computing BullsKeyboard()");
            }

            return 0;
        }

        public static int StringEdit(string str1, string str2)
        {
            try
            {
                int a = str1.Length;
                int b = str2.Length;

                if (a * b == 0)
                {
                    return a + b;
                }

                int[,] dp = new int[a + 1, b + 1];
                
                for (int i = 0; i <= b; i++)
                {
                    dp[0, i] = i;
                }
                
                for (int i = 0; i <= a; i++)
                {
                    dp[i, 0] = i;
                }

                for (int i = 1; i <= a; i++)
                {
                    for (int j = 1; j <= b; j++)
                    {

                        int left = dp[i, j - 1] + 1;

                        int right = dp[i - 1, j] + 1;

                        int edit = dp[i - 1, j - 1];
                        if (str1[i - 1] != str2[j - 1])
                        {
                            edit++;
                        }
                        dp[i, j] = Math.Min(left, Math.Min(right, edit));
                    }
                }
                return dp[a, b];

            }
            catch
            {
                Console.WriteLine("Exception occured while computing StringEdit()");
            }

            return 0;
        }
    }

}

