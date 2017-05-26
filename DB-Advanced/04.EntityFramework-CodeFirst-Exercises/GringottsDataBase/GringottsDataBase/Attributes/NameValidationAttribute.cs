//namespace GringottsDataBase.Attributes
//{
//    using System;
//    using System.ComponentModel.DataAnnotations;
//
//    [AttributeUsage(AttributeTargets.Property)]
//    public class NameValidationAttribute : ValidationAttribute
//    {
//        public override bool IsValid(object value)
//        {
//            string stringValue = value.ToString();
//
//            if (stringValue == null)
//            {
//                throw new ArgumentException("Property with attached attribute must be of type string and not null");
//            }
//            if (char.IsUpper(stringValue[0]))
//            {
//                //....
//            }
//        }
//    }
//}