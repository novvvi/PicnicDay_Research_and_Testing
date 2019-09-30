using System;
using System.Linq;
//dotnet add package System.Runtime.Caching --version 4.5.0
using System.Runtime.Caching;
using System.Threading;

namespace caching
{
    class Program
    {

        static void Main(string[] args)
        {
            bool loop = true;

            while(loop)
            {
                Random r = new Random();
                string user = RdnUser();
                string text = RdnText();
                int time = r.Next(15) * 100;
                Console.WriteLine($"sleep time: {time}\n User: {user} \n text: {text}");
                Thread.Sleep(time);

                Caching(user, text);
                
                
            }

            

        }

        static void Caching(string user, string text)
        {
            ObjectCache cache = MemoryCache.Default;  
            string fileContents = cache[user] as string;  

            
            CacheItemPolicy policy = new CacheItemPolicy();  
            policy.AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(60.0);


            cache.Set(user, text, policy);  

            cache.ToList().ForEach(i => Console.WriteLine(i));
            
            string value = cache.Get(user).ToString();

            Console.WriteLine("******" + value + "*******");
        }

        static string RdnText()
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            string randText = new string(Enumerable.Repeat(chars, 5).Select(s => s[random.Next(s.Length)]).ToArray());
            return randText;
        }

        static string RdnUser()
        {
            Random random = new Random();
            string[] users = new string[4]
            {
                "tom",
                "ann",
                "alex",
                "peter"
            };
            int rdnIdx = random.Next(users.Length);
            return users[rdnIdx];
        }
    }
}
