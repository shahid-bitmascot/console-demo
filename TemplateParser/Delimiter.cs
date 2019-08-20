namespace TemplateParser
{
    public class Delimiter
    {

        public string Start { get; private set; }
        public string End { get; private set; }
        public bool CanFindEnd { get; set; }

        public bool FoundStart { get; private set; }
        public bool FoundEnd { get; private set; }

        public int StartLength { get; private set; }
        public int EndLength { get; private set; }

        private int currentStartPosition = 0;
        private int currentEndPosition = 0;

        public Delimiter(string start, string end)
        {
            Start = start;
            End = end;
            StartLength = start.Length;
            EndLength = end.Length;
        }

        public void Find(char c)
        {
            FoundStart = FindStart(c);
            FoundEnd = FindEnd(c);
        }

        public bool FindStart(char c)
        {
            return Find(c, Start, StartLength, ref currentStartPosition);
        }

        public bool FindEnd(char c)
        {
            return CanFindEnd && Find(c, End, EndLength, ref currentEndPosition);
        }

        private bool Find(char c, string delimiter, int length, ref int currentPosition)
        {
            if (c == delimiter[currentPosition])
                currentPosition++;
            else
                currentPosition = 0;

            if (currentPosition == length)
            {
                currentPosition = 0;
                return true;
            }
            return false;
        }

    }
}
