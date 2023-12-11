using System.Text;

namespace AdventOfCode
{
    public class Day1
    {
        readonly List<string> stringNumbers = new() { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
        public int SumAllCalibrationValues()
        {
            var sumOfAll = 0;
            var lines = File.ReadLines("input.txt");
            foreach (var line in lines)
            {
                var numbers = line.Where(char.IsDigit).ToList();
                if (!numbers.Any())
                    continue;

                if (numbers.Count == 1)
                {
                    int onlyDigit = int.Parse(numbers.First().ToString());
                    sumOfAll += onlyDigit * 10 + onlyDigit;
                }
                else
                {
                    int firstDigit = int.Parse(numbers.First().ToString());
                    int lastDigit = int.Parse(numbers.Last().ToString());
                    sumOfAll += firstDigit * 10 + lastDigit;
                }
            }

            return sumOfAll;
        }
        
        public int SumAllCalibrationValuesPartTwo()
        {
            var sumOfAll = 0;
            var lines = File.ReadLines("input.txt");

            foreach (var line in lines)
            {
                var firstNumber = FindFirstNumber(line);
                var lastNumber = FindLastNumber(line);

                int firstDigit = 0;
                int lastDigit = 0;
                if (!int.TryParse(firstNumber, out firstDigit))
                    ParseNumberWords(firstNumber, out firstDigit);

                if (!int.TryParse(lastNumber, out lastDigit))
                    ParseNumberWords(lastNumber, out lastDigit);

                sumOfAll += (firstDigit * 10) + lastDigit;
            }

            return sumOfAll;
        }

        private string FindFirstNumber(string input)
        {
            StringBuilder sb = new();
            foreach (char c in input)
            {
                if (char.IsDigit(c))
                    return c.ToString();
                else
                {
                    sb.Append(c);
                    var possibleNumbers = stringNumbers.Where(i => i.StartsWith(sb.ToString())).ToList();
                    if (!possibleNumbers.Any())
                    {
                        sb.Clear();
                        if(stringNumbers.Any(i => i.StartsWith(c)))
                            sb.Append(c);
                    }
                    else if (possibleNumbers.Count() == 1 && sb.Length == possibleNumbers.First().Length)
                    {
                        return possibleNumbers.First();
                    }
                }
            }
            return string.Empty;
        }

        private string FindLastNumber(string input)
        {
            var reverseArray = input.Reverse();
            StringBuilder sb = new();
            foreach (var c in reverseArray)
            {
                if (char.IsDigit(c))
                    return c.ToString();
                else
                {
                    sb.Insert(0, c);
                    var possibleNumbers = stringNumbers.Where(i => i.EndsWith(sb.ToString())).ToList();
                    if (!possibleNumbers.Any())
                    {
                        sb.Clear();
                        if (stringNumbers.Any(i => i.EndsWith(c)))
                            sb.Insert(0, c);
                    }
                    else if (possibleNumbers.Count() == 1 && sb.Length == possibleNumbers.First().Length)
                    {
                        return possibleNumbers.First();
                    }
                }
            }
            return string.Empty;
        }

        private void ParseNumberWords(string word, out int number)
        {
            switch (word)
            {
                case "one":
                    number = 1;
                    break;
                case "two":
                    number = 2;
                    break;
                case "three":
                    number = 3;
                    break;
                case "four":
                    number = 4;
                    break;
                case "five":
                    number = 5;
                    break;
                case "six":
                    number = 6;
                    break;
                case "seven":
                    number = 7;
                    break;
                case "eight":
                    number = 8;
                    break;
                case "nine":
                    number = 9;
                    break;
                default:
                    number = -1;
                    break;
            }
        }
    }
}
