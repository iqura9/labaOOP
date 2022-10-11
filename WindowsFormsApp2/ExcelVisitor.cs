using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime.Misc;
using WindoswFormsApp2;

namespace WindowsFormsApp2
{
    public class ExcelVisitor : ExcelBaseVisitor<double>
    {
        Dictionary<string, double> tableIdentifier = new Dictionary<string, double>();

        public override double VisitCompileUnit(ExcelParser.CompileUnitContext context)
        {
            return Visit(context.expression());
        }

        public override double VisitNumberExpr(ExcelParser.NumberExprContext context)
        {
            var result = double.Parse(context.GetText());
            Debug.WriteLine(result);
            return result;
        }

        
        public override double VisitIdentifierExpr([NotNull] ExcelParser.IdentifierExprContext context)
        {
            var result = context.GetText();
            double value;
            if (tableIdentifier.TryGetValue(result.ToString(), out value))
                return value;
            else
                return 0.0;
        }

        public override double VisitParenthesizedExpr([NotNull] ExcelParser.ParenthesizedExprContext context)
        {
            return Visit(context.expression());
        }

        // public override double VisitExponentialExpr([NotNull] ExcelParser.ExponentialExprContext context)
        // {
        //     var left = WalkLeft(context);
        //     var right = WalkRight(context);
        //     Debug.WriteLine("{0}^{1}", left, right);
        //     return System.Math. Pow(left, right);
        // }
        //
        //
        //
        // public override double VisitAdditiveExor([NotNull] ExcelParser.AdditiveExprContext context)
        // {
        //     var left = WalkLeft(context);
        //     var right = WalkRight(context);
        //     if (context.operatorToken.Type == ExcelLexer.ADD)
        //     {
        //         Debug.WriteLine("(0)+{1}", left, right);
        //         return left + right;
        //     }
        //     else
        //     {
        //         Debug.WriteLine("{0}-{1}", left, right);
        //         return left - right;
        //     }
        // }
       
    }
}