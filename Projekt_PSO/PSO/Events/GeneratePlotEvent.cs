using Microsoft.Practices.Prism.Events;
using PSO.Events.Payloads;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSO.Events
{
    public class GeneratePlotEvent : CompositePresentationEvent<GeneratePlotPayload>
    {
    }
}
