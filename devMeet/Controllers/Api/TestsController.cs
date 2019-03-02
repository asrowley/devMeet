using devMeet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace devMeet.Controllers.Api
{
    public class TestsController : ApiController
    {
        private ApplicationDbContext _context;

        public TestsController()
        {
            _context = new ApplicationDbContext();
        }

        //GET api/tests
        public IHttpActionResult GetTests()
        {
            var tests = _context.Tests.ToList();
            return Ok(tests);
        }

        ////POST api/tests
        //[HttpPost]
        //public IHttpActionResult CreateTest(Test test)
        //{
        //    if (!ModelState.IsValid)
        //        return BadRequest();

        //    _context.Tests.Add(test);

        //    _context.SaveChanges();

        //    return Ok(test);
        //}

        //POST api/tests
        [HttpPost]
        public IHttpActionResult CreateTest(TestObject testObject)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var testA = testObject.TestA;
            var testB = testObject.TestB;

            _context.Tests.Add(testA);
            _context.Tests.Add(testB);

            _context.SaveChanges();

            return Ok();
        }
    }
}
