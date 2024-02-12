//using Business_Layer.Interface;
//using Data_Layer.Custom_Models;
//using Data_Layer.DataContext;
//using Data_Layer.DataModels;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net.Mail;
//using System.Net;
//using System.Text;
//using System.Threading.Tasks;

//namespace Business_Layer.Repositories
//{
//    public class FamilyFrndReq : IFamilyFrndReq
//    {
//        private readonly ApplicationDbContext _db;
//        public FamilyFrndReq(ApplicationDbContext db)
//        {
//            _db = db;
//        }
//        public void CreateASPuser(FamilyFrndReqCM familyFrndReqCM, int ReqTypeId)
//        {
//            Aspnetuser?aspnetuser = _db.Aspnetusers.FirstOrDefault(i=>i.Email== familyFrndReqCM.Email);
//            if (aspnetuser == null)
//            {
//                var receiver = familyFrndReqCM.Email;
//                var subject = "Create Account";
//                var message = "Tap on link for Create Account: https://localhost:7173/Patient/patient_signup_page";

//                EmailSendar(receiver, subject, message);

//            }

//            AddInRequest(familyFrndReqCM, ReqTypeId);

//            if (familyFrndReqCM.Upload != null)
//            {
//                AddInRequestwisefile(familyFrndReqCM);
//            }

//            AddInRequestclient(familyFrndReqCM);
//        }
//        public Task EmailSendar(string email, string subject, string message)
//        {
//            var mail = "samspamm17@gmail.com";
//            var password = "yctr xtfl prjb pmwz";

//            var client = new SmtpClient("smtp.gmail.com", 587)
//            {
//                EnableSsl = true,
//                Credentials = new NetworkCredential(mail, password)
//            };

//            return client.SendMailAsync(new MailMessage(from: mail, to: email, subject, message));

//        }
//        public void AddInRequest(FamilyFrndReqCM familyFrndReqCM, int ReqTypeId)
//        {
//            User? user = _db.Users.FirstOrDefault(i => i.Email==familyFrndReqCM.Email );
//            var data2 = new Request() 
//            {
//                Firstname = familyFrndReqCM.FamilyFName,
//                Lastname = familyFrndReqCM.FamilyLName,
//                Email = familyFrndReqCM.FamilyEmail,
//                Phonenumber = familyFrndReqCM.FamilyPhone,
//                Relationname = familyFrndReqCM.FamilyRelation,
//                Userid = user.Userid,
//                Status = 1,
//                //custom
//                Requesttypeid = ReqTypeId, 
//            };
//            _db.Requests.Add(data2);
//            //var id = data2.Requestid;
//            _db.SaveChanges();
//        }
//        public void AddInRequestclient(FamilyFrndReqCM familyFrndReqCM)
//        {
//            //Request? request = _db.Requests.FirstOrDefault(i => i.Email == familyFrndReqCM.Email);

//            //int requestid = request.Requestid;

//            //var data3 = new Requestclient()
//            //{
//            //    Firstname = patientReqCM.FirstName,
//            //    Lastname = patientReqCM.LastName,
//            //    Email = patientReqCM.Email,
//            //    Phonenumber = patientReqCM.Phone,
//            //    Street = patientReqCM.Street,
//            //    City = patientReqCM.City,
//            //    State = patientReqCM.State,
//            //    Zipcode = patientReqCM.Zipcode,

//            //    Requestid = requestid,
//            //};

//            //_db.Requestclients.Add(data3);
//            //_db.SaveChanges();
//        }
//        public void AddInRequestwisefile(FamilyFrndReqCM familyFrndReqCM)
//        {
//            //string filename = patientReqCM.Upload.FileName;
//            //string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Documents", filename);
//            //IFormFile file = patientReqCM.Upload;

//            //using (var fileStream = new FileStream(path, FileMode.Create))
//            //{
//            //    file.CopyTo(fileStream);
//            //}

//            //Request? req = _db.Requests.FirstOrDefault(i => i.Email == patientReqCM.Email);
//            //int ReqId = req.Requestid;

//            //var data3 = new Requestwisefile()
//            //{
//            //    Requestid = ReqId,
//            //    Filename = filename,
//            //};

//            //_db.Requestwisefiles.Add(data3);
//            //_db.SaveChanges();

//        }
//    }
//}








////        public void InsretFamilyFriendRequest(FamilyFriendRequestVM obj)
////        {

////            Request _request = new Request();
////            Requestclient _requestclient = new Requestclient();
////            Requestwisefile _requestwisefile = new Requestwisefile();

////            _request.Requesttypeid = 3;//3 is for request type Family Friend
////            request.Userid = db.Users.FirstOrDefault(x => x.Email == obj.email).Userid; ;
////            _request.Firstname = obj.family_first_name;
////            _request.Lastname = obj.family_last_name;
////            _request.Email = obj.family_email;
////            _request.Phonenumber = obj.family_phone;
////            _request.Status = 1;//1 is for Unassigned
////            _request.Confirmationnumber = obj.firstname.Substring(0, 2) + DateTime.Now.ToString().Substring(0, 19).Replace(" ", "");//here do Logic For unique Confirmation number that will be used by requestclient to fetch particular request from Request table
////            _request.Createddate = DateTime.Now;
////            //_request.Isurgentemailsent = new BitArray(0);

////            _db.Requests.Add(_request);
////            _db.SaveChanges();

////            requestclient.Requestid = db.Requests.FirstOrDefault(x => x.Confirmationnumber == _request.Confirmationnumber).Requestid; ;
////            _requestclient.Notes = obj.symptoms;
////            _requestclient.Firstname = obj.firstname;
////            _requestclient.Lastname = obj.lastname;
////            _requestclient.Email = obj.email;
////            _requestclient.Phonenumber = obj.phone;
////            _requestclient.Address = obj.street + " " + obj.city + " " + obj.state + " " + obj.zipcode;
////            _requestclient.Intdate = Convert.ToInt16(obj.dateofbirth.Substring(8, 2));
////            _requestclient.Intyear = Convert.ToInt16(obj.dateofbirth.Substring(0, 4));
////            _requestclient.Strmonth = obj.dateofbirth.Substring(5, 2);
////            _requestclient.City = obj.city;
////            _requestclient.State = obj.state;
////            _requestclient.Street = obj.street;

////            _db.Requestclients.Add(_requestclient);
////            _db.SaveChanges();

////            requestwisefile.Requestid = db.Requests.FirstOrDefault(x => x.Confirmationnumber == _request.Confirmationnumber).Requestid;
////            _requestwisefile.Filename = obj.Upload.FileName;

////            _db.Requestwisefiles.Add(_requestwisefile);
////            _db.SaveChanges();
////        }

////        public void InsretBusinessRequest(BusinessRequestVM obj)
////        {
////            Business _business = new Business();
////            Request _request = new Request();
////            Requestclient _requestclient = new Requestclient();
////            // Requestwisefile _requestwisefile = new Requestwisefile();

////            _request.Requesttypeid = 1;//1 is for request type Business
////            request.Userid = db.Users.FirstOrDefault(x => x.Email == obj.email).Userid; ;
////            _request.Firstname = obj.business_first_name;
////            _request.Lastname = obj.business_last_name;
////            _request.Email = obj.business_email;
////            _request.Phonenumber = obj.business_phone;
////            _request.Casenumber = obj.business_case_number;
////            _request.Status = 1;//1 is for Unassigned
////            _request.Confirmationnumber = obj.firstname.Substring(0, 2) + DateTime.Now.ToString().Substring(0, 19).Replace(" ", "");//here do Logic For unique Confirmation number that will be used by requestclient to fetch particular request from Request table
////            _request.Createddate = DateTime.Now;
////            //_request.Isurgentemailsent = new BitArray(0);

////            _db.Requests.Add(_request);
////            _db.SaveChanges();

////            requestclient.Requestid = db.Requests.FirstOrDefault(x => x.Confirmationnumber == _request.Confirmationnumber).Requestid; ;
////            _requestclient.Notes = obj.symptoms;
////            _requestclient.Firstname = obj.firstname;
////            _requestclient.Lastname = obj.lastname;
////            _requestclient.Email = obj.email;
////            _requestclient.Phonenumber = obj.phone;
////            _requestclient.Address = obj.street + " " + obj.city + " " + obj.state + " " + obj.zipcode;
////            _requestclient.Intdate = Convert.ToInt16(obj.dateofbirth.Substring(8, 2));
////            _requestclient.Intyear = Convert.ToInt16(obj.dateofbirth.Substring(0, 4));
////            _requestclient.Strmonth = obj.dateofbirth.Substring(5, 2);
////            _requestclient.City = obj.city;
////            _requestclient.State = obj.state;
////            _requestclient.Street = obj.street;

////            _db.Requestclients.Add(_requestclient);
////            _db.SaveChanges();

////            // requestwisefile.Requestid = db.Requests.FirstOrDefault(x => x.Confirmationnumber == _request.Confirmationnumber).Requestid;
////            // _requestwisefile.Filename = obj.Upload.FileName;

////            //_db.Requestwisefiles.Add(_requestwisefile);
////            //_db.SaveChanges();

////            _business.Name = obj.business_name;
////            _business.Phonenumber = obj.business_phone;
////            _db.Businesses.Add(_business);
////            _db.SaveChanges();
////        }
////        public void InsretConciegerRequest(ConciegerRequestVM obj)
////        {
////            Request _request = new Request();
////            Requestclient _requestclient = new Requestclient();
////            // Requestwisefile _requestwisefile = new Requestwisefile();

////            _request.Requesttypeid = 1;//1 is for request type Business
////            request.Userid = db.Users.FirstOrDefault(x => x.Email == obj.email).Userid; ;
////            _request.Firstname = obj.concieger_first_name;
////            _request.Lastname = obj.concieger_last_name;
////            _request.Email = obj.concieger_email;
////            _request.Phonenumber = obj.concieger_phone;

////            _request.Status = 1;//1 is for Unassigned
////            _request.Confirmationnumber = obj.firstname.Substring(0, 2) + DateTime.Now.ToString().Substring(0, 19).Replace(" ", "");//here do Logic For unique Confirmation number that will be used by requestclient to fetch particular request from Request table
////            _request.Createddate = DateTime.Now;
////            //_request.Isurgentemailsent = new BitArray(0);

////            _db.Requests.Add(_request);
////            _db.SaveChanges();

////            requestclient.Requestid = db.Requests.FirstOrDefault(x => x.Confirmationnumber == _request.Confirmationnumber).Requestid; ;
////            _requestclient.Notes = obj.symptoms;
////            _requestclient.Firstname = obj.firstname;
////            _requestclient.Lastname = obj.lastname;
////            _requestclient.Email = obj.email;
////            _requestclient.Phonenumber = obj.phone;
////            _requestclient.Address = obj.street + " " + obj.city + " " + obj.state + " " + obj.zipcode;
////            _requestclient.Intdate = Convert.ToInt16(obj.dateofbirth.Substring(8, 2));
////            _requestclient.Intyear = Convert.ToInt16(obj.dateofbirth.Substring(0, 4));
////            _requestclient.Strmonth = obj.dateofbirth.Substring(5, 2);
////            _requestclient.City = obj.city;
////            _requestclient.State = obj.state;
////            _requestclient.Street = obj.street;

////            _db.Requestclients.Add(_requestclient);
////            _db.SaveChanges();

////            // requestwisefile.Requestid = db.Requests.FirstOrDefault(x => x.Confirmationnumber == _request.Confirmationnumber).Requestid;
////            // _requestwisefile.Filename = obj.Upload.FileName;

////            //_db.Requestwisefiles.Add(_requestwisefile);
////            //_db.SaveChanges();


////        }
////    }
////}
