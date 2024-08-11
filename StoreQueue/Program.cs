using System;
using System.Collections.Generic;

namespace StoreQueue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> buyers = AddCustomersWallet();

            ServeBuyers(buyers);
        }

        static Queue<int> AddCustomersWallet()
        {
            Queue<int> buyers = new Queue<int>();
            Random random = new Random();
            int maxQueueSize = 13;
            int maxBuyersWallet = 10000;
            int minBuyersWallet = 400;
            int randomQueueSize = random.Next(maxQueueSize);

            for (int i = 0; i < randomQueueSize; i++)
            {
                buyers.Enqueue(random.Next(minBuyersWallet, maxBuyersWallet));
            }
            return buyers;
        }

        static void ServeBuyers(Queue<int> buyers)
        {
            int shopMoney = 0;

            bool isWork = true;

            while (isWork)
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

                isWork = buyersInQueue > 0;
            }
        }
    }
}
