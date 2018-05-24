using System;
using System.Runtime.Serialization;

namespace Todo.Core.Domain
{
    [DataContract]
    public class Todo
    {
        [DataMember]
        public Guid Id { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public DateTime? StartDate { get; set; }

        [DataMember]
        public DateTime? EndDate { get; set; }

        [DataMember]
        public bool IsCompleted { get; set; }
    }
}
