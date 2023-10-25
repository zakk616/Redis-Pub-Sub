using StackExchange.Redis;
using System;

namespace Redis_Sub1
{
    class Program
    {
        static void Main(string[] args)
        {
            ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("localhost"); // Redis server connection
            var redisChannel = redis.GetSubscriber();

            // Subscribe to messages of type sub1
            redisChannel.Subscribe("sub1", (channel, message) =>
            {
                Console.WriteLine($"Subscriber 1 received: {message}");
            });

            Console.WriteLine("Subscriber 1 started. Press Enter to exit.");
            Console.ReadLine();
            Console.Read();
            // Close the connection
            //redis.Close();
        }
    }
}


