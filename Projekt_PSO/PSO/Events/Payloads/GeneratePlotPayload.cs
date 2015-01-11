using OxyPlot;
using OxyPlot.Series;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSO.Events.Payloads
{
    public class GeneratePlotPayload
    {
        public string Title { get; set; }
        public List<LineSeries> LineSeries { get; set; }
    }
}
