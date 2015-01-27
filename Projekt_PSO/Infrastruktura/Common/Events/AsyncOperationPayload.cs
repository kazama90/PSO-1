using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastruktura.Events.Payloads
{
    public class AsyncOperationPayload
    {
        public AsyncOperationState OperationState { get; set; }
    }

    public enum AsyncOperationState
    {
        Started,
        Stopped
    }
}
