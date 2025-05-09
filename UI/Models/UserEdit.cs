namespace UI.Models
{
    public class UserEdit
    {
        public string? Id { get; set; }

        public string? Name { get; set; }
        public string? LastName {  get; set; }
        public string? MiddleName { get; set; }  
        public string? Role {  get; set; }


        public int DepartmentId {  get; set; }
        public string? DepartmentName { get; set; }

        public string? WarehouseName { get; set; }
        public int WarehouseId { get; set; }
    }
}
