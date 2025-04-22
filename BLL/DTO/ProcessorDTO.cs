

namespace BLL.DTO
{
    public class ProcessorDTO
    {
        public int Id
        {
            get; set;
        }
        public string? Name
        {
            get; set;
        }
    }

    public class  ProcessorCreate
    {
        public string Name
        {
            get; set;
        }
    }
}
