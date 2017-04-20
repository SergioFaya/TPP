using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace deadlock
{
    class Program
    {
        private static void Transfer(Account accountA, Account accountB, decimal amount)
        {
            Console.WriteLine("Transferring {0:N} euros from account {1} to account {2}...",
                amount, accountA.AccountNumber, accountB.AccountNumber);
            if (accountA.Transfer(accountB, amount))
                Console.WriteLine("\tSuccessful transaction, thread {0}.", Thread.CurrentThread.Name);
            else
                Console.WriteLine("\tWrong transaction, thread {0}.", Thread.CurrentThread.Name);
        }
        
        public static void Main()
        {
            // Fix this deadlock situation

            decimal initialAmount = 30000;

            decimal expectedBalanceA = 30000;
            decimal expectedBalanceB = 30000;


            Account accountA = new Account("A", initialAmount), accountB = new Account("B", initialAmount);

            Random random = new Random();
            int iterations = 1000;
            Thread[] threads = new Thread[iterations];
            for (int i = 0; i < iterations; i++)
            {
                decimal amount = (decimal)random.NextDouble() * random.Next(1, 600);
                if (i % 2 == 0)
                {
                    threads[i] = new Thread(() => Transfer(accountA, accountB, amount));

                    expectedBalanceA -= amount;
                    expectedBalanceB += amount;
                }
                else
                {
                    threads[i] = new Thread(() => Transfer(accountB, accountA, amount));

                    expectedBalanceA += amount;
                    expectedBalanceB -= amount;
                }
                threads[i].Name = "Transfer number " + i;
            }

            foreach (Thread thread in threads)
                thread.Start();


            foreach (Thread thread in threads)
                thread.Join();



            Console.WriteLine("accountA.Balance: " + accountA.Balance + "\texpectedBalanceA: " + expectedBalanceA);
            Console.WriteLine("accountB.Balance: " + accountB.Balance + "\texpectedBalanceB: " + expectedBalanceB);



            Console.ReadLine();
        }


    }
}
