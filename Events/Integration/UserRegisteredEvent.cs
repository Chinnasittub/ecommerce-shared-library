using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary.Events.Integration
{
    public class UserRegisteredEvent
    {
        public Guid UserId { get; set; }
        public string Username { get; set; } = string.Empty;
    }
}
