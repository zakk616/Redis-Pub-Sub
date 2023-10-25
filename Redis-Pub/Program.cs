using StackExchange.Redis;
using System;
using System.Threading;

namespace Redis_Pub
{
    class Program
    {
        static void Main(string[] args)
        {
            ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("localhost"); // Redis server connection

            // Publish messages of different types to different channels
            string message = "Message is: ", sub1 = "sub1", sub2 = "sub2";

            var redisChannel = redis.GetSubscriber();
            for (int i = 1; i <= 100; i++)
            {
                Thread.Sleep(100);
                if (i % 2 == 0)
                {
                    redisChannel.Publish(sub1, "[" + message + i + "]");
                }
                else
                {
                    redisChannel.Publish(sub2, "[" + message + i + "]");
                }
                Console.WriteLine("Published: [" + message + i + "]");
            }

            Console.Read();
            //redis.Close();
        }
    }
}



