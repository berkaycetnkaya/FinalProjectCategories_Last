﻿namespace Business.CCS
{
    public class DatabaseLogger : ILogger
    {
        public void log()
        {
            Console.WriteLine("Veritabanı Loglandı");
        }
    }
}
