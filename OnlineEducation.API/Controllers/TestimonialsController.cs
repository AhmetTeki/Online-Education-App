using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineEducation.Business.Abstract;
using OnlineEducation.DTO.DTOs.AboutDtos;
using OnlineEducation.DTO.DTOs.TestimonialDtos;
using OnlineEducation.Entity.Entities;

namespace OnlineEducation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialsController(IGenericService<Testimonial> _testimonialService, IMapper _mapper) : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var values = _testimonialService.TGetList();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var values = _testimonialService.TGetById(id);
            return Ok(values);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _testimonialService.TDelete(id);
            return Ok("Silme Başarılı");
        }
        [HttpPost]
        public IActionResult Create(CreateTestimonialDto createTestimonialDto)
        {
            var newValue = _mapper.Map<Testimonial>(createTestimonialDto);
            _testimonialService.TCreate(newValue);
            return Ok("Ekleme Başarılı");
        }
        [HttpPut]
        public IActionResult Update(UpdateTestimonialDto updateTestimonialDto)
        {
            var value = _mapper.Map<Testimonial>(updateTestimonialDto);
            _testimonialService.TUpdate(value);
            return Ok("Hakkımda Alanı Güncellendi");

        }
    }
}
