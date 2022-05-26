using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;

namespace OtelWDB.Model
{
    class Otel
    {
        public int odaNum { get; set; }
        public int odaCap { get; set; }
        public string odaOwnerName { get; set; }
        public string odaOwnerSurName { get; set; }
        public string odaStatus { get; set; }
        public string time { get; set; }

        SQLiteConnection _baglan = new SQLiteConnection("Data Source =dbb/otel.db");
        
        //SqlConnection _baglan = new SqlConnection("Data Source=DESKTOP-68QGCQF;Initial Catalog=otel;Integrated Security=True");

        public void connect()
        {
            if (_baglan.State == ConnectionState.Closed)
            {
                _baglan.Open();
            }
        }

        public List<Otel> Get(int a)
        {
            connect();
            SQLiteCommand command = null;
            if (a == 4)
            {
                command = new SQLiteCommand($"select * from room_owner", _baglan);

            }
            else
            {
                command = new SQLiteCommand($"select * from room_owner where odaCap={a}", _baglan);
            }


            SQLiteDataReader reader = command.ExecuteReader();

            List<Otel> odalar = new List<Otel>();

            while (reader.Read())
            {
                Otel oda = new Otel();

                oda.odaNum = Convert.ToInt32(reader["odaNum"]);
                oda.odaCap = Convert.ToInt32(reader["odaCap"]);
                oda.odaOwnerName = reader["odaOwnerName"].ToString();
                oda.odaStatus = reader["odaStatus"].ToString();
                oda.odaOwnerSurName = reader["odaOwnerSurName"].ToString();
                oda.time = reader["time"].ToString();

                odalar.Add(oda);
            }

            reader.Close();
            _baglan.Close();

            return odalar;
        }

        public void Save(Otel mp)
        {
            connect();

            SQLiteCommand command = new SQLiteCommand("Update room_owner set odaOwnerName=@odaOwnerName, odaStatus=@odaStatus, odaOwnerSurName=@odaOwnerSurName, time=@time where odaNum=@odaNum", _baglan);

            command.Parameters.AddWithValue("@odaNum", Convert.ToInt32(mp.odaNum));
            command.Parameters.AddWithValue("@odaOwnerName", mp.odaOwnerName.ToString());
            command.Parameters.AddWithValue("@odaOwnerSurname", mp.odaOwnerSurName.ToString());
            command.Parameters.AddWithValue("@odaStatus", mp.odaStatus.ToString());
            command.Parameters.AddWithValue("@time", mp.time.ToString());

            command.ExecuteNonQuery();
            _baglan.Close();
        }
    }
}
