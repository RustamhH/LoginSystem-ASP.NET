using Login_System.Models;
using System.Reflection.Metadata.Ecma335;

namespace Login_System.Services
{
    public static class Database
    {
        public static List<User> Users { get; set; }=new List<User>();
        
        static Database() 
        {
            Users = JsonHandling.ReadData<List<User>>("users");
        }

    }
}
