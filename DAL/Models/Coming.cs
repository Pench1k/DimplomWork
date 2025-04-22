namespace DAL.Models
{
    public class Coming // Приход // Подумать над полями 
    {
        public int Id { get; set; }
        public string Provider {  get; set; }
        public DateOnly DateOfComing { get; set; }

        public int? WarehouseId {  get; set; }
        public Warehouse Warehouse { get; set; }
        //???
    }
}
