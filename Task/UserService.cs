using System.Text.Json;

namespace Task
{
    public class UserService
    {
        public List<User> Users { get; set; }
        public UserService()
        {
            Users = new List<User>();
            ReadUser();
        }

       public void WriteUsers()
       {
           var usersJson = JsonSerializer.Serialize(Users);
            File.WriteAllText("users.json",usersJson);
            ReadUser();
       }
        public void ReadUser()
        {
            var jsonDoc = File.ReadAllText("users.json");
            Users = JsonSerializer.Deserialize<List<User>>(jsonDoc);
        }
    }
}
