using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace PrimeNumbersAgain
{
    class Program
    {
        //was confused on a lot of this so I did lots of research and found out the "SieveofEratosthenes" method
        private static List<int> primes = new List<int>();
        static void Main(string[] args)
        {
            int n, prime;
            Stopwatch timer = new Stopwatch();

            PrintBanner();
            n = GetNumber();

            timer.Start();
            prime = FindNthPrime(n);
            timer.Stop();
            
            
            Console.WriteLine($"\nToo easy.. {prime} is the nth prime when n is {n}. I found that answer in {timer.Elapsed.Seconds} seconds.");

            EvaluatePassingTime(timer.Elapsed.Seconds);
        }

        static int FindNthPrime(int n)
        {

            int limit = EstimateLimit(n);

            SieveOfEratosthenes(limit);

            return primes[n - 1];
        }
        static int EstimateLimit(int n)
        {
            //this is a base case for small values
            if (n < 6)
            {
                return 15;

            }
            double approx = n * (Math.Log(n) + Math.Log(Math.Log(n)));
            return (int)Math.Ceiling(approx);
        }

        //implemented this method that I found online
        static void SieveOfEratosthenes(int limit)
        {
            bool[] isPrime = new bool[limit + 1];
            for (int i = 2; i <= limit; i++)
            {
                isPrime[i] = true;
            }
               
            for (int i = 2; i * i <= limit; i++)
            {
                if (isPrime[i])
                {
                    for (int j = i * i; j <= limit; j += i)
                    {
                        isPrime[j] = false;
                    }
                }
            }
            primes.Clear();
            for (int i = 2; i <= limit; i++)
            {
                if (isPrime[i]) primes.Add(i);
            }
        }
        static bool IsPrime(int n)
        {
            for (int i = 3; i < n; i++)
            {
                if (IsSkippable(i))
                {
                    continue;
                }

                if (n % i == 0)
                {
                    return false;
                }
            }

            return true;
        }
        static bool IsSkippable(int n)
        {
            if (n % 2 == 0 || n % n == 0)
            {
                return true;
            }

            return false;
        }
        

        
        static int GetNumber()
        {
            int n = 0;
            while (true)
            {
                Console.Write("Which nth prime should I find?: ");
                
                string num = Console.ReadLine();
                if (Int32.TryParse(num, out n))
                {
                    return n;
                }

                Console.WriteLine($"{num} is not a valid number.  Please try again.\n");
            }
        }

        static void PrintBanner()
        {
            Console.WriteLine(".................................................");
            Console.WriteLine(".#####...#####...######..##...##..######...####..");
            Console.WriteLine(".##..##..##..##....##....###.###..##......##.....");
            Console.WriteLine(".#####...#####.....##....##.#.##..####.....####..");
            Console.WriteLine(".##......##..##....##....##...##..##..........##.");
            Console.WriteLine(".##......##..##..######..##...##..######...####..");
            Console.WriteLine(".................................................\n\n");
            Console.WriteLine("Nth Prime Solver O-Matic Online..\nGuaranteed to find primes up to 2 million in under 30 seconds!\n\n");
            
        }

        static void EvaluatePassingTime(int time)
        {
            Console.WriteLine("\n");
            Console.Write("Time Check: ");

            if (time <= 10)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Pass");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Fail");
            }

            Console.ForegroundColor = ConsoleColor.Gray;
            
        }
    }
}
