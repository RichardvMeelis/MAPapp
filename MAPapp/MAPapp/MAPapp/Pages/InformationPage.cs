using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace MAPapp
{
	public class InformationPage : ContentPage
	{
        List<InformationObject> InfoObj;
        public async void VolgendePagina(string s)
        {/*
            if (s == InfoObj[0].ThreeInfoPoint)
                await Navigation.PushAsync(new FivePointsMenu(InfoObj[0]));
           else if (s == InfoObj[1].ThreeInfoPoint)
                await Navigation.PushAsync(new FivePointsMenu(InfoObj[1]));
           else if (s == InfoObj[2].ThreeInfoPoint)
                await Navigation.PushAsync(new FivePointsMenu(InfoObj[2]));
                */
            foreach (InformationObject b in InfoObj)
                if (s == b.ThreeInfoPoint)
                    await Navigation.PushAsync(new FivePointsMenu(b));

        }
        public InformationPage ()
		{
            BackgroundColor = GeneralSettings.backgroundColor;
            InfoObj = GetFromDatabase.GetInformation(GetFromDatabase.currentUserName,GetFromDatabase.currentToken);
            StackLayout stack = new StackLayout();
            foreach (InformationObject b in InfoObj)
                stack.Children.Add(new ClickableLabel(VolgendePagina) { Text = b.ThreeInfoPoint, TextColor = GeneralSettings.textColor });
           
            Content = stack;
			
		}
	} 
}
