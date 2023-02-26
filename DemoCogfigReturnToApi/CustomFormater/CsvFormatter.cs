using DemoCogfigReturnToApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Hosting;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace DemoCogfigReturnToApi.CustomFormater
{
    public class CsvFormatter : TextOutputFormatter
    {
        public CsvFormatter() { 
            SupportedMediaTypes.Add(item: MediaTypeHeaderValue.Parse("application/csv"));
            SupportedEncodings.Add(Encoding.UTF8);
            SupportedEncodings.Add(Encoding.Unicode);
        }

        public override async Task WriteResponseBodyAsync(OutputFormatterWriteContext context, Encoding selectedEncoding)
        {
            var reponse = context.HttpContext.Response;
            var buffer = new StringBuilder();
            
            if (context.Object != null)
            {
                foreach (var post in (IEnumerable<Post>)context.Object)
                {
                    FormatCsv(buffer, post);
                }
            }
            else
            {
                FormatCsv(buffer, (Post)context.Object);
            }
            await reponse.WriteAsync(buffer.ToString(), selectedEncoding);
        }

        protected override bool CanWriteType(Type type)
        {
            return typeof(Post).IsAssignableFrom(type) || typeof(IEnumerable<Post>).IsAssignableFrom(type);
        }

        private static void FormatCsv(StringBuilder buffer, Post post)
        {
            foreach(var blogpost in post.BlogPosts)
            {
                buffer.Append($"{post.Name},{blogpost.Title},{blogpost.Published}");
            }
        }
    }
}
