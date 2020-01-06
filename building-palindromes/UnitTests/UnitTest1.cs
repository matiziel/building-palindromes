using System;
using Xunit;
using building_palindromes;

namespace UnitTests
{
    public class BuildingPalindromesTests
    {
        [Theory]
        [InlineData("jdfh", "fds", "dfhfd")]
        [InlineData("fds", "jdfh", "dfhfd")]
        [InlineData("jhdfkiikfaz", "jdh", "hdfkiikfdh")]
        [InlineData( "jdh", "jhdfkiikfaz", "hdfkiikfdh")]
        [InlineData("jhdfkiikfdhaz", "ikf", "fkiiikf")]
        [InlineData("ikf", "jhdfkiikfdhaz", "fkiiikf")]
        [InlineData("fds", "sdf", "fdssdf")]
        public void GivenToStrings_GetLongestPalindrome(string first, string second, string correctResult)
        {
            var test = new BuildingPalindromes(first, second);
            Assert.Equal(correctResult, test.GetLongestPalindrome());
        }
    }
}
