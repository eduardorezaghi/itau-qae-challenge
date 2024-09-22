using FluentAssertions;
using Newtonsoft.Json;
using NUnitBackendTests.Adapters;
using NUnitBackendTests.DTOs;

namespace NUnitBackendTests
{
    [TestFixture]
    public class UserGetTests
    {
        private HttpAdapter _httpAdapter;
        private HttpResponseMessage? _response;
        private UserDTO? _user;
        private List<UserDTO>? _users;
        private int _userId;

        [SetUp]
        public void Setup()
        {
            _httpAdapter = new HttpAdapter("https://fakestoreapi.com");
        }

        [Test]
        public async Task GetUser_ReturnsValidUser()
        {
            await RequestUserDetail(1);
            await AssertResponseShouldBeSuccessful();
            AssertUserDetailsShouldBeReturned(_user);
        }

        [Test]
        [TestCase("asc")]
        [TestCase("desc")]
        public async Task GetUsers_ValidateOrdering(string ordering)
        {
            await RequestUsers(ordering);
            await AssertResponseShouldBeSuccessful();
            AssertUserDetailsShouldBeReturned(_users![0]);
            AssertOrderingShouldBe(ordering);
        }


        private async Task RequestUsers(string ordering)
        {
            var resource = "/users";
            var parameters = new Dictionary<string, string> { { "sort", ordering } };
            _response = await _httpAdapter.GetAsync(resource, parameters);
            var content = await _response.Content.ReadAsStringAsync();

            this._users = JsonConvert.DeserializeObject<List<UserDTO>>(content);
            this._userId = _users![0].Id;
        }

        private async Task RequestUserDetail(int userId, string ordering = "asc")
        {
            var resource = $"/users/{userId}";
            var parameters = new Dictionary<string, string> { { "sort", ordering } };
            _response = await _httpAdapter.GetAsync(resource, parameters);
            var content = await _response.Content.ReadAsStringAsync();

            this._user = JsonConvert.DeserializeObject<UserDTO>(content);
            this._userId = userId;
        }
        private void AssertOrderingShouldBe(string ordering)
        {
            switch (ordering)
            {
                case "asc":
                    CollectionAssert.IsOrdered(_users, Comparer<UserDTO>.Create((x, y) => x.Id.CompareTo(y.Id)));
                    break;
                case "desc":
                    CollectionAssert.IsOrdered(_users, Comparer<UserDTO>.Create((x, y) => y.Id.CompareTo(x.Id)));
                    break;
                default:
                    throw new ArgumentException("Invalid ordering specified. Use 'asc' or 'desc'.");
            }
        }

        private Task AssertResponseShouldBeSuccessful()
        {
            _response?.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
            return Task.CompletedTask;
        }

        private void AssertUserDetailsShouldBeReturned(UserDTO? user = null)
        {
            user.Should().NotBeNull();
            user?.Id.Should().Be(_userId);
            user?.Name.Should().NotBeNull().And.BeOfType<NameDTO>();
            user?.Name?.Firstname.Should().NotBeNullOrEmpty().And.BeOfType<string>();
            user?.Name?.Lastname.Should().NotBeNullOrEmpty().And.BeOfType<string>();
            user?.Email.Should().NotBeNullOrEmpty().And.BeOfType<string>();
            user?.Address.Should().NotBeNull().And.BeOfType<AddressDTO>();
        }
    }
}
