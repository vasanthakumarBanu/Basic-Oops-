using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Threading.Tasks;

namespace EBBiollCalculation
{
    public class EbCalc
    {
        private static int s_meterId=1000;
        private static int s_billId = 2000;
        public string UserName {get;set;}
        public string Mobile {get;set;}
        public string MailId  {get;set;}
        public string MeterId {get;}
        public string BillId {get;}
        public double Units {get; set;}

        public EbCalc(string userName,string mobile,string mailId,double units)
        {
            ++s_meterId;
            ++s_billId;
            MeterId = "EB"+ s_meterId;
            BillId = "ID" +s_billId;
            UserName = userName;
            Mobile = mobile;
            MailId = mailId;
            Units = 0;
        }
    }
}