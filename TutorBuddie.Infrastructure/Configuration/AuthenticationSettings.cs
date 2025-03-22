using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutorBuddie.Infrastructure.Configuration;

public class AuthenticationSettings
{
	public string Secret { get; set; }
	public int ExpirationDays { get; set; }
}