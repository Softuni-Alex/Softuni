namespace CustomORM.Attributes
{
    using System;

    /// <summary>
    /// Attach this attribute to every property to map
    ///  them to table columns (properties -> columns)
    /// </summary>
    public class ColumnAttribute : Attribute
    {
        public string Name { get; set; }
    }
}