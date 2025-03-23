using AutoMapper;
using TutorBuddie.Domain.Entities;
using TutorBuddie.Domain.Repositories;
using TutorBuddie.Domain.Requests.Course;
using TutorBuddie.Domain.Responses;

namespace TutorBuddie.Domain.Services.Implementations;

public class CourseService : ICourseService
{
	private readonly IMapper _mapper;
	private readonly ICourseRepository _repository;

	public CourseService(IMapper mapper, ICourseRepository repository)
	{
		_mapper = mapper;
		_repository = repository;
	}

	public async Task<IEnumerable<CourseResponse>> GetAsync()
	{
		var result = await _repository.GetAsync();
		return _mapper.Map<IEnumerable<CourseResponse>>(result);
	}

	public async Task<CourseResponse> GetAsync(int id)
	{
		var result = await _repository.GetAsync(id);
		return _mapper.Map<CourseResponse>(result);
	}

	public CourseResponse Add(CreateCourseRequest request)
	{
		var result = _repository.Add(_mapper.Map<Course>(request));
		return _mapper.Map<CourseResponse>(result);
	}

	public CourseResponse Update(UpdateCourseRequest request)
	{
		var result = _repository.Update(_mapper.Map<Course>(request));
		return _mapper.Map<CourseResponse>(result);
	}

	public Task Delete(int id)
	{
		_repository.Delete(id);
		return Task.CompletedTask;
	}
}