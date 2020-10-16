using System;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using book.Service;
using book.Service.dto;

namespace book.Controllers
{
    [ApiController]
    public class BookController : Controller
    {
        
        private readonly BookService _bookService = new BookService();
        
        // GET
        [HttpGet]
        [Route("[controller]")]
        public IActionResult Get()
        {
            return Ok("get");
        }
        
        [HttpGet]
        [Route("[controller]/{title}")]
        public IActionResult Get(string title)
        {
            BookDto book = _bookService.getBooksByTitle(title);
            
            return Ok(JsonConvert.SerializeObject(book));
        }

    }
}