using AutoMapper;
using TutorBuddie.Domain.Entities;
using TutorBuddie.Domain.Repositories;
using TutorBuddie.Domain.Requests.Review;
using TutorBuddie.Domain.Responses;

namespace TutorBuddie.Domain.Services.Implementations;

public class ReviewService : IReviewService
{
	private readonly IMapper _mapper;
	private readonly IReviewRepository _repository;

	public ReviewService(IMapper mapper, IReviewRepository repository)
	{
		_mapper = mapper;
		_repository = repository;
	}

	public async Task<IEnumerable<ReviewResponse>> GetByTutorIdAsync(int tutorId)
	{
		var results = await _repository.GetByTutorIdAsync(tutorId);
		return _mapper.Map<IEnumerable<ReviewResponse>>(results);
	}

	public ReviewResponse Add(CreateReviewRequest request)
	{
		var result = _repository.Add(_mapper.Map<Review>(request));
		return _mapper.Map<ReviewResponse>(result);
	}

	public ReviewResponse Update(UpdateReviewRequest request)
	{
		var result = _repository.Update(_mapper.Map<Review>(request));
		return _mapper.Map<ReviewResponse>(result);
	}
}