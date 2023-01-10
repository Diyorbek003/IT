namespace IT.Entities
{
    public class Admin
    {

        public Guid Id { get; set; }

        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? ConfirmPassword { get; set; }
        public bool? IsAdmin { get; set; }

        public int Phone { get; set; }


    }
}
