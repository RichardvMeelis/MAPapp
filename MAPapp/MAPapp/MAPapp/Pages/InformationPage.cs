using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace MAPapp
{
	public class InformationPage : ContentPage
	{
        //Lijst met informatie voor de informatie paginas
        List<InformationObject> InfoObj;

        public async void VolgendePagina(string s)
        {
            foreach (InformationObject b in InfoObj)
                //Vergelijkt de meegegeven string met de "titel" van het infromatie object 
                if (s == b.ThreeInfoPoint)
                    //Zet de nieuwe pagina op de stack
                    await Navigation.PushAsync(new FivePointsMenu(b));

        }
        public InformationPage ()
		{
            BackgroundColor = GeneralSettings.backgroundColor;
            
            //Haal de informatie op uit de database
            InfoObj = (List<InformationObject>)GetFromDatabase.GetInformation(GetFromDatabase.currentUserName,GetFromDatabase.currentToken);
            
            StackLayout stack = new StackLayout() {VerticalOptions = LayoutOptions.Center,Margin = GeneralSettings.pageMargin };
            
            //Maakt iteratief ClickableLabels aan
            foreach (InformationObject b in InfoObj)
                stack.Children.Add(new ClickableLabel(VolgendePagina,24) { Text = b.ThreeInfoPoint, TextColor = GeneralSettings.textColor, HorizontalOptions = LayoutOptions.CenterAndExpand });
            ScrollView scroll = new ScrollView() { Content = stack };
            Content = scroll;
			
		}
	} 
}
