using building_palindromes;
using Xunit;

namespace UnitTests
{
    public class BuildingPalindromesTests
    {
        [Theory]
        [InlineData("jdfh", "fds", "dfhfd")]
        [InlineData("fds", "jdfh", "dfhfd")]
        [InlineData("jhdfkiikfaz", "jdh", "hdfkiikfdh")]
        [InlineData("jdh", "jhdfkiikfaz", "hdfkiikfdh")]
        [InlineData("jhdfkiikfdhaz", "ikf", "fkiiikf")]
        [InlineData("ikf", "jhdfkiikfdhaz", "fkiiikf")]
        [InlineData("kf", "fkiiikf", "fkiiikf")]
        [InlineData("fds", "sdf", "fdssdf")]
        [InlineData("sdf", "fds", "fdssdf")]
        public void GivenToStrings_GetLongestPalindrome_KMPPalindromes(string first, string second, string correctResult)
        {
            var test = new KMPPalindromes(first, second);
            Assert.Equal(correctResult, test.GetLongestPalindrome());
        }

        [Theory]
        [InlineData("jdfh", "fds", "dfhfd")]
        [InlineData("fds", "jdfh", "dfhfd")]
        [InlineData("jhdfkiikfaz", "jdh", "hdfkiikfdh")]
        [InlineData("jdh", "jhdfkiikfaz", "hdfkiikfdh")]
        [InlineData("jhdfkiikfdhaz", "ikf", "fkiiikf")]
        [InlineData("ikf", "jhdfkiikfdhaz", "fkiiikf")]
        [InlineData("kf", "fkiiikf", "fkiiikf")]
        [InlineData("fds", "sdf", "fdssdf")]
        [InlineData("sdf", "fds", "fdssdf")]
        public void GivenToStrings_GetLongestPalindrome_QuiteBetterNaivePalindromes(string first, string second, string correctResult)
        {
            var test = new QuiteBetterNaivePalindromes(first, second);
            Assert.Equal(correctResult, test.GetLongestPalindrome());
        }
    }
}
