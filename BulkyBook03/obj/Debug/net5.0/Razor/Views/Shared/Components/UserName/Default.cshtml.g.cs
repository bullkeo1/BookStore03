#pragma checksum "/Users/bullkeo/RiderProjects/HaTapLam/NetCore/BulkyBook03/BulkyBook03/Views/Shared/Components/UserName/Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6686beecf6b1260fee6ab1a25287aa9eb3b75bb4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_UserName_Default), @"mvc.1.0.view", @"/Views/Shared/Components/UserName/Default.cshtml")]
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
#line 1 "/Users/bullkeo/RiderProjects/HaTapLam/NetCore/BulkyBook03/BulkyBook03/Views/_ViewImports.cshtml"
using BulkyBook03;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/Users/bullkeo/RiderProjects/HaTapLam/NetCore/BulkyBook03/BulkyBook03/Views/_ViewImports.cshtml"
using BulkyBook03.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6686beecf6b1260fee6ab1a25287aa9eb3b75bb4", @"/Views/Shared/Components/UserName/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e5f7a8e25a8c03b78e23b844c7fb342b03e302e5", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_UserName_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<BulkyBook03.Models.ApplicationUser>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\nHi ! ");
#nullable restore
#line 3 "/Users/bullkeo/RiderProjects/HaTapLam/NetCore/BulkyBook03/BulkyBook03/Views/Shared/Components/UserName/Default.cshtml"
Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("<i class=\"far fa-user\"></i>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<BulkyBook03.Models.ApplicationUser> Html { get; private set; }
    }
}
#pragma warning restore 1591
