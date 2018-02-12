using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fisher.Bookstore.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Fisher.Bookstore.Api.Controllers
{
    [Route("api/[controller]")]
    public class AuthorsController : Controller
    {
        private readonly BookstoreContext db;

        public AuthorsController(BookstoreContext db)
        {
            this.db = db;

            if (this.db.Authors.Count() == 0)
            {
                this.db.Authors.Add(new Author {
                    AuthorId = 1,
                    AuthorName = "Dahl, Roald"
                });

                this.db.Authors.Add(new Author {
                    AuthorId = 2,
                    AuthorName = "Rowling, J.K."
                });

                this.db.SaveChanges();
            }

        }

        [HttpGet]

        public IActionResult GetAll()
        {
            return Ok(db.Authors);
        }

        [HttpGet("{id}", Name="GetAuthor")]

        public IActionResult GetById(int id)
        {
            var Author = db.Authors.Find(id);

            if(Author == null)
            {
                return NotFound();
            }

            return Ok(Author);
        }

        [HttpPost]

        public IActionResult Post([FromBody]Author Author)
        {
            if(Author == null)
            {
                return BadRequest();
            }

            this.db.Authors.Add(Author);
            this.db.SaveChanges();

            return CreatedAtRoute("GetAuthor", new { id = Author.AuthorId}, Author);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Author newAuthor)
        {
            if (newAuthor == null || newAuthor.AuthorId != id)
            {
                return BadRequest();
            }
            var currentAuthor = this.db.Authors.FirstOrDefault(x => x.AuthorId == id);

            if (currentAuthor == null)
            {
                return NotFound();
            }

            currentAuthor.BirthDate = newAuthor.BirthDate;

            this.db.Authors.Update(currentAuthor);
            this.db.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]

        public IActionResult Delete(int id)
        {
            var Author = this.db.Authors.FirstOrDefault(x => x.AuthorId == id);

            if (Author == null)
            {
                return NotFound();
            }

            this.db.Authors.Remove(Author);
            this.db.SaveChanges();

            return NoContent();
        }
    }
}