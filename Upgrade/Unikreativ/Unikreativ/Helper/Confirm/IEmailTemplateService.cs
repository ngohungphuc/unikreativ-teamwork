using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Unikreativ.Helper.Confirm
{
    public interface IEmailTemplateService
    {
        Task<string> RenderTemplateAsync<TModel>(string viewName, TModel model);
    }
}