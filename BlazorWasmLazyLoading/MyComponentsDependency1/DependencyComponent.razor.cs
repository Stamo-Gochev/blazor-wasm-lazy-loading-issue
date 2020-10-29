using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyComponentsDependency1
{
    public partial class DependencyComponent : ComponentBase
    {
        public List<int> Data { get; set; } = new List<int>() { 11, 12, 13 };

        protected override void OnAfterRender(bool firstRender)
        {
            var data = new List<int>();
            data.Add(1);
            data.Add(2);
            data.Add(100);

            var queryable = data.AsQueryable();

            var result = queryable.Where(x => x > 1);

            Data.AddRange(result.ToList());

            base.OnAfterRender(firstRender);
        }

    }
}
