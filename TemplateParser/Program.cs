using Scriban;
using System;

namespace TemplateParser
{
    class Program
    {
        static void Main(string[] args)
        {
            var tt = "Name: {{Name}}, Email: {{ if Email == 'sahidul@bitmascot.com' }} Condition True {{ endif }}";
            Console.WriteLine(tt);
            while (true)
            {
                var p = new TemplateParser(new Delimiter("{{", "}}"));
                p.Parse(tt);
                tt = Console.ReadLine();
            }

            var model = new Model
            {
                Name = "Name",
                Id = 1
            };

            var t = @"
                    {{
                        if id > 2
                            Id : id
                        end
                    }}
                    Name : {{ name }}
                    {{ end }}
                ";

            var template = Template.Parse(t);
            var r = template.Render(model);


            Console.WriteLine(r);
        }
    }

    class Model
    {
        public string Name { get; set; }
        public int Id { get; set; }
    }
}
