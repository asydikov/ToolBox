namespace ToolBox.Services.DBWorker.EF
{
    public class SqlSettings
    {
        string Server { get; }
        string UserId { get; }
        string Password { get; }
        string Database { get; }

        //public SqlSettings(string server, string userId, string password, string database)
        //{
        //    Server = server;
        //    UserId = userId;
        //    Password = password;
        //    Database = database;
        //}
        public string ConnectionString { get; set; }

    }
}