using System;
using Umbraco.Core.Models;

namespace PravaStranaUlice.Models.DocumentTypes
{
    public interface IBlogPage : IPage
    {
        DateTime Date { get; }
    }
}
