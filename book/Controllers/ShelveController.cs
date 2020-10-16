using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using book.Domain;
using book.Service;
using book.Service.dto;

namespace book.Controllers
{
    [ApiController]
    public class ShelveController : Controller
    {
        private readonly BookService _bookService = new BookService();
        
        // GET
        [HttpGet]
        [Route("[controller]s")]
        public IActionResult Index()
        {
            List<BookResult> bookList = _bookService.getShelves();
            return Ok(JsonConvert.SerializeObject(bookList));
        }
        
        //POST
        [HttpPost]
        [Route("[controller]")]
        public ActionResult<BookDto[]> Post([FromBody] BookDto book)
        {
            if (_bookService.insertInShelve(book))
            {
                return Ok("Success");
            }
            else
            {
                return StatusCode(500, "error inserting");
            }
        }
    }
}