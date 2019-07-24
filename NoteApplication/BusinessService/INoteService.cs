using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NoteApplication.DataAccess;
using NoteApplication.DataAccess.Models;

namespace NoteApplication.BusinessService
{
    public interface INoteService
    {
        IEnumerable<NoteDTO> GetNotesService();
        Boolean AddNoteService(NoteDTO note);
        NoteDTO UpdateNoteService(NoteDTO changedNote);
        Boolean DeleteNoteService(int id);
        IEnumerable<NoteDTO> GetNotesByDateService(DateTime selectedDate);
    }
}
