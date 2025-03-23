using TutorBuddie.Domain.Entities;
using TutorBuddie.Domain.Requests.Review;
using TutorBuddie.Domain.Responses;

namespace TutorBuddie.Domain.Services;

public interface IReviewService
{
	Task<IEnumerable<ReviewResponse>> GetByTutorIdAsync(int tutorId);
	ReviewResponse Add(CreateReviewRequest request);
	ReviewResponse Update(UpdateReviewRequest request);
}