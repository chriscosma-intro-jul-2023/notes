namespace StringCalculatorKata
{
    public class StringCalculator
    {
        public int Add(string numbers)
        {
            if (numbers == "")
                return 0;

            if (numbers.StartsWith("//"))
            {
                char delimiter = numbers.ToCharArray()[2];
                if (delimiter == '-' && numbers.Contains("--"))
                {
                    int negativeIndex = numbers.IndexOf("--") + 2;
                    string negativeNum = new(numbers[negativeIndex..].TakeWhile((c) => c != '-').ToArray());
                    throw new ArgumentOutOfRangeException($"negatives not allowed: {negativeNum}");
                }
                numbers = numbers.Replace(delimiter, ',').Substring(4);
            }

            if (numbers.Contains(',') || numbers.Contains('\n'))
            {
                var parsedNumbers = numbers
                    .Replace('\n', ',')
                    .Split(',')
                    .Select(int.Parse);

                if (parsedNumbers.Where((i) => i < 0).Any())
                {
                    int negativeNum = parsedNumbers.Where((i) => i < 0).First();
                    throw new ArgumentOutOfRangeException($"negatives not allowed: {negativeNum}");
                }
                   
                return parsedNumbers
                    .Where((n) => n <= 1000)
                    .Sum();
            }

            int digit = int.Parse(numbers);
            if (digit < 0)
            {
                throw new ArgumentOutOfRangeException($"negatives not allowed: {digit}");
            } else if (digit > 1000)
            {
                return 0;
            } else
            {
                return digit;
            }
        }
    }
}
