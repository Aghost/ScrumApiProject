using System;
using System.Linq;
using System.Collections.Generic;
using ScrumBoard.Data;
using ScrumBoard.Data.Models;
// Id
// Name
// Data
namespace ScrumBoard.Data.Models {
    public class Board {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Data { get; set; }

        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }

        public List<Task> Task { get; set; }
    }
}
