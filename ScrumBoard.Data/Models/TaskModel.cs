using System;
// Id
// Name
// Data
namespace ScrumBoard.Data.Models {
    public class Task {
        public int Id { get; set; }
        public string TaskName { get; set; }
        public string TaskData { get; set; }

        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}
