using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using RecordCase.Core.Validation;

namespace RecordCase.Core.MVVM
{
    public class ViewModelBaseValidating : ViewModelBase, IDataErrorInfo
    {
        private static List<IValidationRulesEngine> ValidationRulesEngines { get; set; }


        static ViewModelBaseValidating()
        {
            ValidationRulesEngines = new List<IValidationRulesEngine>();
        }

        public virtual string Error
        {
            get
            {
                if (ValidationRulesEngines.Any())
                {
                    return ValidationRulesEngines.SelectMany(vre=>vre.Validate(this)).FirstOrDefault();
                }
                return null;
            }
        }

        public virtual string this[string columnName]
        {
            get
            {
                if (ValidationRulesEngines.Any())
                {
                    return ValidationRulesEngines.SelectMany(vre =>vre.ValidateProperty(this, columnName)).FirstOrDefault();
                }
                return null;

            }
        }

        public static void AddValidationRulesEngine(IValidationRulesEngine engine)
        {
            ValidationRulesEngines.Add(engine);
        }
    }
}
