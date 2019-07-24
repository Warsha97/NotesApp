using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoteApplication.DataAccess.Models
{
    public class NoteDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Note { get; set; }
        public DateTime? Created { get; set; }
        
    }
}
