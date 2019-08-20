using System;

namespace TemplateParser
{
    public class StatementResolver : IStatementResolver
    {
        public string Resolve(string statement, object model)
        {
            Console.WriteLine(statement);
            return "*";
        }
    }
}
