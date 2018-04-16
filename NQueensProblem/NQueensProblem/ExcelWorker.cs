using ExcelLibrary.SpreadSheet;
using System;

namespace CSVFileReadWrite
{
    class ExcelWorker
    {
        public readonly int DIMENSION_NUMBER_INDEX = 0;
        public readonly int BEST_RATING_INDEX = 1;
        public readonly int GRADE_AVERAGE_INDEX = 2;
        public readonly int WORST_RATING_INDEX = 3;

        public readonly int FIRST_INDEX_IN_EXCEL_COLUMN = 0;
        public readonly int COLUMN_A_INDEX = 0;
        public readonly int COLUMN_B_INDEX = 1;
        public readonly int COLUMN_C_INDEX = 2;
        public readonly int COLUMN_D_INDEX = 3;

        public readonly String DEFAULT_FILE_NAME = "newdoc.xls";
        public readonly String DEFAULT_WORKSHEET_NAME = "First Sheet";

        int rowCounterA;
        int rowCounterB;
        int rowCounterC;
        int rowCounterD;

        //we will work with only one workbook and worksheet
        Workbook workbook;
        Worksheet worksheet;

        String nameOfFile;

        public ExcelWorker(string fileName)
        {
            //create new xls file
            nameOfFile = $"{fileName}.xls";
            SameConstructorActions(nameOfFile);
        }

        public ExcelWorker()
        {
            //create new xls file
            nameOfFile = DEFAULT_FILE_NAME;
            SameConstructorActions(nameOfFile);
        }

        private void SameConstructorActions(string fileName)
        {
            workbook = new Workbook();
            worksheet = new Worksheet(DEFAULT_WORKSHEET_NAME);

            workbook.Worksheets.Add(worksheet);
            Save();

            rowCounterA = FIRST_INDEX_IN_EXCEL_COLUMN;
            rowCounterB = FIRST_INDEX_IN_EXCEL_COLUMN;
            rowCounterC = FIRST_INDEX_IN_EXCEL_COLUMN;
            rowCounterD = FIRST_INDEX_IN_EXCEL_COLUMN;
        }

        /// <summary>
        /// Add cell to worksheet
        /// </summary>
        /// <param name="x">row index</param>
        /// <param name="y">column index</param>
        /// <param name=""></param>
        public void AddCellToWorksheet<T>(int x, int y, T dataValue)
        {
            worksheet.Cells[x, y] = new Cell(dataValue);
        }

        /// <summary>
        /// Add Cell To Worksheet into Columns A, B
        /// </summary>
        public void AddCellToWorksheetIntoColumnsAB(int boadrDimention, int timeMs)
        {
            AddCellToWorksheet(rowCounterA++, COLUMN_A_INDEX, boadrDimention);
            AddCellToWorksheet(rowCounterB++, COLUMN_B_INDEX, timeMs);
            Save();
        }

        public void AddCellToWorksheetIntoColumnsABC(int var1, int var2, int var3)
        {
            AddCellToWorksheet(rowCounterA++, COLUMN_A_INDEX, var1);
            AddCellToWorksheet(rowCounterB++, COLUMN_B_INDEX, var2);
            AddCellToWorksheet(rowCounterC++, COLUMN_C_INDEX, var3);
            Save();
        }

        public void AddCellToWorksheetIntoColumnsABCD<T>(T generationNumber, T bestCost, T averageCost, T worstCost)
        {
            AddCellToWorksheet(rowCounterA++, COLUMN_A_INDEX, generationNumber);
            AddCellToWorksheet(rowCounterB++, COLUMN_B_INDEX, bestCost);
            AddCellToWorksheet(rowCounterC++, COLUMN_C_INDEX, averageCost);
            AddCellToWorksheet(rowCounterD++, COLUMN_D_INDEX, worstCost);
            Save();
        }

        public void AddStringCellToWorksheetIntoColumnsABCD(string generationNumber, string bestCost, string averageCost, string worstCost)
        {
            AddCellToWorksheet(rowCounterA++, COLUMN_A_INDEX, generationNumber);
            AddCellToWorksheet(rowCounterB++, COLUMN_B_INDEX, bestCost);
            AddCellToWorksheet(rowCounterC++, COLUMN_C_INDEX, averageCost);
            AddCellToWorksheet(rowCounterD++, COLUMN_D_INDEX, worstCost);
            Save();
        }

        private void Save()
        {
            workbook.Save(nameOfFile);
        }
    }
}
