namespace TutorBuddie.Domain.Repositories;

public interface IRepository
{
	IUnitOfWork UnitOfWork { get; }
}