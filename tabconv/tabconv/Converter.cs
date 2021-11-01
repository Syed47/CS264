using System.Linq;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace tabconv
{
    class Converter
    {
        private Helper helper;
        // default constructor
        public Converter() : this(new Helper()) {}
        // general constuctor
        public Converter(Helper helper)
        {
            this.helper = helper;
        }
        // convert data from one format to another
        public void Convert()
        {
            Table table; // for storing data

            string inFile = helper.GetInFile();
            string outFile = helper.GetOutFileExt();
            string[] fileLines = helper.ReadFile();

            switch (helper.GetInFileExt())
            {
                case ".csv":
                    helper.Debug("Parsing data from " + inFile);
                    table = ParseCSV(fileLines);
                    helper.Debug("Data extracted from " + inFile);
                    break;
                case ".html":
                    helper.Debug("Parsing data from " + inFile);
                    table = ParseHTML(fileLines);
                    helper.Debug("Data extracted from " + inFile);
                    break;
                case ".json":
                    helper.Debug("Parsing data from " + inFile);
                    table = ParseJSON(fileLines);
                    helper.Debug("Data extracted from " + inFile);
                    break;
                case ".md":
                    helper.Debug("Parsing data from " + inFile);
                    table = ParseMD(fileLines);
                    helper.Debug("Data extracted from " + inFile);
                    break;
                default:
                    helper.Debug("File format " + helper.GetOutFileExt() + "cannot be parsed.");
                    return; // not break because the next step should not execute
            }

            switch (helper.GetOutFileExt())
            {
                case ".csv":
                    helper.Debug("Writing data to " + outFile);
                    WriteCSV(table);
                    helper.Debug("Data written to " + outFile);
                    break;
                case ".html":
                    helper.Debug("Writing data to " + outFile);
                    WriteHTML(table);
                    helper.Debug("Data written to " + outFile);
                    break;
                case ".json":
                    helper.Debug("Writing data to " + outFile);
                    WriteJSON(table);
                    helper.Debug("Data written to " + outFile);
                    break;
                case ".md":
                    helper.Debug("Writing data to " + outFile);
                    WriteMD(table);
                    helper.Debug("Data written to " + outFile);
                    break;
                default:
                    helper.Debug("Cannot convert to " + helper.GetOutFileExt() + " file format.");
                    break;
            }
        }

        private Table ParseJSON(string[] lines)
        {
            List<string> headers = new();
            List<List<string>> rows = new();

            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].Trim() == "{")
                {
                    i++; // proceed to the next line
                    List<string> values = new(); // for storing current row values

                    // until comes across }
                    while (!(lines[i].Trim() == "}" || lines[i].Trim() == "},"))
                    {
                        string[] kv = lines[i].Trim().Split(":");
                        if (kv.Length == 2)
                        {
                            string header = kv[0], value = kv[1];
                            header = header.Replace('"', ' ').Trim();
                            value = value.Replace(',', ' ').Replace('"', ' ').Trim();

                            if (!headers.Contains(header))
                            {
                                headers.Add(header);
                            }
                            values.Add(value);
                        }
                        i++;
                    }
                    rows.Add(values);
                }
            }

            return new Table(headers, rows);
        }

        private void WriteJSON(Table table)
        {
            List<string> headers = table.GetHeaders();
            List<List<string>> rows = table.GetRows();
            List<string> lines = new();

            lines.Add("[");
            for (int k = 0; k < rows.Count; k++)
            {
                List<string> row = rows[k];
                lines.Add("\t{");
                for (int i = 0; i < row.Count; i++)
                {
                    string record = "";
                    record += "\t\t\"" + headers[i] + "\":";
                    // checking if the value is a number of string
                    int n = 0;
                    if (int.TryParse(row[i], out n))
                    {
                        record += n;
                    }
                    else
                    {
                        record += "\"" + row[i] + "\"";
                    }
                    // checking whether a comma should be included at the end of the block
                    lines.Add((i + 1 == row.Count) ? record : record + ",");
                }
                // checking whether a comma should be included after the end of block
                lines.Add((k + 1 == rows.Count) ? "\t}" : "\t},");
            }
            lines.Add("]");
            // writing to file
            helper.WriteFile(lines.Cast<string>().ToArray());
        }

        private Table ParseMD(string[] lines)
        {
            List<string> headers = new();
            List<List<string>> rows = new();

            foreach (string header in lines[0].Split("|"))
            {
                string t = header.Trim();
                if (t.Length > 0)
                {
                    headers.Add(t);
                }
            }

            for (int i = 2; i < lines.Length; i++)
            {
                List<string> row = new();
                foreach (string s in lines[i].Split("|"))
                {
                    string t = s.Trim();
                    if (t.Length > 0)
                    {
                        row.Add(t);
                    }
                }
                rows.Add(row);
            }

            return new Table(headers, rows);
        }

        private void WriteMD(Table table)
        {
            List<string> headers = table.GetHeaders();
            List<List<string>> rows = table.GetRows();
            List<string> lines = new();

            int[] maxwidth = new int[headers.Count];
            // finding the max spacing between columns
            for (int i = 0; i < headers.Count; i++)
            {
                if (maxwidth[i] < headers[i].Length)
                {
                    maxwidth[i] = headers[i].Length;
                }
                for (int j = 0; j < rows.Count; j++)
                {
                    if (maxwidth[i] < rows[j][i].Length)
                    {
                        maxwidth[i] = rows[j][i].Length;
                    }
                }
            }


            string headerRow = "|";
            string dashRow = "|";
            for (int i = 0; i < headers.Count; i++)
            { // putting | at the correct location in on each row
                headerRow += headers[i].PadRight(maxwidth[i]) + "|";
                for (int j = 0; j < maxwidth[i]; j++)
                {
                    dashRow += "-";
                }
                dashRow += "|";
            }
            // removing tabs and replacing with space
            headerRow = Regex.Replace(headerRow, "\t+", " ");
            lines.Add(headerRow);
            lines.Add(dashRow);

            for (int i = 0; i < headers.Count; i++)
            {
                string row = "|";
                for (int j = 0; j < rows.Count; j++)
                {
                    string s = rows[i][j].Trim();
                    s = Regex.Replace(s, "\\t+", " ");
                    if (s == "-")
                    {
                        row += s.PadLeft(maxwidth[j]) + "|";
                    }
                    else
                    {
                        row += s.PadRight(maxwidth[j]) + "|";
                    }
                }
                lines.Add(row);
            }

            helper.WriteFile(lines.Cast<string>().ToArray());
        }

        private Table ParseHTML(string[] lines)
        {
            List<string> headers = new();
            List<string> values = new();

            foreach (string s in lines)
            {
                // finding headers in html
                if (Regex.Match(s, "^.*<th>.*<\\/th>.*$").Success)
                {
                    // removing tags from html headers and extracting the header name
                    string header = Regex.Replace(Regex.Replace(s, "<th>", ""), "<\\/th>", "").Trim();
                    header = Regex.Replace(header, "\\t+", " ");
                    headers.Add(header);
                }
                // findig data values
                if (Regex.Match(s, "^.*<td.*>.*<\\/td>.*$").Success)
                {
                    // removing tags from html and extracting the data value 
                    string value = Regex.Replace(Regex.Replace(s, "\\<td(.*?)\\>", ""), "<\\/td>", "").Trim();
                    value = Regex.Replace(value, "\\t+", " ");
                    values.Add(value);
                }
            }

            // converting 1D list to 2d list so that it can be passed to Table
            List<List<string>> rows = new();
            List<string> temp = new();
            foreach (string value in values)
            {
                temp.Add(value);
                if (temp.Count % headers.Count == 0)
                {
                    rows.Add(temp);
                    temp = new();
                }
            }

            return new Table(headers, rows);
        }


        private void WriteHTML(Table table)
        {
            List<string> headers = table.GetHeaders();
            List<List<string>> rows = table.GetRows();
            List<string> lines = new();
            // start
            lines.Add("<table>");
            // adding headers section
            lines.Add("\t<tr>");
            foreach (string header in headers)
            {
                lines.Add("\t\t<th>" + header + "</th>");
            }
            lines.Add("\t</tr>");
            // adding values section
            foreach (List<string> row in rows)
            {
                lines.Add("\t<tr>");
                foreach (string value in row)
                {
                    lines.Add("\t\t<td>" + value + "</td>");
                }
                lines.Add("\t</tr>");
            }
            lines.Add("</table>");

            helper.WriteFile(lines.Cast<string>().ToArray());
        }


        private Table ParseCSV(string[] lines)
        {
            List<string> headers = new();
            List<List<string>> rows = new();

            foreach (string s in lines[0].Split(","))
            {
                headers.Add(RemoveChar('"', s.Trim()));
            }

            for (int i = 1; i < lines.Length; i++)
            {
                List<string> row = new List<string>();
                foreach (string s in lines[i].Split(","))
                {
                    row.Add(RemoveChar('"', s.Trim()));
                }
                rows.Add(row);
            }

            return new Table(headers, rows);
        }

        private void WriteCSV(Table table)
        {
            List<string> headers = table.GetHeaders();
            List<List<string>> rows = table.GetRows();
            List<string> lines = new();

            string headerStr = "";
            foreach (string header in headers)
            {
                headerStr += "\"" + header + "\",";
            }
            // removing the extra comma at the end of the line
            headerStr = headerStr.Substring(0, headerStr.Length - 1);
            lines.Add(headerStr);

            foreach (List<string> row in rows)
            {
                string rowStr = "";
                foreach (string val in row)
                {   // checking if the value is number or string
                    int i = 0;
                    if (int.TryParse(val, out i))
                    {
                        rowStr += val + ",";
                    }
                    else
                    {
                        rowStr += "\"" + val + "\",";
                    }
                }
                rowStr = rowStr.Substring(0, rowStr.Length - 1);
                lines.Add(rowStr);
            }

            GetHelper().WriteFile(lines.Cast<string>().ToArray());
        }
        // removing a char from given string passed to the method
        public string RemoveChar(char t, string str)
        {
            string result = "";
            foreach (char c in str)
            {
                if (c != t)
                {
                    result += c;
                }
            }
            return result;
        }

        public Helper GetHelper()
        {
            return helper;
        }

        public void SetHelper(Helper helper)
        {
            this.helper = helper;
        }
    }
}
