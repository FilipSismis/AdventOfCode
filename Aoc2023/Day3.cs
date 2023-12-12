namespace AdventOfCode
{
    public class Day3
    {
        
        public int SumOfEngineParts()
        {
            int sumOfEnignes = 0;
            var charArray = LoadDataIntoArrays();
            int nrOfRows = charArray.GetLength(0);
            int nrOfCols = charArray.GetLength(1);

            for (int y = 0; y < nrOfRows; y++)
            {
                for (int x = 0; x < nrOfCols; x++)
                {
                    if (IsSymbol(charArray[y, x]))
                    {
                        var digitIndexesAround = GetDigitIndexesAroundASymbol(charArray, y, x);
                        if (digitIndexesAround.Any())
                        {
                            foreach(var index in digitIndexesAround)
                            {
                                sumOfEnignes += GetEnginePartsAroundSymbolSummed(charArray, index.Item1, index.Item2);
                            }
                        }
                    }
                }
            }


            return sumOfEnignes;
        }

        private char[,] LoadDataIntoArrays()
        {
            string[] lines = File.ReadAllLines("d3in.txt");

            int rows = lines.Length;
            int cols = lines[0].Length;

            char[,] charArray = new char[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                char[] lineChars = lines[i].ToCharArray();
                for (int j = 0; j < cols; j++)
                {
                    charArray[i, j] = lineChars[j];
                }
            }
            return charArray;
        }

        private bool IsSymbol(char c) => !char.IsDigit(c) && !c.Equals('.');

        private List<(int, int)> GetDigitIndexesAroundASymbol(char[,] charArray, int y, int x)
        {
            //would add check for index out of range when checking around a symbol but my input doesn't have any symbols on the border
            List<(int, int)> tupleList = new();
            for(int checkY = -1; checkY < 2; checkY++)
            {
                for(int checkX = -1; checkX < 2; checkX++)
                {
                    if (char.IsDigit(charArray[y + checkY, x + checkX]))
                        tupleList.Add((y + checkY, x + checkX));
                }
            }
            return tupleList;
        }

        private int GetEnginePartsAroundSymbolSummed(char[,] charArray, int y, int x ) 
        {

            return -1;
        }
    }
}
