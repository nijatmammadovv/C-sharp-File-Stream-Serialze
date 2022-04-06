using System.Collections.Generic;


namespace C_sharp_File_Stream_Serialze.Models
{
    class Order
    {
        public int Id { get; set; }
        public List<OrderItem> OrderItems { get; set; }
    }
}
