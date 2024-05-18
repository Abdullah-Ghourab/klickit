using klickit.Core.Entities;

namespace klickit.Core.DTOs
{
    public class ChangeOrderStatusDto
    {
        public int OrderId { get; set; }
        public Status Status { get; set; }
    }
}
