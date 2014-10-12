using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowledgeBox
{
    public class Helper
    {
        public static Guid GetNewGuid()
        {
            Guid guid = Guid.NewGuid();

            return guid;
        }
        public static Guid GetNewGuid(string guidId)
        {
            Guid guid = new Guid(guidId);
            return guid;
        }
    }
}