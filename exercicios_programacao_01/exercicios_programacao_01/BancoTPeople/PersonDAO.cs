using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace exercicios_programacao_01.BancoTPeople
{
    class PersonDAO : IDisposable
    {
        private SqlConnection conn;

        public PersonDAO()
        {
            this.conn = new SqlConnection("Server=(localdb)\\mssqllocaldb;Database=testes;Trusted_Connection=true;");
            this.conn.Open();
        }

        internal void Add(Person person)
        {
            try
            {
                var insertCmd = conn.CreateCommand();
                insertCmd.CommandText = "INSERT INTO Person (Code, FullName, Document, BornDate) VALUES (@code, @fullname, @document, @bornDate)";

                var paramCode = new SqlParameter("nome", person.Code);
                insertCmd.Parameters.Add(paramCode);

                var paramFullName = new SqlParameter("categoria", person.FullName);
                insertCmd.Parameters.Add(paramFullName);

                var paramDocument = new SqlParameter("preco", person.Document);
                insertCmd.Parameters.Add(paramDocument);

                var paramBorndate = new SqlParameter("preco", person.BornDate);
                insertCmd.Parameters.Add(paramBorndate);

                insertCmd.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                throw new SystemException(e.Message, e);
            }
        }

        internal List<Person> People()
        {
            var people = new List<Person>();
            var selectCmd = conn.CreateCommand();
            selectCmd.CommandText = "SELECT * FROM Person";

            var result = selectCmd.ExecuteReader();

            while (result.Read())
            {
                Person person = new Person();
                person.ID = Convert.ToInt32(result["CPERSON_ID"]);
                person.Code = Convert.ToString(result["CCODE"]);
                person.FullName = Convert.ToString(result["CFULL_NAME"]);
                person.Document = Convert.ToString(result["CDOCUMENT"]);
                person.BornDate = Convert.ToDateTime(result["CBORN_DATE"]);

                people.Add(person);
            }

            result.Close();

            return people;
        }

        public void Dispose()
        {
            this.conn.Close();
        }
    }
}
