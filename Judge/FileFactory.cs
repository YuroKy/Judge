using System.IO;

namespace Judge
{
    public class FileFactory
    {
        private int _id = 0;
        private string _root;

        public FileFactory(string root)
        {
            this._root = root;
        }
        public int GetId() { return _id; }

        public string CreateFileAndGetFileName(string sourceCode)
        {
            string fileName = string.Format("solve_{0}", _id++);

            using (StreamWriter sw = new StreamWriter(_root + fileName + ".txt"))
            {
                sw.Write(sourceCode);
            }
            return _root + fileName;
        }
    }
}
