using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.TagHelpers
{
    public class EmailTagHelper: TagHelper
    {
        const string Domain  ="ppedv.de";
        public string MailTo { get; set; } ="support";

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var address = MailTo +  "@" + Domain;
            output.TagName = "a";
            output.Attributes.SetAttribute("href", "mailto:" + address);
            output.Content.SetContent ("Kontaktieren Sie ...");
            //base.Process(context, output);
        }
    }
}
