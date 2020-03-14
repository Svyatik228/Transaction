using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;

namespace ConsoleApp2
{

    class Account
    {
        public int Id { get; private set; } 
        public int Sum { get; set; }
        public Account(int _id)
        {
            Id = _id;
        }
    }
    class Transaction<T> where T : Account
    {
        public T FromAccount { get; set; }  
        public T ToAccount { get; set; }    
        public int Sum { get; set; }        

        public void Execute()
        {
            if (FromAccount.Sum > Sum)
            {
                FromAccount.Sum -= Sum;
                ToAccount.Sum += Sum;
                Console.WriteLine($"Рахунок {FromAccount.Id}: {FromAccount.Sum}$ \nРахунок {ToAccount.Id}: {ToAccount.Sum}$");
            }
            else
            {
                Console.WriteLine($"Недостатньо грошей на рахуноку {FromAccount.Id}");
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Account a = new Account(23);
            Account b = new Account(25);
            a.Sum = 4500;
            b.Sum = 2300;
            
            Transaction<Account> c = new Transaction<Account>();
            c.FromAccount = a;
            c.ToAccount = b;
            c.Sum = 1000;
            c.Execute();
       
        }
    }
}


