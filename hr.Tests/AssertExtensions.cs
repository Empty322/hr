using Newtonsoft.Json;

namespace hr.Tests;

internal static class AssertExtensions
{
    public static void AreEqualByJson(object expected, object actual)
    {
        var expectedJson = JsonConvert.SerializeObject(expected);
        var actualJson = JsonConvert.SerializeObject(actual);

        Assert.That(actualJson, Is.EqualTo(expectedJson));
    }
}
