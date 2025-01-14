using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarikalarDemo.Interfaces
{
    public interface IEmailSender
    {
        public void SendEmail(string address, string photoUrl);
    }
}
