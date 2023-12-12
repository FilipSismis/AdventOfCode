using System.Text;

namespace AdventOfCode
{
    public class Day1
    {
        readonly List<string> stringNumbers = new() { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
        public int SumAllCalibrationValues()
        {
            var sumOfAll = 0;
            var lines = File.ReadLines("d1input.txt");
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
            var lines = File.ReadLines("d1input.txt");
            int lineNr = 1;
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

                var number = (firstDigit * 10) + lastDigit;
                sumOfAll += number;
                Console.WriteLine($"Line:{lineNr} | Input:{line} | First digit:{firstDigit} | Last digit:{lastDigit} | Number:{number} | Total sum:{sumOfAll}");
                lineNr ++;
            }

            return sumOfAll;
        }

        private string FindFirstNumber(string input)
        {
            for (int i = 0; i <= input.Length; i++)
            {
                char c = input[i];
                if (char.IsDigit(c))
                    return c.ToString();
                else
                {
                    var possibleNumbers = stringNumbers.Where(i => i.StartsWith(c)).ToList();
                    if (possibleNumbers.Any())
                    {
                        int startIndex = i;
                        foreach (var number in possibleNumbers)
                        {
                            if ((startIndex + number.Length) <= input.Length)
                                if(input.Substring(startIndex, number.Length).Equals(number))
                                    return number;
                        }
                    }
                }
            }
            return string.Empty;
        }

        private string FindLastNumber(string input)
        {
            var reverseList = input.Reverse().ToArray();
            for (int i = 0; i < reverseList.Count(); i++)
            {
                char c = reverseList[i];
                if (char.IsDigit(c))
                    return c.ToString();
                else
                {
                    var possibleNumbers = stringNumbers.Where(i => i.EndsWith(c)).ToList();
                    if (possibleNumbers.Any())
                    {
                        var endIndex = input.Length - 1 - i;
                        foreach (var number in possibleNumbers)
                        {
                            var startIndex = endIndex - number.Length + 1;
                            if (startIndex >= 0 && (startIndex + number.Length) <= input.Length)
                                if (input.Substring(startIndex, number.Length).Equals(number))
                                    return number;
                        }
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
