using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NoteApplication.Models;

namespace NoteApplication.BusinessService
{
    public class NoteService : INoteService
    {
        NotesDBContext _context = new NotesDBContext();

        private readonly INotesRepository _notesRepository;

        public NoteService(INotesRepository notesRepository)
        {
            _notesRepository = notesRepository;
        }

        // public NotesController(NotesDBContext context)
        //{
        //  _context = context;

        //if(_context.Notes.Count() == 0)
        //{
        //  _context.Notes.Add(new Notes { Note = "Note1" });
        //_context.SaveChanges();
        //}
        //}
        // GET: api/<controller>
        
        // [Route("api/[controller]/list")]
        public IEnumerable<Notes> GetNotesService()
        {
            
            return _notesRepository.GetNotes();
           // return View(_notesRepository.GetNotes());
        }
        
        public int AddNoteService(Notes note)
        {

            return _notesRepository.AddNote(note);
        }

        public Notes UpdateNoteService(Notes changedNote)
        {
            return _notesRepository.UpdateNote(changedNote);
            //return changedNote;
        }

        public Notes DeleteNoteService(int id)
        {
            return _notesRepository.DeleteNote(id);
        }

        
        public IEnumerable<Notes> GetNotesByDateService(DateTime selectedDate)
        {
            return _notesRepository.GetNotesOfDate(selectedDate);
        }

        
    }
}
