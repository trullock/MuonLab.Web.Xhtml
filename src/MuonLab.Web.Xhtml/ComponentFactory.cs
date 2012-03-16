using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using MuonLab.Web.Xhtml.Components;
using MuonLab.Web.Xhtml.Components.Implementations;
using MuonLab.Web.Xhtml.Configuration;
using MuonLab.Web.Xhtml.Properties;

namespace MuonLab.Web.Xhtml
{
	public sealed class ComponentFactory<TViewModel> : IComponentFactory<TViewModel>
	{
		readonly IFormConfiguration configuration;
		public IComponentNameResolver NameResolver { get; set; }
		public IComponentIdResolver IdResolver { get; private set; }
		public IComponentLabelResolver LabelResolver { get; private set; }
		public IErrorProvider ErrorProvider { get; private set; }

		public ComponentFactory(
			IFormConfiguration configuration,
			IComponentNameResolver nameResolver,
			IComponentIdResolver idResolver,
			IComponentLabelResolver labelResolver,
			IErrorProvider errorProvider)
		{
			this.ErrorProvider = errorProvider;
			this.configuration = configuration;
			this.NameResolver = nameResolver;
			this.IdResolver = idResolver;
			this.LabelResolver = labelResolver;
		}

		public IHiddenFieldComponent<TProperty> HiddenFieldFor<TProperty>(Expression<Func<TViewModel, TProperty>> property, TViewModel entity, Func<TProperty, string> toStringFunc)
		{
			var hidden = new HiddenFieldComponent<TViewModel, TProperty>(toStringFunc);
			InitializeComponent(hidden, entity, property);
			return hidden;
		}

		public ITextBoxComponent<TProperty> TextBoxFor<TProperty>(Expression<Func<TViewModel, TProperty>> property, TViewModel entity)
		{
			var textBox = new TextBoxComponent<TViewModel, TProperty>();
			InitializeComponent(textBox, entity, property);
			return textBox;
		}

		public IPasswordBoxComponent PasswordBoxFor(Expression<Func<TViewModel, string>> property, TViewModel entity)
		{
			var passwordBox = new PasswordBoxComponent<TViewModel>();
			InitializeComponent(passwordBox, entity, property);
			return passwordBox;
		}

		public ITextAreaComponent<TProperty> TextAreaFor<TProperty>(Expression<Func<TViewModel, TProperty>> property, TViewModel entity)
		{
			var textAreaComponent = new TextAreaComponent<TViewModel, TProperty>();

			InitializeComponent(textAreaComponent, entity, property);

			return textAreaComponent;
		}

		public IDropDownComponent<TProperty> DropDownFor<TProperty, TData>(Expression<Func<TViewModel, TProperty>> property, TViewModel entity, IEnumerable<TData> items, Func<TProperty, string> propertyValueFunc, Func<TData, string> itemValueFunc, Func<TData, string> itemTextFunc)
		{
			var dropDown = new DropDownComponent<TViewModel, TProperty, TData>(items, propertyValueFunc, itemValueFunc, itemTextFunc);

			InitializeComponent(dropDown, entity, property);

			return dropDown;
		}

		public ICheckBoxListComponent CheckBoxListFor<TProperty, TData>(Expression<Func<TViewModel, TProperty>> property, TViewModel entity, IEnumerable<TData> items, Func<TData, string> itemValueFunc, Func<TData, string> itemTextFunc, Func<TProperty, TData, bool> itemIsValue)
		{
			var checkBoxComponent = new CheckBoxListComponent<TViewModel, TProperty, TData>(items, itemValueFunc, itemTextFunc, itemIsValue);

			InitializeComponent(checkBoxComponent, entity, property);

			return checkBoxComponent;
		}

		public ICheckBoxComponent CheckBoxFor(Expression<Func<TViewModel, bool>> property, TViewModel entity)
		{
			var checkBoxComponent = new CheckBoxComponent<TViewModel>();

			InitializeComponent(checkBoxComponent, entity, property);

			return checkBoxComponent;
		}


		public IRadioButtonListComponent RadioButtonListFor<TProperty, TData>(Expression<Func<TViewModel, TProperty>> property, TViewModel entity, IEnumerable<TData> items, Func<TData, string> itemValueFunc, Func<TData, string> itemTextFunc)
		{
			var radioButtonList = new RadioButtonListComponent<TViewModel, TProperty, TData>(items, itemValueFunc, itemTextFunc);

			InitializeComponent(radioButtonList, entity, property);

			return radioButtonList;
		}

		public IFileUploadComponent FileUploadFor<TProperty>(Expression<Func<TViewModel, TProperty>> property, TViewModel entity)
		{
			var fileUploadComponent = new FileUploadComponent<TViewModel, TProperty>();

			InitializeComponent(fileUploadComponent, entity, property);

			return fileUploadComponent;
		}

		public ValidationMessage ValidationMessageFor<TProperty>(Expression<Func<TViewModel, TProperty>> property, TViewModel entity)
		{
			var name = this.NameResolver.ResolveName(property);
			var state = this.ErrorProvider.GetStateFor(name);
			var errors = this.ErrorProvider.GetErrorsFor(name);

			return new ValidationMessage(state, ValidationMarkerMode.Always, errors);
		}

		void InitializeComponent<TComponentViewModel, TProperty>(Component<TComponentViewModel, TProperty> component, TComponentViewModel viewModel, Expression<Func<TComponentViewModel, TProperty>> property)
		{
			// Set the Name
			component.WithName(this.NameResolver.ResolveName(property));

			// Set the Value
			if (!ReferenceEquals(viewModel, null))
			{
				try
				{
					component.WithValue(property.Compile().Invoke(viewModel));
				}
				catch (NullReferenceException e)
				{
					throw new ComponentRenderingException("Could not set component value, some part of the property chain is null: " + property, e);
				}
			}

			// Set the Id
			component.WithId(this.IdResolver.ResolveId(property, component.ControlPrefix));

			// run the config on the component
			if (this.configuration != null)
				this.configuration.Initialize(component);
		}

		void InitializeComponent<TComponentViewModel, TProperty>(VisibleComponent<TComponentViewModel, TProperty> component, TComponentViewModel viewModel, Expression<Func<TComponentViewModel, TProperty>> property)
		{
			// Set the Name
			component.WithName(this.NameResolver.ResolveName(property));

			var state = ComponentState.Unvalidated;

			// Set the Value
			if (!ReferenceEquals(viewModel, null))
			{
				try
				{
					component.WithValue(property.Compile().Invoke(viewModel));
				}
				catch (NullReferenceException e)
				{
					throw new ComponentRenderingException("Could not set component value, some part of the property chain is null: " + property, e);
				}

				state = this.ErrorProvider.GetStateFor(component.Name);
				if (state != ComponentState.Unvalidated)
				{
					var attemptedValue = this.ErrorProvider.GetAttemptedValueFor(component.Name);
					if(attemptedValue != null)
						component.WithAttemptedValue(attemptedValue);
				}
			}

			// Set the Id
			component.WithId(this.IdResolver.ResolveId(property, component.ControlPrefix));

			// set the default label, then hide it as it should be hidden by default.
			component.WithLabel(this.LabelResolver.ResolveLabel(property)).WithoutLabel();

			// run the config on the component
			if (this.configuration != null)
				this.configuration.Initialize(component);

			component.WithState(state, this.ErrorProvider.GetErrorsFor(component.Name));
		}
	}
}