
using Xunit;

namespace Weknow_BasicExtensions_Tests
{
    public class CollectionExtensionsTests
    {
        [Fact]
        public void ToYield_Test()
        {
            int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var r1 = 1.ToYield(2, arr[2..]);
            var r2 = 1.ToYield(2, 3, arr[3..]);
            var r3 = 1.ToYield(2, 3, 4, arr[4..]);
            var r4 = arr[..2].ToYield(3, 4, 5, 6, 7, 8, 9);

            Assert.Equal(arr, r1);
            Assert.Equal(r1, r2);
            Assert.Equal(r2, r3);
            Assert.Equal(r3, r4);
        }
    }
}
