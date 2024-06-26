using KolokwiumAPI.DTOs;

namespace KolokwiumAPI.BLL
{
    public interface IKeyboardService
    {
        IEnumerable<KeyboardResponseDTO> GetKeyboards();
        void DeleteKeyboard(int keyboardId);
        void AddKeyboard(KeyboardRequestDTO keyboardRequest);
    }
}
