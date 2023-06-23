using YuraSoft.QueryBuilder.Common;

namespace YuraSoft.QueryBuilder.PostgreSql
{
    public static class UpdateExtensions
    {
        private static readonly ExpressionFactory _factory = ExpressionFactory.Instance;

        public static Update SetTrue(this Update update, string column) =>
            update.Set(column, _factory.True());

        public static Update SetTrue(this Update update, string column, string columnSource) =>
            update.Set(column, columnSource, _factory.True());

        public static Update SetTrue(this Update update, string column, ISource columnSource) =>
            update.Set(column, columnSource, _factory.True());

        public static Update SetTrue(this Update update, IColumn column) =>
            update.Set(column, _factory.True());

        public static Update SetFalse(this Update update, string column) =>
            update.Set(column, _factory.False());

        public static Update SetFalse(this Update update, string column, string columnSource) =>
            update.Set(column, columnSource, _factory.False());

        public static Update SetFalse(this Update update, string column, ISource columnSource) =>
            update.Set(column, columnSource, _factory.False());

        public static Update SetFalse(this Update update, IColumn column) =>
            update.Set(column, _factory.False());

        public static Update Set(this Update update, string column, bool value) =>
            update.Set(column, _factory.Bool(value));

        public static Update Set(this Update update, string column, string columnSource, bool value) =>
            update.Set(column, columnSource, _factory.Bool(value));

        public static Update Set(this Update update, string column, ISource columnSource, bool value) =>
            update.Set(column, columnSource, _factory.Bool(value));

        public static Update Set(this Update update, IColumn column, bool value) =>
            update.Set(column, _factory.Bool(value));
    }
}
