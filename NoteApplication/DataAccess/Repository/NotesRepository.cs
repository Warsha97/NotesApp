using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.EntityFrameworkCore;
using NoteApplication.DataAccess.Models;
using NoteApplication.DataAccess.DBContext;
using Serilog;

namespace NoteApplication.DataAccess.Repository
{
    public class NotesRepository : INotesRepository
    {
        // NotesDBContext db = new NotesDBContext();

        private readonly NotesDBContext _context;
        public NotesRepository(NotesDBContext context)
        {
            this._context = context;
        }

        
        public Boolean AddNote(NoteDTO notedto)
        {
            try
            {
                Notes note = new Notes
                {
                    Title = notedto.Title,
                    Note = notedto.Note,
                    Created = DateTime.Now,
                    LastUpdated = DateTime.Now
                };
                _context.Notes.Add(note);
                _context.SaveChanges();
                return true;
            }


            catch (Exception exception)
            {

                Log.Error(exception, exception.Message);
                throw new Exception(exception.Message);


            }
        }

        public Boolean DeleteNote(int id)
        {
            try
            {
                Notes note = new Notes
                {
                    Id = id
                };

                note = _context.Notes.Find(id);
               
                NoteDTO retnote = new NoteDTO
                {
                    Id = note.Id,
                    Title = note.Title,
                    Note = note.Note,
                    Created = note.Created
                };
                _context.Notes.Remove(note);
                _context.SaveChanges();
                return true;
            }


            catch (Exception exception)
            {

                Log.Error(exception, exception.Message);
                throw new Exception(exception.Message);


            }


        }

        public IEnumerable<NoteDTO> GetNotesOfDate(DateTime date)
        {


            List<Notes> list = new List<Notes>();
            //NoteDTO notedto = new NoteDTO();
            //Notes note = new Notes();
            try
            {
                var notes = new List<NoteDTO>();
                //return notes;
                list = _context.Notes.Where(d => d.Created == date).ToList();

                foreach (Notes element in list)
                {
                    var note = new NoteDTO()
                    {
                        Title = element.Title,
                        Note = element.Note,
                    };
                    notes.Add(note);

                }
                return notes;
                               
            }
            catch (Exception exception)
            {

                Log.Error(exception, exception.Message);
                throw new Exception(exception.Message);


            }
        }

        public IEnumerable<NoteDTO> GetNotes()
        {
            
            List<Notes> list = new List<Notes>();
            
            try
            {
                var notes = new List<NoteDTO>();
                
                list = _context.Notes.OrderBy(d => d.Created).ToList();

                foreach (Notes element in list)
                {
                    var note = new NoteDTO()
                    {
                        Id = element.Id,
                        Title = element.Title,
                        Note = element.Note,
                        Created = element.Created
                    };
                    notes.Add(note);

                }
                return notes;
            }

            catch (Exception exception)
            {

                Log.Error(exception, exception.Message);
                throw new Exception(exception.Message);


            }
        }

        public NoteDTO UpdateNote(NoteDTO changedNote)
        {
            try
            {

                //Notes notes = new Notes { Id = changedNote.Id};


                //Notes note = _context.Notes.Where(o => o.Id == notes.Id);

               // Notes note = _context.Notes.Where(o => o.Id == changedNote.Id).FirstOrDefault();
                //    {
                //        note.Note = changedNote.Note,

                //    }

                //notes.Title = changedNote.Title;
                //notes.Note = changedNote.Note;
                //notes.LastUpdated = DateTime.Now;
                
                 //_context.Notes.Attach(notes);



                Notes note = _context.Notes.Find(changedNote.Id);
                note.Title = changedNote.Title;
                note.Note = changedNote.Note;
                note.LastUpdated = DateTime.Now;

                _context.Entry(note).State = EntityState.Modified;
                _context.SaveChanges();


               // _context.Update(note);

                return changedNote;
            }

           

            catch(ArgumentNullException exception)
            {
                if (changedNote.Id == 0)
                {
                    Log.Error(exception, exception.Message);
                    throw new ArgumentNullException("Note for Id = " + changedNote.Id + " does not exist");
                }
                throw new Exception("System Error: The note for " + changedNote.Id + " cannot be updated");

            }
        }


        public void Save()
        {
            _context.SaveChanges();
        }


    }
}
