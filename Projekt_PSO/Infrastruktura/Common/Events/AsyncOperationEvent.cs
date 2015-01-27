using Infrastruktura.Events.Payloads;
using Microsoft.Practices.Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastruktura.Events
{
    public class AsyncOperationEvent : CompositePresentationEvent<AsyncOperationPayload>
    {
    }
}
