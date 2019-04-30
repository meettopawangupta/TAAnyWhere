using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;

namespace TAAnywhereUI.CustomHelper
{
    public static class LoginHelper
    {
        public static MvcHtmlString GetLoginFormObject(this HtmlHelper _loginhtml,string _class)
        {
            string LoginStr = string.Empty;
            LoginStr = "<div class='form - group'>";
            LoginStr += "<label for='txtLoginUserName'>User Name</label>";
            LoginStr += CustomTextBox(_loginhtml, "text", "", "txtLoginUserName", ""); 
            LoginStr += "</div>";
            LoginStr += "<div class='form - group'>";
            LoginStr += "<label for='txtLoginUserPassword'>Password</label>";
            LoginStr += CustomTextBox(_loginhtml, "password", "", "txtLoginUserPassword", "");
            LoginStr += "</div>";
            LoginStr += "<br/><div class='form - group'>";
            LoginStr += SubmitButton(_loginhtml, "Login", "btnLogin",_class);
            LoginStr += "&nbsp;&nbsp;&nbsp;";
            LoginStr += "</div>";
            return new MvcHtmlString(LoginStr);

        }

        public static MvcHtmlString CustomTextBox(this HtmlHelper html, string type, string value, string name, string _class)
        {
            string str = "<input  class='form-control " + _class + "' type='" + type + "' value='" + value + "' name='" + name + "' />";
            return new MvcHtmlString(str);
        }

        //
        // Summary:
        //     Returns a text input element for each property in the object that is represented
        //     by the specified expression, using the specified HTML attributes.
        //
        // Parameters:
        //   htmlHelper:
        //     The HTML helper instance that this method extends.
        //
        //   expression:
        //     An expression that identifies the object that contains the properties to render.
        //
        //   htmlAttributes:
        //     An object that contains the HTML attributes to set for the element.
        //
        // Type parameters:
        //   TModel:
        //     The type of the model.
        //
        //   TProperty:
        //     The type of the value.
        //
        // Returns:
        //     An HTML input element whose type attribute is set to "text" for each property
        //     in the object that is represented by the expression.
        //
        // Exceptions:
        //   T:System.ArgumentException:
        //     The expression parameter is null or empty.
        public static MvcHtmlString CustomTextBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper,  Expression<Func<TModel, TProperty>> expression, string type,  string _class)
        {
            var name = ExpressionHelper.GetExpressionText(expression);
            var metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            string str = "<input  class='form-control " + _class + "' type='" + type + "' value='" + metadata.Model as string + "' name='" + name + "' />";
            return new MvcHtmlString(str);
        }

        public static IHtmlString MyEditorFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, string type, string _class)
        {
            //var member = expression.Body as MemberExpression;
            //var stringLength = member.Member.GetCustomAttributes(typeof(StringLengthAttribute), false).FirstOrDefault() as StringLengthAttribute;

            //RouteValueDictionary viewData = HtmlHelper.AnonymousObjectToHtmlAttributes(ViewData);
            //RouteValueDictionary htmlAttributes = HtmlHelper.AnonymousObjectToHtmlAttributes(viewData["htmlAttributes"]);

            //if (stringLength != null)
            //{
            //    htmlAttributes.Add("maxlength", stringLength.MaximumLength);
            //}

            //return htmlHelper.EditorFor(expression, htmlAttributes); // use custom HTML attributes here
            
            var name = ExpressionHelper.GetExpressionText(expression);
            var metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            TagBuilder tb = new TagBuilder("input");
            tb.Attributes.Add("type", type);
            tb.Attributes.Add("name", name);
            tb.Attributes.Add("value", metadata.Model as string);
            tb.Attributes.Add("class", "form-control " + _class);
            return new MvcHtmlString(tb.ToString());
        }


        public static MvcHtmlString SubmitButton(this HtmlHelper html, string value, string name,string _class)
        {
            string str = "<input class='btn btn-"+ _class + "' type='Submit' value='" + value + "' name='" + name + "' />";
            return new MvcHtmlString(str);
        }

    }
}