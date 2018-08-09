using System;
using System.Windows.Forms.DataVisualization.Charting;
namespace Leden.Net
{
    public partial class frmChart : frmBasis
    {
        public frmChart()
        {
            InitializeComponent();

            //chart1.Series["Leden"].Points.AddXY("Max", 150);
            //chart1.Series["Leden"].Points.AddXY("Aap", 100);
            //chart1.Series["Leden"].Points.AddXY("Koe", 50);
            //chart1.Series["Leden"].Points.AddXY("Paard",25);
            Random random = new Random();
            for (int pointIndex = 0; pointIndex < 10; pointIndex++)
            {
                chart1.Series["LightBlue"].Points.AddY(random.Next(45, 95));
            }

            // Set chart type
            chart1.Series["LightBlue"].ChartType = SeriesChartType.StackedArea100;

            // Show point labels
            chart1.Series["LightBlue"].IsValueShownAsLabel = true;

            // Disable X axis margin
            chart1.ChartAreas["Default"].AxisX.IsMarginVisible = false;

            // Set the first two series to be grouped into Group1
            chart1.Series["LightBlue"]["StackedGroupName"] = "Group1";
            chart1.Series["Gold"]["StackedGroupName"] = "Group1";

            // Set the last two series to be grouped into Group2
            chart1.Series["Red"]["StackedGroupName"] = "Group2";
            chart1.Series["DarkBlue"]["StackedGroupName"] = "Group2";

            // Set to 3D
            chart1.ChartAreas["Default"].Area3DStyle.Enable3D = true;        
        
        }
    }
}
