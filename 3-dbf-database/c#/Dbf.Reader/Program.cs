using System.Data.OleDb;

string filePath = @"C:\Temp";
string tableName = "FAR0091";
string connectionString = $"Provider=VFPOLEDB;Data Source={filePath};";

using (OleDbConnection connection = new OleDbConnection(connectionString))
{
    connection.Open();

    string query = $"SELECT * FROM {tableName}";
    using OleDbCommand command = new(query, connection);
    using OleDbDataReader reader = command.ExecuteReader();
    if (reader.HasRows)
    {
        string csvFilePath = Path.Combine(filePath, $"{tableName}.csv");
        using (StreamWriter writer = new StreamWriter(csvFilePath))
        {
            for (int i = 0; i < reader.FieldCount; i++)
            {
                writer.Write(reader.GetName(i));
                if (i < reader.FieldCount - 1)
                {
                    writer.Write(",");
                }
            }
            writer.WriteLine();

            while (reader.Read())
            {
                //string codPro = reader["ccodpro"].ToString();
                //string desPro = reader["ddespro"].ToString();
                //string vpreven = reader["vpreven"].ToString();
                //Console.WriteLine($"Code: {codPro}, Description: {desPro}, Price: {vpreven}");

                for (int i = 0; i < reader.FieldCount; i++)
                {
                    string value = $"{reader[i].ToString().Replace(",", ".")}";
                    writer.Write(value);
                    if (i < reader.FieldCount - 1)
                    {
                        writer.Write(",");
                    }
                }
                writer.WriteLine();
            }
        }

        Console.WriteLine($"Data saved to {csvFilePath}");
    }
}
