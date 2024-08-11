using System;
using System.Collections.Generic;

namespace StoreQueue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> buyers = AddCustomersBill();

            PayCustomer(buyers);
        }

        static Queue<int> AddCustomersBill()
        {
            Queue<int> buyers = new Queue<int>();
            Random random = new Random();
            int maxQueueSize = 13;
            int maxBuyersBill = 10000;
            int minBuyersBill = 400;
            int randomQueueSize = random.Next(maxQueueSize);

            for (int i = 0; i < randomQueueSize; i++)
            {
                buyers.Enqueue(random.Next(minBuyersBill, maxBuyersBill));
            }
            return buyers;
        }

        static void PayCustomer(Queue<int> buyers)
        {
            int shopMoney = 0;

            bool isBuyersExist = true;

            while (isBuyersExist)
            {
                int wallet = buyers.Dequeue();
                int buyersInQueue = buyers.Count;

                Console.WriteLine($"Денег в кассе: {shopMoney}");                                    
                Console.WriteLine($"У кассы находиться покупатель с суммой покупок {wallet}");
                Console.WriteLine($"Всего в очереди: {buyersInQueue}");
                Console.WriteLine("Чтобы обслужить клиента нажмите на любую клавишу.");

                Console.ReadKey();

                shopMoney += wallet;

                Console.Clear();

                isBuyersExist = buyersInQueue > 0;
            }
        }
    }
}
