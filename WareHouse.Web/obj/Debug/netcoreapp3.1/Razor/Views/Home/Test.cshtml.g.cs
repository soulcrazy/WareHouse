#pragma checksum "D:\MyProject\OneDrive - OBA GG\C#\Warehouse\WareHouse.Web\Views\Home\Test.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b3a22edb0cbd6481d6cca400f4b0848e98e0555b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Test), @"mvc.1.0.view", @"/Views/Home/Test.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b3a22edb0cbd6481d6cca400f4b0848e98e0555b", @"/Views/Home/Test.cshtml")]
    public class Views_Home_Test : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\MyProject\OneDrive - OBA GG\C#\Warehouse\WareHouse.Web\Views\Home\Test.cshtml"
  
    ViewData["Title"] = "Test";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<h2>Test</h2>

<a href=""/Home/TestUnit"" class=""btn btn-default"" id=""test-btn"">测试</a>
<a href=""/Home/Business"" class=""btn btn-default"" id=""business-btn"">BusinessException</a>
<table id=""mytab"" class=""table table-hover""></table>

<figure>
    <h3>图片验证码</h3>
    <fieldset>
        <img id=""mixImg"" title=""数字字母混合验证码"" src=""/Login/MixVerifyCode"" alt=""vcode"" style=""cursor:pointer;"" />
    </fieldset>
    <input type=""text"" name=""code"" id=""code""");
            BeginWriteAttribute("value", " value=\"", 540, "\"", 548, 0);
            EndWriteAttribute();
            WriteLiteral(" />\r\n    <button id=\"check-btn\" class=\"btn btn-default\">校验</button>\r\n</figure>\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script>
        $(""#mixImg"").click(function () {
            $(""#mixImg"").prop(""src"", ""/Login/MixVerifyCode?"" + Math.random());
        });
        $(""#check-btn"").click(function () {
            $(""#mixImg"").trigger('click');
            //$(""#mixImg"").prop(""src"", ""/Login/MixVerifyCode?"" + Math.random());
            //var code = $(""#code"").val();
            //if (code === """") {
            //    $.message(""请输入验证码"");
            //    return 0;
            //}
            //$.post({
            //    url: ""/Home/CheckCode"",
            //    data: {
            //        code: code
            //    },
            //    success: function (res) {
            //        $.message(res.message);
            //    },
            //    error: function () {
            //        $(""#mixImg"").prop(""src"", ""/Login/MixVerifyCode?"" + Math.random());
            //    }
            //});
        });
    </script>
");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
