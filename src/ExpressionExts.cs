using System;
using System.Linq.Expressions;

namespace Common
{
    /// <summary>
    /// Provides methods for working with <see cref="Expression"/>
    /// </summary>
    public static class ExpressionExts
    {
        public static string GetMemberName(Expression exp)
        {
            if (exp == null)
                throw new ArgumentException("Expression cannot be null when getting object member name.");
            if (exp is UnaryExpression unary_exp)
                return GetMemberName(unary_exp);
            if (exp is MemberExpression member_exp)
                return member_exp.Member.Name;

            if (exp is MethodCallExpression method_exp)
                return method_exp.Method.Name;
            throw new ArgumentException("Expression passed to get member name is invalid.");
        }
        private static string GetMemberName(UnaryExpression unary)
        {
            if (unary.Operand is MethodCallExpression method_exp)
                return method_exp.Method.Name;
            return ((MemberExpression)unary.Operand).Member.Name;
        }
    }
}
