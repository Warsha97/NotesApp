using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace NoteApplication.Models
{
    public class NotesRepository : INotesRepository
    {
       // NotesDBContext db = new NotesDBContext();

        private readonly NotesDBContext _context;
        public NotesRepository(NotesDBContext context)
        {
            this._context = context;
        }

          /* public Notes AddNote(Notes note)
           {
               _context.Notes.Add(note);
               _context.SaveChanges();
               return note;
           } */

        public int AddNote(Notes note)
        {
            _context.Notes.Add(note);
            _context.SaveChanges();
            return 1;
        }

        public Notes DeleteNote(int id)
        {
            Notes note = _context.Notes.Find(id);
            if (note != null)
            {
                _context.Notes.Remove(note);
                _context.SaveChanges();
            }
            return note;
        }

        public IEnumerable<Notes> GetNotesOfDate(DateTime date)
        {

            List<Notes> list = new List<Notes>();
            try
            {
                //list = db.Notes.Select(n => new { n.Title, n.Note }).AsEnumerable();
                list = _context.Notes.Where(d => date == d.Created).ToList();
                return list;
                               
            }
            catch
            {
                throw;
            }
        }

        public IEnumerable<Notes> GetNotes()
        {
            //return _context.Notes;
            try
            {
                return _context.Notes.ToList();
            }
            catch
            {
                throw;
            }
        }

        public Notes UpdateNote(Notes changedNote)
        {
           _context.Entry(changedNote).State = EntityState.Modified;
            _context.SaveChanges();
            return changedNote;
        }

        
    }
}
