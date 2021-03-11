using System;
using System.Collections.Generic;

namespace Primitive.Core.Models
{
    // TODO WTS: Remove this class once your pages/features are using your data.
    // This is used by the SampleDataService.
    // It is the model class we use to display data on pages like Grid, Chart, and Master Detail.
    public class appstruct
    {

        public string APPName { get; set; }


        public string Description { get; set; }

        public string AMUID { get; set; }

        public int Index { get; set; }

        public char Symbol => (char)SymbolCode;

        public int SymbolCode { get; set; } = 57656;

        public override string ToString()
        {
            return $"{APPName} {AMUID}";
        }
    }
}
