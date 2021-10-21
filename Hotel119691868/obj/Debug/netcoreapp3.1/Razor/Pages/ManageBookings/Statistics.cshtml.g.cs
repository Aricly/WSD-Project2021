#pragma checksum "C:\Users\yeliz\Documents\GitHub\WSD-Project2021\Hotel119691868\Pages\ManageBookings\Statistics.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "cb76df146100094bb102706c2c44b9a91c14318d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(Hotel119691868.Pages.ManageBookings.Pages_ManageBookings_Statistics), @"mvc.1.0.razor-page", @"/Pages/ManageBookings/Statistics.cshtml")]
namespace Hotel119691868.Pages.ManageBookings
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
#line 1 "C:\Users\yeliz\Documents\GitHub\WSD-Project2021\Hotel119691868\Pages\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\yeliz\Documents\GitHub\WSD-Project2021\Hotel119691868\Pages\_ViewImports.cshtml"
using Hotel119691868;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\yeliz\Documents\GitHub\WSD-Project2021\Hotel119691868\Pages\_ViewImports.cshtml"
using Hotel119691868.Data;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cb76df146100094bb102706c2c44b9a91c14318d", @"/Pages/ManageBookings/Statistics.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c2591993ef914605d04d4c4870eb8a6d9833fd53", @"/Pages/_ViewImports.cshtml")]
    public class Pages_ManageBookings_Statistics : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Users\yeliz\Documents\GitHub\WSD-Project2021\Hotel119691868\Pages\ManageBookings\Statistics.cshtml"
  
    
        ViewData["Title"] = "Statistics";
        Layout = "~/Pages/Shared/_Layout.cshtml";
    

#line default
#line hidden
#nullable disable
            WriteLiteral("<h2>Customer distribution with respect to postcodes</h2>\r\n<br />\r\n\r\n<div>\r\n");
            WriteLiteral("    <table class=\"table\">\r\n        <tr>\r\n            <th>\r\n                ");
#nullable restore
#line 17 "C:\Users\yeliz\Documents\GitHub\WSD-Project2021\Hotel119691868\Pages\ManageBookings\Statistics.cshtml"
           Write(Html.DisplayNameFor(m => m.StatisticsStats[0].Postcode));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 20 "C:\Users\yeliz\Documents\GitHub\WSD-Project2021\Hotel119691868\Pages\ManageBookings\Statistics.cshtml"
           Write(Html.DisplayNameFor(m => m.StatisticsStats[0].NumberOfCustomer));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n        </tr>\r\n\r\n");
#nullable restore
#line 24 "C:\Users\yeliz\Documents\GitHub\WSD-Project2021\Hotel119691868\Pages\ManageBookings\Statistics.cshtml"
         foreach (var item in Model.StatisticsStats)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>\r\n                    ");
#nullable restore
#line 28 "C:\Users\yeliz\Documents\GitHub\WSD-Project2021\Hotel119691868\Pages\ManageBookings\Statistics.cshtml"
               Write(Html.DisplayFor(modelItem => item.Postcode));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 31 "C:\Users\yeliz\Documents\GitHub\WSD-Project2021\Hotel119691868\Pages\ManageBookings\Statistics.cshtml"
               Write(Html.DisplayFor(modelItem => item.NumberOfCustomer));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n            </tr>\r\n");
#nullable restore
#line 34 "C:\Users\yeliz\Documents\GitHub\WSD-Project2021\Hotel119691868\Pages\ManageBookings\Statistics.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </table>\r\n</div>\r\n<h2>Booking distribution with respect to rooms</h2>\r\n<br />\r\n\r\n<div>\r\n");
            WriteLiteral("    <table class=\"table\">\r\n        <tr>\r\n            <th>\r\n                ");
#nullable restore
#line 45 "C:\Users\yeliz\Documents\GitHub\WSD-Project2021\Hotel119691868\Pages\ManageBookings\Statistics.cshtml"
           Write(Html.DisplayNameFor(m => m.StatisticsStats2[0].RoomID));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 48 "C:\Users\yeliz\Documents\GitHub\WSD-Project2021\Hotel119691868\Pages\ManageBookings\Statistics.cshtml"
           Write(Html.DisplayNameFor(m => m.StatisticsStats2[0].NumberOfBooking));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n        </tr>\r\n\r\n");
#nullable restore
#line 52 "C:\Users\yeliz\Documents\GitHub\WSD-Project2021\Hotel119691868\Pages\ManageBookings\Statistics.cshtml"
         foreach (var item in Model.StatisticsStats2)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>\r\n                    ");
#nullable restore
#line 56 "C:\Users\yeliz\Documents\GitHub\WSD-Project2021\Hotel119691868\Pages\ManageBookings\Statistics.cshtml"
               Write(Html.DisplayFor(modelItem => item.RoomID));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 59 "C:\Users\yeliz\Documents\GitHub\WSD-Project2021\Hotel119691868\Pages\ManageBookings\Statistics.cshtml"
               Write(Html.DisplayFor(modelItem => item.NumberOfBooking));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n            </tr>\r\n");
#nullable restore
#line 62 "C:\Users\yeliz\Documents\GitHub\WSD-Project2021\Hotel119691868\Pages\ManageBookings\Statistics.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </table>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Hotel119691868.Pages.ManageBookings.StatisticsModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Hotel119691868.Pages.ManageBookings.StatisticsModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Hotel119691868.Pages.ManageBookings.StatisticsModel>)PageContext?.ViewData;
        public Hotel119691868.Pages.ManageBookings.StatisticsModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591