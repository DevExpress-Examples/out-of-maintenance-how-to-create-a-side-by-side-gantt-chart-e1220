<!-- default file list -->
*Files to look at*:

* [Form1.cs](./CS/Form1.cs) (VB: [Form1.vb](./VB/Form1.vb))
<!-- default file list end -->
# How to create a Side-by-Side Gantt chart

The following example demonstrates how to create a [Side-By-Side Gantt](https://docs.devexpress.com/WindowsForms/2984/controls-and-libraries/chart-control/series-views/2d-series-views/gantt-series-views/side-by-side-gantt-chart?p=netframework) chart at runtime.

Note that this series view type is associated with the [Gantt Diagram](https://docs.devexpress.com/WindowsForms/5910/controls-and-libraries/chart-control/diagram/gantt-diagram?p=netframework) type, and you should cast your [diagram](https://docs.devexpress.com/WindowsForms/DevExpress.XtraCharts.ChartControl.Diagram?p=netframework) object to this type, in order to access its specific options.

Starting from v14.1, text pattern properties ([AxisLabel.TextPattern](https://docs.devexpress.com/CoreLibraries/DevExpress.XtraCharts.AxisLabel.TextPattern?p=netframework), [SeriesLabelBase.TextPattern](https://docs.devexpress.com/CoreLibraries/DevExpress.XtraCharts.SeriesLabelBase.TextPattern?p=netframework), [SeriesBase.LegendTextPattern](https://docs.devexpress.com/CoreLibraries/DevExpress.XtraCharts.SeriesBase.LegendTextPattern?p=netframework)) have been introduced instead of point options.
