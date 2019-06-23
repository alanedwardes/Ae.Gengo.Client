using System.Collections.Specialized;
using Ae.Gengo.Client.Internal;
using Xunit;

namespace Ae.Gengo.Client.Tests
{
    public class ClientExtensionsTests
    {
        [Fact]
        public void TestToQueryString()
        {
            var query = new NameValueCollection
            {
                { "test", "abc" },
                { "test", "bcd" },
                { "wibble", "foo" }
            };

            var queryString = query.ToQueryString();

            Assert.Equal("?test=abc&test=bcd&wibble=foo", queryString);
        }

        [Fact]
        public void TestEmptyToQueryString()
        {
            var query = new NameValueCollection();

            var queryString = query.ToQueryString();

            Assert.Equal(string.Empty, queryString);
        }
    }
}
