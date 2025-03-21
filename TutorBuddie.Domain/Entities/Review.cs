using System;

namespace TutorBuddie.Domain.Entities;

public class Review
{
	public int Id { get; set; }
	public int BookingId { get; set; }
	public int TutorId { get; set; }
	public int Rating { get; set; }
	public string Comment { get; set; }
	public DateTime CreatedAtUtc { get; set; }
	public Booking Booking { get; set; }
	public Tutor Tutor { get; set; }	
}
