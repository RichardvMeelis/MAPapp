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

            var plotModel = new PlotModel { Title = "Burndown Chart" };

            //icon voor iphone tabbedpage
            Icon = "burndownicon.png";
            
            //De punten aan de grafiek toevoegen 
            plotModel.Series.Add(createLineSeries(project));
            
            //X-as met data als waarden
            plotModel.Axes.Add(new DateTimeAxis { Position = AxisPosition.Bottom, AbsoluteMinimum = DateTimeAxis.ToDouble(project.start_date)-1, StringFormat = "dd/MM" , Minimum = DateTimeAxis.ToDouble(project.start_date)-1,Maximum = DateTimeAxis.ToDouble(project.start_date.AddDays(5)),MajorStep = 1, MinorStep = 1 });
            plotModel.Axes.Add(new LinearAxis { Position = AxisPosition.Left, IsPanEnabled = false, AbsoluteMinimum = 0, Maximum = totalPointsMember + 10, Minimum = 0 });   
            PlotView plot = new PlotView() {Model = plotModel,
                VerticalOptions = LayoutOptions.Fill,
                HorizontalOptions = LayoutOptions.Fill, 
                
            };

            Content = plot;
		
		}

        //Creëren van punten in de grafiek uit de data in het project
        public static LineSeries createLineSeries(Project project)
        {
            var lineSeries = new LineSeries
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
            
            // Alle dagen sinds de start van het project tot nu worden afgegaan  
            for (int i = 0; i <= DateTime.Today.Subtract(project.start_date).Days + 1; i++)
            {
                foreach (Task t in project.Tasks)
                {
                    //Als de taak op de gecheckte dag is afgerond wordt de waarde van het totaal afgetrokken
                    if (t.timecompleted != null && t.timecompleted.Value.DayOfYear == project.start_date.AddDays(i).DayOfYear)
                    {
                        totalPoints -= t.UBVPoints;
                    }       
                }         
                lineSeries.Points.Add(new DataPoint(DateTimeAxis.ToDouble(project.start_date.AddDays(i).Date), totalPoints) );
            }
            return lineSeries;
        }
	}
}
