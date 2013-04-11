using System;
using System.Linq.Expressions;
using MuonLab.Commons.Reflection;
using MuonLab.Web.Xhtml.Configuration;

namespace MuonLab.Web.Xhtml
{
	public class EnglishComponentLabelResolver : IComponentLabelResolver
	{
		readonly LanguageMode mode;

		public EnglishComponentLabelResolver(LanguageMode mode = LanguageMode.SentenceCase)
		{
			this.mode = mode;
		}

		public string ResolveLabel<TEntity, TProperty>(Expression<Func<TEntity, TProperty>> property)
		{
			return ReflectionHelper.GetMemberInfo(property).GetEnglishName(mode);
		}

		public string ResolveBool(bool value)
		{
			return value ? "Yes" : "No";
		}
	}
}