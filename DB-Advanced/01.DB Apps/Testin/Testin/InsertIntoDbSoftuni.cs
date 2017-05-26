using System;
using System.Data.SqlClient;

namespace Testin
{
    public class InsertIntoDbSoftuni
    {

        public static void Main(string[] args)
        {

            InsertProperties("Mihov", "Lesgo", DateTime.Today, null);
        }

        private static void InsertProperties(string name, string description, DateTime startDateTime, DateTime? endDateTime)
        {
            SqlConnection connection = new SqlConnection("Server=.;Database=SoftUni;Integrated Security=true");
            connection.Open();

            using (connection)
            {
                SqlCommand command = new SqlCommand("INSERT INTO Projects(Name,Description,StartDate,EndDate) " +
                                                    "VALUES(@name,@description,@startDateTime,@endDateTime)", connection);

                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@description", description);
                command.Parameters.AddWithValue("@startDateTime", startDateTime);

                SqlParameter endDateTimeParam = new SqlParameter("@endDateTime", endDateTime);

                if (endDateTime == null)
                {
                    endDateTimeParam.Value = DBNull.Value;
                }

                command.Parameters.Add(endDateTimeParam);
                command.ExecuteNonQuery();
            }
        }
    }
}