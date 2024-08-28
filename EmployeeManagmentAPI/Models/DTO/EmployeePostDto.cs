namespace EmployeeManagmentAPI.Models.DTO
{
    public class EmployeePostDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }
        public int? ManagerId { get; set; } 
    }
}
