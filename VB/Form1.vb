Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports DevExpress.Utils
Imports DevExpress.XtraCharts
' ...

Namespace Series_SideBySideGanttChart
    Partial Public Class Form1
        Inherits Form

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
            ' Create a new chart.
            Dim ganttChart As New ChartControl()

            ' Create two Gantt series.
            Dim series1 As New Series("Estimation", ViewType.SideBySideGantt)
            Dim series2 As New Series("Implementation", ViewType.SideBySideGantt)

            ' Specify the date-time value scale type,
            ' because it is qualitative by default.
            series1.ValueScaleType = ScaleType.DateTime
            series2.ValueScaleType = ScaleType.DateTime

            ' Add points to them.
            series1.Points.Add(New SeriesPoint("Task 1", New Date() { _
                New Date(2006, 8, 16), _
                New Date(2006, 8, 31) _
            }))
            series1.Points.Add(New SeriesPoint("Task 2", New Date() { _
                New Date(2006, 8, 31), _
                New Date(2006, 9, 15) _
            }))
            series1.Points.Add(New SeriesPoint("Task 3", New Date() { _
                New Date(2006, 9, 15), _
                New Date(2006, 9, 30) _
            }))
            series1.Points.Add(New SeriesPoint("Task 4", New Date() { _
                New Date(2006, 9, 30), _
                New Date(2006, 10, 15) _
            }))

            series2.Points.Add(New SeriesPoint("Task 1", New Date() { _
                New Date(2006, 8, 16), _
                New Date(2006, 9, 5) _
            }))
            series2.Points.Add(New SeriesPoint("Task 2", New Date() { _
                New Date(2006, 9, 5), _
                New Date(2006, 9, 22) _
            }))
            series2.Points.Add(New SeriesPoint("Task 3", New Date() { _
                New Date(2006, 9, 22), _
                New Date(2006, 10, 10) _
            }))
            series2.Points.Add(New SeriesPoint("Task 4", New Date() { _
                New Date(2006, 10, 10), _
                New Date(2006, 10, 23) _
            }))

            ' Add both series to the chart.
            ganttChart.Series.AddRange(New Series() { series1, series2 })

            ' Access the view-type-specific options of the second series.
            Dim myView2 As SideBySideGanttSeriesView = CType(series2.View, SideBySideGanttSeriesView)

            myView2.MaxValueMarkerVisibility = DefaultBoolean.True
            myView2.MaxValueMarker.Kind = MarkerKind.Star
            myView2.MaxValueMarker.StarPointCount = 5
            myView2.MaxValueMarker.Size = 10

            myView2.MinValueMarkerVisibility = DefaultBoolean.True
            myView2.MinValueMarker.Kind = MarkerKind.Circle
            myView2.MinValueMarker.Size = 10

            myView2.BarWidth = 0.5

            ' Customize the chart (if necessary).
            Dim myDiagram As GanttDiagram = CType(ganttChart.Diagram, GanttDiagram)

            myDiagram.AxisX.Title.Visibility = DefaultBoolean.True
            myDiagram.AxisX.Title.Text = "Tasks"
            myDiagram.AxisY.Interlaced = True
            myDiagram.AxisY.DateTimeScaleOptions.GridSpacing = 2
            myDiagram.AxisY.Label.Angle = -30
            myDiagram.AxisY.Label.EnableAntialiasing = DefaultBoolean.True
            myDiagram.AxisY.Label.TextPattern = "{V:MMMM dd}"

            ' Customize the legend (if necessary).
            ganttChart.Legend.AlignmentHorizontal = LegendAlignmentHorizontal.Right
            ganttChart.Legend.AlignmentVertical = LegendAlignmentVertical.TopOutside
            ganttChart.Legend.Direction = LegendDirection.LeftToRight

            ' Add a constant line.
            Dim deadline As New ConstantLine("Deadline", New Date(2006, 10, 15))
            deadline.ShowInLegend = False
            deadline.Title.Alignment = ConstantLineTitleAlignment.Far
            deadline.Color = Color.Red
            myDiagram.AxisY.ConstantLines.Add(deadline)

            ' Add a title to the chart (if necessary).
            ganttChart.Titles.Add(New ChartTitle())
            ganttChart.Titles(0).Text = "A Side-by-Side Gantt Chart"

            ' Add the chart to the form.
            ganttChart.Dock = DockStyle.Fill
            Me.Controls.Add(ganttChart)
        End Sub
    End Class
End Namespace