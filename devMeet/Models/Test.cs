using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace devMeet.Models
{
    public class Test
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class TestObject
    {
        public Test TestA { get; set; }
        public Test TestB { get; set; }
    }
}