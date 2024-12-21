﻿namespace Cafe.Presentation.Common.Requests.Desserts;

public class DessertRequest
{
    required public string Name { get; set; }

    public string Description { get; set; }

    required public int Calories { get; set; }

    required public float Price { get; set; }

    public List<string> Ingredients { get; set; } = new List<string>();
}
