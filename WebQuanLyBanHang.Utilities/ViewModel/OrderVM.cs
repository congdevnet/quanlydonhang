namespace WebQuanLyBanHang.Utilities.ViewModel
{
    public class OrderVM
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public DateTime? DateCreated { get; set; } = DateTime.Now;
        public bool IsOrderActive { get; set; }
        public Guid UserId { get; set; }

        public OrderVM(Guid id, DateTime? dateCreated, Guid userId,bool isOrderActive)
        {
            Id = id; 
            DateCreated = dateCreated; 
            UserId = userId;
            IsOrderActive = isOrderActive;
        }
    }
}