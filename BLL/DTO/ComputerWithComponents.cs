using DAL.Models;

namespace BLL.DTO
{
    public class ComputerWithComponents
    {
        public int Id { get; set; }

        public int? ProcessorId { get; set; } // Процессор
        public string? ProcessorName { get; set; }

        public int? MotherboardId { get; set; } // Материнская плата
        public string? MotherboardName { get; set; }

        public int? RamId { get; set; } // Оперативная память
        public string? RamName { get; set; }

        public int? OcId { get; set; } // Операционная система
        public string? OcName { get; set; }

        public int? MemoryDiskId { get; set; } // Материнская плата
        public string? MemoryDiskName { get; set; }

        public int? PowerUnitId { get; set; } // Блок питания
        public string? PowerUnitName { get; set; }

        public int? VideoCardId { get; set; } // Видеокарта
        public string? VideoCardName { get; set; }


        public int? MouseId { get; set; } // Мышка
        public string? MouseName { get; set; }


        public int? KeyboardId { get; set; } // Клавиатура
        public string? KeyboardName { get; set; }

        public int? ScreenId { get; set; } // Монитор
        public string? ScreenName { get; set; }

        public ComputerStatus ComputerStatus { get; set; }  
    }
}
