using KolokwiumAPI.Model;

namespace KolokwiumAPI.DTOs
{
    public class KeyboardResponseDTO
    {
        public int ID { get; set; }
        public string Model { get; set; }
        public KeyboardType Type { get; set; }
    }
}
