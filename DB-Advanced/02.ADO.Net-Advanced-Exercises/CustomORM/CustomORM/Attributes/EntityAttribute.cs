namespace CustomORM.Attributes
{
    using System;

    /// <summary>
    /// Attach this attribute to map the class to a table
    /// </summary>
    public class EntityAttribute : Attribute
    {
        public string TableName { get; set; }
    }
}