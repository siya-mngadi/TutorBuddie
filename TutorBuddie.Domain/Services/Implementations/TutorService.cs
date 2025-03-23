using AutoMapper;
using TutorBuddie.Domain.Entities;
using TutorBuddie.Domain.Repositories;
using TutorBuddie.Domain.Requests.Tutor;
using TutorBuddie.Domain.Responses;

namespace TutorBuddie.Domain.Services.Implementations;

public class TutorService : ITutorService
{
	private readonly IMapper _mapper;
	private readonly ITutorRepository _repository;
	private readonly ITutorCourseRepository _tutorCourseRepository;

	public TutorService(IMapper mapper, ITutorRepository repository, ITutorCourseRepository tutorCourseRepository)
	{
		_mapper = mapper;
		_repository = repository;
		_tutorCourseRepository = tutorCourseRepository;
	}

	public async Task<IEnumerable<TutorResponse>> GetAsync()
	{
		var results = await _repository.GetAsync();
		return _mapper.Map<IEnumerable<TutorResponse>>(results);
	}

	public async Task<TutorResponse> GetAsync(int id)
	{
		var result = await _repository.GetAsync(id);
		return _mapper.Map<TutorResponse>(result);
	}

	public TutorResponse Add(CreateTutorRequest request)
	{
		var result = _repository.Add(_mapper.Map<Tutor>(request));
		return _mapper.Map<TutorResponse>(result);
	}

	public TutorResponse Update(UpdateTutorRequest request)
	{
		var result = _repository.Update(_mapper.Map<Tutor>(request));
		return _mapper.Map<TutorResponse>(result);
	}

	public async Task<IEnumerable<TutorCourseResponse>> GetByTutorIdAsync(int tutorId)
	{
		var results = await _tutorCourseRepository.GetByTutorIdAsync(tutorId);
		return _mapper.Map<IEnumerable<TutorCourseResponse>>(results);
	}

	public TutorCourseResponse Add(int tutorId, int courseId)
	{
		var result = _tutorCourseRepository.Add(tutorId, courseId);
		return _mapper.Map<TutorCourseResponse>(result);
	}

	public Task<bool> Delete(int tutorId, int courseId)
	{
		return _tutorCourseRepository.Delete(tutorId, courseId);
	}
}