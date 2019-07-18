using System;
using System.Collections.Generic;

namespace NoteApplication.Models
{
    public partial class Notes
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Note { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? LastUpdated { get; set; }
    }
}
