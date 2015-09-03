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
        public static List<int> GetPhaseIds(string ids)
        {
            string[] arrIds = ids.Split(',');
            List<int> phaseIds = new List<int>();
            foreach (var id in arrIds)
            {
                int phaseId = 0;
                bool parsed = int.TryParse(id, out phaseId);
                if (parsed) phaseIds.Add(phaseId);
            }
            return phaseIds;            
        }
        public static List<int> GetPhaseIds(string[] ids)
        {
            List<int> phaseIds = new List<int>();
            if (ids != null)
            {
                foreach (var id in ids)
                {
                    int phaseId = 0;
                    bool parsed = int.TryParse(id, out phaseId);
                    if (parsed) phaseIds.Add(phaseId);
                }
            }
            return phaseIds;
        }
    }
}