#pragma checksum "D:\MyProject\OneDrive - OBA GG\C#\Warehouse\WareHouse.Web\Views\Storage\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3ebcfed220b5a2a1ced80645fbf0aefec3d9df84"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Storage_Index), @"mvc.1.0.view", @"/Views/Storage/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3ebcfed220b5a2a1ced80645fbf0aefec3d9df84", @"/Views/Storage/Index.cshtml")]
    public class Views_Storage_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\MyProject\OneDrive - OBA GG\C#\Warehouse\WareHouse.Web\Views\Storage\Index.cshtml"
  
    ViewData["Title"] = "仓库管理";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div>\r\n    <button id=\"add-btn\" class=\"btn btn-cyan\">添加仓库</button>\r\n    <table class=\"table table-striped table-hover\" id=\"storage-table\">\r\n    </table>\r\n</div>\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script>
        $('#storage-table').bootstrapTable({
            method: 'get',
            url: ""/Storage/GetAll"", //请求路径
            striped: true, //是否显示行间隔色
            pageNumber: 1, //初始化加载第一页
            pagination: true, //是否分页
            sidePagination: 'client', //server:服务器端分页|client：前端分页
            pageSize: 5, //单页记录数
            pageList: [5, 10, 20, 30], //可选择单页记录数
            showRefresh: true, //刷新按钮
            columns: [
                {
                    field: ""id"",
                    title: ""主键""
                }, {
                    field: ""name"",
                    title: ""仓库名称""
                },{
                    field: ""address"",
                    title: ""仓库地址""
                }, {
                    field: ""id"",
                    title: ""操作"",
                    formatter: function(value, row, index) {
                        var html = '';
                        html += ""<button class='btn btn-default' onclick='edit("" + value + "")");
                WriteLiteral(@"'>修改</button>"";
                        html += ""<button class='btn btn-default' onclick='region("" + value + "")'>区域</button>"";
                        html += ""<button class='btn btn-default' onclick='del("" + value + "")'>删除</button>"";
                        return html;
                    }
                }
            ]
        });

        $(""#add-btn"").click(function () {
            window.location.href = """);
#nullable restore
#line 50 "D:\MyProject\OneDrive - OBA GG\C#\Warehouse\WareHouse.Web\Views\Storage\Index.cshtml"
                               Write(Url.Action("Create"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\";\r\n        });\r\n        function edit(id) {\r\n            window.location.href = \"");
#nullable restore
#line 53 "D:\MyProject\OneDrive - OBA GG\C#\Warehouse\WareHouse.Web\Views\Storage\Index.cshtml"
                               Write(Url.Action("Update"));

#line default
#line hidden
#nullable disable
                WriteLiteral("?id=\"+id;\r\n        }\r\n        function region(id) {\r\n            window.location.href = \"");
#nullable restore
#line 56 "D:\MyProject\OneDrive - OBA GG\C#\Warehouse\WareHouse.Web\Views\Storage\Index.cshtml"
                               Write(Url.Action("Region"));

#line default
#line hidden
#nullable disable
                WriteLiteral("?id=\"+id;\r\n        }\r\n        function del(id) {\r\n            $.post({\r\n                url: \'");
#nullable restore
#line 60 "D:\MyProject\OneDrive - OBA GG\C#\Warehouse\WareHouse.Web\Views\Storage\Index.cshtml"
                 Write(Url.Action("DeleteStorage"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"',
                data: {
                    id:id
                },
                success: function (res) {
                    if (res.code===200) {
                        $.message(res.message);
                        setTimeout(function() {
                            window.location.href = """);
#nullable restore
#line 68 "D:\MyProject\OneDrive - OBA GG\C#\Warehouse\WareHouse.Web\Views\Storage\Index.cshtml"
                                               Write(Url.Action("Index"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\";\r\n                        },1000);\r\n                    }\r\n                }\r\n            });\r\n        }\r\n    </script>\r\n");
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
