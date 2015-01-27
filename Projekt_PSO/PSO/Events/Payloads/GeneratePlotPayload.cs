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
        /// <summary>
        /// Title of the plot
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Collection of series of points
        /// </summary>
        public List<LineSeries> LineSeries { get; set; }
        /// <summary>
        /// Set to true to add points to the plot; set to false to generate a new plot
        /// </summary>
        public bool AddPoints { get; set; }
    }
}
