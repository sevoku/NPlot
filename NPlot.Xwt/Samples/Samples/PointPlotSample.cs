using System;
using System.IO;
using System.Reflection;

using Xwt;
using Xwt.Drawing;

using NPlot;

namespace Samples
{
	public class PointPlotSample : PlotSample
	{
		public PointPlotSample () : base ()
		{
			infoText = "";
			infoText += "Sinc Function Example. Demonstrates - \n";
			infoText += " * Charting LinePlot and PointPlot at the same time. \n";
			infoText += " * Adding a legend.";

			plotCanvas.Clear(); // clear everything. reset fonts. remove plot components etc.

			System.Random r = new Random();
			double[] a = new double[100];
			double[] b = new double[100];
			double mult = 0.00001f;
			for (int i=0; i<100; ++i) {
				a[i] = ((double)r.Next(1000)/5000.0f-0.1f)*mult;
				if (i == 50) {
					b[i] = 1.0f*mult;
				} 
				else {
					b[i] = Math.Sin ((((double)i-50.0)/4.0))/(((double)i-50.0)/4.0);
					b[i] *= mult;
				}
				a[i] += b[i];
			}
		
			Marker m = new Marker (Marker.MarkerType.Cross1, 6, Colors.Blue);
			PointPlot pp = new PointPlot (m);
			pp.OrdinateData = a;
			pp.AbscissaData = new StartStep (-500.0, 10.0);
			pp.Label = "Random";
			plotCanvas.Add (pp); 

			LinePlot lp = new LinePlot ();
			lp.OrdinateData = b;
			lp.AbscissaData = new StartStep( -500.0, 10.0 );
			lp.LineColor = Colors.Red;
			lp.LineWidth = 2;
			plotCanvas.Add (lp);

			plotCanvas.Title = "Sinc Function";
			plotCanvas.YAxis1.Label = "Magnitude";
			plotCanvas.XAxis1.Label = "Position";

			Legend legend = new Legend();
			legend.AttachTo (XAxisPosition.Top, YAxisPosition.Left);
			legend.VerticalEdgePlacement = Legend.Placement.Inside;
			legend.HorizontalEdgePlacement = Legend.Placement.Inside;
			legend.YOffset = 8;

			plotCanvas.Legend = legend;
			plotCanvas.LegendZOrder = 1; // default zorder for adding idrawables is 0, so this puts legend on top.

			PackStart (plotCanvas.Canvas, true);
			Label la = new Label (infoText);
			PackStart (la);
		}
	}
}

