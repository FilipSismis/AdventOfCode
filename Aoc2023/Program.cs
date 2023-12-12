using AdventOfCode;

public class Program
{
    static void Main(string[] args)
    {
        //var day1 = new Day1();

        //var day1Result = day1.SumAllCalibrationValues();
        //Console.WriteLine($"Day 1 - sum of all calibration values is:{day1Result}");

        //var day1Part2Result = day1.SumAllCalibrationValuesPartTwo();
        //Console.WriteLine($"Day 1 - sum of all calibration values part two is:{day1Part2Result}");

        var day2 = new Day2();

        var day2Part1Result = day2.SumOfPossibleGameIds();
        Console.WriteLine($"Day 2 - sum of all possible game ids is:{day2Part1Result}");

    }
}