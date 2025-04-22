

namespace BLL.DTO
{
    public class RepairComputerDTO
    {
        public int Id { get; set; }

        public int? ComputerPassportId { get; set; }
      
        public int? WorkerId { get; set; }
  
        public string ServiceCenter { get; set; }

        public string Note { get; set; }
     
    }
}
