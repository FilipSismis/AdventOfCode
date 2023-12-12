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
            var lines = File.ReadLines("d2in.txt");

            foreach (var line in lines)
            {
                var dataSplit = line.Split(':');
                var gameid = int.Parse(dataSplit[0].Split(' ')[1].Trim());
                var reveals = dataSplit[1].Split(';');
                bool isPossible = true;
                foreach (var reveal in reveals)
                {
                    var data = reveal.Split(',');
                    foreach(var item in data)
                    { 
                        var trimmed = item.Trim(' ');
                        var split = item.Split(' ', options: StringSplitOptions.RemoveEmptyEntries);
                        var numberPart = int.Parse(split[0]);
                        var colorPart = split[1];
                        if (colorPart.Equals("blue"))
                            isPossible = isPossible && numberPart <= maxNrOfBlue;
                        if (colorPart.Equals("green"))
                            isPossible = isPossible && numberPart <= maxNrOfGreen;
                        if (colorPart.Equals("red"))
                            isPossible = isPossible && numberPart <= maxNrOfRed;
                    }
                }
                if(isPossible)
                    sumOfAll += gameid;
            }
            return sumOfAll;
        }

        public int SumOfPowerForAllTheGameSets()
        {
            var sumOfPower = 0;
            var lines = File.ReadLines("d2in.txt");
            foreach (var line in lines)
            {
                var reveals = line.Split(':')[1].Split(';');
                int maxR = 0;
                int maxG = 0;
                int maxB = 0;
                foreach (var reveal in reveals)
                {
                    var data = reveal.Split(',');
                    foreach(var item in data)
                    {
                        var trimmed = item.Trim(' ');
                        var split = item.Split(' ', options: StringSplitOptions.RemoveEmptyEntries);
                        var numberPart = int.Parse(split[0]);
                        var colorPart = split[1];
                        if (colorPart.Equals("blue"))
                            maxB = numberPart > maxB ? numberPart : maxB;
                        if (colorPart.Equals("green"))
                            maxG = numberPart > maxG ? numberPart : maxG;
                        if (colorPart.Equals("red"))
                            maxR = numberPart > maxR ? numberPart : maxR;
                    }
                }
                int powerOfSet = maxR * maxG * maxB;
                sumOfPower += powerOfSet;
            }
            return sumOfPower;
        }

    }
}
