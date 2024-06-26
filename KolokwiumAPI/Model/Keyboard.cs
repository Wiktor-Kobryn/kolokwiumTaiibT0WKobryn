namespace KolokwiumAPI.Model
{
    public enum KeyboardType
    {
        membranowa = 0,
        nozycowa = 1,
        mechaniczna = 2,
        optyczna = 3,
        hybrydowa = 4
    }

    public class Keyboard
    {
        public int ID { get; set; }
        public string Model { get; set; }
        public KeyboardType Type { get; set; }

    }
}
