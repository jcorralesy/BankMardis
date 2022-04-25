using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Infrastructure.Internal;
using ModelBD.BankMardis;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelBD
{
    public abstract class AEntityModel<T> : DbContext
    {
        public readonly string _connectionString;
        protected SqlConnection Connection;
        protected SqlConnection connection => Connection ?? (Connection = GetOpenConnection());

        public AEntityModel(DbContextOptions options) : base(options)
        {
            _connectionString = options.FindExtension<SqlServerOptionsExtension>().ConnectionString;
            Database.SetCommandTimeout(2147483647);
        }

        public SqlConnection GetOpenConnection(bool mars = false)
        {
            var cs = _connectionString;
            if (mars)
            {
                var scsb = new SqlConnectionStringBuilder(cs)
                {
                    MultipleActiveResultSets = true
                };

                cs = scsb.ConnectionString;
            }

            var connection = new SqlConnection(cs);

            connection.Open();
            return connection;
        }

        public SqlConnection GetClosedConnection()
        {
            var conn = new SqlConnection(_connectionString);
            if (conn.State != ConnectionState.Closed) throw new InvalidOperationException("should be closed!");
            return conn;
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Cuenta> Cuentas { get; set; }
        public DbSet<Persona> Personas { get; set; }
        public DbSet<Transaccion> Transaccions { get; set; }

    }
}
