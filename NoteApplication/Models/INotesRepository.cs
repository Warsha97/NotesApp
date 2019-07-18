using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NoteApplication.Models
{
    public interface INotesRepository
    {
        IEnumerable<Notes> GetNotes();
        //Notes AddNote(Notes note);
        int AddNote(Notes note);
        //Notes AddNote(Notes note);
        Notes DeleteNote(int id);
        Notes UpdateNote(Notes changedNote);
        IEnumerable<Notes> GetNotesOfDate(DateTime date);


    }
}
