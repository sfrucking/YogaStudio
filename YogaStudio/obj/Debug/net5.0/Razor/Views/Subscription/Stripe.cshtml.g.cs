#pragma checksum "C:\Users\Marco\Documents\YogaStudio\YogaStudio\YogaStudio\Views\Subscription\Stripe.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "35a71c079a21fa9e24f3b7b6fd28dd0890d22f9d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Subscription_Stripe), @"mvc.1.0.view", @"/Views/Subscription/Stripe.cshtml")]
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
#line 1 "C:\Users\Marco\Documents\YogaStudio\YogaStudio\YogaStudio\Views\Subscription\Stripe.cshtml"
using Microsoft.Extensions.Options;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Marco\Documents\YogaStudio\YogaStudio\YogaStudio\Views\Subscription\Stripe.cshtml"
using YogaStudio.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"35a71c079a21fa9e24f3b7b6fd28dd0890d22f9d", @"/Views/Subscription/Stripe.cshtml")]
    public class Views_Subscription_Stripe : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<YogaStudio.Models.Subscription>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 6 "C:\Users\Marco\Documents\YogaStudio\YogaStudio\YogaStudio\Views\Subscription\Stripe.cshtml"
 foreach(Subscription s in Model)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("\t<div>\r\n\t\t<form action=\"/Subscription/Subscribe\" method=\"post\">\r\n\t\t\t<article>\r\n\t\t\t\t<label>Amount: ");
#nullable restore
#line 11 "C:\Users\Marco\Documents\YogaStudio\YogaStudio\YogaStudio\Views\Subscription\Stripe.cshtml"
                          Write(s.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral("</label>\r\n\t\t\t</article>\r\n\t\t\t<script src=\"//checkout.stripe.com/v2/checkout.js\"\r\n\t\t\t\t\tclass=\"stripe-button\"\r\n\t\t\t\t\tdata-key=\"");
#nullable restore
#line 15 "C:\Users\Marco\Documents\YogaStudio\YogaStudio\YogaStudio\Views\Subscription\Stripe.cshtml"
                         Write(Stripe.Value.PublishableKey);

#line default
#line hidden
#nullable disable
            WriteLiteral("\"\r\n\t\t\t\t\tdata-locale=\"auto\"\r\n\t\t\t\t\tdata-description=\"Sample Charge\"\r\n\t\t\t\t\tdata-amount=");
#nullable restore
#line 18 "C:\Users\Marco\Documents\YogaStudio\YogaStudio\YogaStudio\Views\Subscription\Stripe.cshtml"
                            Write(s.Price * 100);

#line default
#line hidden
#nullable disable
            WriteLiteral(">\r\n\t\t\t</script>\r\n\t\t\t<input type=\"text\" id=\"amount\" name=\"amount\"");
            BeginWriteAttribute("value", " value=", 626, "", 649, 1);
#nullable restore
#line 20 "C:\Users\Marco\Documents\YogaStudio\YogaStudio\YogaStudio\Views\Subscription\Stripe.cshtml"
WriteAttributeValue("", 633, s.Price * 100, 633, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" hidden>\r\n\t\t\t<input type=\"text\" id=\"type\" name=\"type\"");
            BeginWriteAttribute("value", " value=", 702, "", 716, 1);
#nullable restore
#line 21 "C:\Users\Marco\Documents\YogaStudio\YogaStudio\YogaStudio\Views\Subscription\Stripe.cshtml"
WriteAttributeValue("", 709, s.Type, 709, 7, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" hidden>\r\n\t\t\t<input type=\"number\" id=\"id\" name=\"id\"");
            BeginWriteAttribute("value", " value=", 767, "", 779, 1);
#nullable restore
#line 22 "C:\Users\Marco\Documents\YogaStudio\YogaStudio\YogaStudio\Views\Subscription\Stripe.cshtml"
WriteAttributeValue("", 774, s.Id, 774, 5, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" hidden>\r\n\t\t</form>\r\n\t</div>\r\n");
#nullable restore
#line 25 "C:\Users\Marco\Documents\YogaStudio\YogaStudio\YogaStudio\Views\Subscription\Stripe.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\t");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public IOptions<YogaStudio.Data.StripeSettings> Stripe { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<YogaStudio.Models.Subscription>> Html { get; private set; }
    }
}
#pragma warning restore 1591
