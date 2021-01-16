using Divisima.BL.Repositories;
using Divisima.DAL.Entities;
using Divisima.DAL.Entities.Contexts;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Divisima.WebUI.TagHelpers
{
	[HtmlTargetElement("latesttproducts")]
	public class ProductItem : TagHelper
	{
		public int itemsID { get; set; }

		public string itemsName { get; set; }
		public string itemsPrice { get; set; }
		public string itemsPicture { get; set; }


        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.PreContent.SetHtmlContent("<div class='product-item'>");
            StringBuilder sb = new StringBuilder();
            sb.Append(@"<div class='pi-pic'>
						<img src='"+ itemsPicture + @"' alt=''>
						<div class='pi-links'>
							<a href='urun/"+itemsName+@"/"+itemsID+@"' class='add-card'><i class='flaticon-bag'></i><span>ADD TO CART</span></a>
							<a href='#' class='wishlist-btn'><i class='flaticon-heart'></i></a>
						</div>
					</div>
					<div class='pi-text'>
						<h6>$"+ itemsPrice + @"</h6>
						<p>"+itemsName+@"</p>
					</div>");
            
            sb.Append("</div>");
            output.PostContent.SetHtmlContent(sb.ToString());
        }
    }
}
