using System;
using MustardBlack.Html.Forms.Components;
using MustardBlack.Html.Forms.Tests.Components.FormattableComponentSpecifications;

namespace MustardBlack.Html.Forms.Tests.Components.TextBoxSpecifications.Format
{
    public class FormatWithSpecificaiton : FormatWithSpecification<TextBoxComponent<TestEntity, DateTime>, DateTime>
    {
        protected override DateTime value => new DateTime(2009, 12, 12);

	    protected override Func<DateTime, string> formatFunc
        {
            get { return x => string.Format("{0:dd/MM/yyyy}", x); }
        }

        protected override string expectedRendering => "<input type=\"text\" value=\"12/12/2009\" />";
    }
}