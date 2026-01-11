using Microsoft.AspNetCore.Mvc;

namespace MyszkiAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MiceController : ControllerBase
    {
        //zwraca wszysztkie myszki
        [HttpGet] public IEnumerable<Mouse1> GetAll() => MouseRepository.GetAll();
        // zwraca 1 myszke po id
        [HttpGet("{id}")]
        public ActionResult<Mouse1> GetById(int id) =>
            MouseRepository.GetById(id) is Mouse1 mouse ? mouse : NotFound();
        // dodaje nową myszke
        [HttpPost]
        public ActionResult<Mouse1> Post(Mouse1 mouse) =>
            CreatedAtAction(nameof(GetById), new { id = MouseRepository.Add(mouse).Id }, mouse);
        // aktualizuje nową myszke
        [HttpPut("{id}")]
        public ActionResult<Mouse1> Put(int id, Mouse1 mouse) =>
            MouseRepository.Update(id, mouse) is Mouse1 updated ? updated : NotFound();
        // usuwa nową myszke
        [HttpDelete("{id}")]
        public IActionResult Delete(int id) =>
            MouseRepository.Delete(id) ? NoContent() : NotFound();
    }
}
