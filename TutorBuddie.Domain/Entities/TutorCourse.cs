using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutorBuddie.Domain.Entities;

public class TutorCourse
{
	public int TutorId { get; set; }
	public Tutor Tutor { get; set; }
	public int CourseId { get; set; }
	public Course Course { get; set; }
}