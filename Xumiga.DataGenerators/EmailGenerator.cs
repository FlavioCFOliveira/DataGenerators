using System;
using System.Collections.Generic;
using System.Text;

namespace Xumiga.DataGenerators
{
    public static class EmailGenerator
    {
        /// <summary>
        /// Generates a random email concidering for [userName@domainName.domain] the default random sizes are:
        /// userName => 8 to 64 chars
        /// domainName => 3 to 16 chars
        /// domain => 2 to 5 chars
        /// </summary>
        /// <returns></returns>
        public static string GenerateEmail()
        {
            string userName = StringGenerator.GetAlphabeticLower(8, 64);
            string domainName = StringGenerator.GetAlphabeticLower(3, 16);
            string domain = StringGenerator.GetAlphabeticLower(2, 5);

            return GetEmail(userName, domainName, domain);
        }

        /// <summary>
        /// Generate an email with a ranged size username 
        /// </summary>
        /// <param name="userNameMinSize">Minimum username ammout of chars</param>
        /// <param name="userNameMaxSize">Maximum username ammout of chars</param>
        /// <param name="domainName">The email domain name</param>
        /// <param name="domain">The domain extension</param>
        /// <returns></returns>
        public static string GenerateEmail(int userNameMinSize, int userNameMaxSize, string domainName, string domain)
        {
            string userName = StringGenerator.GetAlphabetic(userNameMinSize, userNameMaxSize);

            return GetEmail(userName, domainName, domain);
        }

        /// <summary>
        /// Generate an email with a fixed sizes
        /// </summary>
        /// <param name="userNameSize"></param>
        /// <param name="domainNameSize"></param>
        /// <param name="domainSize"></param>
        /// <returns></returns>
        public static string GenerateEmail(int userNameSize, int domainNameSize, int domainSize)
        {
            string userName = StringGenerator.GetAlphabeticLower(userNameSize);
            string domainName = StringGenerator.GetAlphabeticLower(domainNameSize);
            string domain = StringGenerator.GetAlphabeticLower(domainSize);

            return GetEmail(userName, domainName, domain);
        }

        /// <summary>
        /// returns an email with the data provided.
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="domainName"></param>
        /// <param name="domain"></param>
        /// <returns></returns>
        public static string GetEmail(string userName, string domainName, string domain)
        {
            if (string.IsNullOrEmpty(userName)) throw new ArgumentNullException(nameof(userName));
            if (string.IsNullOrEmpty(domainName)) throw new ArgumentNullException(nameof(domainName));
            if (string.IsNullOrEmpty(domain)) throw new ArgumentNullException(nameof(domain));

            while (domain.StartsWith("."))
            {
                domain = domain.Substring(1);
            }

            return $"{userName}@{domainName}.{domain}";
        }

    }
}
