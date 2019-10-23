﻿using System.ComponentModel.DataAnnotations;

namespace Food.Models.Ingredients
{
    public class IngredientViewModel
    {
        public int? Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
