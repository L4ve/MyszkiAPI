using System.Linq;
using System.Xml.Linq;

namespace MyszkiAPI
{
    public static class MouseRepository
    {
        // wszystkie listy, 4 przykładowe na uruchomieniu by lista maui nie była pusta
        private static List<Mouse1> mice = new()
        {
            // Kilka przykładowych myszek dodanych do listy
            new() { Id = 1, Model = "G102", Firma = "Logitech", Sensor = "PixArt 3327", Waga = 85, Link = "https://www.amazon.com/Logitech-Customizable-Lighting-Programmable-Tracking/dp/B0895BG8QP?th=1" },
            new() { Id = 2, Model = "DeathAdder V3", Firma = "Razer", Sensor = "Focus+", Waga = 82, Link = "https://www.amazon.com/DeathAdder-Wired-Gaming-Mouse-HyperPolling/dp/B0B6XTDJS1" },
            new() { Id = 3, Model = "Hyperlight", Firma = "Hitscan", Sensor = "PixArt 3389", Waga = 70, Link = "https://hitscan.com/products/hyperlight" },
            new() { Id = 4, Model = "G Pro Superlight 2C", Firma = "Logitech", Sensor = "Hero 25K", Waga = 62, Link = "https://www.logitechg.com/en-us/shop/p/pro-x-superlight-2c" }
        };

        // Zwraca wszystkie myszki w formie IEnumerable<Mouse1>
        public static IEnumerable<Mouse1> GetAll() => mice;

        public static Mouse1? GetById(int id) => mice.FirstOrDefault(m => m.Id == id);

        // Dodaje nową myszkę do listy
        public static Mouse1 Add(Mouse1 mouse)
        {
            mouse.Id = mice.Any() ? mice.Max(m => m.Id) + 1 : 1;

            mice.Add(mouse);

            return mouse;
        }

        // Aktualizuje istniejącą myszkę po ID
        public static Mouse1? Update(int id, Mouse1 mouse)
        {
            var existing = GetById(id);

            if (existing == null) return null;

            // Aktualizuje dane myszki
            existing.Model = mouse.Model;
            existing.Firma = mouse.Firma;
            existing.Sensor = mouse.Sensor;
            existing.Waga = mouse.Waga;
            existing.Link = mouse.Link;

            return existing;
        }

        public static bool Delete(int id) => mice.Remove(GetById(id)!);

    }
}
