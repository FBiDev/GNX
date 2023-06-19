using System.Text;
using System.IO;

namespace GNX
{
    public class StringWriterUTF8 : StringWriter
    {
        public override Encoding Encoding { get { return Encoding.UTF8; } }
    }
}