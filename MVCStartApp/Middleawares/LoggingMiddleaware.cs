// AlexeyQwake Qwake

using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MVCStartApp.Models;
using MVCStartApp.Models.Db;

namespace MVCStartApp.Middleawares
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private IBlogRepository blogRepository;
        private IRequestRepository requestRepository;
  

        public LoggingMiddleware(RequestDelegate next, IBlogRepository blogRepository, IRequestRepository requestRepository)
        {
            _next = next;
            this.blogRepository = blogRepository;
            this.requestRepository = requestRepository;

        }

        public async Task InvokeAsync(HttpContext context)
        {
            var request = new Request() {Url = context.Request.GetDisplayUrl()};
            
            await requestRepository.LogRequest(request);
            await _next.Invoke(context);
        }
        
    }
}