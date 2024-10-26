namespace Covide.Web.Models
{
    public class CmykColor
    {
        public int Cyan { get; }
        public int Magenta { get; }
        public int Yellow { get; }
        public int Key { get; }

        public CmykColor(int cyan, int magenta, int yellow, int key)
        {
            Cyan = cyan;
            Magenta = magenta;
            Yellow = yellow;
            Key = key;
        }
    }
}
