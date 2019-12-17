using System;

namespace MainService
{
    public class ConnectionString
    {
        public string Database { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
        public string User { get; set; }
        public string Password { get; set; }

        public int Timeout { get; set; } = 900000;

        public string SslMode { get; set; } = "None";

        public new string ToString()
        {
            if
            ((string.IsNullOrEmpty(Database))
             || (string.IsNullOrEmpty(Host))
             || (string.IsNullOrEmpty(User))
             || (string.IsNullOrEmpty(Password)))
                throw new ArgumentException("You need to set up connection string");


            return $"Server={Host}; Port={Port}; database={Database}; UID={User}; password={Password}; SslMode={SslMode};ConnectionTimeout={Timeout};DefaultCommandTimeout={Timeout};";
        }
    }
}