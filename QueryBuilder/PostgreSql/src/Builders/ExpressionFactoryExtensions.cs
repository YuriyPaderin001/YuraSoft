using System;

using YuraSoft.QueryBuilder.Common;

namespace YuraSoft.QueryBuilder.PostgreSql
{
    public static class ExpressionFactoryExtensions
    {
		public static EqualCondition True(this ExpressionFactory factory, IExpression expression) =>
			Equal(factory, expression, value: true);

		public static EqualCondition True(this ExpressionFactory factory, Func<ExpressionFactory, IExpression> expressionFunction) =>
			Equal(factory, expressionFunction, value: true);

		public static EqualCondition True(this ExpressionFactory factory, string column) =>
			Equal(factory, column, value: true);

        public static EqualCondition True(this ExpressionFactory factory, string column, string table) =>
            Equal(factory, column, table, value: true);

        public static EqualCondition True(this ExpressionFactory factory, string column, ISource source) =>
            Equal(factory, column, source, value: true);

        public static EqualCondition False(this ExpressionFactory factory, IExpression expression) =>
            Equal(factory, expression, value: false);

        public static EqualCondition False(this ExpressionFactory factory, Func<ExpressionFactory, IExpression> expressionFunction) =>
            Equal(factory, expressionFunction, value: false);

        public static EqualCondition False(this ExpressionFactory factory, string column) =>
            Equal(factory, column, value: false);

        public static EqualCondition False(this ExpressionFactory factory, string column, string table) =>
            Equal(factory, column, table, value: false);

        public static EqualCondition False(this ExpressionFactory factory, string column, ISource source) =>
            Equal(factory, column, source, value: false);

		public static EqualCondition Equal(this ExpressionFactory factory, IExpression expression, bool value) =>
            factory.Equal(expression, Bool(factory, value));

        public static EqualCondition Equal(this ExpressionFactory factory, Func<ExpressionFactory, IExpression> expressionFunction, bool value) =>
            factory.Equal(expressionFunction, Bool(factory, value));

        public static EqualCondition Equal(this ExpressionFactory factory, string column, bool value) =>
            factory.Equal(column, Bool(factory, value));

        public static EqualCondition Equal(this ExpressionFactory factory, string column, string table, bool value) =>
            factory.Equal(column, table, Bool(factory, value));

        public static EqualCondition Equal(this ExpressionFactory factory, string column, ISource source, bool value) =>
            factory.Equal(column, source, Bool(factory, value));

        public static NotEqualCondition NotEqual(this ExpressionFactory factory, IExpression expression, bool value) =>
            factory.NotEqual(expression, Bool(factory, value));

        public static NotEqualCondition NotEqual(this ExpressionFactory factory, Func<ExpressionFactory, IExpression> expressionFunction, bool value) =>
            factory.NotEqual(expressionFunction, Bool(factory, value));

        public static NotEqualCondition NotEqual(this ExpressionFactory factory, string column, bool value) =>
            factory.NotEqual(column, Bool(factory, value));

        public static NotEqualCondition NotEqual(this ExpressionFactory factory, string column, string table, bool value) =>
            factory.NotEqual(column, table, Bool(factory, value));

        public static NotEqualCondition NotEqual(this ExpressionFactory factory, string column, ISource source, bool value) =>
            factory.NotEqual(column, source, Bool(factory, value));

        public static CoalesceFunction Coalesce(this ExpressionFactory factory, string column, bool value) =>
            factory.Coalesce(factory.Column(column), Bool(factory, value));

        public static CoalesceFunction Coalesce(this ExpressionFactory factory, string column, string table, bool value) =>
            factory.Coalesce(factory.Column(column, table), Bool(factory, value));

        public static CoalesceFunction Coalesce(this ExpressionFactory factory, string column, ISource source, bool value) =>
            factory.Coalesce(factory.Column(column, source), Bool(factory, value));

        public static CoalesceFunction Coalesce(this ExpressionFactory factory, Func<ExpressionFactory, IExpression> expressionFunction, bool value) =>
            factory.Coalesce(factory.Expression(expressionFunction), Bool(factory, value));

        public static CoalesceFunction Coalesce(this ExpressionFactory factory, IExpression expression, bool value) =>
            factory.Coalesce(expression, Bool(factory, value));

        public static BoolValue True(this ExpressionFactory factory) => Bool(factory, value: true);
        public static BoolValue False(this ExpressionFactory factory) => Bool(factory, value: false);

        public static IValue Bool(this ExpressionFactory factory, bool? value) => value.HasValue
            ? Bool(factory, value) : factory.Null();

		public static BoolValue Bool(this ExpressionFactory _, bool value) => new BoolValue(value);
	}
}
