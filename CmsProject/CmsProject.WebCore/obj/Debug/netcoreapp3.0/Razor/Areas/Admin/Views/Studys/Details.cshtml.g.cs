#pragma checksum "C:\Users\s.khorshidi\Downloads\uni\7-CmsProject_991023_0035_Add_8_Table\CmsProject\CmsProject.WebCore\Areas\Admin\Views\Studys\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9af0d427e806ed23c488d025d697b8c5b565d55e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Studys_Details), @"mvc.1.0.view", @"/Areas/Admin/Views/Studys/Details.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\s.khorshidi\Downloads\uni\7-CmsProject_991023_0035_Add_8_Table\CmsProject\CmsProject.WebCore\Areas\Admin\Views\_ViewImports.cshtml"
using CmsProject.WebCore;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9af0d427e806ed23c488d025d697b8c5b565d55e", @"/Areas/Admin/Views/Studys/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"48b8f7cb3b1b60cd0fcb967bd353636aab10a3db", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Studys_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<CmsProject.ViewModel.Study.StudyViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-info"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\s.khorshidi\Downloads\uni\7-CmsProject_991023_0035_Add_8_Table\CmsProject\CmsProject.WebCore\Areas\Admin\Views\Studys\Details.cshtml"
  
    ViewData["Title"] = "جزئیات دروس مطالعه";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h2>جزئیات</h2>\r\n\r\n<div>\r\n    <h4>دروس مطالعه</h4>\r\n    <hr />\r\n    <dl class=\"dl-horizontal\">\r\n        <dt>\r\n            ");
#nullable restore
#line 14 "C:\Users\s.khorshidi\Downloads\uni\7-CmsProject_991023_0035_Add_8_Table\CmsProject\CmsProject.WebCore\Areas\Admin\Views\Studys\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Code));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
#nullable restore
#line 17 "C:\Users\s.khorshidi\Downloads\uni\7-CmsProject_991023_0035_Add_8_Table\CmsProject\CmsProject.WebCore\Areas\Admin\Views\Studys\Details.cshtml"
       Write(Html.DisplayFor(model => model.Code));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n    <dl class=\"dl-horizontal\">\r\n        <dt>\r\n            ");
#nullable restore
#line 22 "C:\Users\s.khorshidi\Downloads\uni\7-CmsProject_991023_0035_Add_8_Table\CmsProject\CmsProject.WebCore\Areas\Admin\Views\Studys\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
#nullable restore
#line 25 "C:\Users\s.khorshidi\Downloads\uni\7-CmsProject_991023_0035_Add_8_Table\CmsProject\CmsProject.WebCore\Areas\Admin\Views\Studys\Details.cshtml"
       Write(Html.DisplayFor(model => model.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n    <dl class=\"dl-horizontal\">\r\n        <dt>\r\n            ");
#nullable restore
#line 30 "C:\Users\s.khorshidi\Downloads\uni\7-CmsProject_991023_0035_Add_8_Table\CmsProject\CmsProject.WebCore\Areas\Admin\Views\Studys\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.TheoreticalHour));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
#nullable restore
#line 33 "C:\Users\s.khorshidi\Downloads\uni\7-CmsProject_991023_0035_Add_8_Table\CmsProject\CmsProject.WebCore\Areas\Admin\Views\Studys\Details.cshtml"
       Write(Html.DisplayFor(model => model.TheoreticalHour));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n    <dl class=\"dl-horizontal\">\r\n        <dt>\r\n            ");
#nullable restore
#line 38 "C:\Users\s.khorshidi\Downloads\uni\7-CmsProject_991023_0035_Add_8_Table\CmsProject\CmsProject.WebCore\Areas\Admin\Views\Studys\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.PracticalHour));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
#nullable restore
#line 41 "C:\Users\s.khorshidi\Downloads\uni\7-CmsProject_991023_0035_Add_8_Table\CmsProject\CmsProject.WebCore\Areas\Admin\Views\Studys\Details.cshtml"
       Write(Html.DisplayFor(model => model.PracticalHour));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n    <dl class=\"dl-horizontal\">\r\n        <dt>\r\n            ");
#nullable restore
#line 46 "C:\Users\s.khorshidi\Downloads\uni\7-CmsProject_991023_0035_Add_8_Table\CmsProject\CmsProject.WebCore\Areas\Admin\Views\Studys\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.TheoreticalCount));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
#nullable restore
#line 49 "C:\Users\s.khorshidi\Downloads\uni\7-CmsProject_991023_0035_Add_8_Table\CmsProject\CmsProject.WebCore\Areas\Admin\Views\Studys\Details.cshtml"
       Write(Html.DisplayFor(model => model.TheoreticalCount));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n    <dl class=\"dl-horizontal\">\r\n        <dt>\r\n            ");
#nullable restore
#line 54 "C:\Users\s.khorshidi\Downloads\uni\7-CmsProject_991023_0035_Add_8_Table\CmsProject\CmsProject.WebCore\Areas\Admin\Views\Studys\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.PracticalCount));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
#nullable restore
#line 57 "C:\Users\s.khorshidi\Downloads\uni\7-CmsProject_991023_0035_Add_8_Table\CmsProject\CmsProject.WebCore\Areas\Admin\Views\Studys\Details.cshtml"
       Write(Html.DisplayFor(model => model.PracticalCount));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n    <dl class=\"dl-horizontal\">\r\n        <dt>\r\n            ");
#nullable restore
#line 62 "C:\Users\s.khorshidi\Downloads\uni\7-CmsProject_991023_0035_Add_8_Table\CmsProject\CmsProject.WebCore\Areas\Admin\Views\Studys\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.LessonType));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
#nullable restore
#line 65 "C:\Users\s.khorshidi\Downloads\uni\7-CmsProject_991023_0035_Add_8_Table\CmsProject\CmsProject.WebCore\Areas\Admin\Views\Studys\Details.cshtml"
       Write(Html.DisplayFor(model => model.LessonType));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n    <dl class=\"dl-horizontal\">\r\n        <dt>\r\n            ");
#nullable restore
#line 70 "C:\Users\s.khorshidi\Downloads\uni\7-CmsProject_991023_0035_Add_8_Table\CmsProject\CmsProject.WebCore\Areas\Admin\Views\Studys\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.LessonTypeCode));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
#nullable restore
#line 73 "C:\Users\s.khorshidi\Downloads\uni\7-CmsProject_991023_0035_Add_8_Table\CmsProject\CmsProject.WebCore\Areas\Admin\Views\Studys\Details.cshtml"
       Write(Html.DisplayFor(model => model.LessonTypeCode));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n");
            WriteLiteral("    <dl class=\"dl-horizontal\">\r\n        <dt>\r\n            ");
#nullable restore
#line 86 "C:\Users\s.khorshidi\Downloads\uni\7-CmsProject_991023_0035_Add_8_Table\CmsProject\CmsProject.WebCore\Areas\Admin\Views\Studys\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.GradeStr));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
#nullable restore
#line 89 "C:\Users\s.khorshidi\Downloads\uni\7-CmsProject_991023_0035_Add_8_Table\CmsProject\CmsProject.WebCore\Areas\Admin\Views\Studys\Details.cshtml"
       Write(Html.DisplayFor(model => model.GradeStr));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n</div>\r\n<div>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9af0d427e806ed23c488d025d697b8c5b565d55e11868", async() => {
                WriteLiteral("ویرایش");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 94 "C:\Users\s.khorshidi\Downloads\uni\7-CmsProject_991023_0035_Add_8_Table\CmsProject\CmsProject.WebCore\Areas\Admin\Views\Studys\Details.cshtml"
                           WriteLiteral(Model.ID);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9af0d427e806ed23c488d025d697b8c5b565d55e14156", async() => {
                WriteLiteral("بازگشت به لیست");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</div>\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CmsProject.ViewModel.Study.StudyViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591