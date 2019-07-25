using System;
using Xunit;
using NoteApplication.BusinessService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using NoteApplication.DataAccess.Repository;
using NoteApplication.DataAccess.Models;

namespace BusinessService.Test
{
    public class NoteServicesTests
    {
        

        [Fact]
        public void ShouldReturnANoteDTOObjectWhenAddNoteServiceIsTriggered()
        {
            Mock<INotesRepository> mockedNotesRepository = new Mock<INotesRepository>();
            NoteService _noteService = new NoteService(mockedNotesRepository.Object);

            NoteDTO fakeNote = new NoteDTO()
            {
                Id = 1,
                Title = "Unit Testing for Adding",
                Note = "Unit Testing the Service Layer for Add Note Service",
                Created = DateTime.Now
            };

            var response = _noteService.AddNoteService(fakeNote);
            Assert.IsType<Boolean>(response);
                       
        }

        [Fact]
        public void ShouldReturnAnExceptionWhenAddNoteServiceIsTriggered()
        {
            Mock<INotesRepository> mockedNotesRepository = new Mock<INotesRepository>();
            NoteService _noteService = new NoteService(mockedNotesRepository.Object);

            NoteDTO fakeNote = new NoteDTO()
            {
                Id = -1,
                Title = "Unit Testing for Adding",
                Note = "Unit Testing the Service Layer for Add Note Service",
                Created = DateTime.Now
            };

            
            Assert.Throws<ArgumentOutOfRangeException>(() => _noteService.AddNoteService(fakeNote));

        }

        [Fact]
        public void ShouldReturnANoteDTOObjectWhenUpdateNoteServiceIsTriggered()
        {
            Mock<INotesRepository> mockedNotesRepository = new Mock<INotesRepository>();
            NoteService _noteService = new NoteService(mockedNotesRepository.Object);

            NoteDTO fakeNote = new NoteDTO()
            {
                Id = 1,
                Title = "Unit Testing for Updating",
                Note = "Unit Testing the Service Layer for Update Note Service",
                Created = DateTime.Now
            };

            var response = _noteService.UpdateNoteService(fakeNote);

            Assert.IsType<NoteDTO>(response);


        }

        [Fact]
        public void ShouldReturnAnInvalidObjectWhenUpdateNoteServiceIsTriggered()
        {
            Mock<INotesRepository> mockedNotesRepository = new Mock<INotesRepository>();
            NoteService _noteService = new NoteService(mockedNotesRepository.Object);

            NoteDTO fakeNote = new NoteDTO()
            {
                Id = -1,
                Title = "Unit Testing for Updating",
                Note = "Unit Testing the Service Layer for Update Note Service",
                Created = DateTime.Now
            };

            var response = _noteService.UpdateNoteService(fakeNote);
            Assert.Null(response);

            //Assert.IsType<ArgumentException>(response);


        }

        [Fact]
        public void ShouldDeleteANoteWhenDeleteNoteServiceIsTriggered()
        {
            Mock<INotesRepository> mockedNotesRepository = new Mock<INotesRepository>();
            NoteService _noteService = new NoteService(mockedNotesRepository.Object);

            var fakeId = 1;

            var response = _noteService.DeleteNoteService(fakeId);

            Assert.IsType<Boolean>(response);


        }
        [Fact]
        public void ShouldReturnAnExceptionWhenDeleteNoteServiceIsTriggered()
        {
            Mock<INotesRepository> mockedNotesRepository = new Mock<INotesRepository>();
            NoteService _noteService = new NoteService(mockedNotesRepository.Object);

            var fakeId = -1;

            
            Assert.Throws<ArgumentOutOfRangeException>(() => _noteService.DeleteNoteService(fakeId));


        }

        

        
    }
    
}
