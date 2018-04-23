using System;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraCharts;
// ...

namespace Series_SideBySideGanttChart {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            // Create a new chart.
            ChartControl ganttChart = new ChartControl();

            // Create two Gantt series.
            Series series1 = new Series("Estimation", ViewType.SideBySideGantt);
            Series series2 = new Series("Implementation", ViewType.SideBySideGantt);

            // Specify the date-time value scale type,
            // because it is qualitative by default.
            series1.ValueScaleType = ScaleType.DateTime;
            series2.ValueScaleType = ScaleType.DateTime;

            // Add points to them.
            series1.Points.Add(new SeriesPoint("Task 1", new DateTime[] { 
                new DateTime(2006, 8, 16), new DateTime(2006, 8, 31) }));
            series1.Points.Add(new SeriesPoint("Task 2", new DateTime[] { 
                new DateTime(2006, 8, 31), new DateTime(2006, 9, 15) }));
            series1.Points.Add(new SeriesPoint("Task 3", new DateTime[] { 
                new DateTime(2006, 9, 15), new DateTime(2006, 9, 30) }));
            series1.Points.Add(new SeriesPoint("Task 4", new DateTime[] { 
                new DateTime(2006, 9, 30), new DateTime(2006, 10, 15) }));

            series2.Points.Add(new SeriesPoint("Task 1", new DateTime[] { 
                new DateTime(2006, 8, 16), new DateTime(2006, 9, 5) }));
            series2.Points.Add(new SeriesPoint("Task 2", new DateTime[] { 
                new DateTime(2006, 9, 5), new DateTime(2006, 9, 22) }));
            series2.Points.Add(new SeriesPoint("Task 3", new DateTime[] { 
                new DateTime(2006, 9, 22), new DateTime(2006, 10, 10) }));
            series2.Points.Add(new SeriesPoint("Task 4", new DateTime[] { 
                new DateTime(2006, 10, 10), new DateTime(2006, 10, 23) }));

            // Add both series to the chart.
            ganttChart.Series.AddRange(new Series[] { series1, series2 });

            // Access the view-type-specific options of the second series.
            SideBySideGanttSeriesView myView2 = (SideBySideGanttSeriesView)series2.View;

            myView2.MaxValueMarkerVisibility = DefaultBoolean.True;
            myView2.MaxValueMarker.Kind = MarkerKind.Star;
            myView2.MaxValueMarker.StarPointCount = 5;
            myView2.MaxValueMarker.Size = 10;

            myView2.MinValueMarkerVisibility = DefaultBoolean.True;
            myView2.MinValueMarker.Kind = MarkerKind.Circle;
            myView2.MinValueMarker.Size = 10;

            myView2.BarWidth = 0.5;

            // Customize the chart (if necessary).
            GanttDiagram myDiagram = (GanttDiagram)ganttChart.Diagram;

            myDiagram.AxisX.Title.Visible = true;
            myDiagram.AxisX.Title.Text = "Tasks";
            myDiagram.AxisY.Interlaced = true;
            myDiagram.AxisY.DateTimeScaleOptions.GridSpacing = 2;
            myDiagram.AxisY.Label.Angle = -30;
            myDiagram.AxisY.Label.EnableAntialiasing = DefaultBoolean.True;
            myDiagram.AxisY.Label.TextPattern = "{V:MMMM dd}";

            // Customize the legend (if necessary).
            ganttChart.Legend.AlignmentHorizontal = LegendAlignmentHorizontal.Right;
            ganttChart.Legend.AlignmentVertical = LegendAlignmentVertical.TopOutside;
            ganttChart.Legend.Direction = LegendDirection.LeftToRight;

            // Add a constant line.
            ConstantLine deadline = new ConstantLine("Deadline", new DateTime(2006, 10, 15));
            deadline.ShowInLegend = false;
            deadline.Title.Alignment = ConstantLineTitleAlignment.Far;
            deadline.Color = Color.Red;
            myDiagram.AxisY.ConstantLines.Add(deadline);

            // Add a title to the chart (if necessary).
            ganttChart.Titles.Add(new ChartTitle());
            ganttChart.Titles[0].Text = "A Side-by-Side Gantt Chart";

            // Add the chart to the form.
            ganttChart.Dock = DockStyle.Fill;
            this.Controls.Add(ganttChart);
        }
    }
}