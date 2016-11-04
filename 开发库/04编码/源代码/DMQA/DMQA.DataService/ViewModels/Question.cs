using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace DMQA.DataService.ViewModels
{
    public class Question
    {
        public string Code { get; set; }

        public string CatalogCode { get; set; }

        public string  UserCode{ get; set; }

        public string Title { get; set; }

        public string Text { get; set; }

        public int? Mark { get; set; }

        public DateTime? PostDatetime { get; set; }

        public int? Type { get; set; }

        public string _state { get; set; }
    }
}
