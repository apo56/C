using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace WebSport.Tools
{
    public static class HTMLHelperExtensions
    {

        public static MvcHtmlString CustomEditorFor<TModel, TValue>(this HtmlHelper<TModel> html, 
                                                        Expression<Func<TModel, TValue>> expression)
        {
            var htmlString = "";

            TagBuilder div = new TagBuilder("div");
            div.AddCssClass("form-group");
            
            var htmlStringLabel = html.LabelFor<TModel, TValue>(expression, new { @class = "control-label col-md-2" });

            TagBuilder divCol = new TagBuilder("div");
            divCol.AddCssClass("col-md-10");
            
            htmlString += html.EditorFor<TModel, TValue>(expression, new { htmlAttributes = new { @class = "form-control" } });
            htmlString += html.ValidationMessageFor<TModel, TValue>(expression, "", new { @class = "text-danger" });

            divCol.InnerHtml = htmlString;
            div.InnerHtml = htmlStringLabel + divCol.ToString();
            return MvcHtmlString.Create(div.ToString());;          
        }

        public static MvcHtmlString CustomDropDownFor<TModel, TValueLabel, TValueSelected>(this HtmlHelper<TModel> html,
                                                        Expression<Func<TModel, TValueLabel>> expression,
                                                        Expression<Func<TModel, TValueSelected>> selected,
                                                        IEnumerable<SelectListItem> liste)
        {

            var htmlString = "";
            TagBuilder div = new TagBuilder("div");
            div.AddCssClass("form-group");

            var htmlStringLabel = html.LabelFor<TModel, TValueLabel>(expression, new { @class = "control-label col-md-2" });

            TagBuilder divCol = new TagBuilder("div");
            divCol.AddCssClass("col-md-10");

            htmlString += html.DropDownListFor<TModel, TValueSelected>(selected, liste, "Aucune course", new { @class = "form-control" });

            divCol.InnerHtml = htmlString;
            div.InnerHtml = htmlStringLabel + divCol.ToString();
            return MvcHtmlString.Create(div.ToString()); ;
        }


    }
}