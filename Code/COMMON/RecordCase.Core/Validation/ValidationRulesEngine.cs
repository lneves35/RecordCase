using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using LinqKit;
using RecordCase.Common.Exceptions;

namespace RecordCase.Core.Validation
{

    public class ValidationRulesEngine : IValidationRulesEngine
    {
        private readonly Dictionary<Type, object> validationRules;

        public ValidationRulesEngine()
        {       
            validationRules = new Dictionary<Type, object>();            
        }

        public void AddValidation<T>(ValidationRule<T> valRule)
        {
            var keyVal = validationRules.FirstOrDefault(kv => kv.Key == typeof(T));

            if (keyVal.Key == null)
                validationRules.Add(typeof(T), new List<ValidationRule<T>> { valRule });
            else
            {
                var list = (List<ValidationRule<T>>)keyVal.Value;
                list.Add(valRule);
            }
        }

        public void AddValidation<T>(Expression<Func<T, bool>> expression, string errorMessage)
        {
            AddValidation(new ValidationRule<T>(expression, errorMessage));
        }

        public void ValidateOrThrow(object obj)
        {
            Validate(obj, true);
        }

        /// <summary>
        /// Validates an object and returns an error for each failed validation rule.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="o"></param>
        /// <returns></returns>
        public List<string> Validate(object o)
        {
            return Validate(o, false);
        }

        /// <summary>
        /// Returns a validation rules list defined for a certain type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public List<ValidationRule<T>> GetValidationRules<T>()
        {
            var keyVal = validationRules.FirstOrDefault(kv => kv.Key == typeof(T));
            if (keyVal.Key == null)
                return null;
            return (List<ValidationRule<T>>)keyVal.Value;
        }

        public bool HasValidationRules<T>()
        {
            var valRules = GetValidationRules<T>();
            return valRules != null && valRules.Any();
        }

        private List<string> Validate(object o, bool throws)
        {
            List<string> errors = new List<string>();
            //Get all validators from runtime type and from basetypes
            validationRules.Where(kvp => kvp.Key.IsAssignableFrom((o.GetType()))).ForEach(kvp => 
            {                
                var count = (Int32)kvp.Value.GetType().GetMethod("get_Count").Invoke(kvp.Value, null);
                var itemIndexing = kvp.Value.GetType().GetMethod("get_Item");
                for (int i = 0; i < count; i++)
                {
                    //Validator[i]
                    object item = itemIndexing.Invoke(kvp.Value, new object[] {i});

                    //Validator[i].Expression
                    var expression = item.GetType().GetProperty("Expression").GetValue(item);
                    var errorMessage = (string)item.GetType().GetProperty("ErrorMessage").GetValue(item);
                        
                    //Invoke
                    var method = (typeof(Extensions)).GetMethods().Single(m => m.Name == "Invoke" && m.GetParameters().Count() == 2);

                    var res = (bool)method.MakeGenericMethod(kvp.Key, typeof(bool)).Invoke(null, new object[] { expression, o });

                    if (!res)
                    {
                        if (throws)
                            throw new ValidationException(errorMessage);
                        else
                            errors.Add(errorMessage);
                    }
                }
            });
            return errors;
        }
    }
}
