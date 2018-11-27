namespace Logger
{
    using LogFIle_Contract;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class LogFile : ILogFile
    {
        private TextWriter textWriter;

        private TextReader textReader;

        private int size;

        public int Size()
        {

            this.textReader = new StreamReader("../../../LogFile.txt");

            string text = textReader.ReadToEnd();

            return text.ToCharArray()
                    .Where(Char.IsLetter)
                    .Sum(c => c);
        }


        public LogFile()
        {
            if (!File.Exists("../../../LogFile.txt"))
            {
                var myFile = File.Create("../../../LogFile.txt");
                myFile.Close();
            }
        }
    }
}
