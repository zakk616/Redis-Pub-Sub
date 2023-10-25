using StackExchange.Redis;
using System;

namespace Redis_Sub2
{
    class Program
    {
        static void Main(string[] args)
        {
            ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("localhost"); // Redis server connection
            var redisChannel = redis.GetSubscriber();

            // Subscribe to messages of type sub2
            redisChannel.Subscribe("sub2", (channel, message) =>
            {
                Console.WriteLine($"Subscriber 2 received: {message}");
            });

            Console.WriteLine("Subscriber 2 started. Press Enter to exit.");
            Console.ReadLine();
            Console.Read();
            // Close the connection
            //redis.Close();
        }
    }
}


