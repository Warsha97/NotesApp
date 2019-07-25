using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using NoteApplication.DataAccess.Models;

namespace NoteApplication.DataAccess.Repository
{
    public interface INotesRepository
    {
        IEnumerable<NoteDTO> GetNotes();
        //Notes AddNote(Notes note);
        Boolean AddNote(NoteDTO note);
        //Notes AddNote(Notes note);
        Boolean DeleteNote(int id);
        NoteDTO UpdateNote(NoteDTO changedNote);
        IEnumerable<NoteDTO> GetNotesOfDate(DateTime date);
        void Save();


    }
}
