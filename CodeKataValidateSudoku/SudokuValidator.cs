using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public bool IsValid() => ColumnsAreValid() && RowsAreValid() && RegionsAreValid();

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
                }
            }
            return rowsAreColumns;
        }

        public int[][] FindRegions()
        {
            var regions = new List<int[]>();
            for (var i = 0; i < 9; i += 3)
            {
                for (var j = 0; j < 9; j += 3)
                {
                    var region = new List<int>();
                    for (var k = i; k < i + 3; k++)
                    {
                        for (var l = j; l < j + 3; l++)
                        {
                            var value = sudokuData[k][l];
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
            foreach(var row in rows){
                if(row.ToHashSet().Count() != 9) return false;
            }
            return true;
        }
    }
}
