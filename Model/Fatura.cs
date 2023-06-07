using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Dynamic;

namespace hotel_loby.Model
{
    class Fatura
    {
        public int id { get; set; }
        public string owner { get; set; }

        public int price { get; set; }


        SQLiteConnection _baglan = new SQLiteConnection("Data Source =dbb/otel.db");

        public void connect()
        {
            if (_baglan.State == ConnectionState.Closed)
            {
                _baglan.Open();
            }
        }

        public List<Fatura> Get(int id)
        {
            connect();
            SQLiteCommand command = new SQLiteCommand($"select * from faturalar where id={id}", _baglan); ;

            SQLiteDataReader reader = command.ExecuteReader();

            List<Fatura> Faturalar = new List<Fatura>();

            while (reader.Read())
            {
                Fatura fatura = new Fatura();
                fatura.id = Convert.ToInt32(reader["id"]);
                fatura.owner = Convert.ToString(reader["owner"]);
                fatura.price = Convert.ToInt32(reader["price"]);
                Faturalar.Add(fatura);
            }
            reader.Close();
            _baglan.Close();

            return Faturalar;
        }

        public void CreateFatura(int id, string owner, int price)
        {
            connect();

            SQLiteCommand command = new SQLiteCommand("INSERT INTO faturalar (id, owner, price) VALUES (@id, @owner, @price)", _baglan);

            command.Parameters.AddWithValue("@id", Convert.ToInt32(id));
            command.Parameters.AddWithValue("@owner", Convert.ToString(owner));
            command.Parameters.AddWithValue("@price", Convert.ToInt32(price));

            command.ExecuteNonQuery();
            _baglan.Close();

        }

        public void ClearFatura(int id)
        {
            connect();
            SQLiteCommand command = new SQLiteCommand($"DELETE from faturalar where id={id}", _baglan);
            command.ExecuteNonQuery();
        }
    }


}
