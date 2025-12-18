using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductionSystem.Models
{
    public class SystemLog
    {
        public int LogId { get; set; }
        public DateTime DateTimeActual { get; set; }
        public string Username { get; set; }
        public string ActionActivity { get; set; }
        public string TableName { get; set; }
        public string DescriptionValue { get; set; }
        public bool Success { get; set; }
    }
}