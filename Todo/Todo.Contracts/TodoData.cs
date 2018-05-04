using System;
using System.Runtime.Serialization;

namespace Todo.Contracts
{
    [DataContract]
    public class TodoData
    {
        [DataMember]
        public Guid Id { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public string StartDate { get; set; }

        [DataMember]
        public string EndDate { get; set; }

        [DataMember]
        public bool IsCompleted { get; set; }
    }
}
