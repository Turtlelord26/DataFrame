using DataFrame.Generic;

namespace DataFrame
{
    public static class DataFrameFactory
    {
        public static IDataFrame ReadCSV(string filetext, bool firstRowHeaders = false)
        {
            string[] rows = filetext.Split('\n');
            int dataBeginsAt = 0;
            string[] headers;
            string[] firstRow = SplitCleanly(rows[0]);
            if (firstRowHeaders)
            {
                headers = firstRow;
                dataBeginsAt = 1;

                //check for duplicates
                HashSet<string> headersSeen = [];
                for (int h = 0; h < headers.Length; h++)
                {
                    if (!headersSeen.Add(headers[h]))
                    {
                        throw new ArgumentException($"Supplied headers contain the duplicate value {headers[h]} at column {h} (0-indexed).");
                    }
                }
            }
            else
            {
                headers = new string[firstRow.Length];
                for (int h = 0; h < headers.Length; h++)
                {
                    headers[h] = $"Column_{h}";
                }
            }
            string[][] data = SplitRowsIntoData(rows, dataBeginsAt);
            return MakeDataFrameFromData(data, headers);
        }

        public static IDataFrame ReadCSV(string filetext, IList<string> headers) => ReadCSV(filetext, [.. headers]);

        public static IDataFrame ReadCSV(string filetext, string[] headers)
        {
            string[] rows = filetext.Split('\n');
            string[][] data = SplitRowsIntoData(rows);
            int dataCols = data[0].Length;
            if (dataCols != headers.Length)
            {
                throw new ArgumentException($"Supplied header count does not match column count of data. Given {headers.Length} headers, detected {dataCols} columns in first row of data.");
            }
            return MakeDataFrameFromData(data, headers);
        }

        //We do not attempt to impute binary or categorical data, as we cannot reasonably tell from the first element alone.
        //Imputation of date formats left as an exercise for the future. We'll add an independent bool parameter for it at that time.
        private static IDataFrame MakeDataFrameFromData(string[][] data, string[] headers, bool imputeNumeric = true)
        {
            //BoolSeriesCollection binary = new(...)
            //CategoricalSeriesCollection categorical = new(...)
            //NumericSeriesCollection numeric = new(...)
            //StringSeriesCollection descriptive = new(...)
            //TimeSeriesCollection temporal = new(...)
            int numRows = data.Length;
            if (numRows <= 0)
            {
                throw new ArgumentException($"No data supplied for {typeof(IDataFrame)} creation");
            }
            int numCols = data[0].Length;
            if (imputeNumeric)
            {
                for (int col = 0; col < numCols; col++)
                {
                    string firstElement = data[0][col];
                    if (double.TryParse(firstElement, out double numericElement))
                    {
                        List<double> numericData = [numericElement];
                        for (int row = 1; row < numRows; row++)
                        {
                            try
                            {
                                numericData.Add(double.Parse(data[row][col]));
                            }
                            catch (FormatException fe)
                            {
                                throw new FormatException($"{fe.Message}\nParsing failure occured at row {row}, column {col} on datum {data[row][col]}. The first element of this column was {firstElement} and parsed as numeric data.");
                            }
                            //numeric.Add(NumericSeriesFactory.MakeNumericSeries(numericData));
                        }
                    }
                    else
                    {
                        List<string> stringData = [firstElement];
                        for (int row = 1; row < numRows; row++)
                        {
                            stringData.Add(data[row][col]);
                        }
                        //descriptive.Add(StringSeriesFactory.MakeStringSeries(stringData));
                    }
                }
            }
            else
            {
                List<string>[] columnData = new List<string>[numCols];
                for (int col = 0; col < numCols; col++)
                {
                    columnData[col] = [];
                }
                for (int row = 0; row < numRows; row++)
                {
                    if (data[row].Length != numCols)
                    {
                        throw new ArgumentException($"Inconsistent column count detected. Row 0 has {numCols} elements, but row {row} has {data[row].Length})");
                    }
                    for (int col = 0; col < numCols; col++)
                    {
                        columnData[col].Add(data[row][col]);
                    }
                }
                for (int col = 0; col < numCols; col++)
                {
                    //descriptive.Add(StringSeriesFactory.MakeStringSeries(columnData[col]);
                }
            }
            //return MakeDataFrameFromSeriesCollections(binary, categorical, numeric, descriptive, temporal);
            throw new NotImplementedException();
        }

        private static string[][] SplitRowsIntoData(string[] rows, int startIndex = 0)
        {
            int numRows = rows.Length;
            string[][] data = new string[numRows - startIndex][];
            int row = startIndex;
            int dataRow = 0;
            while (row < numRows)
            {
                data[dataRow] = SplitCleanly(rows[row]);
                row++;
                dataRow++;
            }
            return data;
        }

        private static string[] SplitCleanly(string row, char delimiter = ',') => row.Trim().Split(delimiter);
    }
}
