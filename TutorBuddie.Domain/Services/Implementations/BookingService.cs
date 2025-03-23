using AutoMapper;
using TutorBuddie.Domain.Entities;
using TutorBuddie.Domain.Repositories;
using TutorBuddie.Domain.Requests.Booking;
using TutorBuddie.Domain.Responses;

namespace TutorBuddie.Domain.Services.Implementations;

public class BookingService : IBookingService
{
	private readonly IMapper _mapper;
	private readonly IBookingRepository _bookingRepository;

	public BookingService(IMapper mapper, IBookingRepository bookingRepository)
	{
		_mapper = mapper;
		_bookingRepository = bookingRepository;
	}

	public async Task<IEnumerable<BookingResponse>> GetByTutorIdAsync(int tutorId)
	{
		var results = await _bookingRepository.GetByTutorIdAsync(tutorId);
		return _mapper.Map<IEnumerable<BookingResponse>>(results);
	}

	public BookingResponse Update(UpdateBookingRequest request)
	{
		var result = _bookingRepository.Update(_mapper.Map<Booking>(request));
		return _mapper.Map<BookingResponse>(result);
	}

	public BookingResponse Add(CreateBookingRequest request)
	{
		var result = _bookingRepository.Add(_mapper.Map<Booking>(request));
		return _mapper.Map<BookingResponse>(result);
	}
}