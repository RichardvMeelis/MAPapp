using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net;

namespace MAPapp
{
    class GetFromDatabase
    {

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
            WebRequest request = WebRequest.Create(url);
            WebResponse ws = request.GetResponse();
            try
            {
                Stream ReceiveStream = ws.GetResponseStream();

                Encoding encode = System.Text.Encoding.GetEncoding("utf-8");

                // Pipe the stream to a higher level stream reader with the required encoding format. 
                StreamReader readStream = new StreamReader(ReceiveStream, encode);

                String s = readStream.ReadToEnd();//JsonConvert.DeserializeObject<String>(readStream.ReadToEnd());
                return s;
            }
            catch { return "error"; }
        }
        public List<Project> getProjects(String userName, String token)
        {

        }
    }
}
