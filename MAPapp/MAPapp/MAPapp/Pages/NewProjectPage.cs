﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace MAPapp {
    public class NewProjectPage : ContentPage {
        //Alle invoer velden voor de nieuwe project pagina
        Entry nameEntry = new Entry() { TextColor = GeneralSettings.textColor, BackgroundColor = GeneralSettings.entryColor};
        Entry descriptionEntry = new Entry() { TextColor = GeneralSettings.textColor, BackgroundColor = GeneralSettings.entryColor };

        Button b;

        //Kiezen van begin en eind datums
        DatePicker start = new DatePicker() { BackgroundColor = GeneralSettings.entryColor, TextColor = GeneralSettings.textColor};
        DatePicker end = new DatePicker() {BackgroundColor = GeneralSettings.entryColor, TextColor = GeneralSettings.textColor} ;

        public NewProjectPage()
        {
            BackgroundColor = GeneralSettings.backgroundColor;
            //Maak scrollview voor project info
            ScrollView scroll = new ScrollView() { Content = new StackLayout { Children = { new Label { Text = Globals.projnaam, TextColor = GeneralSettings.textColor }, nameEntry, new Label { Text = Globals.beschrijving, TextColor = GeneralSettings.textColor }, descriptionEntry, new Label { Text = Globals.datumbegin, TextColor = GeneralSettings.textColor }, start, new Label { Text = Globals.datumeind, TextColor = GeneralSettings.textColor }, end } } };
            //Button voor nieuw project
            b = new Button() { Text = Globals.knopaanmaken, HorizontalOptions = LayoutOptions.Center, BackgroundColor = GeneralSettings.mainColor, TextColor = GeneralSettings.btextColor };
            b.Clicked += B_Clicked;
            //Voeg content toe aan stacklayout
            Content = new StackLayout
            {
                Margin = GeneralSettings.pageMargin,
                Children = {
                    scroll, b
                }
            };
        }

        private async void B_Clicked(object sender, EventArgs e)
        {
            b.IsEnabled = false;
           //Nieuw project toevoegen aan de database
            ContactDataBase.createProject(ContactDataBase.currentUserName, ContactDataBase.currentToken, nameEntry.Text, descriptionEntry.Text, start.Date);
            await Navigation.PushAsync(new ProjectsPage((List<Project>)ContactDataBase.GetProjects(ContactDataBase.currentUserName, ContactDataBase.currentToken)), false);

            //Het verwijderen van de oude pages in de stack
            for (int counter = 1; counter <= 2; counter++)
            {
                Navigation.RemovePage(Navigation.NavigationStack[1]);
            }
        }
    }
}
