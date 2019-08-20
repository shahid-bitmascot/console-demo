namespace TemplateParser
{
    public interface IStatementResolver
    {
        string Resolve(string statement, object model);
    }
}
