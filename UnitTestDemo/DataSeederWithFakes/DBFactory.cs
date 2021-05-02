using System;
using DataSeederWithFakes.Models;
using MySql.Data.MySqlClient;

namespace DataSeederWithFakes
{
    public class DBFactory
    {
        private static MySqlConnection con;

        static DBFactory()
        {
            string server = "localhost";
            string database = "FakerData";
            string uid = "faker";
            string password = "faker";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" + 
                               database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            con = new MySqlConnection(connectionString);
            con.Open();
        }

        static public long GetLastEmployeeNr()
        {
            string sql = "SELECT max(personeelsNr) FROM tbl_employee;";
            MySqlCommand cmd = new MySqlCommand(sql, con);
            var result = cmd.ExecuteScalar();
            long id;
            try
            {
                id = Int64.Parse(result.ToString());
            }
            catch (Exception e)
            {
                id = 10000;
            }

            return id;
        }

        /// <summary>
        /// Insert a new record in table 'tbl_employee'. On success the id (PrimaryKey) of the given Employee-parameter
        /// is updated with the assigned auto-increment value.
        /// </summary>
        /// <param name="employee">A record containing information to insert in the database</param>
        /// <returns>TRUE if the insertion was successful.</returns>
        static public bool CreateNewEmployee(Employee employee)
        {
            string sql = @"INSERT INTO tbl_employee (
                          personeelsNr,
                          achternaam,
                          voornaam,
                          mail,
                          geslacht,
                          geboortedatum
            ) VALUES (
                          @personeelsNr,
                          @achternaam,
                          @voornaam,
                          @mail,
                          @geslacht,
                          @geboortedatum
            )";
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@personeelsNr", employee.personeelsNr);
            cmd.Parameters.AddWithValue("@achternaam", employee.achternaam);
            cmd.Parameters.AddWithValue("@voornaam", employee.voornaam);
            cmd.Parameters.AddWithValue("@mail", employee.mail);
            cmd.Parameters.AddWithValue("@geslacht", employee.geslacht);
            cmd.Parameters.AddWithValue("@geboortedatum", employee.geboortedatum);

            try
            {
                int rowsAffected = cmd.ExecuteNonQuery();
                employee.id = cmd.LastInsertedId;
                return (rowsAffected == 1);
            }
            catch (Exception e)
            {
                return false;
            }
        } // createNewPerson

        /// <summary>
        /// Insert a new record in table 'tbl_reviews'. On success the id (PrimaryKey) of the given REview-parameter
        /// </summary>
        /// <param name="review">An object containing information to insert a record</param>
        /// <returns>TRUE if the insertion was successful</returns>
        public static bool createReview(Review review)
        {
            string sql = @"INSERT INTO tbl_reviews (
                          fk_idEmployee,
                          review
            ) VALUES (
                          @fk_idEmployee,
                          @review
            )";
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@fk_idEmployee", review.fk_idEmployee);
            cmd.Parameters.AddWithValue("@review", review.review);

            try
            {
                int rowsAffected = cmd.ExecuteNonQuery();
                review.id = cmd.LastInsertedId;
                return (rowsAffected == 1);
            }
            catch (Exception e)
            {
                return false;
            }
        }//createReview
    }
}