using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace TaskManagementSystem.Models
{
    public class User : IdentityUser
    {
        public ICollection<TaskItem> Tasks { get; set; }
    }
}
