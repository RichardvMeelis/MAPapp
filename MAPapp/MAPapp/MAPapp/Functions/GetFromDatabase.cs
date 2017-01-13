using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net;
using System.Diagnostics;
using Newtonsoft.Json;
namespace MAPapp
{
    class GetFromDatabase
    {
        public static string currentToken;
        public static string currentUserName;
        static Stopwatch s = new Stopwatch();
        private static String CreateURL(String userName, String passWord, String command, String token, String fName, String lName, String joincode, int projectId, int sprintID)
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
            else if (command == "getInformation")
            {
                url += "_MAP_REST_REQUEST_=_MAP_GET_COMPONENTS_&_MAP_USERNAME_=" + userName + "&_MAP_AUTH_TOKEN_=" + token;
            }
            else if (command == "getTasks")
            {
                url += "_MAP_REST_REQUEST_=_MAP_GET_TASKS_&_MAP_USERNAME_=" + userName + "&_MAP_AUTH_TOKEN_=" + token + "&_MAP_PROJECT_ID_=" + projectId;
            }
            else if (command == "getSprint")
            {
                url += "_MAP_REST_REQUEST_=_MAP_GET_SPRINT_&_MAP_USERNAME_=" + userName + "&_MAP_AUTH_TOKEN_=" + token + "&_MAP_SPRINT_ID_=" + sprintID + "&_MAP_PROJECT_ID_=" + projectId;
            }
            else if (command == "joinProject")
            {
                url += "_MAP_REST_REQUEST_=_MAP_JOIN_PROJECT_&_MAP_AUTH_TOKEN_=" + token + "&_MAP_USERNAME_=" + userName + "&_MAP_PROJECT_ID_=" + projectId; 
            }

            return url;
        }

        private static String getJsonData(String username, String password, String command, String token, String fName, String lName, String joincode, int projectId, int sprintID)
        {
            string url = CreateURL(username, password, command, token, fName, lName, joincode,projectId, sprintID);
            System.Diagnostics.Debug.WriteLine(url);
            
            WebRequest request = WebRequest.Create(url);
            request.Proxy = null;
           
            
            
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

            List < Project > s = JsonConvert.DeserializeObject<List<Project>>(getJsonData(userName,null, "getProjectsUser", token,null,null,null,0,0));
            return s;
        }
        public static String SingIn(String userName, String password)
        {
           // s.Start();
            String z = JsonConvert.DeserializeObject<String>(getJsonData(userName, password, "signIn", null, null, null, null, 0,0));
           
            return z;
        }
        public static String CreateUser(String userName, String password, String fName, String lName, String joincode)
        {
            string s = getJsonData(userName, password, "createNewUser", null, fName, lName, joincode,0,0);
           /// System.Diagnostics.Debug.WriteLine(s);
            return JsonConvert.DeserializeObject<String>(s);
        }
        public static List<InformationObject> GetInformation(String userName, String token)
        {
            string s = getJsonData(userName,null,"getInformation",token,null,null,null,0,0);
            List<Tip> tips = JsonConvert.DeserializeObject<List<Tip>>(s);
            List<InformationObject> info = new List<InformationObject>();
            string stringetje = "";
            int i = 0;
            foreach(Tip t in tips)
            {
                if(t.pname != stringetje)
                {
                    info.Add(new InformationObject(new List<Tip> {t },t.pname));
                    stringetje = t.pname;
                    i++;
                }
                else
                {
                    info[i-1].Tips.Add(t);
                }
            } 
            return info;
        }
        public static List<Task>  GetTasks(String userName, String token, int projectId)
        {
            try
            {
                return JsonConvert.DeserializeObject<List<Task>>(getJsonData(userName, null, "getTasks", token, null, null, null, projectId, 0));
            }
            catch { return new List<Task>() { new Task(new DateTime(), null, null, 0, 0, 0, null, 0, 0, 0) {HasAccess = false } };
                    }
        }
        public static Sprint GetSprint(String userName, String token, int projectID, int sprintID)
        {

            try
            {
                return JsonConvert.DeserializeObject<Sprint>(getJsonData(userName, null, "getSprint", token, null, null, null, projectID, sprintID));
            }
            catch { return null; }
        }
        public static string JoinProject(String userName, String token, int projectID)
        {
            return JsonConvert.DeserializeObject<string>(getJsonData(userName, null, "joinProject", token, null, null, null, projectID, 0));

        }
    }
}
