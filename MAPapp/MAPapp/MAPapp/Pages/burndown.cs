using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using OxyPlot.Xamarin.Forms;

using Xamarin.Forms;

namespace MAPapp
{
	public class burndown : ContentPage
	{
        static int totalPointsMember;
		public burndown (Project project)
		{
            Title = Globals.burndowntitle;
            BackgroundColor = Color.White;
            var plotModel = new PlotModel { Title = "OxyPlot Demo" };
            
           


            LineSeries series1 = createLineSeries(project);
            plotModel.Series.Add(series1);
            //  plotModel.Axes.Add(new LinearAxis { Position = AxisPosition.Bottom, AbsoluteMinimum = 0,Minimum = 0, });
            // plotModel.Axes.Add(new LinearAxis { Position = AxisPosition.Left, IsPanEnabled = false, AbsoluteMinimum = 0, Maximum = totalPointsMember, Minimum = 0, });
            plotModel.Axes.Add(new DateTimeAxis { Position = AxisPosition.Bottom, AbsoluteMinimum = DateTimeAxis.ToDouble(project.start_date), StringFormat = "dd/MM" , Minimum = DateTimeAxis.ToDouble(project.start_date),Maximum = DateTimeAxis.ToDouble(project.start_date.AddDays(5)),MajorStep = 1, MinorStep = 1 });
            plotModel.Axes.Add(new LinearAxis { Position = AxisPosition.Left, IsPanEnabled = false, AbsoluteMinimum = 0, Maximum = totalPointsMember, Minimum = 0 });   
            PlotView plot = new PlotView() {Model = plotModel,
                VerticalOptions = LayoutOptions.Fill,
                HorizontalOptions = LayoutOptions.Fill, 
                
            };

            Content = plot;
		
		}

        public static LineSeries createLineSeries(Project project)
        {
            var series1 = new LineSeries
            {
                MarkerType = MarkerType.Circle,
                MarkerSize = 4,
                MarkerStroke = OxyColors.White
            };
            
            int totalPoints = 0;
            foreach (Task t in project.Tasks)
            {
                totalPoints += t.UBVPoints;
            }
           totalPointsMember = totalPoints;
            series1.Points.Add(new DataPoint(DateTimeAxis.ToDouble(project.start_date),totalPoints));
            List<Task> removeTasks = new List<Task>();
            for (int i = 0; i <= DateTime.Today.Subtract(project.start_date).Days; i++)
            {
                foreach (Task t in project.Tasks)
                {
                   
                    if (t.timecompleted != null && t.timecompleted.Value.DayOfYear == project.start_date.AddDays(i).DayOfYear)
                    {
                        
                        totalPoints -= t.UBVPoints;
                        //project.Tasks.Remove(t);
                    }
                    foreach (Task z in removeTasks)
                    project.Tasks.Remove(z);
                }
                series1.Points.Add(new DataPoint(DateTimeAxis.ToDouble(project.start_date.AddDays(i).Date), totalPoints));
            }
            return series1;
        }
	}
}
