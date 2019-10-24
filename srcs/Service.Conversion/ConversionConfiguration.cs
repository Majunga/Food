using System;
using System.Collections.Generic;
using System.Text;

using AutoMapper;

namespace Service.Conversion
{
    public class ConversionConfiguration
    {
        public MapperConfiguration MapperConfig => new MapperConfiguration(
            m =>
                {
                    m.AddProfile(new IngredientServiceMapper());
                    m.AddProfile(new RecipeServiceMapper());
                });
    }
}
