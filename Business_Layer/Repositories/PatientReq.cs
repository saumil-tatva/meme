using Business_Layer.Interface;
using Data_Layer.Custom_Models;
using Data_Layer.DataContext;
using Data_Layer.DataModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.Repositories
{
    public class PatientReq : IPatientReq
    {
        private readonly ApplicationDbContext _db;
        public PatientReq(ApplicationDbContext db)
        {
            _db = db;
        }
        public void CreateASPuser(PatientReqCM patientReqCM, int ReqTypeId)
        {
            Aspnetuser?aspnetuser = _db.Aspnetusers.FirstOrDefault(i=>i.Email== patientReqCM.Email);
            if (aspnetuser==null)
            {
                if (patientReqCM.PasswordHash==patientReqCM.ConfirmPasswordHash)
                {
                    var data = new Aspnetuser()
                    {
                        Id = Guid.NewGuid().ToString(),
                        Email = patientReqCM.Email,
                        Username = patientReqCM.FirstName + "_" + patientReqCM.LastName,
                        Passwordhash = patientReqCM.PasswordHash,
                        Phonenumber = patientReqCM.Phone,
                    };
                    _db.Aspnetusers.Add(data);
                    _db.SaveChanges();
                }
                Aspnetuser?newaspnetuser = _db.Aspnetusers.FirstOrDefault(i=>i.Email== patientReqCM.Email);
                AddInUser(patientReqCM, newaspnetuser.Id);
            }
            else
            {
                string AspnetuserId = aspnetuser.Id;
                if(!_db.Aspnetusers.Any(i => i.Email == aspnetuser.Email))
                {
                    AddInUser(patientReqCM, AspnetuserId);
                }
            }
            AddInRequest(patientReqCM, ReqTypeId);

            if (patientReqCM.Upload != null)
            {
                AddInRequestwisefile(patientReqCM);
            }

            AddInRequestclient(patientReqCM);
        }
        public void AddInUser(PatientReqCM patientReqCM, string AspnetuserId)
        {
            var data1 = new User
            {
                Firstname = patientReqCM.FirstName,
                Lastname = patientReqCM.LastName,
                Email = patientReqCM.Email,
                Mobile = patientReqCM.Phone,
                Street = patientReqCM.Street,
                City = patientReqCM.City,
                State = patientReqCM.State,
                Zipcode = patientReqCM.Zipcode,
                Aspnetuserid = AspnetuserId,
                Createdby = AspnetuserId,
                Modifiedby = AspnetuserId,

            };
            _db.Users.Add(data1);
            _db.SaveChanges();
        }
        public void AddInRequest(PatientReqCM patientReqCM, int ReqTypeId)
        {
            User? user = _db.Users.FirstOrDefault(i => i.Email==patientReqCM.Email );
            var data2 = new Request() 
            {
                Firstname = user.Firstname,
                Lastname = user.Lastname,
                Email = user.Email,
                Phonenumber = user.Mobile,
                Userid = user.Userid,
                Status = 1,
                //custom
                Requesttypeid = ReqTypeId, 
            };
            _db.Requests.Add(data2);
            _db.SaveChanges();
        }
        public void AddInRequestclient(PatientReqCM patientReqCM)
        {
            Request? request = _db.Requests.FirstOrDefault(i => i.Email == patientReqCM.Email);

            int requestid = request.Requestid;

            var data3 = new Requestclient()
            {
                Firstname = patientReqCM.FirstName,
                Lastname = patientReqCM.LastName,
                Email = patientReqCM.Email,
                Phonenumber = patientReqCM.Phone,
                Street = patientReqCM.Street,
                City = patientReqCM.City,
                State = patientReqCM.State,
                Zipcode = patientReqCM.Zipcode,

                Requestid = requestid,
            };

            _db.Requestclients.Add(data3);
            _db.SaveChanges();
        }
        public void AddInRequestwisefile(PatientReqCM patientReqCM)
        {
            string filename = patientReqCM.Upload.FileName;
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Documents", filename);
            IFormFile file = patientReqCM.Upload;

            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                file.CopyTo(fileStream);
            }

            Request? req = _db.Requests.FirstOrDefault(i => i.Email == patientReqCM.Email);
            int ReqId = req.Requestid;

            var data3 = new Requestwisefile()
            {
                Requestid = ReqId,
                Filename = filename,
            };

            _db.Requestwisefiles.Add(data3);
            _db.SaveChanges();

        }
    }
}
