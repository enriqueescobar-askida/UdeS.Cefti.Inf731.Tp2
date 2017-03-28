namespace DataAccess
{
    using System;
    using System.IO;

    using Exceptions;

    public class ConvoyReader
    {
        #region Properties
        private readonly string filePath;
        #endregion

        #region Constructor
        public ConvoyReader(string aFilePath)
        {
            if (new FileInfo(aFilePath).Exists) this.filePath = aFilePath;
            else throw new ConvoyFileNotFoundException("File path cannot be found");
        }
        #endregion

        #region PublicMethods
        public void ReadFile()
        {
            bool boo = true;
            FileStream fileStream = new FileStream(this.filePath, FileMode.Open, FileAccess.Read);
            using (StreamReader streamReader = new StreamReader(fileStream)) //, Encoding.UTF8))
            {
                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    boo = line.Contains(";");
                    Console.Out.WriteLine(line);
                }
            }
            if (!boo)
                throw new ConvoyDataException("Character ';' cannot be found");
        }
        #endregion

        #region PublicOverride
        public override string ToString()
        {
            return this.filePath;
        }
        #endregion
    }
}
