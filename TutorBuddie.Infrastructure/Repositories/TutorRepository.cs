﻿using TutorBuddie.Domain.Entities;
using TutorBuddie.Domain.Repositories;

namespace TutorBuddie.Infrastructure.Repositories;

public class TutorRepository : ITutorRepository
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
}