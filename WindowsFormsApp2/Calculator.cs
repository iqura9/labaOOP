using Antlr4.Runtime;
using WindoswFormsApp2;

namespace WindowsFormsApp2
{
    public static class Calculator
    {
        public static double Evaluate(string expression)
        {
            var lexer = new ExcelLexer(new AntlrInputStream(expression));
            lexer.RemoveErrorListeners();
            lexer.AddErrorListener(new ThrowExceptionErrorListener());
            var tokens = new CommonTokenStream(lexer);
            var parser = new ExcelParser(tokens);
            var tree = parser.compileUnit();
            var visitor = new ExcelVisitor();
            return visitor.Visit(tree);
        }
    }
}