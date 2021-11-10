using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
namespace SK.ERP.SERVICE.Installers
{
    public class NewtonsoftJsonNamingPolicy : JsonNamingPolicy
    {
        private readonly NamingStrategy _namingStrategy;

        /// <summary>
        /// Creates new instance of <see cref="NewtonsoftJsonNamingPolicy"/>.
        /// </summary>
        /// <param name="namingStrategy">Newtonsoft naming strategy.</param>
        public NewtonsoftJsonNamingPolicy(NamingStrategy namingStrategy)
        {
            _namingStrategy = namingStrategy;
        }

        /// <inheritdoc />
        public override string ConvertName(string name)
        {
            return _namingStrategy.GetPropertyName(name, false);
        }
    }
}
