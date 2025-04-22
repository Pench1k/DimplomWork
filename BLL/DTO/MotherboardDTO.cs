

namespace BLL.DTO
{
    public class MotherboardDTO
    {

        public int Id
        {
            get; set;
        }
        public string Name
        {
            get; set;
        }
    }

    public class MotherboardCreate
    {      
        public string Name
        {
            get; set;
        }
    }
}
