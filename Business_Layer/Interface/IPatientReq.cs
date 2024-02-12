using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Layer.Custom_Models;
using Data_Layer.DataModels;

namespace Business_Layer.Interface
{
    public interface IPatientReq
    {
        public void CreateASPuser(PatientReqCM patientReqCM, int ReqTypeId);
        public void AddInUser(PatientReqCM patientReqCM, string AspnetuserId);
        public void AddInRequest(PatientReqCM patientReqCM, int ReqTypeId);
        public void AddInRequestclient(PatientReqCM patientReqCM);
        public void AddInRequestwisefile(PatientReqCM patientReqCM);
    }
}
