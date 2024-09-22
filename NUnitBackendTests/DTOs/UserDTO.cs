namespace NUnitBackendTests.DTOs
{
    public class UserDTO
    {
        public AddressDTO? Address { get; set; }
        public int Id { get; set; }
        public string? Email { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public NameDTO? Name { get; set; }
        public string? Phone { get; set; }
        public int __v { get; set; }

        public static int CompareById(UserDTO x, UserDTO y)
        {
            return x.Id.CompareTo(y.Id);
        }
    }

    public class AddressDTO
    {
        public GeolocationDTO? Geolocation { get; set; }
        public string? City { get; set; }
        public string? Street { get; set; }
        public int Number { get; set; }
        public string? Zipcode { get; set; }
    }

    public class GeolocationDTO
    {
        public string? Lat { get; set; }
        public string? Long { get; set; }
    }

    public class NameDTO
    {
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
    }
}