﻿using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
    public class ArrivalFromTheWarehouse // Выдача со склада в подразделение // Дописать статусы!!!
    {
        public int Id { get; set; } 

        public int? ComputerPassportId { get; set; }
        public ComputerPassport? ComputerPassport { get; set; }

        public int? WarehouseId { get; set; }
        public Warehouse? Warehouse { get; set; }

        public int? OfficeId {  get; set; }
        public Office? Office { get; set; }

        public string? UserId { get; set; }
        public ApplicationUser? User { get; set; }

        public DateOnly DateOfArrivalFromTheWarehouse { get; set; }

        public string? Note { get; set; }
        public StatusForArrival Status { get; set; }
    }

    public enum StatusForArrival
    {
        [Display(Name = "Ожидает подтверждение от склада")]
        WaiteWarehouse,

        [Display(Name = "Отклонен складом")]
        RejectWarehouse,

        [Display(Name = "Ожидает подтверждение от подразделения")]
        WaiteMetodist,

        [Display(Name = "Отклонен подразделением")]
        RejectMetodist,

        [Display(Name = "Завершен")]
        Сompleted
    }
}
