namespace DMQA.Database.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_Answer
    {
        [Key]
        [StringLength(50)]
        public string Code { get; set; }

        [StringLength(50)]
        public string QuestionCode { get; set; }

        [StringLength(50)]
        public string UserCode { get; set; }

        [StringLength(200)]
        public string Title { get; set; }

        [Column(TypeName = "ntext")]
        public string Text { get; set; }

        public bool? BestAnswer { get; set; }

        public DateTime? PostDatetime { get; set; }

        public int? VoteNice { get; set; }

        public int? VoteBad { get; set; }
    }
}
