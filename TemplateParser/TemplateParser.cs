namespace TemplateParser
{
    public class TemplateParser
    {

        private static string START_DELIMITER = "{{";
        private static string END_DELIMITER = "}}";

        void Parse(string template)
        {

            int pos = 0;
            int len = template.Length;
            while (pos < len)
            {

                if (START_DELIMITER[0] == template[0] && len <= pos + START_DELIMITER.Length)
                {
                    bool startDelimiterFound = true;
                    for (int i = 0; startDelimiterFound && i < START_DELIMITER.Length; i++)
                    {
                        if (template[pos + i] != START_DELIMITER[i])
                            startDelimiterFound = false;
                    }
                }

            }

        }

    }
}
