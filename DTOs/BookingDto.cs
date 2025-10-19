namespace Hotel_Reservation_System.DTOs
{
    public class BookingDto
    {
        public int Id { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public decimal TotalCost { get; set; }
        public string Status { get; set; } = "Active";
    }
}
