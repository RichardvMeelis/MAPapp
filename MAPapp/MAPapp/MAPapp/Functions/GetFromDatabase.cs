using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net;
using Newtonsoft.Json;
namespace MAPapp
{
    class GetFromDatabase
    {
        public static string token;
        public static string Username;
        private static String CreateURL(String userName, String passWord, String command, String token, String fName, String lName, String joincode)
        {
            string url = "https://apihost.nl/map/api.php?";
            if (command == "signIn")
            {
                url += "_MAP_REST_REQUEST_=_MAP_AUTH_" + "&_MAP_USERNAME_=" + userName + "&_MAP_EPASS_=" + passWord;
            }
            else if (command == "signOut")
            {
                url += "_MAP_REST_REQUEST_=_MAP_TOKEN_DESTROY_" + "&_MAP_USERNAME_=" + userName + "&_MAP_AUTH_TOKEN_=" + token;
            }
            else if (command == "getProjectsUser")
            {
                url += "_MAP_REST_REQUEST_=_MAP_GET_PROJECTS_ALL_" + "&_MAP_USERNAME_=" + userName + "&_MAP_AUTH_TOKEN_=" + token;
            }
            else if (command == "getProjectsCompany")
            {
                url += "";
            }
            else if (command == "createNewUser")
            {
                url += "_MAP_REST_REQUEST_=_MAP_INS_USER_&_MAP_USERNAME_=" + userName + "&_MAP_EPASS_=" + passWord + "&_MAP_INS_FNAME_=" + fName + "&_MAP_INS_LNAME_=" + lName + "&_MAP_JOIN_CODE_=" + joincode;
            }
            //  Console.WriteLine(url);
            return url;
        }

        private static String getJsonData(String username, String password, String command, String token, String fName, String lName, String joincode)
        {
            string url = CreateURL(username, password, command, token, fName, lName, joincode);
            System.Diagnostics.Debug.WriteLine(url);
            WebRequest request = WebRequest.Create(url);
            WebResponse ws = request.GetResponse();
            try
            {
                Stream ReceiveStream = ws.GetResponseStream();

                Encoding encode = System.Text.Encoding.GetEncoding("utf-8");

                // Pipe the stream to a higher level stream reader with the required encoding format. 
                StreamReader readStream = new StreamReader(ReceiveStream, encode);

                String s = readStream.ReadToEnd();
                return s;
            }
            catch { return "error"; }
        }
        public static List<Project> getProjects(String userName, String token)
        {

            List < Project > s = JsonConvert.DeserializeObject<List<Project>>(getJsonData(userName,null, "getProjectsUser", token,null,null,null));
            return s;
        }
        public static String SingIn(String userName, String password)
        {
            return JsonConvert.DeserializeObject<String>(getJsonData(userName,password,"signIn",null,null,null,null));
        }
        public static String CreateUser(String userName, String password, String fName, String lName, String joincode)
        {
            string s = getJsonData(userName, password, "createNewUser", null, fName, lName, joincode);
           /// System.Diagnostics.Debug.WriteLine(s);
            return JsonConvert.DeserializeObject<String>(s);
        }
    }
}
