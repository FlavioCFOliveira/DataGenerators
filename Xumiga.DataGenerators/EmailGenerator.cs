using System;
using System.Collections.Generic;
using System.Text;

namespace Xumiga.DataGenerators
{
    public static class EmailGenerator
    {

        public static string GetEmail()
        {
            string userName = StringGenerator.GetAlphabeticLower(8, 64);
            string domainName = StringGenerator.GetAlphabeticLower(3, 16);
            string domain = StringGenerator.GetAlphabeticLower(2, 5);

            return GetEmail(userName, domainName, domain);
        }

        public static string GetEmail(int userNameMinSize, int userNameMaxSize, string domainName, string domain)
        {
            string userName = StringGenerator.GetAlphabetic(userNameMinSize, userNameMaxSize);

            return GetEmail(userName, domainName, domain);
        }

        public static string GetEmail(int userNameSize, int domainNameSize, int domainSize)
        {
            string userName = StringGenerator.GetAlphabeticLower(userNameSize);
            string domainName = StringGenerator.GetAlphabeticLower(domainNameSize);
            string domain = StringGenerator.GetAlphabeticLower(domainSize);

            return GetEmail(userName, domainName, domain);
        }

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
