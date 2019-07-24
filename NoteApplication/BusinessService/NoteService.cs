using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NoteApplication.DataAccess;
using NoteApplication.DataAccess.Models;
using NoteApplication.DataAccess.Repository;

namespace NoteApplication.BusinessService
{
    public class NoteService : INoteService
    {
        private readonly INotesRepository _notesRepository;

        public NoteService(INotesRepository notesRepository)
        {
            this._notesRepository = notesRepository;
        }

        
        public IEnumerable<NoteDTO> GetNotesService()
        {

            return _notesRepository.GetNotes();
            
        }

        public Boolean AddNoteService(NoteDTO note)
        {
            if(note.Id < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            return _notesRepository.AddNote(note);
        }

        public NoteDTO UpdateNoteService(NoteDTO changedNote)
        {
            if(changedNote.Id < 0)
            {
                return null;
            }

           // _notesRepository.UpdateNote(changedNote);
            _notesRepository.Save();
            return _notesRepository.UpdateNote(changedNote);
            //return changedNote;
            //return _notesRepository.UpdateNote(changedNote);
            
        }

        public Boolean DeleteNoteService(int id)
        {
            if (id < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
          //  _notesRepository.DeleteNote(id);
          //  _notesRepository.Save();
            return _notesRepository.DeleteNote(id);
        }


        public IEnumerable<NoteDTO> GetNotesByDateService(DateTime selectedDate)
        {
            return _notesRepository.GetNotesOfDate(selectedDate);
        }


    }
}
