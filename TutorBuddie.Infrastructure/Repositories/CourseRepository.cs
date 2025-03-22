using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TutorBuddie.Domain.Entities;
using TutorBuddie.Domain.Repositories;

namespace TutorBuddie.Infrastructure.Repositories;

public class CourseRepository : ICourseRepository
{
	public Task<IEnumerable<Tutor>> GetAsync()
	{
		throw new NotImplementedException();
	}

	public Task<Tutor> GetAsync(int id)
	{
		throw new NotImplementedException();
	}

	public Tutor Add(Tutor details)
	{
		throw new NotImplementedException();
	}

	public Task Delete(int id)
	{
		throw new NotImplementedException();
	}
}