using System;

namespace DateStamp
{
    public class Document
    {
        public readonly string content;
        public readonly string filePath;

        public Document(string filePath, string content)
        {
            this.filePath = filePath;
            this.content = content;
        }
    }
}
