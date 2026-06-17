using System.Collections.Generic;

namespace PROEKT2
{
    public class Game
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Platform { get; set; } = string.Empty;
        public int TimePlayedMinutes { get; set; } // Время в игре
        public List<Achievement> Achievements { get; set; } = new List<Achievement>();
    }

    public class Achievement
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsUnlocked { get; set; }
        public bool IsTimeBased { get; set; } // Зависит ли от времени
        public int RequiredMinutes { get; set; } // Сколько минут нужно
    }
}