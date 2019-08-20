using System;
using System.Text;

namespace TemplateParser
{
    public class Parser
    {

        public bool Reading { get; private set; }

        public Action<string> OnFindStatement;

        public IStatementResolver Resolver { get; set; }

        private Delimiter delimiter;
        private StringBuilder builder;
        private StringBuilder statement = new StringBuilder();

        public Parser(Delimiter delimiter, StringBuilder builder)
        {
            this.builder = builder;
            this.delimiter = delimiter;
            Resolver = new StatementResolver();
        }

        public void Parse(string template)
        {
            int p = 0;
            int templateLength = template.Length;
            while (p < templateLength)
            {
                char c = template[p];
                Parse(c);
                p++;
            }
        }

        private void Parse(char c)
        {
            delimiter.Find(c);

            if (delimiter.FoundStart)
                StartReading();

            if (delimiter.FoundEnd)
            {
                EndReading();

                string original = statement.ToString(0, statement.Length - (delimiter.EndLength - 1));
                statement.Length = 0;
                OnFindStatement?.Invoke(original);
            }

            if (Reading && !delimiter.FoundStart)
                statement.Append(c);

            if (!Reading && !delimiter.FoundEnd)
                builder.Append(c);


            if (delimiter.FoundStart)
            {
                int builderLength = builder.Length;
                builder.Remove(builderLength - (delimiter.StartLength - 1), delimiter.StartLength - 1);
            }
        }

        private void StartReading()
        {
            Reading = true;
            delimiter.CanFindEnd = true;
        }

        private void EndReading()
        {
            if (Reading)
            {
                Reading = false;
                delimiter.CanFindEnd = false;
            }
        }

    }
}
