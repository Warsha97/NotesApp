using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NoteApplication.Models;
using NoteApplication.BusinessService;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NoteApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : Controller
    {



        // private readonly INotesRepository _notesRepository;
        private readonly INoteService _noteService;


        public NotesController(INoteService noteService)
        {
            _noteService = noteService;
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
        [HttpGet]
       // [Route("api/[controller]/list")]
        //public ActionResult GetNotes()
        public IEnumerable<Notes> GetNotes()
        {
            //return await _context.Notes.ToListAsync();
            // return _context.Notes.ToList();
            //return _notesRepository.GetNotes();
            //return View(_notesRepository.GetNotes());
            return _noteService.GetNotesService();
        }

        // POST api/<controller>

        // [Route("api/[controller]/new-note")]
        /* public IActionResult AddNote(Notes note)
         {
             if (ModelState.IsValid)
             {
                 Notes newNote = _notesRepository.AddNote(note);
             }
             return View(note);
         }  */
        //[HttpPost]
        //public int Post(Notes note)
        //{
            
         //   return _noteService.AddNoteService(note);
        //}

        [HttpPost]
        public int Post(Notes createdNote)
        {

        return _noteService.AddNoteService(createdNote);



    }


        // PUT api/<controller>/5
        [HttpPut("{id}")]
       // [Route("api/[controller]/changed-note/{id}")]
        public Notes Update(Notes changedNote)
        {
            // _notesRepository.UpdateNote(changedNote);
            //return changedNote;
            _noteService.UpdateNoteService(changedNote);
            return changedNote;
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
      //  [Route("api/[controller]/deleted-note/{id}")]
        public Notes Delete(int id)
        {
            //return _notesRepository.DeleteNote(id);
            return _noteService.DeleteNoteService(id);
        }

        [HttpGet("{selectedDate}")]
        public IEnumerable<Notes> GetNotesByDate(DateTime selectedDate)
        {
            //return _notesRepository.GetNotesOfDate(selectedDate);
            return _noteService.GetNotesByDateService(selectedDate);
        }
            

    }
}
