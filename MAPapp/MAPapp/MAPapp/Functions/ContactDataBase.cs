using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net;
using System.Diagnostics;
using Newtonsoft.Json;
namespace MAPapp {
    class ContactDataBase {

        //Opgeslagen waarden van de database
        public static string currentToken;
        public static string currentUserName;
        public static User currentUser;
    
        //Genereert de url voor contact met de database
        private static String CreateURL(String userName,String niewUserName, String passWord, String niewPassword, String command, String token, String fName, String lName, String joincode, int projectId, int sprintID, int taskid, string taskName, string taskDescription, int jspoints, int rroePoints, int timeCriticality, int Ucvalue, int ubvValue, string projectName, string projectDescription, DateTime startDate, string sprintName, int sprintDuration, int sprintTarget)
        {
            string url = "https://apihost.nl/map/api.php/?";
            switch (command)
            {
                case "signIn":
                    url += "_MAP_REST_REQUEST_=_MAP_AUTH_" + "&_MAP_USERNAME_=" + userName + "&_MAP_EPASS_=" + passWord;
                    break;
                case "signOut":
                    url += "_MAP_REST_REQUEST_=_MAP_TOKEN_DESTROY_" + "&_MAP_USERNAME_=" + userName + "&_MAP_AUTH_TOKEN_=" + token;
                    break;
                case "getProjectsUser":
                    url += "_MAP_REST_REQUEST_=_MAP_GET_PROJECTS_ALL_" + "&_MAP_USERNAME_=" + userName + "&_MAP_AUTH_TOKEN_=" + token;
                    break;
                case "createNewUser":
                    url += "_MAP_REST_REQUEST_=_MAP_INS_USER_&_MAP_USERNAME_=" + userName + "&_MAP_EPASS_=" + passWord + "&_MAP_INS_FNAME_=" + fName + "&_MAP_INS_LNAME_=" + lName + "&_MAP_JOIN_CODE_=" + joincode;
                    break;
                case "getInformation":
                    url += "_MAP_REST_REQUEST_=_MAP_GET_COMPONENTS_&_MAP_USERNAME_=" + userName + "&_MAP_AUTH_TOKEN_=" + token;
                    break;
                case "getTasks":
                    url += "_MAP_REST_REQUEST_=_MAP_GET_TASKS_&_MAP_USERNAME_=" + userName + "&_MAP_AUTH_TOKEN_=" + token + "&_MAP_PROJECT_ID_=" + projectId;
                    break;
                case "getSassasasasaprint":
                    url += "_MAP_REST_REQUEST_=_MAP_GET_SPRINT_&_MAP_USERNAME_=" + userName + "&_MAP_AUTH_TOKEN_=" + token + "&_MAP_SPRINT_ID_=" + sprintID + "&_MAP_PROJECT_ID_=" + projectId;
                    break;
                case "getSprint":
                    url += "_MAP_REST_REQUEST_=_MAP_GET_CURRENT_SPRINT_&_MAP_USERNAME_=" + userName + "&_MAP_AUTH_TOKEN_=" + token + "&_MAP_PROJECT_ID_=" + projectId;
                    break;
                case "joinProject":
                    url += "_MAP_REST_REQUEST_=_MAP_JOIN_PROJECT_&_MAP_AUTH_TOKEN_=" + token + "&_MAP_USERNAME_=" + userName + "&_MAP_PROJECT_ID_=" + projectId;
                    break;
                case "assingTask":
                    url += "_MAP_REST_REQUEST_=_MAP_ASSIGN_TASK_&_MAP_AUTH_TOKEN_=" + token + "&_MAP_USERNAME_=" + userName + "&_MAP_PROJECT_ID_=" + projectId + "&_MAP_TASK_ID_=" + taskid;
                    break;
                case "addTaskToSprint":
                    url += "_MAP_REST_REQUEST_=_MAP_ADD_TO_SPRINT_&_MAP_AUTH_TOKEN_=" + token + "&_MAP_USERNAME_=" + userName + "&_MAP_PROJECT_ID_=" + projectId + "&_MAP_TASK_ID_=" + taskid + "&_MAP_SPRINT_ID_=" + sprintID;
                    break;
                case "getUserInfo":
                    url += "_MAP_REST_REQUEST_=_MAP_GET_USER_INFO_&_MAP_AUTH_TOKEN_=" + token + "&_MAP_USERNAME_=" + userName;
                    break;
                case "addTaskToProject":
                    url += "_MAP_REST_REQUEST_=_MAP_INS_TASK_&_MAP_AUTH_TOKEN_=" + token + "&_MAP_USERNAME_=" + userName + "&_MAP_TASK_NAME_=" + taskName + "&_MAP_TASK_DESC_=" + taskDescription + "&_MAP_TASK_VAL_JS_=" + jspoints + "&_MAP_TASK_VAL_UBV_=" + ubvValue + "&_MAP_TASK_VAL_RROE_=" + rroePoints + "&_MAP_TASK_VAL_TC_=" + timeCriticality + "&_MAP_TASK_VAL_UC_=" + Ucvalue + "&_MAP_PROJECT_ID_=" + projectId;
                    break;
                case "createNewProject":
                    url += "_MAP_REST_REQUEST_=_MAP_INS_PROJECT_&_MAP_AUTH_TOKEN_=" + token + "&_MAP_USERNAME_=" + userName + "&_MAP_PROJECT_NAME_=" + projectName + "&_MAP_PROJECT_DESC_=" + projectDescription + "&_MAP_START_DATE_=" + startDate.ToString();
                    break;
                case "ChangePasword":
                    url += "_MAP_REST_REQUEST_=_MAP_UPDATE_USER_PASSWORD_&_MAP_AUTH_TOKEN_=" + token + "&_MAP_USERNAME_=" + userName + "&_MAP_NEW_PASSWORD_=" + niewPassword + "&_MAP_EPASS_=" + passWord;
                    break;
                case "ChangeEmail":
                    url += "_MAP_REST_REQUEST_=_MAP_UPDATE_USERNAME_&_MAP_AUTH_TOKEN_=" + token + "&_MAP_USERNAME_=" + userName + "&_MAP_EPASS_=" + passWord + "&_MAP_NEW_USERNAME_=" + niewUserName;
                    break;
                case "createNewSprint":
                    url += "_MAP_REST_REQUEST_=_MAP_INS_SPRINT_&_MAP_AUTH_TOKEN_=" + token + "&_MAP_USERNAME_=" + userName + "&_MAP_SPRINT_NAME_=" + sprintName + "&_MAP_SPRINT_DURATION_=" + sprintDuration + "&_MAP_SPRINT_TPOINTS_=" + sprintTarget + "&_MAP_START_DATE_=" + startDate + "&_MAP_PROJECT_ID_=" + projectId;
                    break;
                case "completeTask":
                    url += "_MAP_REST_REQUEST_=_MAP_COMPLETE_TASK_&_MAP_AUTH_TOKEN_=" + token + "&_MAP_USERNAME_=" + userName + "&_MAP_TASK_ID_=" + taskid + "&_MAP_PROJECT_ID_=" + projectId; ;
                    break;
                case "logOut":
                    url += "_MAP_REST_REQUEST_=_MAP_TOKEN_DESTROY_&_MAP_AUTH_TOKEN_=" + token + "&_MAP_USERNAME_=" + userName;
                    break;
            }
            return url;
        }
    
        //Haalt met de url uit CreateURL de data op uit de database
        private static String getJsonData(String username,  String command, String token = null, String password = null, String fName = null, String lName = null, String joincode = null, int projectId = 0, int sprintID= 0, int taskid = 0, string taskName = null, string taskDescription = null, int jspoints = 0, int rroePoints = 0, int timeCriticality = 0, int Ucvalue = 0, int ubvValue = 0, string projectName = null, string projectDescription = null, DateTime startDate = new DateTime(), string nieuwpasword = null, string sprintname = null, int sprintDuration = 0, int sprintTarget = 0, string nieuwUserName = null)
        {
            string url = CreateURL(username,nieuwUserName, password, nieuwpasword, command, token, fName, lName, joincode, projectId, sprintID, taskid, taskName, taskDescription, jspoints, rroePoints, timeCriticality, Ucvalue, ubvValue,projectName,projectDescription,startDate,sprintname,sprintDuration,sprintTarget);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.UserAgent = "ae30f0ddf72d";
            request.Proxy = null;
            try
            {
                WebResponse ws = request.GetResponse();
                Stream ReceiveStream = ws.GetResponseStream();
                Encoding encode = System.Text.Encoding.GetEncoding("utf-8");
                String s;         
                using (StreamReader reader = new StreamReader (ReceiveStream,encode)) {
                s = reader.ReadToEnd ();
                }
                return s;
            }
            catch { return "error"; }
        }

  //-----------------------------------------------------------------------------------------OPHALEN VAN DATA UIT DATABASE------------------------------------------------------------------------------------------      
        public static object GetProjects(String userName, String token)
        {
            try
            {
                return JsonConvert.DeserializeObject<List<Project>>(getJsonData(userName, "getProjectsUser", token: token));
            }
            catch { return null; }
           
            
        }
       
       
        public static object GetInformation(String userName, String token)
        {
            string s = getJsonData(userName, "getInformation", token: token);
            List<Tip> tips = JsonConvert.DeserializeObject<List<Tip>>(s);
            List<InformationObject> info = new List<InformationObject>();
            string compare = "";
            int i = 0;
            foreach (Tip t in tips)
            {
                // Als er een niewe pagina naam komt wordt er een nieuw informationobject aangemaakt
                if (t.pname != compare)
                {
                    info.Add(new InformationObject(new List<Tip> { t }, t.pname));
                    //Compare wordt de naam zodat er weer vergeleken kan worden
                    compare = t.pname;
                    i++;
                }
                else
                    info[i - 1].Tips.Add(t);
            }
            return info;
        }
        public static object GetTasks(String userName, String token, int projectId)
        {
            string s = getJsonData(userName, "getTasks",token: token,projectId: projectId);
            try
            {
                return JsonConvert.DeserializeObject<List<Task>>(s);
            }
            catch
            {
                return s;
            }
        }
        public static object GetSprint(String userName, String token, int projectID)
        {
            try
            {
                return JsonConvert.DeserializeObject<List<Sprint>>(getJsonData(userName, "getSprint", token: token, projectId: projectID))[0];
            }
            catch { return null; }
        }

//-------------------------------------------------------------------------CONTACT MET DATABASE ZONDER INFORMATIE OPHALEN-----------------------------------------------------------------------------------------------------------------------------------------------------------
        
        //Omdat deze methodes een string returnen is er geen try/catch nodig, want de JsonConvert slaagd altijd
        public static object JoinProject(String userName, String token, int projectID)
        {
            return JsonConvert.DeserializeObject<String>(getJsonData(userName, "joinProject", token: token, projectId: projectID));
        }
        public static object SingIn(String userName, String password)
        {
            return JsonConvert.DeserializeObject<String>(getJsonData(userName, "signIn", password: password));
        }
        public static object CreateUser(String userName, String password, String fName, String lName, String joincode)
        {
            return JsonConvert.DeserializeObject<String>(getJsonData(userName, "createNewUser", password: password, fName: fName, lName: lName, joincode: joincode));
        }
        public static object JoinTask(String userName, String token, int taskid, int projectid)
        {
            return JsonConvert.DeserializeObject<String>(getJsonData(userName, "assingTask", token: token, projectId: projectid,taskid: taskid));
        }
        public static object addTaskToSprint(String userName, String token, int taskid, int projectid, int sprintid)
        {
            return JsonConvert.DeserializeObject<String>(getJsonData(userName, "addTaskToSprint", token: token, projectId: projectid, sprintID: sprintid, taskid: taskid));
        }
        public static object addTaskToProject(String userName, String token, String taskName, String taskDescription, int projectId, int rroevalue, int jspoints, int Ubvalue, int timeCriticality, int uncCertainty)
        {
            return JsonConvert.DeserializeObject<String>(getJsonData(userName, "addTaskToProject", token: token, projectId: projectId, taskName: taskName,taskDescription: taskDescription,jspoints: jspoints,rroePoints: rroevalue,timeCriticality: timeCriticality,Ucvalue: uncCertainty,ubvValue: Ubvalue));
        }
        public static object GetUserInfo(String userName, String token)
        {
            return JsonConvert.DeserializeObject<List<User>>(getJsonData(userName, "getUserInfo", token: token))[0];
        }
        public static object createProject(String userName, String token, String projectName, String projectDescription, DateTime startDate)
        {
            return JsonConvert.DeserializeObject<String>(getJsonData(userName, "createNewProject", token: token, projectDescription: projectDescription, projectName: projectName,startDate: startDate));
        }
        public static object UpdatePasword(String userName, String token, String password, String nieuwpassword)
        {
            return JsonConvert.DeserializeObject<String>(getJsonData(userName, "ChangePasword", token:token, password:password, nieuwpasword:nieuwpassword ));
        }
        public static object UpdateEmail(String userName, String token, String password, String nieuwemail)
        {
            return JsonConvert.DeserializeObject<String>(getJsonData(userName, "ChangeEmail", token: token, password: password, nieuwUserName: nieuwemail));
        }
        public static object createNewSprint(String userName, String token, String sprintName, int sprintDuration, int sprintTarget, DateTime startDate, int projectId)
        {
            return JsonConvert.DeserializeObject<String>(getJsonData(userName, "createNewSprint", token: token, sprintname: sprintName, sprintTarget: sprintTarget,startDate: startDate, sprintDuration: sprintDuration, projectId: projectId));
        }
        public static object completeTask(String Username, String token, int taskID, int projectID)
        {
            return JsonConvert.DeserializeObject<String>(getJsonData(Username,"completeTask",token: token,taskid: taskID,projectId: projectID));
        }
        public static object logOut(String Username, String token)
        {
            return JsonConvert.DeserializeObject<String>(getJsonData(Username, "logOut", token: token));
        }


    }
}

