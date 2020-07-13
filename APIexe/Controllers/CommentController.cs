using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIexe.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIexe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly AppDBContext _context;

        public CommentController(AppDBContext context)
        {
            _context = context;
        }

        // GET: api/<CommentController>
        [HttpGet]
        public ActionResult<List<Comment>> Get()
        {
            try
            {
                var listComment = _context.Comments.ToList();
                return Ok(listComment);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<CommentController>/5
        [HttpGet("{id}")]
        public ActionResult<Comment> Get(int id)
        {
            try
            {
                var comment = _context.Comments.Find(id);
                if(comment == null)
                {
                    return NotFound();
                }
                return Ok(comment);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<CommentController>
        [HttpPost]
        public ActionResult Post([FromBody] Comment comment)
        {
            try
            {
                _context.Add(comment);
                _context.SaveChanges();

                return Ok();
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<CommentController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Comment comment)
        {
            try
            {
                if (id != comment.id)
                    return BadRequest();

                _context.Entry(comment).State = EntityState.Modified;
                _context.Update(comment);
                _context.SaveChanges();

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<CommentController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var comm = _context.Comments.Find(id);

                if(comm == null)
                    return NotFound();

                _context.Remove(comm);
                _context.SaveChanges();

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
