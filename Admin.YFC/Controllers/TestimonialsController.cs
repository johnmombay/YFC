using Admin.YFC.Models;
using Admin.YFC.Services;
using Microsoft.AspNetCore.Mvc;

namespace Admin.YFC.Controllers
{
	public class TestimonialsController : Controller
	{
		private readonly TestimonialServices _testimonialServices;

		public TestimonialsController(TestimonialServices testimonialServices)
		{
			_testimonialServices = testimonialServices;
		}

		public IActionResult Index()
		{
			return View();
		}

		public async Task<IActionResult> GetTestimonials()
		{
			var testimonials = await _testimonialServices.GetTestimonials();
			return Json( new { data = testimonials });
		}

		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Create([Bind("Author,Content")] Testimonial testimonial)
		{
			if (ModelState.IsValid)
			{
				await _testimonialServices.AddTestimonial(testimonial);
				return RedirectToAction(nameof(Index));
			}
			return View(testimonial);
		}

		public async Task<IActionResult> Edit(int id)
		{
			var testimonial = await _testimonialServices.GetTestimonialById(id);
			return View(testimonial);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(int id, [Bind("TestimonialId,Author,Content")] Testimonial testimonial)
		{
			if (id != testimonial.TestimonialId)
			{
				return NotFound();
			}
			if (ModelState.IsValid)
			{
				await _testimonialServices.UpdateTestimonial(testimonial);
				return RedirectToAction(nameof(Index));
			}
			return View(testimonial);
		}

		public async Task<IActionResult> Remove(int id)
		{
			var testimonial = await _testimonialServices.GetTestimonialById(id);
			return View(testimonial);
		}

		public async Task<IActionResult> Delete([Bind("TestimonialId,Author,Content")] Testimonial testimonial)
		{
			await _testimonialServices.DeleteTestimonial(testimonial.TestimonialId);
			return RedirectToAction(nameof(Index));
		}

	}
}
