using System;
using System.Text;

namespace TemplateParser
{
    public class TemplateParser
    {

        public TemplateDelimiter Delimiter { get; set; }

        protected bool IsMacroReadingStarted { get; private set; }
        protected bool IsMacroReadingEnded { get; private set; }

        private int currentStartDelimiterPosition = 0;
        private int currentEndDelimiterPosition = 0;

        private StringBuilder macro = new StringBuilder();
        private StringBuilder newTemplate = new StringBuilder();

        protected bool CanCheckEndDelimiterFinding { get; private set; }

        public TemplateParser()
        {
            //
        }

        public void Parse(string template)
        {

            EndMacroReading();

            int currentPosition = 0;
            int templateLength = template.Length;

            Console.WriteLine(template);

            while (currentPosition < templateLength)
            {

                char currentCharacter = template[currentPosition];

                var foundStartDelimiter = FindDelimiter(currentCharacter, Delimiter.StartDelimiter, Delimiter.StartDelimiterLength, ref currentStartDelimiterPosition);

                var foundEndDelimiter = CanCheckEndDelimiterFinding && FindDelimiter(currentCharacter, Delimiter.EndDelimiter, Delimiter.EndDelimiterLength, ref currentEndDelimiterPosition);

                if (foundStartDelimiter)
                    StartMacroReading();

                if (IsMacroReadingStarted && foundEndDelimiter)
                {
                    var m = macro.ToString(0, macro.Length - (Delimiter.EndDelimiterLength - 1));
                    macro.Length = 0;
                    EndMacroReading();
                    newTemplate.Append(ResolveMacro(m));
                }

                if (IsMacroReadingStarted && !foundStartDelimiter)
                    macro.Append(currentCharacter);

                if (!IsMacroReadingStarted && IsMacroReadingEnded && !foundEndDelimiter)
                    newTemplate.Append(currentCharacter);

                if (foundStartDelimiter)
                {
                    int newTemplateLength = newTemplate.Length;
                    newTemplate.Remove(newTemplateLength - (Delimiter.StartDelimiterLength - 1), Delimiter.StartDelimiterLength - 1);
                }

                currentPosition++;

            }

            Console.WriteLine("New Template: {0}", newTemplate);

        }

        private string ResolveMacro(string macro, object model = null)
        {
            Console.WriteLine(macro);
            return "*";
        }

        private bool FindDelimiter(char c, string delimiter, int delimiterLength, ref int currentDelimiterPosition)
        {
            if (c == delimiter[currentDelimiterPosition])
                currentDelimiterPosition++;
            else
                currentDelimiterPosition = 0;

            if (currentDelimiterPosition == delimiterLength)
            {
                currentDelimiterPosition = 0;
                return true;
            }
            return false;
        }

        private void StartMacroReading()
        {
            CanCheckEndDelimiterFinding = true;
            IsMacroReadingStarted = true;
            IsMacroReadingEnded = false;
        }

        private void EndMacroReading()
        {
            CanCheckEndDelimiterFinding = false;
            IsMacroReadingStarted = false;
            IsMacroReadingEnded = true;
        }

    }
}
