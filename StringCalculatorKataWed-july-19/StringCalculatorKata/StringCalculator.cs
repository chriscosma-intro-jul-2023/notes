namespace StringCalculatorKata
{
    public class StringCalculator
    {
        public int Add(string numbers)
        {
            if (numbers == "")
            {
                return 0;
            } 
            return numbers.Split(',')
                .Select(int.Parse)
                .Sum();
        }
    }
}
