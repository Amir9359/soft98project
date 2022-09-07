using System;
using System.Reflection.PortableExecutable;

namespace soft98.Core.Infrastructure
{
    public class CodeGenrators
    {
        public static string ActiveCode()
        {
            return Guid.NewGuid().ToString().Replace("-", "").Substring(0, 6);
        }
        public static string ProductCode()
        {
            return Guid.NewGuid().ToString().Replace("-", "").Substring(0, 6);
        }

        public static string OrderCode()
        {
            var rand = new Random();
            string stCode = rand.Next(11000000, 99999999).ToString();
            return stCode;
        }
    }
}