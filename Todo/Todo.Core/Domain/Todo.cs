using System;

namespace Todo.Data.Core.Domain
{
    public class Todo
    {
        public Guid Id { get; set; }

        public string Description { get; set; }

        public string StartDate { get; set; }

        public string EndDate { get; set; }

        public bool IsCompleted { get; set; }
    }
}
