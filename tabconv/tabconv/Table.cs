using System.Collections.Generic;

namespace tabconv
{
    class Table
    {   
        private List<string> headers; // store column names
        private List<List<string>> rows; // each list store single row data

        // default constructor
        public Table() : this(new List<string>(), new List<List<string>>()) {}

        // general constructor
        public Table(List<string> headers, List<List<string>> rows)
        {
            SetHeaders(headers);
            SetRows(rows);
        }

        public void SetHeaders(List<string> headers)
        {
            this.headers = new List<string>();
            // headers copy
            foreach (string header in headers)
            {
                this.headers.Add(header);
            }
        }

        public void SetRows(List<List<string>> rows)
        {
            this.rows = new List<List<string>>();
            // rows copy
            foreach (List<string> row in rows)
            {
                List<string> temp = new List<string>();
                foreach (string value in row)
                {
                    temp.Add(value);
                }
                this.rows.Add(temp);
            }
        }

        public List<string> GetHeaders()
        {
            return headers;
        }

        public List<List<string>> GetRows()
        {
            return rows;
        }
    }
}
