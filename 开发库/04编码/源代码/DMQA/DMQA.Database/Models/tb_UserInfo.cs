namespace DMQA.Database.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_UserInfo
    {
        [Key]
        [StringLength(50)]
        public string Code { get; set; }

        [StringLength(200)]
        public string UserName { get; set; }

        [StringLength(50)]
        public string Password { get; set; }

        [StringLength(2)]
        public string Sex { get; set; }

        [StringLength(100)]
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
    }
}
