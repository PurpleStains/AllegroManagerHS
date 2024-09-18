using AllegroConnector.Domain.EAN;

namespace AllegroConnector.Application.Validation
{
    public class EANValidator : IEANValidator
    {
        public bool IsValidEAN(string ean)
        {
            // Validate length: should be either 8 or 13 digits
            if (ean == null || (ean.Length != 8 && ean.Length != 13))
            {
                return false;
            }

            // Ensure all characters are digits
            if (!ulong.TryParse(ean, out _))
            {
                return false;
            }

            int sum = 0;
            int length = ean.Length;

            for (int i = 0; i < length - 1; i++)
            {
                int digit = ean[i] - '0';

                if ((length == 13 && (i % 2 == 0)) || (length == 8 && (i % 2 != 0)))
                {
                    // For EAN-13: digits in odd positions (0-based index)
                    // For EAN-8: digits in even positions
                    sum += digit;
                }
                else
                {
                    // For EAN-13: digits in even positions
                    // For EAN-8: digits in odd positions
                    sum += digit * 3;
                }
            }

            int checksum = (10 - (sum % 10)) % 10;
            int checkDigit = ean[length - 1] - '0';

            return checksum == checkDigit;
        }
    }
}
