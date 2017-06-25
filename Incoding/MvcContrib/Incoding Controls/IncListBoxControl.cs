namespace Incoding.MvcContrib
{
    #region << Using >>

    using System;
    using System.Linq.Expressions;
    using Microsoft.AspNetCore.Mvc;
    using Incoding.Extensions;

    #endregion

    public class IncListBoxControl<TModel, TProperty> : IncDropDownControl<TModel, TProperty>
    {
        #region Constructors

        public IncListBoxControl(HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> property)
                : base(htmlHelper, property)
        {
            this.attributes.Set(HtmlAttribute.Multiple.ToStringLower(), "multiple");
        }

        #endregion
    }
}