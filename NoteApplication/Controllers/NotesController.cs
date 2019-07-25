using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NoteApplication.BusinessService;
using NoteApplication.DataAccess;
using NoteApplication.DataAccess.Models;



// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NoteApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : Controller
    {

        private readonly INoteService _noteService;


        public NotesController(INoteService noteService)
        {
            _noteService = noteService;

        }



        
        [HttpGet]
        
        public IEnumerable<NoteDTO> GetNotes()
        {

            return _noteService.GetNotesService();
        }

        
        [HttpPost]

        public Boolean AddNote(NoteDTO note)
        {

            return _noteService.AddNoteService(note);
        }


        [HttpPut("{id}")]
       
        public NoteDTO Update(NoteDTO changedNote)
        {

            _noteService.UpdateNoteService(changedNote);
            return changedNote;
        }


        [HttpDelete("{id}")]
        
        public Boolean Delete(int id)
        {

            return _noteService.DeleteNoteService(id);
        }

        [HttpGet("{selectedDate}")]

       
        public IEnumerable<NoteDTO> GetNotesByDate(DateTime selectedDate)
        {
           return _noteService.GetNotesByDateService(selectedDate);
        }


    }
}
