using Microsoft.AspNetCore.Mvc;

namespace MyszkiAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MiceController : ControllerBase
    {
        [HttpGet]
        public ActionResult Get([FromQuery] int? id)
        {
            if (id.HasValue)
            {
                var mouse = MouseRepository.GetById(id.Value);
                return mouse is not null ? Ok(mouse) : NotFound();
            }

            return Ok(MouseRepository.GetAll());
        }
        [HttpPost]
        public ActionResult<Mouse1> Post(Mouse1 mouse)
        {
            var addedMouse = MouseRepository.Add(mouse);
            return CreatedAtAction(nameof(Get), new { id = addedMouse.Id }, addedMouse);
        }
    }
}