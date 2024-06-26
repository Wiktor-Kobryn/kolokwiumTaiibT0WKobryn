using KolokwiumAPI.DTOs;
using KolokwiumAPI.Model;

namespace KolokwiumAPI.BLL
{
    public class KeyboardService : IKeyboardService
    {
        readonly List<Keyboard> keyboards = new()
        {
            new Keyboard {ID = 1, Model="Tracer B222", Type=KeyboardType.optyczna},
            new Keyboard {ID = 2, Model="Tracer A34", Type=KeyboardType.nozycowa},
            new Keyboard {ID = 3, Model="Logietch w2", Type=KeyboardType.nozycowa},
            new Keyboard {ID = 4, Model="Logitech j7", Type=KeyboardType.hybrydowa}
        };

        public void AddKeyboard(KeyboardRequestDTO keyboardRequest)
        {
            if (keyboardRequest.Model == "" || keyboardRequest.Model == null)
                throw new Exception("Keyboard Model cannot be empty! ");

            if((int)keyboardRequest.Type < 0 || (int)keyboardRequest.Type > 4)
                throw new Exception("Unrecognised keyboard type! ");

            Keyboard keyboard = new()
            {
                ID = keyboards.Max(x => x.ID) + 1, // ID przydzielane po stronie API
                Model = keyboardRequest.Model,
                Type = keyboardRequest.Type
            };

            keyboards.Add(keyboard);
        }

        public void DeleteKeyboard(int keyboardId)
        {
            var searched = keyboards.Find(m => m.ID == keyboardId);
            if (searched == null)
                throw new Exception("Keyboard not found! - id=" + keyboardId);

            keyboards.Remove(searched);
        }

        public IEnumerable<KeyboardResponseDTO> GetKeyboards()
        {
            List<KeyboardResponseDTO>keyboardsResponse = new List<KeyboardResponseDTO>();
            foreach (var k in keyboards)
            {
                keyboardsResponse.Add(toKeyboardResponseDTO(k));
            }

            return keyboardsResponse;
        }

        KeyboardResponseDTO toKeyboardResponseDTO(Keyboard keyboard)
        {
            return new KeyboardResponseDTO
            {
                ID = keyboard.ID,
                Model = keyboard.Model,
                Type = keyboard.Type
            };
        }
    }
}
