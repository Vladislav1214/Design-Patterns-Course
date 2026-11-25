using System.Collections.Generic;
using System.Linq;

namespace Cm_5_Lb_3
{
    public class CallLog
    {
        private readonly List<string> _entries = new();

        public void Add(string message) => _entries.Add(message);

        public List<string> Flush()
        {
            var result = _entries.ToList();
            _entries.Clear();
            return result;
        }
    }
}