﻿using System;
using System.Text;

namespace Sudoku.SwarmInt
{
    public class SwarmSudoku
    {
        private SwarmSudoku(int[,] cellValues)
        {
            CellValues = cellValues;
        }

        public static SwarmSudoku New(int[,] cellValues)
        {
            return new SwarmSudoku(SwarmIntSolver.DuplicateMatrix(cellValues));
        }

        public static SwarmSudoku New(SwarmSudoku swarmSudoku)
        {
            return new SwarmSudoku(SwarmIntSolver.DuplicateMatrix(swarmSudoku.CellValues));
        }

        public int[,] CellValues { get; }

        public int Error
        {
            get
            {
                return CountErrors(true) + CountErrors(false);

                int CountErrors(bool countByRow)
                {
                    var errors = 0;
                    for (var i = 0; i < SwarmIntSolver.SIZE; ++i)
                    {
                        var counts = new int[SwarmIntSolver.SIZE];
                        for (var j = 0; j < SwarmIntSolver.SIZE; ++j)
                        {
                            var cellValue = countByRow ? CellValues[i, j] : CellValues[j, i];
                            ++counts[cellValue - 1];
                        }

                        for (var k = 0; k < SwarmIntSolver.SIZE; ++k)
                        {
                            if (counts[k] == 0)
                                ++errors;
                        }
                    }

                    return errors;
                }
            }
        }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            for (var r = 0; r < SwarmIntSolver.SIZE; ++r)
            {
                if (r == 3 || r == 6) stringBuilder.AppendLine();
                for (var c = 0; c < SwarmIntSolver.SIZE; ++c)
                {
                    if (c == 3 || c == 6) stringBuilder.Append(" ");
                    if (CellValues[r, c] == 0)
                        stringBuilder.Append(" _");
                    else
                        stringBuilder.Append(" " + CellValues[r, c]);
                }

                stringBuilder.AppendLine();
            }

            return stringBuilder.ToString();
        }

        public static SwarmSudoku Difficult
        {
            get
            {
                var problem = new[,]
                {
          {0, 0, 6, 2, 0, 0, 0, 8, 0},
          {0, 0, 8, 9, 7, 0, 0, 0, 0},
          {0, 0, 4, 8, 1, 0, 5, 0, 0},
          {0, 0, 0, 0, 6, 0, 0, 0, 2},
          {0, 7, 0, 0, 0, 0, 0, 3, 0},
          {6, 0, 0, 0, 5, 0, 0, 0, 0},
          {0, 0, 2, 0, 4, 7, 1, 0, 0},
          {0, 0, 3, 0, 2, 8, 4, 0, 0},
          {0, 5, 0, 0, 0, 1, 2, 0, 0}
        };

                return new SwarmSudoku(problem);
            }
        }

        /// <summary>
        /// http://ieeexplore.ieee.org/stamp/stamp.jsp?tp=&arnumber=5412260
        /// no = 200, me = 9000
        /// </summary>
        public static SwarmSudoku VeryDifficult
        {
            get
            {
                var problem = new[,]
                {
          {0, 0, 0, 0, 7, 0, 0, 0, 0},
          {0, 9, 0, 5, 0, 6, 0, 8, 0},
          {0, 0, 8, 4, 0, 1, 2, 0, 0},
          {0, 5, 9, 0, 0, 0, 8, 4, 0},
          {7, 0, 0, 0, 0, 0, 0, 0, 6},
          {0, 2, 3, 0, 0, 0, 5, 7, 0},
          {0, 0, 5, 3, 0, 7, 4, 0, 0},
          {0, 1, 0, 6, 0, 8, 0, 9, 0},
          {0, 0, 0, 0, 1, 0, 0, 0, 0}
        };

                return new SwarmSudoku(problem);
            }
        }

        public static SwarmSudoku Easy
        {
            get
            {
                var problem = new[,]
                {
          {0, 0, 7, 0, 0, 2, 9, 3, 0},
          {0, 8, 1, 0, 0, 0, 0, 0, 5},
          {9, 0, 4, 7, 0, 0, 1, 6, 0},
          {0, 1, 0, 8, 0, 0, 0, 0, 6},
          {8, 4, 6, 0, 0, 0, 5, 9, 2},
          {5, 0, 0, 0, 0, 6, 0, 1, 0},
          {0, 9, 2, 0, 0, 8, 3, 0, 1},
          {4, 0, 0, 0, 0, 0, 6, 5, 0},
          {0, 6, 5, 4, 0, 0, 2, 0, 0}
        };

                return new SwarmSudoku(problem);
            }
        }

        /// <summary>
        /// http://elmo.sbs.arizona.edu/sandiway/sudoku/examples.html
        /// no = 100, me = 19,000
        /// </summary>
        public static SwarmSudoku ExtremelyDifficult
        {
            get
            {
                var problem = new[,]
                {
          {0, 0, 0, 6, 0, 0, 4, 0, 0},
          {7, 0, 0, 0, 0, 3, 6, 0, 0},
          {0, 0, 0, 0, 9, 1, 0, 8, 0},
          {0, 0, 0, 0, 0, 0, 0, 0, 0},
          {0, 5, 0, 1, 8, 0, 0, 0, 3},
          {0, 0, 0, 3, 0, 6, 0, 4, 5},
          {0, 4, 0, 2, 0, 0, 0, 6, 0},
          {9, 0, 3, 0, 0, 0, 0, 0, 0},
          {0, 2, 0, 0, 0, 0, 1, 0, 0}
        };

                return new SwarmSudoku(problem);
            }
        }

        /// <summary>
        /// http://elmo.sbs.arizona.edu/sandiway/sudoku/examples.html
        /// no = 100, me = 5,000
        /// </summary>
        public static SwarmSudoku MostDifficult
        {
            get
            {
                var problem = new[,]
                {
          {0, 2, 0, 0, 0, 0, 0, 0, 0},
          {0, 0, 0, 6, 0, 0, 0, 0, 3},
          {0, 7, 4, 0, 8, 0, 0, 0, 0},
          {0, 0, 0, 0, 0, 3, 0, 0, 2},
          {0, 8, 0, 0, 4, 0, 0, 1, 0},
          {6, 0, 0, 5, 0, 0, 0, 0, 0},
          {0, 0, 0, 0, 1, 0, 7, 8, 0},
          {5, 0, 0, 0, 0, 9, 0, 0, 0},
          {0, 0, 0, 0, 0, 0, 0, 4, 0}
        };

                return new SwarmSudoku(problem);
            }
        }
    }
}