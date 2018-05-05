using System;

namespace Todo.Core.Domain
{
    public class Todo
    {
        public Guid Id { get; set; }

        public string Description { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public bool IsCompleted { get; set; }
    }
}
