using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NoteApplication.Models;

namespace NoteApplication.BusinessService
{
    public interface INoteService
    {
        IEnumerable<Notes> GetNotesService();
        int AddNoteService(Notes note);
        Notes UpdateNoteService(Notes changedNote);
        Notes DeleteNoteService(int id);
        IEnumerable<Notes> GetNotesByDateService(DateTime selectedDate);
    }
}
