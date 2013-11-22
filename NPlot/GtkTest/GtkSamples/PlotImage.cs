using System;
using System.Drawing;
using System.IO;
using System.Reflection;

using NPlot;

namespace GtkSamples
{
	public class PlotImage : PlotSample
	{
		public PlotImage ()
		{
			infoText = "";
			infoText += "Image Example. Demonstrates - \n";
			infoText += " * ImagePlot IDrawable \n";
			infoText += " * Rubber band selection plot interaction";

			string myfile = 
			"-1.251382E-3 -1.279191E-3 -7.230207E-4 -8.064462E-4 -5.005528E-4 -5.839783E-4 -1.696318E-3 -1.668509E-3 -3.893189E-4 -4.449358E-4 -1.473850E-3 -1.473850E-3 -1.974403E-3 -1.946594E-3 -2.085637E-3 -2.085637E-3 -1.612892E-3 -1.640701E-3 -1.863169E-3 " +
			"-1.251382E-3 -1.306999E-3 -6.674037E-4 -8.620631E-4 -4.449358E-4 -6.674037E-4 -1.668509E-4 -1.668509E-3 -3.615103E-4 -5.005528E-4 -5.561698E-5 -1.473850E-3 -4.449358E-4 -1.946594E-3 -6.395953E-4 -2.057828E-3 -1.585084E-3 -1.696318E-3 -1.807552E-3 " +
			"-1.223573E-3 -1.306999E-3 -6.117867E-4 -9.176802E-4 -3.893189E-4 -7.508292E-4 -1.390424E-4 -1.640701E-3 -3.615103E-4 -5.561698E-4 -5.561698E-5 -1.446041E-3 -4.449358E-4 -1.918786E-3 -6.117867E-4 -2.057828E-3 -1.585084E-3 -1.724126E-3 -1.779743E-3 " +
			"-1.251382E-3 -1.334807E-3 -5.839783E-4 -9.732971E-4 -3.615103E-4 -8.342547E-4 -1.390424E-4 3.893189E-4 1.751935E-3 2.919891E-3 3.476061E-3 3.031125E-3 1.807552E-3 6.674037E-4 -6.117867E-4 -2.030020E-3 -1.585084E-3 -1.779743E-3 -1.779743E-3 " +
			"-1.279191E-3 -1.362616E-3 -5.561698E-4 -1.028914E-3 -3.615103E-4 8.620631E-4 2.335913E-3 3.114551E-3 4.087848E-3 5.227996E-3 6.395952E-3 5.700740E-3 4.560592E-3 2.502764E-3 1.362616E-3 -6.117867E-4 -1.585084E-3 -1.807552E-3 -1.751935E-3 " +
			"-1.306999E-3 -1.390424E-3 -5.561698E-4 -1.056723E-3 1.890977E-3 4.087848E-3 6.117868E-3 9.621738E-3 1.357054E-2 1.721345E-2 1.715784E-2 1.462726E-2 1.059503E-2 6.368144E-3 3.253593E-3 1.279191E-3 6.674037E-4 -1.807552E-3 -1.779743E-3 " +
			"-1.390424E-3 -1.390424E-3 -5.561698E-4 1.585084E-3 4.560592E-3 8.481589E-3 1.437699E-2 2.155158E-2 2.702985E-2 3.078400E-2 3.134017E-2 2.892083E-2 2.338694E-2 1.446041E-2 6.757463E-3 3.031125E-3 6.674037E-4 -1.807552E-3 -1.807552E-3 " +
			"-1.446041E-3 -1.362616E-3 1.140148E-3 3.448253E-3 7.647335E-3 1.512782E-2 2.360941E-2 3.125674E-2 3.520555E-2 3.673501E-2 3.692967E-2 3.598418E-2 3.345361E-2 2.466613E-2 1.415452E-2 5.700740E-3 3.114551E-3 8.342547E-5 -1.835360E-3 " +
			"-1.529467E-3 -1.334807E-3 1.112340E-3 5.367038E-3 1.154052E-2 2.080075E-2 3.011659E-2 3.581733E-2 3.751365E-2 3.676282E-2 3.687406E-2 3.776393E-2 3.598418E-2 3.139579E-2 1.999430E-2 9.315844E-3 3.142359E-3 1.112340E-4 -1.863169E-3 " +
			"-1.640701E-3 -1.306999E-3 1.084531E-3 6.785271E-3 1.557275E-2 2.410996E-2 3.311991E-2 3.584514E-2 3.748584E-2 3.681844E-2 3.681844E-2 3.776393E-2 3.592857E-2 3.350923E-2 2.177405E-2 1.140148E-2 3.114551E-3 1.112340E-4 -1.890977E-3 " +
			"-1.696318E-3 -1.251382E-3 1.056723E-3 6.813080E-3 1.557275E-2 2.413777E-2 3.311991E-2 3.756927E-2 3.745804E-2 3.687406E-2 3.676282E-2 3.776393E-2 3.590076E-2 3.350923E-2 2.174624E-2 1.142929E-2 3.114551E-3 1.390424E-4 -1.918786E-3 " +
			"-1.779743E-3 -1.195765E-3 1.028914E-3 6.785271E-3 1.256944E-2 2.180186E-2 3.039468E-2 3.598418E-2 3.743023E-2 3.695748E-2 3.673501E-2 3.773612E-2 3.587295E-2 2.967166E-2 1.874292E-2 9.593928E-3 3.086742E-3 1.668509E-4 -1.918786E-3 " +
			"-1.863169E-3 -1.140148E-3 -1.362616E-3 3.058934E-3 7.285824E-3 1.532248E-2 2.472175E-2 3.195195E-2 3.478842E-2 3.701310E-2 3.670720E-2 3.545582E-2 3.220223E-2 2.333132E-2 1.354273E-2 5.978825E-3 1.279191E-3 1.668509E-4 -1.918786E-3 " +
			"-1.918786E-3 -1.084531E-3 -1.390424E-3 6.674037E-4 3.448253E-3 7.563909E-3 1.596207E-2 2.394311E-2 2.875398E-2 3.103427E-2 3.181291E-2 2.972727E-2 2.363721E-2 1.543371E-2 9.176801E-3 5.978825E-3 1.251382E-3 1.668509E-4 -1.890977E-3 " +
			"-1.974403E-3 -1.056723E-3 -1.390424E-3 6.674037E-4 1.362616E-3 3.781955E-3 8.036654E-3 1.304218E-2 1.824237E-2 2.127349E-2 2.174624E-2 1.963279E-2 1.573960E-2 1.148491E-2 7.341441E-3 3.197976E-3 -1.446041E-3 -1.557275E-3 -1.835360E-3 " +
			"-2.030020E-3 -1.056723E-3 -1.334807E-3 -1.084531E-3 -1.279191E-3 1.001106E-3 3.948805E-3 6.674037E-3 9.983247E-3 1.243039E-2 1.426576E-2 1.454384E-2 1.184642E-2 8.787482E-3 4.504975E-3 6.952122E-4 -1.418233E-3 -1.557275E-3 -1.779743E-3 " +
			"-2.057828E-3 -1.056723E-3 -1.306999E-3 -1.084531E-3 -1.251382E-3 -7.786377E-4 6.395953E-4 2.586189E-3 4.254699E-3 6.117868E-3 7.619526E-3 7.508292E-3 5.951017E-3 3.003317E-3 -9.176802E-4 -1.195765E-3 -1.362616E-3 -1.557275E-3 -1.751935E-3 " +
			"-2.085637E-3 -1.084531E-3 -1.251382E-3 -1.112340E-3 -1.223573E-3 -7.786377E-4 -8.620631E-4 -3.893189E-4 -4.449358E-4 3.337019E-4 1.167957E-3 9.454886E-4 3.893189E-4 -8.342547E-4 -9.176802E-4 -1.195765E-3 -1.306999E-3 -1.585084E-3 -1.696318E-3 " +
			"-2.113445E-3 -1.140148E-3 -1.195765E-3 -1.140148E-3 -1.167957E-3 -7.786377E-4 -8.342547E-4 -3.893189E-4 -4.171273E-4 -1.279191E-3 -1.251382E-3 -1.195765E-3 -1.195765E-3 -8.342547E-4 -8.620631E-4 -1.223573E-3 -1.251382E-3 -1.612892E-3 -1.668509E-3";

			string [] tokens = myfile.Split(new char [1] {' '});
			double [,] map = new double [19,19];
			for (int i=0; i < 19; ++i)
			{
				for (int j=0; j < 19; ++j)
				{
					map[i,j] = Convert.ToDouble(tokens[i*19+j], new
						System.Globalization.CultureInfo("en-US"));
				}
			}

			plotSurface.Clear();
			
			plotSurface.Title = "Cathode 11.2 QE Map";
			
			ImagePlot ip = new ImagePlot(map, -9.0f, 1.0f, -9.0f, 1.0f);
			//ip.Gradient = new StepGradient( StepGradient.Type.Rainbow );
			ip.Gradient = new LinearGradient( Color.Gold, Color.Black );

			plotSurface.Add(ip);
			plotSurface.XAxis1.Label = "x [mm]";
			plotSurface.YAxis1.Label = "y [mm]";

			plotSurface.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;

			//plotSurface.AddAxesConstraint( new AxesConstraint.AxisPosition( PlotSurface2D.YAxisPosition.Left, 0) );
			//plotSurface.AddAxesConstraint( new AxesConstraint.AxisPosition( PlotSurface2D.XAxisPosition.Top, 0) );
			//plotSurface.AddAxesConstraint(
			//new AxesConstraint.YPixelWorldLength(0.1f,PlotSurface2D.XAxisPosition.Bottom) );
			//plotSurface.AddAxesConstraint( new AxesConstraint.AspectRatio(1.0,PlotSurface2D.XAxisPosition.Top,PlotSurface2D.YAxisPosition.Left) );
			plotSurface.AddInteraction (new KeyActions());
			plotSurface.AddInteraction (new PlotSelection(Color.White));

			plotSurface.Refresh();

		}
	}
}

