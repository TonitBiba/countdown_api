using System;

namespace countdown_api.Models.Events
{
    public class Create
    {
        public string name { get; set; }

        public DateTime date { get; set; }
    }
}
