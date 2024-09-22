using FluentAssertions;
using Newtonsoft.Json;
using NUnitBackendTests.Adapters;
using NUnitBackendTests.DTOs;

namespace NUnitBackendTests.Tests
{
    [TestFixture]
    public class UserPutTests
    {
        private const string _baseUrl = "https://fakestoreapi.com";
        private HttpAdapter _httpAdapter;
        private HttpResponseMessage? _response;
        private UserDTO _user;
        private UserDTO? _updated_user;


        private UserDTO RequestUserDetail(int userId)
        {
            var resource = $"/users/{userId}";
            _response = _httpAdapter.GetAsync(resource).Result;
            var content = _response.Content.ReadAsStringAsync().Result;

            UserDTO user = JsonConvert.DeserializeObject<UserDTO>(content) ??
                throw new InvalidOperationException("Deserialization resulted in a null object.");

            return user;
        }


        [SetUp]
        public void Setup()
        {
            _httpAdapter = new HttpAdapter(_baseUrl);
             this._user = RequestUserDetail(1);
        }

        [Test]
        public async Task UpdateUser_ReturnsValidUser()
        {
            // Arrange
            _updated_user = new UserDTO
            {
                Id = _user.Id,
                Email = "updated@mail.com",
                Username = "updated_username",
                Password = "updated_password",
                Name = new NameDTO
                {
                    Firstname = "updated_firstname",
                    Lastname = "updated_lastname"
                },
                Phone = "1-770-736-8031",
                Address = new AddressDTO
                {
                    City = "updated_city",
                    Street = "updated_street",
                    Number = 123,
                    Zipcode = "updated_zipcode",
                    Geolocation = new GeolocationDTO
                    {
                        Lat = "updated_lat",
                        Long = "updated_long"
                    }
                },
                __v = 0
            };

            // Act
            await WhenIUpdateTheUser(_user.Id, _updated_user);

            // Assert
            ThenTheResponseShouldBeSuccessful();
            ThenTheUpdatedUserDetailsShouldBeReturned(_updated_user);
        }

        private async Task WhenIUpdateTheUser(int userId, UserDTO updatedUser)
        {
            _response = await _httpAdapter.PutAsync($"{_baseUrl}/users/{userId}", updatedUser);
            var content = await _response.Content.ReadAsStringAsync();
            _user = JsonConvert.DeserializeObject<UserDTO>(content) ?? 
                    throw new InvalidOperationException("Deserialization resulted in a null object.");
        }

        private void ThenTheResponseShouldBeSuccessful()
        {
            _response?.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }

        private void ThenTheUpdatedUserDetailsShouldBeReturned(UserDTO expectedUser)
        {
            _user.Should().NotBeNull();
            _user.Name.Should().NotBeNull();
            _user.Address.Should().NotBeNull();
            _user.Address!.Geolocation.Should().NotBeNull();

            _user.Email.Should().Be(expectedUser.Email);
            _user.Username.Should().Be(expectedUser.Username);
            _user.Name!.Firstname.Should().Be(expectedUser.Name!.Firstname);
            _user.Name.Lastname.Should().Be(expectedUser.Name.Lastname);
            _user.Address!.City.Should().Be(expectedUser.Address!.City);
            _user.Address.Street.Should().Be(expectedUser.Address.Street);
            _user.Address.Number.Should().Be(expectedUser.Address.Number);
            _user.Address.Zipcode.Should().Be(expectedUser.Address.Zipcode);
            _user.Address.Geolocation!.Lat.Should().Be(expectedUser.Address.Geolocation!.Lat);
            _user.Address.Geolocation.Long.Should().Be(expectedUser.Address.Geolocation.Long);
            _user.Phone.Should().Be(expectedUser.Phone);
        }

    }
}