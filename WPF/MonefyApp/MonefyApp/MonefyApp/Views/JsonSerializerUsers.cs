using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;
using System.Security.Cryptography;

namespace MonefyApp.Views
{
    public class JsonSerializerUsers
    {
        public string Login { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public List<JsonSerializerUsers> Users { get; set; }


        public JsonSerializerUsers()
        {
            Users = new List<JsonSerializerUsers>();
        }

        public JsonSerializerUsers(string login, string password, string email)
        {
            Login = login;
            Password = password;
            Email = email;
        }

        public void SaveToJson(string filePath)
        {
            List<JsonSerializerUsers> users = LoadFromJson(filePath).Users;
            users.Add(this);
            string jsonString = JsonSerializer.Serialize(users);
            File.WriteAllText(filePath, jsonString);
        }

        public static JsonSerializerUsers LoadFromJson(string filePath)
        {
            if (File.Exists(filePath))
            {
                string jsonString = File.ReadAllText(filePath);
                return new JsonSerializerUsers { Users = JsonSerializer.Deserialize<List<JsonSerializerUsers>>(jsonString) };
            }
            return new JsonSerializerUsers();
        }

    }

}
