using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineEducation.Business.Abstract;
using OnlineEducation.DTO.DTOs.AboutDtos;
using OnlineEducation.DTO.DTOs.SubscribeDtos;
using OnlineEducation.Entity.Entities;

namespace OnlineEducation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscribersController(IGenericService<Subscriber> _subscriberService, IMapper _mapper) : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var values = _subscriberService.TGetList();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var values = _subscriberService.TGetById(id);
            return Ok(values);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _subscriberService.TDelete(id);
            return Ok("Silme Başarılı");
        }
        [HttpPost]
        public IActionResult Create(CreateSubscribeDto createSubscribeDto)
        {
            var newValue = _mapper.Map<Subscriber>(createSubscribeDto);
            _subscriberService.TCreate(newValue);
            return Ok("Ekleme Başarılı");
        }
        [HttpPut]
        public IActionResult Update(UpdateSubscribeDto updateSubscribeDto)
        {
            var value = _mapper.Map<Subscriber>(updateSubscribeDto);
            _subscriberService.TUpdate(value);
            return Ok("Hakkımda Alanı Güncellendi");

        }
    }
}
