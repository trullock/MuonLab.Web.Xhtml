<%@ Import Namespace="MustardBlack.Html.Forms.Examples.Net46" %>
<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<MustardBlack.Html.Forms.Examples.Net46.ViewModels.TestViewModel>" %><!DOCTYPE html>
<html>
<head runat="server">
    <title>Test</title>
</head>
<body>
    <div>
        <%: Html.BeginForm() %>

			<%: Html.TextBoxFor(x => x.Name) %>
			<%: Html.PasswordBoxFor(x => x.Password) %>
			<%: Html.DropDownFor(x => x.Sex).WithNullOption("Please Choose") %>

			<%: Html.TextBoxFor(x => x.Age) %>
			<div>
				<button type="submit"><span>Submit</span></button>
			</div>

		<%: Html.EndForm() %>
    </div>
</body>
</html>
