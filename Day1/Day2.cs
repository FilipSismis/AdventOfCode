namespace AdventOfCode
{
    public class Day2
    {
        const int maxNrOfRed = 12;
        const int maxNrOfGreen = 13;
        const int maxNrOfBlue = 14;

        public int SumOfPossibleGameIds()
        {
            var sumOfAll = 0;
            var lines = File.ReadLines("d2input.txt");

            foreach (var line in lines)
            {
                var dataSplit = line.Split(':');
                var gameid = int.Parse(dataSplit[0].Split(' ')[1].Trim());
                var reveals = dataSplit[1].Split(';');
                bool isPossible = true;


                if(isPossible)
                    sumOfAll += gameid;
            }

            return sumOfAll;
        }
    }
}
