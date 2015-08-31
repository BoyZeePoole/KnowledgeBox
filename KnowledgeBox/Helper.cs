using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowledgeBox
{
    public class Helper
    {
        public static Guid GetNewGuid(string guidId = "")
        {
            if (string.IsNullOrEmpty(guidId))
            {
                Guid guid = Guid.NewGuid();
                return guid;
            }
            else
            {
                Guid guid = new Guid(guidId);
                return guid;
            }
        }
    }
}