using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Training_App.ViewModels
{
    public class ReflectionDemoViewModel<T> where T : class
    {
        public List<T> IdentityUserProperties { get; set; }
    }
}
