using System;
using System.Collections.Generic;
using System.Text;

namespace MAPapp
{
    class SaveTestData
    {
        public static List<InformationObject> info = new List<InformationObject>();
        public static List<Project> projects = new List<Project>();
        public static void CreateTestData()
        {
            Random r = new Random();
            for (int i = 0; i < 50; i++)
            {
               projects.Add(new Project(DateTime.Today, new DateTime(2016, r.Next(1, 12), r.Next(1, 30)), "Project " + i, "BlinkLaneMAPapp", "testproject") { Users = new List<User> { new User("Sam", "test@test.com", "test") }, Tasks = new List<Task> { new Task(new DateTime(), "Taak 1", "Beschrijving", r.Next(0, 15), r.Next(0, 15), false, new User("Sam", "test@test.com", "test"), r.Next(1, 12), r.Next(1, 21), r.Next(1, 5)), new Task(new DateTime(), "Taak 2", "Beschrijving", r.Next(0, 15), r.Next(0, 15), false, new User("Sam", "test@test.com", "test"), r.Next(1, 12), r.Next(1, 21), r.Next(1, 5)) } });

            }

            info.Add(new InformationObject( new List<string>() { "In de Turkse stad Kayseri zijn dertien doden en bijna vijftig gewonden gevallen bij een aanslag die was gericht tegen een passerende bus met militairen. Alle doden zijn militairen. Zes gewonden verkeren in kritieke toestand, maakte minister van Binnenlandse Zaken Soylu enkele uren later bekend. In de bus zaten zo'n 25 militairen die met weekendverlof gingen. Op het moment van de explosie bevonden zich ook studenten op straat, melden Turkse media. De Turkse president Erdogan legt de schuld voor de aanslag bij de Koerdische PKK. Hij wijst er in zijn reactie op dat Turkije wordt aangevallen door'\"separatistische groeperingen die met elkaar samenwerken\", en dat die aanslagen niet losstaan van \"wat er in Syrië en Irak gebeurt\". In die landen strijden Koerdische groeperingen die volgens Erdogan verwant zijn aan de PKK. Video afspelen 00:15 Aanslag in Turkije op bus militairen Turkije werd precies een week geleden opgeschrikt door een dubbele bomaanslag in Istanbul, waarbij 44 mensen omkwamen. Die aanslag werd later opgeëist door de militante Koerdische beweging TAK. Sindsdien circuleren er berichten dat er meer aanslagen op leger en politie op komst zijn. Koerden beschuldigd Het Turkse leger voert - met name in het het oosten van Turkije - een keiharde strijd tegen militante Koerden. Die plegen verspreid over het hele land geregeld bloedige aanslagen. Woedende burgers hebben in Kayseri het kantoor van de Koerdische politieke partij HDP bestormd en in brand gestoken uit protest tegen de aanslag van vanmorgen. Minister Soylu heeft gedreigd met represailles tegen de groepering die verantwoordelijk is voor de aanslag. ", "uyf goiuadfhguodbfuhfiashfiasdgfiouadfi8uadfhiudfhaufhiaufhiauhfuodghfuyarguyfguoyafdguyoafguyafhahfuayohfauofhuoafghaoufhbasuoiyfhasuoyfhasouifhsaiufgs9pfgaifyifhsuifgjsoihfiodughaopifghhaopifghaoi[ghaoipghoai", "uyf goiuadfhguodbfuhfiashfiasdgfiouadfi8uadfhiudfhaufhiaufhiauhfuodghfuyarguyfguoyafdguyoafguyafhahfuayohfauofhuoafghaoufhbasuoiyfhasuoyfhasouifhsaiufgs9pfgaifyifhsuifgjsoihfiodughaopifghhaopifghaoi[ghaoipghoai", "d", "e" }, new List<string>() { "PUNT1", "PUNT2", "PUNT3", "PUNT4", "PUNT5" }, "PUNT 1" ));
            info.Add(new InformationObject(new List<string>() { "1", "2", "3", "4", "5" }, new List<string>() { "a", "b", "c", "d", "e" }, "huwRFGUIWYFRDGUYIOESFGIUYGHZSDUFHYJKVAWVNRHUYISKESNMREUAIYWRHGJKHDKSDRHMDSBUZKJHYDKJSDHRGHZISOUFGZSOKLRGTH BILKSDRTGBHONISZHFBISZLBGDVUKAGFUKAGWQJh jkkh jkhfbzskufgzsui"));
            info.Add(new InformationObject(new List<string>() { "1", "2", "3", "4", "5" }, new List<string>() { "a", "b", "c", "d", "e" }, " 5r6y5ytgt435gyuqu6t5hyguguhyiougbhwbyw8ugyusgr8u9hgrd7y87gyt69t789wrfgeGYQER5T978G3T45GY5G7YGF B4HT798F53Q4GGYBUQV34TG79T6234R9B4RQWVTUYGB EWRQVGUYWQREQREWTVUYGUYTFB "));

        }
    }
}
