using System;
using System.Collections.Generic;
using System.Text;

namespace PruebaTecnica.Utils
{
    public class Utils
    {
        public static string GetNewId()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
