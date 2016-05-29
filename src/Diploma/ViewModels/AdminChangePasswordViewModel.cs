using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diploma.ViewModels
{
    public class AdminChangePasswordViewModel
    {
        public string NewPassword { get; set; }
        public string OldPassword { get; set; }
        public string UserName { get; set; }
    }
}
