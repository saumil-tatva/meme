using Business_Layer.Interface;
using Data_Layer.DataContext;
using Data_Layer.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.Repositories
{
    public class Login : ILogin
    {
        private readonly ApplicationDbContext _db;
        public Login(ApplicationDbContext db)
        {
            _db = db;
        }
        public Aspnetuser LoginAuthentication(Aspnetuser obj)
        {
            var user = _db.Aspnetusers.FirstOrDefault(x => x.Email == obj.Email && x.Passwordhash == obj.Passwordhash);
            return user;
        }
    }
}