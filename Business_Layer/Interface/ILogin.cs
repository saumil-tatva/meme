using Data_Layer.DataContext;
using Data_Layer.DataModels;
using System;
using System.Collections.Generic;
using System.Linq; 
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.Interface
{
    public interface ILogin
    {
         Aspnetuser LoginAuthentication(Aspnetuser obj);
    }
}