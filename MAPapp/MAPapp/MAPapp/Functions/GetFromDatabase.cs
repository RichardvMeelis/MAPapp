using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net;
using System.Diagnostics;
using Newtonsoft.Json;
namespace MAPapp {
    class GetFromDatabase {
        public static string currentToken;
        public static string currentUserName;
        public static User currentUser;
        static Stopwatch s = new Stopwatch();
        private static String CreateURL(String userName, String passWord, String command, String token, String fName, String lName, String joincode, int projectId, int sprintID, int taskid, string taskName, string taskDescription, int jspoints, int rroePoints, int timeCriticality, int Ucvalue, int ubvValue)
        {

            string url = "https://apihost.nl/map/api.php/?";
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
            else if (command == "getSassasasasaprint")
            {
                url += "_MAP_REST_REQUEST_=_MAP_GET_SPRINT_&_MAP_USERNAME_=" + userName + "&_MAP_AUTH_TOKEN_=" + token + "&_MAP_SPRINT_ID_=" + sprintID + "&_MAP_PROJECT_ID_=" + projectId;
            }
            else if (command == "getSprint")
            {
                url += "_MAP_REST_REQUEST_=_MAP_GET_CURRENT_SPRINT_&_MAP_USERNAME_=" + userName + "&_MAP_AUTH_TOKEN_=" + token + "&_MAP_PROJECT_ID_=" + projectId;
            }
            else if (command == "joinProject")
            {
                url += "_MAP_REST_REQUEST_=_MAP_JOIN_PROJECT_&_MAP_AUTH_TOKEN_=" + token + "&_MAP_USERNAME_=" + userName + "&_MAP_PROJECT_ID_=" + projectId;
            }
            else if (command == "assingTask")
            {
                url += "_MAP_REST_REQUEST_=_MAP_ASSIGN_TASK_&_MAP_AUTH_TOKEN_=" + token + "&_MAP_USERNAME_=" + userName + "&_MAP_PROJECT_ID_=" + projectId + "&_MAP_TASK_ID_=" + taskid;
            }
            else if (command == "addTaskToSprint")
            {
                url += "_MAP_REST_REQUEST_=_MAP_ADD_TO_SPRINT_&_MAP_AUTH_TOKEN_=" + token + "&_MAP_USERNAME_=" + userName + "&_MAP_PROJECT_ID_=" + projectId + "&_MAP_TASK_ID_=" + taskid + "&_MAP_SPRINT_ID_=" + sprintID;
            }
            else if (command == "getUserInfo")
            {
                url += "_MAP_REST_REQUEST_=_MAP_GET_USER_INFO_&_MAP_AUTH_TOKEN_=" + token + "&_MAP_USERNAME_=" + userName;
            }
            else if (command == "addTaskToProject")
            {
                url += "_MAP_REST_REQUEST_=_MAP_INS_TASK_&_MAP_AUTH_TOKEN_=" + token + "&_MAP_USERNAME_=" + userName + "&_MAP_TASK_NAME_=" + taskName + "&_MAP_TASK_DESC_=" + taskDescription + "&_MAP_TASK_VAL_JS_=" + jspoints + "&_MAP_TASK_VAL_UBV_=" + ubvValue + "&_MAP_TASK_VAL_RROE_=" + rroePoints + "&_MAP_TASK_VAL_TC_=" + timeCriticality + "&_MAP_TASK_VAL_UC_=" + Ucvalue + "&_MAP_PROJECT_ID_=" + projectId;
            }

            return url;
        }

        private static String getJsonData(String username, String password, String command, String token, String fName, String lName, String joincode, int projectId, int sprintID, int taskid, string taskName, string taskDescription, int jspoints, int rroePoints, int timeCriticality, int Ucvalue, int ubvValue)
        {
            string url = CreateURL(username, password, command, token, fName, lName, joincode, projectId, sprintID, taskid, taskName, taskDescription, jspoints, rroePoints, timeCriticality, Ucvalue, ubvValue);
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

        public static object GetProjects(String userName, String token)
        {

            List<Project> s = JsonConvert.DeserializeObject<List<Project>>(getJsonData(userName, null, "getProjectsUser", token, null, null, null, 0, 0, 0, null, null, 0, 0, 0, 0, 0));
            return s;
        }
        public static object SingIn(String userName, String password)
        {
            // s.Start();
            String z = JsonConvert.DeserializeObject<String>(getJsonData(userName, password, "signIn", null, null, null, null, 0, 0, 0, null, null, 0, 0, 0, 0, 0));

            return z;
        }
        public static object CreateUser(String userName, String password, String fName, String lName, String joincode)
        {
            string s = getJsonData(userName, password, "createNewUser", null, fName, lName, joincode, 0, 0, 0, null, null, 0, 0, 0, 0, 0);
            return JsonConvert.DeserializeObject<String>(s);
        }
        public static object GetInformation(String userName, String token)
        {
            string s = getJsonData(userName, null, "getInformation", token, null, null, null, 0, 0, 0, null, null, 0, 0, 0, 0, 0);
            List<Tip> tips = JsonConvert.DeserializeObject<List<Tip>>(s);
            List<InformationObject> info = new List<InformationObject>();
            string stringetje = "";
            int i = 0;
            foreach (Tip t in tips)
            {
                if (t.pname != stringetje)
                {
                    info.Add(new InformationObject(new List<Tip> { t }, t.pname));
                    stringetje = t.pname;
                    i++;
                }
                else
                {
                    info[i - 1].Tips.Add(t);
                }
            }
            return info;
        }
        public static object GetTasks(String userName, String token, int projectId)
        {
            string s = getJsonData(userName, null, "getTasks", token, null, null, null, projectId, 0, 0, null, null, 0, 0, 0, 0, 0);
            try
            {
                return JsonConvert.DeserializeObject<List<Task>>(s);
            }
            catch
            {
                return s;//return new List<Task>() { new Task(new DateTime(), null, null, 0, 0, 0, null, 0, 0, 0) {HasAccess = false } };
            }
        }
        public static object GetSprint(String userName, String token, int projectID)
        {
            try
            {
                return JsonConvert.DeserializeObject<List<Sprint>>(getJsonData(userName, null, "getSprint", token, null, null, null, projectID, 0, 0, null, null, 0, 0, 0, 0, 0))[0];
            }
            catch { return null; }
        }
        public static object JoinProject(String userName, String token, int projectID)
        {
            return JsonConvert.DeserializeObject<string>(getJsonData(userName, null, "joinProject", token, null, null, null, projectID, 0, 0, null, null, 0, 0, 0, 0, 0));

        }
        public static object JoinTask(String userName, String token, int taskid, int projectid)
        {
            return JsonConvert.DeserializeObject<String>(getJsonData(userName, null, "assingTask", token, null, null, null, projectid, 0, taskid, null, null, 0, 0, 0, 0, 0));
        }
        public static object addTaskToSprint(String userName, String token, int taskid, int projectid, int sprintid)
        {
            return JsonConvert.DeserializeObject<String>(getJsonData(userName, null, "addTaskToSprint", token, null, null, null, projectid, sprintid, taskid, null, null, 0, 0, 0, 0, 0));
        }
        public static object addTaskToProject(String userName, String token, String taskName, String taskDescription, int projectId, int rroevalue, int jspoints, int Ubvalue, int timeCriticality, int uncCertainty)
        {
            return JsonConvert.DeserializeObject<String>(getJsonData(userName, null, "addTaskToProject", token, null, null, null, projectId, 0, 0, taskName, taskDescription, jspoints, rroevalue, timeCriticality, uncCertainty, Ubvalue));
        }
        public static object GetUserInfo(String userName, String token)
        {
            return JsonConvert.DeserializeObject<List<User>>(getJsonData(userName, null, "getUserInfo", token, null, null, null, 0, 0, 0, null, null, 0, 0, 0, 0, 0))[0];
        }


    }
}

