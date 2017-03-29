namespace DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    using Exceptions;

    public class ConvoyReader
    {
        #region Properties
        private readonly string filePath;
        public string LocomotiveInfo { get; internal set; }
        public List<string> OperationList { get; internal set; }
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
            List<string> operationList = new List<string>();
            FileStream fileStream = new FileStream(this.filePath, FileMode.Open, FileAccess.Read);
            using (StreamReader streamReader = new StreamReader(fileStream)) //, Encoding.UTF8))
            {
                string line;
                int count = 0;
                while ((line = streamReader.ReadLine()) != null)
                {
                    bool boo = line.Contains(";");
                    if (!boo)
                        throw new ConvoyDataException("Character ';' cannot be found");
                    if (count == 0)
                        this.ValidateLocomotive(line);
                    else operationList.Add(line);
                    Console.Out.WriteLine(line);
                    count++;
                }
            }
            this.OperationList = operationList;
        }
        #endregion

        #region PublicOverride
        public override string ToString()
        {
            return this.filePath;
        }
        #endregion

        #region PrivateMethods
        private void ValidateLocomotive(string line)
        {
            string[] s = line.Split(';');
            if (s.Length != 2) throw new ConvoyOutOfRangeException("Wrong number of parameters for locomotive");


            int[] ints = new int[2];

            if (int.TryParse(s[0], out ints[0]) & int.TryParse(s[1], out ints[1]))
                this.LocomotiveInfo = line;
            else
                throw new ConvoyArgumentException("Wrong argument format");
        }
        #endregion
    }
}
