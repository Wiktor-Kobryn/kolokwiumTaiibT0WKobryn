using KolokwiumAPI.BLL;
using KolokwiumAPI.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace KolokwiumAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KeyboardsController : Controller
    {
        readonly IKeyboardService service;
        
        public KeyboardsController(IKeyboardService service)
        {
            this.service = service;
        }

        [HttpGet]
        public IEnumerable<KeyboardResponseDTO> GetKeyboards()
        {
            return service.GetKeyboards();
        }

        [HttpPost]
        public void AddKeyboard([FromBody] KeyboardRequestDTO keyboardRequest)
        {
            service.AddKeyboard(keyboardRequest);
        }

        [HttpDelete("{keyboardId}")]
        public void DeleteMouse(int keyboardId)
        {
            service.DeleteKeyboard(keyboardId);
        }
    }
}
