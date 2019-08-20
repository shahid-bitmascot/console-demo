using System;
using System.Linq;
using System.Text;

namespace TemplateParser
{
    public class TemplateParser
    {

        private readonly Parser parser;
        private StringBuilder newTemplate = new StringBuilder();

        public TemplateParser(Delimiter delimiter)
        {
            var model = new
            {
                Name = "Sahidul",
                Email = "sahidul@bitmascot.com"
            };

            parser = new Parser(delimiter, newTemplate);

            parser.OnFindStatement = str =>
            {

                string copyStr = str.Trim();
                string[] strArr = copyStr.Split(' ');

                switch (strArr[0].ToLower())
                {
                    case "if":
                        var left = strArr[1];
                        var opt = strArr[2];
                        var right = strArr[3].Trim('\'');
                        var varValue = model.GetType().GetProperty(left)?.GetValue(model)?.ToString();
                        switch(opt)
                        {
                            case "==" when varValue == right:
                                var r = true;
                                break;
                        }
                        break;
                }

                var newStr = parser.Resolver.Resolve(str, null);

                var prop = model.GetType().GetProperty(str);
                if (prop != null)
                {
                    var v = prop.GetValue(model);
                    newTemplate.Append(v);
                }

            };
        }

        public void Parse(string template)
        {

            parser.Parse(template);
            Console.WriteLine("New Template: {0}", newTemplate);

        }

    }
}
