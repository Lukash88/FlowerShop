﻿namespace FlowerShop.ApplicationServices.API.Domain;

public class PagedResponse<TResponse>
{
    /// <summary>
    /// Gets or sets the current page.
    /// </summary>
    /// <value>The current page.</value>
    public int CurrentPage { get; set; }

    /// <summary>
    /// Gets or sets the size of the page.
    /// </summary>
    /// <value>The size of the page.</value>
    public int PageSize { get; set; }

    /// <summary>
    /// Gets or sets the page count.
    /// </summary>
    /// <value>The page count.</value>
    public int PageCount { get; set; }

    /// <summary>
    /// Gets or sets the row count.
    /// </summary>
    /// <value>The row count.</value>
    public long RowCount { get; set; }

    /// <summary>
    /// Gets or sets the results.
    /// </summary>
    /// <value>The results.</value>
    public List<TResponse> Results { get; set; } = [];
}