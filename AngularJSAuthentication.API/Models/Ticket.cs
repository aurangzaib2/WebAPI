using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AngularJSAuthentication.API.Models
{
    public class Ticket
    {
        [Key]
        public long TicketID { get; set; }
        public long CustomerID { get; set; }
        public DateTime CreatedDate { get; set; }
        public long CreatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public long UpdatedBy { get; set; }
        public bool IsArchived { get; set; }
        public long NoteID { get; set; }
    }
}