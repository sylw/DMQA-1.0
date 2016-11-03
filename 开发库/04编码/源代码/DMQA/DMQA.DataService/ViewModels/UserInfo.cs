using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMQA.DataService.ViewModels
{
    public class UserInfo
    {
        public string Code { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string Sex { get; set; }

        public string Email { get; set; }

        public int? Mark { get; set; }

        public int? RewardMark { get; set; }

        public int? PaidMark { get; set; }

        public int? ACount { get; set; }

        public int? AAcceptCount { get; set; }

        public int? QSolvedCount { get; set; }

        public int? QUnsolveCount { get; set; }

        public int? QCancelledCount { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string _state { get; set; }
    }
}
