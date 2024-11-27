using System;

namespace BlazorChart;

public enum ChartType
{
    Bar,            // "bar"
    Line,           // "line"
    Pie,            // "pie"
    Doughnut,       // "doughnut"
    PolarArea,      // "polarArea"
    Radar,          // "radar"
    Bubble,         // "bubble"
    Scatter,        // "scatter"
    HorizontalBar,  // "horizontalBar" (deprecated in newer Chart.js versions)
    Area            // "area" (custom type in some Chart.js setups)
}