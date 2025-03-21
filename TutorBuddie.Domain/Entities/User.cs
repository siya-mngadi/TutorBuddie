using TutorBuddie.Domain.Enums;
using Microsoft.AspNetCore.Identity;

namespace TutorBuddie.Domain.Entities;

public class User : IdentityUser
{
    public string Name { get; set; }
    public Role Role { get; set; }
}
