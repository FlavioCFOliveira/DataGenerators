using System;

namespace Xumiga.DataGenerators;

public static class EmailGenerator
{
    public static string GenerateEmailAddressWithWords(int numberOfWords = 3, string separator = ".")
    {
        string userName = string.Join(separator, WordGenerator.GenerateWords(numberOfWords));
        string domainName = WordGenerator.GenerateWord(4, 9);
        string domain = StringGenerator.GetAlphabeticLower(2, 5);

        return GetEmailAddress(userName, domainName, domain);
    }

    /// <summary>
    /// Generates a random email concidering for [userName@domainName.domain] the default random sizes are:
    /// userName => 8 to 32 chars
    /// domainName => 3 to 16 chars
    /// domain => 2 to 5 chars
    /// </summary>
    /// <returns></returns>
    public static string GenerateEmailAddress()
    {
        string userName = StringGenerator.GetAlphabeticLower(8, 32);
        string domainName = StringGenerator.GetAlphabeticLower(3, 16);
        string domain = StringGenerator.GetAlphabeticLower(2, 5);

        return GetEmailAddress(userName, domainName, domain);
    }

    /// <summary>
    /// Generate an email with a ranged size username 
    /// </summary>
    /// <param name="userNameMinSize">Minimum username ammout of chars</param>
    /// <param name="userNameMaxSize">Maximum username ammout of chars</param>
    /// <param name="hostName">The email domain name</param>
    /// <param name="hostExtension">The domain extension</param>
    /// <returns></returns>
    public static string GenerateEmailAddress(int userNameMinSize, int userNameMaxSize, string hostName, string hostExtension)
    {
        string userName = StringGenerator.GetAlphabetic(userNameMinSize, userNameMaxSize);

        return GetEmailAddress(userName, hostName, hostExtension);
    }

    /// <summary>
    /// Generate an email with a fixed sizes
    /// </summary>
    /// <param name="userNameSize"></param>
    /// <param name="hostNameSize"></param>
    /// <param name="hostExtensionSize"></param>
    /// <returns></returns>
    public static string GenerateEmailAddress(int userNameSize, int hostNameSize, int hostExtensionSize)
    {
        string userName = StringGenerator.GetAlphabeticLower(userNameSize);
        string domainName = StringGenerator.GetAlphabeticLower(hostNameSize);
        string domain = StringGenerator.GetAlphabeticLower(hostExtensionSize);

        return GetEmailAddress(userName, domainName, domain);
    }

    /// <summary>
    /// Generate an email with a fixed sizes
    /// </summary>
    /// <param name="userNameSize"></param>
    /// <param name="hostNameSize"></param>
    /// <param name="hostExtensionSize"></param>
    /// <returns></returns>
    public static string GenerateEmailAddress(int userNameSize, int hostSize)
    {
        string userName = StringGenerator.GetAlphabeticLower(userNameSize);
        string host = StringGenerator.GetAlphabeticLower(hostSize);

        return GetEmailAddress(userName, host);
    }

    /// <summary>
    /// returns an email address with the provided data.
    /// </summary>
    /// <param name="userName"></param>
    /// <param name="hostName"></param>
    /// <param name="hostExtension"></param>
    /// <returns></returns>
    private static string GetEmailAddress(string userName, string hostName, string hostExtension)
    {
        if (string.IsNullOrEmpty(userName)) throw new ArgumentNullException(nameof(userName));
        if (string.IsNullOrEmpty(hostName)) throw new ArgumentNullException(nameof(hostName));
        if (string.IsNullOrEmpty(hostExtension)) throw new ArgumentNullException(nameof(hostExtension));

        while (hostExtension.StartsWith("."))
        {
            hostExtension = hostExtension.Substring(1);
        }

        return $"{userName.Trim()}@{hostName.Trim()}.{hostExtension.Trim()}";
    }

    /// <summary>
    /// returns an email address according the provided data.
    /// </summary>
    /// <param name="userName"></param>
    /// <param name="host"></param>
    /// <returns></returns>
    private static string GetEmailAddress(string userName, string host)
    {
        if (string.IsNullOrEmpty(userName)) throw new ArgumentNullException(nameof(userName));
        if (string.IsNullOrEmpty(host)) throw new ArgumentNullException(nameof(host));

        return $"{userName.Trim()}@{host.Trim()}";
    }

}