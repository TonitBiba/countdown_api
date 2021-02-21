using System;

namespace countdown_api.Models.Events
{
    public class EventVM
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime EventDate { get; set; }

    }
}
