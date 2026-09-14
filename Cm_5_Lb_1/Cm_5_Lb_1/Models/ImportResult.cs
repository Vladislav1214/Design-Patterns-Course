using System;
using System.Collections.Generic;
using System.Text;

namespace Cm_5_Lb_1.Models
{
    public class ImportResult
    {
        public bool IsSuccess { get; set; }
        public string ErrorMessage { get; set; }
        public int ProcessedCount { get; set; }
    }
}
