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

    }
}