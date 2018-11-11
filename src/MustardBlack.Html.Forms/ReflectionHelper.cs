using System;
using System.Linq.Expressions;
using System.Reflection;

namespace MustardBlack.Html.Forms
{
	public static class ReflectionHelper
	{
		public static Expression<Func<T, TValue>> BuildGet<T, TValue>(PropertyInfo property)
		{
			var type = typeof (T);
			var expression = Expression.Parameter(type, "x");
			return Expression.Lambda<Func<T, TValue>>(Expression.Property(expression, property), new[] { expression });
		}

		static MemberExpression GetBody<TEntity, TResult>(Expression<Func<TEntity, TResult>> property)
		{
			if ((typeof (TResult).IsGenericType && typeof (TResult).GetGenericTypeDefinition() == typeof (Nullable<>)) && (property.Body is UnaryExpression))
			{
				var body = property.Body as UnaryExpression;
				return (body.Operand as MemberExpression);
			}
			return (property.Body as MemberExpression);
		}

		public static MemberInfo GetMemberInfo<T, TResult>(Expression<Func<T, TResult>> property)
		{
			return GetBody(property).Member;
		}

		public static string GetPropertyName<T, TResult>(Expression<Func<T, TResult>> property)
		{
			return GetBody(property).Member.Name;
		}

		public static object GetPropertyValue(object obj, string propertyName)
		{
			return obj.GetType().GetProperty(propertyName).GetValue(obj, null);
		}

		public static TValue GetPropertyValue<TEntity, TValue>(TEntity entity, Expression<Func<TEntity, TValue>> property)
		{
			return property.Compile()(entity);
		}

		static bool MemberAccessExpressionsAreEqual(MemberExpression expression1, MemberExpression expression2)
		{
			if ((expression1 != null) && (expression2 != null))
			{
				return ((expression1.Member.Name == expression2.Member.Name) &&
				        MemberAccessExpressionsAreEqual(expression1.Expression as MemberExpression,
					        expression2.Expression as MemberExpression));
			}
			return true;
		}

		public static bool MemberAccessExpressionsAreEqual<T, TProperty>(Expression<Func<T, TProperty>> expression1, Expression<Func<T, TProperty>> expression2)
		{
			return MemberAccessExpressionsAreEqual(expression1.Body as MemberExpression, expression2.Body as MemberExpression);
		}

		static string propertyChainToString(Expression expression, char delimeter)
		{
			if (expression is MemberExpression)
			{
				MemberExpression expression2 = expression as MemberExpression;
				return (propertyChainToString(expression2.Expression, delimeter) + expression2.Member.Name + delimeter);
			}
			if (expression is MethodCallExpression)
			{
				MethodCallExpression expression3 = expression as MethodCallExpression;
				if (expression3.Method.Name == "get_Item")
				{
					object obj2 =
						((expression3.Arguments[0] as MemberExpression).Member as FieldInfo).GetValue(
							((expression3.Arguments[0] as MemberExpression).Expression as ConstantExpression).Value);
					return
						string.Concat(new object[] { (expression3.Object as MemberExpression).Member.Name, "[", obj2, "]", delimeter });
				}
			}
			return string.Empty;
		}

		[Obsolete("Use ExpressionHelper.GetExpressionText")]
		public static string PropertyChainToString(Expression expression, char delimeter)
		{
			if (!(expression is LambdaExpression))
			{
				throw new NotSupportedException("Probably a nullable type, need implementing! Debug: " + expression);
			}
			LambdaExpression expression2 = expression as LambdaExpression;
			return propertyChainToString(expression2.Body, delimeter).TrimEnd(new char[] { delimeter });
		}

		[Obsolete("Use ExpressionHelper.GetExpressionText")]
		public static string PropertyChainToString<TEntity, TResult>(Expression<Func<TEntity, TResult>> property, char delimeter)
		{
			var body = GetBody(property);
			return (propertyChainToString(body.Expression, delimeter) + body.Member.Name);
		}

		public static void SetPropertyValue<TEntity, TProperty>(TEntity entity, Expression<Func<TEntity, TProperty>> property, TProperty value)
		{
			typeof (TEntity).GetProperty(GetPropertyName(property)).SetValue(entity, value, null);
		}
	}
}