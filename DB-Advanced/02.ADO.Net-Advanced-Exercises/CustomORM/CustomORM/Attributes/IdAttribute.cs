namespace CustomORM.Attributes
{
    using System;

    /// <summary>
    /// Attach this attribute only to columns
    ///  that will contain our id's
    /// </summary>
    public class IdAttribute : Attribute
    {
    }
}