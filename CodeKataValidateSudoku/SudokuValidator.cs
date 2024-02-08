namespace CodeKataValidateSudoku
{
    public class Sudoku
    {
        private int[][] sudokuData;

        public Sudoku(int[][] sudokuData)
        {
            this.sudokuData = sudokuData;
        }

        public bool ColumnsAreValid() => RowsAreValid(ColumnsAreRows());

        public bool IsValid() => ValidateInput() && ColumnsAreValid() && RowsAreValid() && RegionsAreValid();

        public bool RegionsAreValid() => RowsAreValid(FindRegions());

        public bool RowsAreValid() => RowsAreValid(sudokuData);

        public int[][] ColumnsAreRows()
        {
            var rowsAreColumns = new int[sudokuData.Length][];
            for (var i = 0; i < sudokuData.Length; i++)
            {
                rowsAreColumns[i] = new int[sudokuData.Length];
                for (var j = 0; j < sudokuData[0].Length; j++)
                {
                    rowsAreColumns[i][j] = sudokuData[j][i];
                    if (sudokuData[j][i] > sudokuData.Length)
                    {
                        var replacement = new int[sudokuData.Length];
                        for(var k = 0; k < rowsAreColumns[i].Length; k++)
                        {
                            replacement[k] = 0;
                        }
                        rowsAreColumns[i] = replacement;
                    }
                }
            }
            return rowsAreColumns;
        }

        public int[][] FindRegions()
        {
            var regions = new List<int[]>();
            var qty = sudokuData.Length;
            var steps = (int)Math.Sqrt(sudokuData.Length);
            for (var i = 0; i < qty; i += steps)
            {
                for (var j = 0; j < qty; j += steps)
                {
                    var region = new List<int>();
                    for (var k = i; k < i + steps; k++)
                    {
                        for (var l = j; l < j + steps; l++)
                        {
                            region.Add(sudokuData[k][l]);
                        }
                    }
                    regions.Add(region.ToArray());
                }
            }
            return regions.ToArray();
        }

        public bool RowsAreValid(int[][] rows)
        {
            for(var r=0; r<rows.Length; r++)
            {
                if (rows[r].Any(a => a == 0)) return false;
                if(new HashSet<int>(rows[r]).Count != rows.Length) return false;
            }
            return true;
        }

        public bool ValidateInput()
        {
            if(sudokuData.Length < 1) return false;
            for(var i = 0; i<sudokuData.Length; i++)
            {
                if (sudokuData[i].Length != sudokuData.Length) return false;
            }
            return true;
        }
    }
}
