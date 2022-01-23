using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Book.Models;

namespace Book.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {

        private static List<BookItem> items = new List<BookItem>() {
            new BookItem() { Id = 1, Name = @"a" },
            new BookItem() { Id = 2, Name = @"b" },
            new BookItem() { Id = 3, Name = @"c" },
        };

        [HttpGet]
        public ActionResult<List<BookItem>> GetAll()
            => items;

        [HttpGet("{id}", Name = "BookItem")]
        public ActionResult<BookItem> GetById(int id)
        {
            var item = items.Find(i => i.Id == id);
            if (item == null)
                return NotFound();
            return item;
        }
    }
}