using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllinOne.Entity.ViewModel
{
    public class RESTfulResult
    {
        [Key]
        public int StatusCode { get; set; }
        public bool Succeeded { get; set; }
        public object Data { get; set; }
        public string Message { get; set; }
        public long Timestamp { get { return DateTimeOffset.UtcNow.ToUnixTimeMilliseconds(); } }
    }
}
