#pragma checksum "D:\MyProject\OneDrive - OBA GG\C#\Warehouse\WareHouse.Web\Views\Home\EditPwd.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "93518f84477cdba75e19d74ad18fe7c25b0d57b9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_EditPwd), @"mvc.1.0.view", @"/Views/Home/EditPwd.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"93518f84477cdba75e19d74ad18fe7c25b0d57b9", @"/Views/Home/EditPwd.cshtml")]
    public class Views_Home_EditPwd : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\MyProject\OneDrive - OBA GG\C#\Warehouse\WareHouse.Web\Views\Home\EditPwd.cshtml"
  
    ViewData["Title"] = "修改密码";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""container-fluid"">

    <div class=""row"">
        <div class=""col-lg-12"">
            <div class=""card"">
                <div class=""card-body"">
                    <div class=""form-group"">
                        <label for=""old-password"">旧密码</label>
                        <input type=""password"" class=""form-control"" name=""oldpwd"" id=""old-password"" placeholder=""输入账号的原登录密码"">
                    </div>
                    <div class=""form-group"">
                        <label for=""new-password"">新密码</label>
                        <input type=""password"" class=""form-control"" name=""newpwd"" id=""new-password"" placeholder=""输入新的密码"">
                    </div>
                    <div class=""form-group"">
                        <label for=""confirm-password"">确认新密码</label>
                        <input type=""password"" class=""form-control"" name=""confirmpwd"" id=""confirm-password"" placeholder=""请再次输入新的密码"">
                    </div>
                    <button id=""update-btn"" class=""btn btn-");
            WriteLiteral("primary\">修改密码</button>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script>
        $(""#update-btn"").click(function () {
            if ($(""#new-password"").val() !== $(""#confirm-password"")) {
                alert(""两次输入的新密码不一致，请重新输入"");
            } else {
                $.ajax({
                    url: ""/Home/UpdatePwd"",
                    data: {
                        userId:");
#nullable restore
#line 41 "D:\MyProject\OneDrive - OBA GG\C#\Warehouse\WareHouse.Web\Views\Home\EditPwd.cshtml"
                          Write(ViewData["userId"]);

#line default
#line hidden
#nullable disable
                WriteLiteral(@",
                        oldPwd: $(""#old-password""),
                        newPwd:$(""#new-password"")
                    },
                    type: ""post"",
                    success: function(res) {
                        console.log(res);
                    },
                    error: function(res) {
                        console.log(res);
                    }
                });
            }
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
