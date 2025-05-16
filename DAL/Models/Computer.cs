using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
    public class Computer
    {
        public int Id { get; set; }

        public int? ProcessorId {  get; set; } // Процессор
        public Processor? Processor { get; set; }

        public int? MotherboardId {  get; set; } // Материнская плата
        public Motherboard? Motherboard { get; set; }

        public int? RamId {  get; set; } // Оперативная память
        public RAM? Ram { get; set; }

        public int? OcId { get; set; } // Операционная система
        public OC? Oc { get; set; }

        public int? MemoryDiskId {  get; set; } // Материнская плата
        public MemoryDisk? MemoryDisk { get; set; }

        public int? PowerUnitId {  get; set; } // Блок питания
        public PowerUnit? PowerUnit { get; set; }

        public int? VideoCardId {  get; set; } // Видеокарта
        public VideoСard? VideoCard { get; set; }


        public int? MouseId { get; set; } // Мышка
        public Mouse? Mouse { get; set; }


        public int? KeyboardId {  get; set; } // Клавиатура
        public Keyboard? Keyboard { get; set; }

        public int? ScreenId {  get; set; } // Монитор
        public Screen? Screen { get; set; }

        public int? ComingId { get; set; }
        public Coming? Coming { get; set; }

        public ComputerStatus ComputerStatus { get; set; }
    }

    public enum ComputerStatus
    {
        [Display(Name = "Ожидает подтверждения")]
        PendingConfirmation,

        [Display(Name = "Подтвержден складом")]
        Confirmed,

        [Display(Name = "Готов к работе")]
        HavePassport
    }
}
