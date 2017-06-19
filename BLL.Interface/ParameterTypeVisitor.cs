using System.Linq;
using System.Linq.Expressions;

namespace BLL.Interface
{
    class ParameterTypeVisitor<TSource, TDestination> : ExpressionVisitor
    {
        public ParameterExpression ParameterExpression { get; private set; }

        public ParameterTypeVisitor(ParameterExpression parameterExpression)
        {
            ParameterExpression = parameterExpression;
        }

        protected override Expression VisitParameter(ParameterExpression node)
        {
            return ParameterExpression;
        }

        protected override Expression VisitMember(MemberExpression node)
        {
            if (node.Member.DeclaringType == typeof(TSource))
                return Expression.MakeMemberAccess(Visit(node.Expression), typeof(TDestination).GetMember(node.Member.Name).FirstOrDefault());
            return base.VisitMember(node);
        }
    }
}
