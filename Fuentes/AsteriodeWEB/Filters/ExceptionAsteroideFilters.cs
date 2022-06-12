using AsteriodeWEB.Exceptions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsteriodeWEB.Filters
{
    public class ExceptionAsteroideFilters : IExceptionFilter
    {
        private readonly IWebHostEnvironment _hostEnviroment;
        private readonly IModelMetadataProvider _modelMetadaProvider;

        public ExceptionAsteroideFilters(IWebHostEnvironment hostEnviroment, IModelMetadataProvider modelMetadaProvider)
        {
            this._hostEnviroment = hostEnviroment;
            this._modelMetadaProvider = modelMetadaProvider;
        }
        void IExceptionFilter.OnException(ExceptionContext context)
        {
            if (context.Exception is AsteroideException)
            {
                context.Result = new JsonResult("Fallo algo en la aplicacion " + _hostEnviroment.ApplicationName + " la excepcion del tipo " + context.Exception.GetType() + " Mensaje " + context.Exception.Message);
            }
        }
    }
}
