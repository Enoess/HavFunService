using System;
using HavFunService.DTOs;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;

namespace HavFunService
{
    public class Service1 : IService1
    {
        public string GetData(int value)
        {
            return string.Format("You entered:" + value);
        }
        public string GetNumber()
        {
            return string.Format("You entered 2");
        }

        private MySqlDataReader RequestDatabase(string request)
        {
            MySqlDataReader reader=null;
            var dbCon = DBConnection.Instance();
            dbCon.DatabaseName = "HavFun";
            if (dbCon.IsConnect())
            {
                //suppose col0 and col1 are defined as VARCHAR in the DB
                string query = request;
                var cmd = new MySqlCommand(query, dbCon.Connection);
                reader = cmd.ExecuteReader();
                //while (reader.Read())
                //{
                //    string someStringFromColumnZero = reader.GetString(0);
                //    string someStringFromColumnOne = reader.GetString(1);
                //    Console.WriteLine(someStringFromColumnZero + "," + someStringFromColumnOne);
                //}
                //dbCon.Close();
            }
            return reader;
        }
        public string SubscribeHavFun(string data)
        {
            SubscribeHaveFunDTO shDTO = JsonConvert.DeserializeObject<SubscribeHaveFunDTO>(data);
            if (RequestDatabase(string.Format("INSERT INTO Utilisateur  VALUES ('', '{0}','{1}','{2}','{3}','{4}','{5}','{6}')", 
                shDTO.Nom, 
                shDTO.Prenom, 
                shDTO.Tel, 
                shDTO.Mail, 
                shDTO.Longi, 
                shDTO.Lati, 
                shDTO.Password)) != null)
                return "Request Succeed";
            else
                return "error";
        }

        public string SubscribeToBar(SubscribeToBarDTO stbDTO)
        {
            
            if (RequestDatabase(string.Format("INSERT INTO  Abonnement VALUES (' ', '{0}','{1}')", stbDTO.UserId, stbDTO.BarId)) != null)
                return "Request Succeed";
            else
                return "error";
        }

        public string PostComment(PostCommentDTO pcDTO)
        {
            if (RequestDatabase(string.Format("INSERT INTO Avis  VALUES (' ', '{0}','{1}','{2}','{3}')", pcDTO.Comment, pcDTO.Note, pcDTO.BarId, pcDTO.UserId)) != null)
                return "Request Succeed";
            else
                return "error";
        }

        public string PostEvent(PostEventDTO peDTO)
        {
            if (RequestDatabase(string.Format("INSERT INTO Event  VALUES (' ', '{0}','{1}','{2}','{3}')", peDTO.EventName, peDTO.EventDescription,peDTO.EventDate,peDTO.BarId)) != null)
                return "Request Succeed";
            else
                return "error";
        }
        public string LoginToHavFun(LoginToHavFunDTO lthfDTO)
        {
            MySqlDataReader reader = RequestDatabase("SELECT Nom_user,Prenom_user FROM Utilisateur");
            if (reader != null)
            {
                if(lthfDTO.Login == reader.GetString(0) && lthfDTO.Password == reader.GetString(1))
                    return "Connection Succeed";
                else
                    return "Connection error";
            }
            else
            {
                return "error";
            }

        }


    }
}
