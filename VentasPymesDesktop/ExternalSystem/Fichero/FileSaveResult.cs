using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExternalSystem.Fichero
{
    public enum FileSaveResult
    {
        CREATED,
        OVERRIDED,
        ERROR = 0,
        SKIP,
        CANCEL
    }
}
