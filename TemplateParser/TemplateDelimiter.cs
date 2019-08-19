namespace TemplateParser
{
    public struct TemplateDelimiter
    {

        public string StartDelimiter { get; set; }
        public string EndDelimiter { get; set; }

        public int StartDelimiterLength { get; set; }
        public int EndDelimiterLength { get; set; }

        public TemplateDelimiter(string startDelimiter, string endDelimiter)
        {
            StartDelimiter = startDelimiter;
            EndDelimiter = endDelimiter;
            StartDelimiterLength = startDelimiter.Length;
            EndDelimiterLength = endDelimiter.Length;
        }

    }
}
