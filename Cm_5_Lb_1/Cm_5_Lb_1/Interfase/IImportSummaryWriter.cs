using Cm_5_Lb_1.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cm_5_Lb_1.Interfase
{
    public interface IImportSummaryWriter
    {
        void WriteSummary(ImportResult result);
    }
}
