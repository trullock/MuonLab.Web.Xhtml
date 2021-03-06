using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using MuonLab.Web.Xhtml.Components;
using MuonLab.Web.Xhtml.Components.Implementations;
using MuonLab.Web.Xhtml.Configuration;

namespace MuonLab.Web.Xhtml
{
	public interface IComponentFactory<TModel>
	{
		IHiddenFieldComponent<TProperty> HiddenFieldFor<TProperty>(Expression<Func<TModel, TProperty>> property, TModel entity, Func<TProperty, string> toStringFunc);

		IRadioButtonListComponent RadioButtonListFor<TProperty, TData>(Expression<Func<TModel, TProperty>> property, TModel entity, IEnumerable<TData> items, Func<TData, string> itemValueFunc, Func<TData, string> itemTextFunc);

		IDropDownComponent<TProperty> DropDownFor<TProperty, TData>(Expression<Func<TModel, TProperty>> property, TModel entity, IEnumerable<TData> items, Func<TProperty, string> propertyValueFunc, Func<TData, string> itemValueFunc, Func<TData, string> itemTextFunc, Func<TData, object> itemHtmlAttributes);

		IFileUploadComponent FileUploadFor<TProperty>(Expression<Func<TModel, TProperty>> property, TModel entity);


		ITextBoxComponent<TProperty> TextBoxFor<TProperty>(Expression<Func<TModel, TProperty>> property, TModel entity);
		IPasswordBoxComponent PasswordBoxFor(Expression<Func<TModel, string>> property, TModel entity);
		IEmailBoxComponent<TProperty> EmailBoxFor<TProperty>(Expression<Func<TModel, TProperty>> property, TModel entity);
		ITextAreaComponent<TProperty> TextAreaFor<TProperty>(Expression<Func<TModel, TProperty>> property, TModel entity);

		ICheckBoxComponent<bool> CheckBoxFor(Expression<Func<TModel, bool>> property, TModel entity);
		ICheckBoxComponent<IEnumerable<TInner>> CheckBoxFor<TInner>(Expression<Func<TModel, IEnumerable<TInner>>> property, TModel entity, TInner value);

		ICheckBoxListComponent CheckBoxListFor<TProperty, TData>(Expression<Func<TModel, TProperty>> property, TModel entity, IEnumerable<TData> items, Func<TData, string> itemValueFunc, Func<TData, string> itemTextFunc, Func<TProperty, TData, bool> itemIsValue);

		string ValidationMessageFor<TProperty>(Expression<Func<TModel, TProperty>> property, TModel entity);
		string ValidationMessageFor(string name, TModel entity);


		IComponentLabelResolver LabelResolver { get; }
		IComponentNameResolver NameResolver { get; set; }
		IComponentIdResolver IdResolver { get; }
		IErrorProvider ErrorProvider { get; }
		void InitializeComponent<TComponentViewModel, TProperty>(Component<TComponentViewModel, TProperty> component, TComponentViewModel viewModel, Expression<Func<TComponentViewModel, TProperty>> property);
		void InitializeComponent<TComponentViewModel, TProperty>(VisibleComponent<TComponentViewModel, TProperty> component, TComponentViewModel viewModel, Expression<Func<TComponentViewModel, TProperty>> property);

	}
}